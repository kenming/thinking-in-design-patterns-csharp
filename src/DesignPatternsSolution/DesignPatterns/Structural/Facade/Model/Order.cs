namespace Thinksoft.Patterns.Structural.Facade.Model
{
    /*
     *  '訂購主檔' 資料型別物件     
     *  這並非是資料庫的表格，僅表達所輸入訂購單的資料結構
     */
    public class Order
    {
        public List<OrderItem> OrderItems { get; set; }   // 訂購項目集合
            = new List<OrderItem>();
        public string CouponCode { get; set; }            // 折扣碼
        public int ShippingFee { get; set; }              // 運費
        public int DiscountAmount { get; set; }           // 折扣金額
        public int TotalItemsAmount                       // 商品總額，此為
            => OrderItems.Sum(item => item.SubTotal);     // 導出 (derived) 屬性
        public int ActualAmount { get; set; }             // 實付金額
    }
}
