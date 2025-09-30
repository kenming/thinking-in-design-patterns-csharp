namespace Thinksoft.Patterns.Behavioral.Strategy.Model
{
    // 訂單商品明細的資料型別
    public class OrderItem
    {
        public string? Name { get; set; }    // 商品名稱
        public int Quantity { get; set; }   // 數量
        public int UnitPrice { get; set; }  // 單價
        public int SubTotal { get; set; }   // 分項金額 (derived attribute)        
    }
}
