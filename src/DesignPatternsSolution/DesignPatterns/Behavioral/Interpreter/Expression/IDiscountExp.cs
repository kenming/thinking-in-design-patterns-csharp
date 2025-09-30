using Thinksoft.Patterns.Behavioral.Interpreter.Context;

namespace Thinksoft.Patterns.Behavioral.Interpreter.Expression
{
    /**
     * The 'AbstractExpression' Interface
     * 定義折扣表達式的抽象介面，所有折扣條件表達式都必須實現此介面
     * 提供統一的評估方法，用於判斷折扣條件是否適用
     */
    public interface IDiscountExp
    {
        /**
         * 評估折扣表達式是否適用於給定的購物上下文
         * @param context 包含購物資訊的上下文物件
         * @return 表達式評估結果，true表示條件成立，false表示條件不成立
         */
        bool Evaluate(ShoppingContext context);
    }
}
