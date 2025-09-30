using Thinksoft.Patterns.Structural.Adapter.Adaptee;

namespace Thinksoft.Patterns.Structural.Adapter.Adaptee
{
    /**
     * 蝦購平台模擬資料庫
     * 存儲通用商品在蝦購平台上的特定資訊和庫存
     */
    public class SopFakeDB
    {
        private readonly Dictionary<string, string> _jsonItems;

        public SopFakeDB()
        {
            // 初始化模擬資料，直接以JSON格式儲存
            // 這裡的商品ID是通用商品ID，而不是平台特有ID
            _jsonItems = new Dictionary<string, string>();

            // P001 掌上型遊戲機在蝦購的資料
            _jsonItems["P001"] = @"{
                ""platform_item_id"": ""SOP_12345"",
                ""item_name"": ""掌上型遊戲機"",
                ""stock_info"": {
                    ""current_stock"": 42
                }
            }";

            // P002 藍牙耳機在蝦購的資料
            _jsonItems["P002"] = @"{
                ""platform_item_id"": ""SOP_23456"",
                ""item_name"": ""藍牙耳機"",
                ""stock_info"": {
                    ""current_stock"": 18
                }
            }";

            // P003 行動電源在蝦購的資料
            _jsonItems["P003"] = @"{
                ""platform_item_id"": ""SOP_34567"",
                ""item_name"": ""行動電源"",
                ""stock_info"": {
                    ""current_stock"": 0
                }
            }";

            // P004 智能手錶在蝦購的資料
            _jsonItems["P004"] = @"{
                ""platform_item_id"": ""SOP_45678"",
                ""item_name"": ""智能手錶"",
                ""stock_info"": {
                    ""current_stock"": 25
                }
            }";
        }

        /**
         * 取得指定商品在蝦購的庫存資訊
         * 
         * @param productIds 要查詢的通用商品ID陣列
         * @return 蝦購格式的庫存資訊JSON字串
         */
        public string GetItemsJson(string[] productIds)
        {
            // 篩選存在的商品項目
            var itemJsonList = productIds
                .Where(_jsonItems.ContainsKey)
                .Select(id => _jsonItems[id])
                .ToList();

            // 構建蝦購特有的完整JSON響應
            return @"{
                ""error"": """",
                ""message"": ""Success"",
                ""response"": {
                    ""item_list"": [" + string.Join(",", itemJsonList) + @"]
                }
            }";
        }
    }
}