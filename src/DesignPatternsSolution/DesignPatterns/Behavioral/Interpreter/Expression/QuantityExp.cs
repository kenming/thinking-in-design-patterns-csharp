using Thinksoft.Patterns.Behavioral.Interpreter.Context;

namespace Thinksoft.Patterns.Behavioral.Interpreter.Expression
{
    /**
     * The 'TerminalExpression' Class
     * 商品數量條件終端表達式
     * 檢查購物車中指定商品的數量是否達到閾值
     * 實現最基本的數量條件判斷
     */
    public class QuantityExp : IDiscountExp
    {
        private string _productId;  // 商品ID
        private int _threshold;     // 商品閾值

        // Constructor
        public QuantityExp(string productId, int threshold)
        {
            _productId = productId;
            _threshold = threshold;
        }

        /**
         * 評估購物車中指定商品的數量是否達到或超過閾值
         * @param context 購物上下文，包含商品數量資訊
         * @return 如果指定商品的數量達到或超過閾值則返回true，否則返回false
         */
        public bool Evaluate(ShoppingContext context)
        {
            var quantities = context.GetValue("Quantities") as Dictionary<string, int>;
            return quantities != null &&
                   quantities.ContainsKey(_productId) &&
                   quantities[_productId] >= _threshold;
        }
    }
}
