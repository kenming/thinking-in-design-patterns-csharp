using Thinksoft.Patterns.Behavioral.Strategy.Model;

namespace Thinksoft.Patterns.Behavioral.Strategy.Distributed
{
    /**
     * 折扣計算策略介面
     * 定義計算折扣金額的操作規格
     */
    public interface IDiscountPrice
    {
        /**
         * 計算折扣金額的操作
         * @param orderDiscount 訂購的折扣物件
         * @param orderAmount 訂單原始金額
         * @return 折扣處理後回傳的 OrderDiscount 資料物件
         */
        OrderDiscount CalcDiscountAmount(OrderDiscount orderDiscount, int orderAmount);
    }
}