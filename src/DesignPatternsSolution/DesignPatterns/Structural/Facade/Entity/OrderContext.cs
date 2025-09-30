using Thinksoft.Patterns.Structural.Facade.Model;

namespace Thinksoft.Patterns.Structural.Facade.Entity
{
    /**
     * 訂單上下文類別
     * 負責訂單相關的業務邏輯處理
     */
    public class OrderContext
    {
        public int CalculateDiscount(Order order)
        {
            int discountAmount = 0;

            if (!string.IsNullOrEmpty(order.CouponCode))
            {
                if (order.CouponCode == "1688")
                {
                    // 商品總額的92折
                    discountAmount = (int)(order.TotalItemsAmount * 0.08);
                }
                else if (order.CouponCode == "NoFee")
                {
                    // 免運費
                    discountAmount = order.ShippingFee;
                }
            }

            return discountAmount;
        }
    }
}
