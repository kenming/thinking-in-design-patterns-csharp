using Thinksoft.Patterns.Behavioral.Strategy.Model;

namespace Thinksoft.Patterns.Behavioral.Strategy.Distributed
{
    /**
     * 折扣券折扣策略類別
     * 實作折扣券折扣的計算邏輯
     */
    public class CouponDiscount : IDiscountPrice
    {
        /**
         * 計算折扣券折扣金額
         * 'A' 開頭折扣碼，抵 100 元
         * 'B' 開頭折扣碼，抵 50 元
         * 'C' 開頭折扣碼，抵 20 元
         * @param orderDiscount 折扣資料物件
         * @param orderAmount 訂單金額
         * @return 處理後的折扣資料物件
         */
        public OrderDiscount CalcDiscountAmount(OrderDiscount orderDiscount, int orderAmount)
        {
            string firstCharCode =
                orderDiscount.Coupon.Substring(0, 1);
            int _discountAmount = 0;        // 折扣金額

            switch (firstCharCode)
            {
                case "A":
                    _discountAmount = 100;
                    break;
                case "B":
                    _discountAmount = 50;
                    break;
                case "C":
                    _discountAmount = 20;
                    break;
            }

            orderDiscount.DiscountAmount = _discountAmount;

            return orderDiscount;
        }
    }
}