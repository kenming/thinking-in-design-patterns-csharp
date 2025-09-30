using Thinksoft.Patterns.Behavioral.Interpreter.Context;

namespace Thinksoft.Patterns.Behavioral.Interpreter.Expression
{
    /**
     * The 'TerminalExpression' Class
     * 商品類別條件終端表達式
     * 檢查購物車中是否包含指定類別的商品
     * 實現最基本的類別條件判斷
     */
    public class CategoryExp : IDiscountExp
    {
        private string _category;   // 檢查的商品類別

        public CategoryExp(string category)
        {
            _category = category;
        }

        /**
         * 評估購物車中是否包含指定類別的商品
         * @param context 購物上下文，包含商品類別列表
         * @return 如果購物車中包含指定類別的商品則返回true，否則返回false
         */
        public bool Evaluate(ShoppingContext context)
        {
            var categories = context.GetValue("Categories") as List<string>;
            return categories != null && categories.Contains(_category);
        }
    }
}
