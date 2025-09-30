using Thinksoft.Patterns.Structural.Facade.Model;

namespace Thinksoft.Patterns.Behavioral.Strategy.Model
{
    /**
     *  表達訂購表單的訂購資料型別
     */
    public class OrderModel
    {
        public List<OrderItem>? Items { get; set; }     // 商品明細清單
        public OrderDiscount? Discount { get; set; }    // 折扣資訊
        public int ShippingFee { get; set; }            // 運費
        public int TotalItemsAmount { get; set; }       // 商品總額        
        public int ActualAmount { get; set; }           // 訂購實際應付總額
    }
}
