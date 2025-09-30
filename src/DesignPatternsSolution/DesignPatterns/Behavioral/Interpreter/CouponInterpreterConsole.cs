using Thinksoft.Patterns.Behavioral.Interpreter.Context;
using Thinksoft.Patterns.Behavioral.Interpreter.Expression;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.Interpreter
{
    /**     
     * 優惠券 Iterpreter 展示 Console
     * 示範如何建立和使用折扣規則解釋器
     * 構建表達式樹並評估折扣規則
     */
    public class CouponInterpreterConsole : IConsoleProgram
    {
        public void Start()
        {
            this.DisplaySimpleCouponRule();
            Console.WriteLine("\n");
            this.DisplayComplexCouponRule();
        }

        /**
         * 示範簡單優惠券規則：滿1000折100
         * 使用單一終端表達式評估規則
         */
        private void DisplaySimpleCouponRule()
        {
            // 建立購物上下文
            ShoppingContext context = new ShoppingContext();
            context.SetValue("TotalAmount", 1200.00m); // 購物車總金額1200元

            // 建立優惠券規則表示式：滿1000
            IDiscountExp rule = new PriceExp(1000.00m);

            // 評估規則
            bool isApplicable = rule.Evaluate(context);

            Console.WriteLine("-- 簡單優惠券規則 ------");
            Console.WriteLine($"運算表達式: TotalAmount >= 1000.00");
            Console.WriteLine($"購物車總金額: {context.GetValue("TotalAmount")}");            
            Console.WriteLine($"規則描述: 滿1000折100");
            Console.WriteLine($"是否適用: {isApplicable}");
        }

        /**
         * 示範複雜優惠券規則：類別:電子產品 且 滿5000 打9折
         * 使用複合表達式（AND運算）評估規則
         */
        private void DisplayComplexCouponRule()
        {
            // 建立購物車上下文
            ShoppingContext context = new ShoppingContext();
            context.SetValue("TotalAmount", 5500.00m); // 購物車總金額5500元

            // 設定購物車中的商品類別
            var categories = new List<string> { "電子產品", "家電" };
            context.SetValue("Categories", categories);

            // 建立優惠券規則表示式：類別:電子產品 且 滿5000
            IDiscountExp categoryRule = new CategoryExp("電子產品");
            IDiscountExp priceRule = new PriceExp(5000.00m);
            IDiscountExp complexRule = new AndExp(categoryRule, priceRule);

            // 評估規則
            bool isApplicable = complexRule.Evaluate(context);

            Console.WriteLine("-- 複雜優惠券規則 ------");
            Console.WriteLine($"運算表達式: " +
                $"(Categories contains '電子產品') AND (TotalAmount >= 5000.00)");
            Console.WriteLine($"購物車總金額: {context.GetValue("TotalAmount")}");
            Console.WriteLine($"商品類別: {string.Join(", ", categories)}");
            Console.WriteLine($"規則描述: 類別:電子產品 且 滿5000 打9折");
            Console.WriteLine($"是否適用: {isApplicable}");
        }
    }
}
