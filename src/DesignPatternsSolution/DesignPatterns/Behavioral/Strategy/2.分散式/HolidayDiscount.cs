using Thinksoft.Patterns.Behavioral.Strategy.Model;

namespace Thinksoft.Patterns.Behavioral.Strategy.Distributed
{
    /**
     * 節慶活動折扣策略類別
     * 實作節慶活動折扣的計算邏輯
     */
    public class HolidayDiscount : IDiscountPrice
    {
        /**
         * 計算節慶活動折扣金額
         * @param orderDiscount 折扣資料物件
         * @param orderAmount 訂單金額
         * @return 處理後的折扣資料物件
         */
        public OrderDiscount CalcDiscountAmount(OrderDiscount orderDiscount, int orderAmount)
        {
            int _discountAmount = 0;        // 折扣金額

            switch (orderDiscount.Holiday)
            {
                case "母親節":     // 滿千送百
                    _discountAmount = (int)(orderAmount / 1000) * 100;
                    orderDiscount.DiscountAmount = _discountAmount;
                    break;
                case "光棍節":     // 免運費
                    orderDiscount.ShippingDiscount = 0;
                    break;
            }

            return orderDiscount;
        }
    }
}