namespace Thinksoft.Patterns.Behavioral.Strategy.Model
{
    /**
     *  折扣資料類別
     */
    public class OrderDiscount
    {
        public OrderDiscountType DiscountType { get; set; }  // 折扣類型
        public int Bonus { get; set; }                      // 紅利點數
        public string? Coupon { get; set; }                 // 折扣券代碼
        public string? Holiday { get; set; }                // 節慶日活動優惠
        public int ShippingDiscount { get; set; }           // 運費折扣金額
        public int DiscountAmount { get; set; }             // 折扣金額
    }
}
