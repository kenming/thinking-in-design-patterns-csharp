namespace Thinksoft.Patterns.Structural.Facade.Model
{
    /**
     * '訂購項目' 資料型別物件
     */
    public class OrderItem
    {
        public string IitemId { get; set; }   // 商品編號
        public string Name { get; set; }      // 商品名稱
        public int UnitPrice { get; set; }    // 商品單價
        public int Quantity { get; set; }     // 商品數量
        public int SubTotal                   // 分項金額，此為
            => UnitPrice * Quantity;          // 導出 (derived) 屬性
    }
}
