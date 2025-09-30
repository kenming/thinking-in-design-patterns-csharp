using Thinksoft.Patterns.Behavioral.Interpreter.Context;

namespace Thinksoft.Patterns.Behavioral.Interpreter.Expression
{
    /**
     * The 'NonTerminalExpression' Class
     * 邏輯OR 非終端表達式
     * 表示兩個折扣條件只需滿足其中一個即可適用折扣
     * 實現複合表達式的 邏輯OR 運算
     */
    public class OrExp : IDiscountExp
    {
        private IDiscountExp _left;     // 左側表達式
        private IDiscountExp _right;    // 右側表達式

        // Constructor
        public OrExp(IDiscountExp left, IDiscountExp right)
        {
            _left = left;
            _right = right;
        }

        /**
         * 評估兩個子表達式，只要其中一個子表達式為true，結果即為true
         * @param context 購物上下文，包含評估表達式所需的資訊
         * @return 兩個子表達式進行OR運算的結果
         */

        public bool Evaluate(ShoppingContext context)
        {
            return _left.Evaluate(context) || _right.Evaluate(context);
        }
    }
}
