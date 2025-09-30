using Thinksoft.Patterns.Behavioral.Interpreter.Context;

namespace Thinksoft.Patterns.Behavioral.Interpreter.Expression
{
    /**
     * The 'NonTerminalExpression' Class
     * 邏輯AND 非終端表達式
     * 表示兩個折扣條件必須同時滿足才能適用折扣
     * 實現複合表達式的 邏輯AND 運算
     */
    public class AndExp : IDiscountExp
    {
        private IDiscountExp _left;     // 左側表達式
        private IDiscountExp _right;    // 右側表達式

        // Constructor
        public AndExp(IDiscountExp left, IDiscountExp right)
        {
            _left = left;
            _right = right;
        }

        /**
         * 評估兩個子表達式，只有當兩個子表達式都為true時，結果才為true
         * @param context 購物上下文，包含評估表達式所需的資訊
         * @return 兩個子表達式進行AND運算的結果
         */
        public bool Evaluate(ShoppingContext context)
        {
            return _left.Evaluate(context) && _right.Evaluate(context);
        }
    }
}
