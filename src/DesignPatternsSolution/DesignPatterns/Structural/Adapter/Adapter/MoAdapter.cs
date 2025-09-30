using System.Text.Json;
using Thinksoft.Patterns.Structural.Adapter.Adaptee;
using Thinksoft.Patterns.Structural.Adapter.Model;

namespace Thinksoft.Patterns.Structural.Adapter.Adapter
{
    /** The 'ConcreteAdapter' 具體調變器
     *  Mo調變器 - 至Mo系統取得庫存資訊
     */
    public class MoAdapter : ICheckStock
    {
        private readonly MoAPI _moAPI;

        /** 建構函式
         *  <param="partnerId">Mo 平台的供應商ID</param>
         *  <param="secretKey">API 存取密鑰</param>
         */
        public MoAdapter(string partnerId, string secretKey)
        {
            _moAPI = new MoAPI(partnerId, secretKey);
        }

        /* 取得Mo庫存資訊，並轉換格式為StockInfo資料類型
         * <param="productIds">要查詢的商品 ID 列表</param>
         * <returns>StockInfo類型的庫存資訊列表</returns>
         * PS: Console 輸出僅為簡化示範，實際開發建議使用Log框架記錄
         */
        public async Task<List<StockInfo>> GetStockInfo(List<string> productIds)
        {
            Console.WriteLine("【MoAdapter】開始將Mo API轉換為StockInfo資料類型");

            // 1. 直接使用輸入的List<string>，無需轉換
            // Mo API 直接接受 List<string> 格式

            // 2. 調用Mo API，獲取 JSON 格式數據
            string jsonResponse = await _moAPI.QueryInventoryAsync(productIds);

            // 3. 解析Mo的 JSON 格式
            var result = new List<StockInfo>();

            try
            {
                // 反序列化Mo JSON 格式
                using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                {
                    // 先檢查API是否成功
                    var status = doc.RootElement.GetProperty("status").GetString();

                    if (status == "SUCCESS")
                    {
                        // Mo特有的 JSON 結構（字典格式）
                        var inventoryData = doc.RootElement.GetProperty("inventory_data");

                        // 遍歷每個產品ID獲取庫存資訊
                        foreach (var productId in productIds)
                        {
                            // 檢查產品ID是否存在於回傳資料中
                            if (inventoryData.TryGetProperty(productId, out var product))
                            {
                                var productName = product.GetProperty("product_name").GetString();
                                var availableQty = product.GetProperty("available_qty").GetInt32();

                                // 將Mo JSON格式轉換為 StockInfo 資料類別
                                result.Add(new StockInfo
                                {
                                    ProductId = productId,
                                    Name = productName,
                                    Quantity = availableQty,  // 設置可用庫存量
                                    Platform = "Mo購物"
                                });
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"【MoAdapter】Mo API 回傳錯誤狀態: {status}");
                    }
                }

                Console.WriteLine($"【MoAdapter】成功將Mo JSON 資料轉換為 StockInfo 資料類型，共 {result.Count} 筆");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"【MoAdapter】解析Mo JSON 時發生錯誤: {ex.Message}");
            }

            return result;
        }
    }
}