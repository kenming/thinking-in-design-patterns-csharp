using Thinksoft.Patterns.Behavioral.Interpreter.Context;

namespace Thinksoft.Patterns.Behavioral.Interpreter.Expression
{
    /**
     * The 'TerminalExpression' Class
     * 金額條件終端表達式
     * 檢查購物車總金額是否達到或超過指定閾值
     * 實現最基本的金額條件判斷
     */
    public class PriceExp : IDiscountExp
    {
        private decimal _threshold;     // 金額閾值

        public PriceExp(decimal threshold)
        {
            _threshold = threshold;
        }

        /**
         * 評估購物車總金額是否達到或超過指定閾值
         * @param context 購物上下文，包含購物車總金額
         * @return 如果購物車總金額達到或超過閾值則返回true，否則返回false
         */
        public bool Evaluate(ShoppingContext context)
        {
            var totalAmount = context.GetValue("TotalAmount") as decimal?;
            return totalAmount.HasValue && totalAmount.Value >= _threshold;
        }
    }
}
