using System.Text.Json;
using Thinksoft.Patterns.Structural.Adapter.Adaptee;
using Thinksoft.Patterns.Structural.Adapter.Model;

namespace Thinksoft.Patterns.Structural.Adapter.Adapter
{
    /** The 'ConcreteAdapter' 具體調變器
     *  蝦購調變器 - 至蝦購系統取得庫存資訊
     */
    public class SopAdapter : ICheckStock
    {
        private readonly SopAPI _sopAPI;

        // 平台ID與代營運編號的對應表
        private readonly Dictionary<string, string> _idMap;

        /** 建構函式
         *  <param="apiKey">蝦購平台 API 金鑰</param>
         *  <param="shopId">蝦購商店 ID</param>         
         */
        public SopAdapter(string apiKey, string shopId)
        {
            _sopAPI = new SopAPI(apiKey, shopId);

            // 初始化ID對應表 - 平台特有ID對應到代營運商品編號
            _idMap = new Dictionary<string, string>
            {
                { "SOP_12345", "P001" }, // 掌上型遊戲機
                { "SOP_23456", "P002" }, // 藍牙耳機
                { "SOP_34567", "P003" }, // 行動電源
                { "SOP_45678", "P004" }  // 智能手錶
            };
        }

        /* 取得蝦購庫存資訊，並轉換格式為StockInfo資料類型
         * <param name="productIds">要查詢的代營運商品編號列表</param>
         * <returns>StockInfo類型的庫存資訊列表</returns>
         * PS: Console 輸出僅為簡化示範，實際開發建議使用Log框架記錄
         */
        public async Task<List<StockInfo>> GetStockInfo(List<string> productIds)
        {
            Console.WriteLine("【SopAdapter】開始將蝦購API轉換為StockInfo資料類型");

            // 1. 轉換輸入參數格式 (List<string> -> string[])
            string[] SopFormatIds = productIds.ToArray();

            // 2. 調用蝦購 API，獲取 JSON 格式數據
            string jsonResponse = await _sopAPI.GetStockAsync(SopFormatIds);

            // 3. 解析蝦購的 JSON 格式
            var result = new List<StockInfo>();

            try
            {
                // 反序列化蝦購 JSON 格式
                using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                {
                    // 蝦購特有的 JSON 結構陣列
                    var itemsArray = doc.RootElement.GetProperty("response").GetProperty("item_list");

                    foreach (var item in itemsArray.EnumerateArray())
                    {
                        // 獲取平台特有ID
                        var platformItemId = item.GetProperty("platform_item_id").GetString();
                        var itemName = item.GetProperty("item_name").GetString();
                        var stockInfo = item.GetProperty("stock_info");
                        var currentStock = stockInfo.GetProperty("current_stock").GetInt32();

                        // 從對應表中查找代營運商品編號
                        if (_idMap.TryGetValue(platformItemId, out var agencyCode))
                        {
                            // 將蝦購JSON格式轉換為 StockInfo 資料類別，使用代營運商品編號
                            result.Add(new StockInfo
                            {
                                ProductId = agencyCode,  // 使用代營運商品編號
                                Name = itemName,
                                Quantity = currentStock,
                                Platform = "蝦購"
                            });
                        }
                        else
                        {
                            Console.WriteLine($"【SopAdapter】警告：找不到平台商品ID {platformItemId} 的對應代營運編號");
                        }
                    }
                }

                Console.WriteLine($"【SopAdapter】成功將蝦購 JSON 資料轉換為 StockInfo 資料類型，共 {result.Count} 筆");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"【SopAdapter】解析蝦購 JSON 時發生錯誤: {ex.Message}");
            }

            return result;
        }
    }
}