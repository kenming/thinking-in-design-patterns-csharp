using Thinksoft.Patterns.Behavioral.Strategy.Model;

namespace Thinksoft.Patterns.Behavioral.Strategy.Distributed
{
    /**
     * 紅利點數折扣策略類別
     * 實作紅利點數折扣的計算邏輯
     */
    public class BonusDiscount : IDiscountPrice
    {
        /**
         * 計算紅利點數折扣金額
         * 根據訂購總額，依序扣除 Bonus 點數費用
         * 1. 1000元(含)以下，折抵最大點數：50
         * 2. 5000元(含)以下，折抵最大點數：300
         * 3. 5000元以上，折抵最大點數：1000
         * @param orderDiscount 折扣資料物件
         * @param orderAmount 訂單金額
         * @return 處理後的折扣資料物件
         */
        public OrderDiscount CalcDiscountAmount(OrderDiscount orderDiscount, int orderAmount)
        {
            int bonus = orderDiscount.Bonus;
            int _discountAmount;        // 折扣金額

            if (orderAmount <= 1000)
                _discountAmount = Math.Min(bonus, 50);
            else if (orderAmount <= 5000)
                _discountAmount = Math.Min(bonus, 300);
            else
                _discountAmount = Math.Min(bonus, 1000);

            orderDiscount.DiscountAmount = _discountAmount;

            return orderDiscount;
        }
    }
}