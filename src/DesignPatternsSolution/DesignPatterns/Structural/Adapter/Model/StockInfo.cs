namespace Thinksoft.Patterns.Structural.Adapter.Model
{
    /**
     * 庫存資訊資料類別
     * 整合蝦購與Mo購不同庫存格式
     */
    public class StockInfo
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Platform { get; set; }
    }
}
