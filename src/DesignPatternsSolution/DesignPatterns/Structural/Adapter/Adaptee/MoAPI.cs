using System.Text.Json;

namespace Thinksoft.Patterns.Structural.Adapter.Adaptee
{
    /// <summary>
    /// Mo 購物平台的 API 客戶端
    /// 用於查詢 Mo購平台上的商品庫存資訊
    /// </summary>
    /// <remarks>
    /// 使用方式：
    /// 1. 建立 MoAPI 實例，提供合作夥伴 ID 和密鑰
    /// 2. 呼叫 QueryInventoryAsync 方法查詢庫存
    /// 
    /// 範例：
    /// <code>
    /// // 初始化 API 客戶端
    /// var MoApi = new MoAPI("YOUR_PARTNER_ID", "YOUR_SECRET_KEY");
    /// 
    /// // 要查詢的產品 ID 列表
    /// var productIds = new List<string> { "P001", "P002", "P003", "P004" };
    /// 
    /// // 查詢庫存資訊
    /// string jsonResult = await MoApi.QueryInventoryAsync(productIds);
    /// 
    /// // 解析 JSON 結果
    /// // 可以使用 JsonDocument 或自定義類別反序列化
    /// using (JsonDocument doc = JsonDocument.Parse(jsonResult))
    /// {
    ///     // 處理回傳結果
    ///     var root = doc.RootElement;
    ///     var status = root.GetProperty("status").GetString();
    ///     
    ///     if (status == "SUCCESS")
    ///     {
    ///         var inventoryData = root.GetProperty("inventory_data");
    ///         foreach (var product in inventoryData.EnumerateObject())
    ///         {
    ///             var productId = product.Name;
    ///             var productName = product.Value.GetProperty("product_name").GetString();
    ///             var quantity = product.Value.GetProperty("available_qty").GetInt32();
    ///             Console.WriteLine($"{productId}: {productName} - 庫存: {quantity}");
    ///         }
    ///     }
    /// }
    /// </code>
    /// </remarks>
    public class MoAPI
    {
        private readonly HttpClient _httpClient;
        private readonly string _partnerId;
        private readonly string _secretKey;
        private readonly MoFakeDB _MoDb;

        /// <summary>
        /// 初始化 Mo API 客戶端
        /// </summary>
        /// <param="partnerId">Mo 平台供應商 ID</param>
        /// <param="secretKey">API 存取密鑰</param>
        public MoAPI(string partnerId, string secretKey)
        {
            _httpClient = new HttpClient();
            _partnerId = partnerId;
            _secretKey = secretKey;
            _MoDb = new MoFakeDB(); // 初始化模擬資料庫

            // Mo 特有的認證Header
            _httpClient.DefaultRequestHeaders.Add("X-MO-PARTNER-ID", _partnerId);
            _httpClient.DefaultRequestHeaders.Add("X-MO-API-KEY", _secretKey);
        }

        /// <summary>
        /// 查詢指定產品的庫存資訊
        /// </summary>
        /// <param="productIds">要查詢的產品 ID 列表</param>
        /// <returns>包含庫存資訊的 JSON 字串</returns>
        /// <remarks>
        /// 回傳的 JSON 格式範例：
        /// {
        ///   "status": "SUCCESS",
        ///   "code": "200",
        ///   "inventory_data": {
        ///     "P001": {
        ///       "product_id": "P001",
        ///       "product_name": "Mo - 掌上型遊戲機",
        ///       "available_qty": 35,
        ///       "booked_qty": 0,
        ///       "last_updated": "2025-05-28T17:30:00+08:00",
        ///       "warehouse": "TW-MAIN"
        ///     },
        ///     ...
        ///   }
        /// }
        /// </remarks>
        public async Task<string> QueryInventoryAsync(List<string> productIds)
        {
            // 模擬 Mo 的 RESTful API 呼叫 - POST 方法
            Console.WriteLine("【Mo API呼叫】使用 POST /mo-api/inventory/query");

            // Mo API 需要 POST RequstBody
            var requestBody = new
            {
                partner_id = _partnerId,
                timestamp = DateTimeOffset.Now.ToUnixTimeSeconds(),
                product_list = productIds
            };

            // 序列化RequstBody為 JSON
            string jsonContent = JsonSerializer.Serialize(requestBody);

            // 實際情況下會發送 HTTP 請求
            // var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // var response = await _httpClient.PostAsync("https://api.moshop.com/mo-api/inventory/query", content);
            // response.EnsureSuccessStatusCode();
            // string jsonResponse = await response.Content.ReadAsStringAsync();

            // 從 MoFakeDB 取得產品資料
            var products = _MoDb.GetProducts(productIds);

            // 建立庫存資料Dictionary
            var inventoryData = new Dictionary<string, object>();

            foreach (var product in products)
            {
                inventoryData[product.Key] = new
                {
                    product_id = product.Value.ProductId,
                    product_name = product.Value.Name,
                    available_qty = product.Value.AvailableQty,
                    booked_qty = 0, // 假設預訂數量為0
                    last_updated = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"),
                    warehouse = "TW-MAIN"
                };
            }

            var response = new
            {
                status = "SUCCESS",
                code = "200",
                inventory_data = inventoryData
            };

            // 序列化為 JSON 字串，指定縮排格式
            return JsonSerializer.Serialize(response, 
                new JsonSerializerOptions { WriteIndented = true });
        }
    }
}