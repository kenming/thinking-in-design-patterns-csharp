namespace Thinksoft.Patterns.Structural.Adapter.Adaptee
{
    /**
      * 蝦購平台API
      * 模擬訪問蝦購RESTful API的客戶端
      * 
      * 使用說明:
      * 
      * 1. 初始化蝦購API客戶端
      * var sopApi = new SopAPI("your-api-key-here", "your-shop-id-here");
      * 
      * 2. 準備要查詢的商品ID列表
      * string[] productIds = new string[] { "P001", "P002", "P003" };
      * 
      * 3. 非同步調用取得庫存資訊
      * try 
      * {
      *     string jsonResponse = await sopApi.GetStockAsync(productIds);
      *     
      *     // 處理JSON響應，可使用System.Text.Json或Newtonsoft.Json解析
      *     // 解析示例:
      *     // using System.Text.Json;
      *     // var stockData = JsonSerializer.Deserialize<SopStockResponse>(jsonResponse);
      *     
      *     // 提取庫存資訊
      *     // foreach (var item in stockData.response.item_list)
      *     // {
      *     //     Console.WriteLine($"商品 {item.item_name} 庫存: {item.stock_info.current_stock}");
      *     // }
      * }
      * catch (Exception ex)
      * {
      *     // 處理API調用異常
      *     Console.WriteLine($"蝦購API調用失敗: {ex.Message}");
      * }
      */
    public class SopAPI
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _shopId;
        private readonly SopFakeDB _db;

        /**
         * 初始化蝦購API客戶端
         * 
         * @param apiKey 訪問蝦購API所需的授權密鑰
         * @param shopId 店鋪ID
         */
        public SopAPI(string apiKey, string shopId)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
            _shopId = shopId;
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            _db = new SopFakeDB();
        }

        /**
         * 查詢蝦購平台商品庫存
         * 模擬RESTful API調用過程
         * 
         * @param itemIds 要查詢的商品ID陣列
         * @return 蝦購平台特有格式的JSON庫存資訊
         * 
         * 回傳的JSON格式範例:
         * {
         *     "error": "",
         *     "message": "Success",
         *     "response": {
         *         "item_list": [
         *             {
         *                 "platform_item_id": "SOP_12345",
         *                 "item_name": "掌上型遊戲機",
         *                 "stock_info": {
         *                     "current_stock": 42
         *                 }
         *             },
         *             ...
         *         ]
         *     }
         * }
         */
        public async Task<string> GetStockAsync(string[] itemIds)
        {
            // 蝦購 API 要求將商品 ID 組合成逗號分隔的字串
            string itemIdParam = string.Join(",", itemIds);

            // 蝦購 API 特有的查詢參數格式 (簡化URL)
            string requestUrl = $"https://api.sop.com/v2/stock?shop_id={_shopId}&item_ids={itemIdParam}";

            // 實際中這裡會發出HTTP請求，這裡僅模擬
            // var response = await _httpClient.GetAsync(requestUrl);
            // response.EnsureSuccessStatusCode();
            // string jsonResponse = await response.Content.ReadAsStringAsync();

            // 從資料庫獲取模擬響應
            return _db.GetItemsJson(itemIds);
        }
    }
}
