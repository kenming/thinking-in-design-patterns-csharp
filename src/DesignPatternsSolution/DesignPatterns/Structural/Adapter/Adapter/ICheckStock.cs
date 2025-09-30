using Thinksoft.Patterns.Structural.Adapter.Model;

namespace Thinksoft.Patterns.Structural.Adapter.Adapter
{
    /*
     *  The 'Adapter' Interface.
     *  定義取得庫存資訊的操作介面
     */
    public interface ICheckStock
    {
        /**
         * 查詢指定商品的庫存資訊        
         * @param productIds 要查詢的商品ID列表
         * @return 包含所有查詢商品庫存資訊的列表
         */
        Task<List<StockInfo>> GetStockInfo(List<string> productIds);
    }
}
