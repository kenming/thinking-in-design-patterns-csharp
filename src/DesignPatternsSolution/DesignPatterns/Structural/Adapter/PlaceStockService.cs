using Thinksoft.Patterns.Structural.Adapter.Adaptee;
using Thinksoft.Patterns.Structural.Adapter.Adapter;
using Thinksoft.Patterns.Structural.Adapter.Model;

namespace Thinksoft.Patterns.Structural.Adapter
{
    /** 
     *	The 'Service' Class, as a Facade Role.
     *  1. 封裝對不同平台 Adapter 的調用與處理
     *  2. 取得各平台的庫存資訊並統計總庫存資訊
     */
    public class PlaceStockService
    {
        // 存儲各電商平台名稱和對應的庫存調變器
        private readonly Dictionary<string, ICheckStock> _platformAdapters;

        // 建構函式
        public PlaceStockService()
        {            
            _platformAdapters = new Dictionary<string, ICheckStock>();

            // 創建調變器實例物件並加入Dictionary
            _platformAdapters.Add("蝦購", new SopAdapter("sop-api-key-123", "shop-123456"));
            _platformAdapters.Add("MO購", new MoAdapter("mo-partner-789", "mo-secret-xyz"));
        }

        // 獲取特定平台的庫存訊息
        public async Task<List<StockInfo>>
            GetPlatformStockAsync(string platformName, List<string> productIds)
        {
            if (_platformAdapters.ContainsKey(platformName))
            {
                Console.WriteLine($"透過 '{platformName}' 調變器查詢庫存");
                return await _platformAdapters[platformName].GetStockInfo(productIds);
            }
            Console.WriteLine($"找不到平台 '{platformName}' 的調變器");
            return new List<StockInfo>();
        }

        // 獲取所有平台的庫存信息
        public async Task<List<StockInfo>>
            GetAllPlatformsStockAsync(List<string> productIds)
        {
            var allStockInfo = new List<StockInfo>();

            foreach (var platformEntry in _platformAdapters)
            {
                Console.WriteLine($"查詢 '{platformEntry.Key}' 平台庫存");
                var platformStock = await platformEntry.Value.GetStockInfo(productIds);
                allStockInfo.AddRange(platformStock);
            }

            return allStockInfo;
        }

        // 依商品統計庫存總量
        public Dictionary<string, int>
            CalculateTotalStockByProduct(List<StockInfo> stockInfoList)
        {
            var totalStock = new Dictionary<string, int>();

            foreach (var group in stockInfoList.GroupBy(s => s.ProductId))
            {
                totalStock[group.Key] = group.Sum(s => s.Quantity);
            }

            return totalStock;
        }
    }
}
