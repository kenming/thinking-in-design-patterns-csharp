using System;
using Thinksoft.Patterns.Creational.FactoryMethod.Creator;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Creational.FactoryMethod
{
    /**
     * The 'Client' Console
     * 保費計算控制台程式     
     * 示範如何使用 Factory Method 模式計算不同商品的保險費用
     */
    public class CalculatePremiumConsole : IConsoleProgram
    {
        public void Start()
        {
            Console.WriteLine("=== Factory Method 模式 - 保費計算範例 ===\n");

            // 創建快遞保費計算器
            var calculator = new ExpressShippingCalculator();
            var service = new CalculatePremiumService(calculator);

            Console.WriteLine("使用快遞保費計算器計算不同商品的保險費用：");
            Console.WriteLine("📝 決策邏輯：");
            Console.WriteLine("   • 電子產品或價值超過 $1000 的商品 → 加值保險方案");
            Console.WriteLine("   • 一般商品且價值低於 $1000 → 基本保險方案\n");

            // 測試案例 1：一般商品（低價值）
            Console.WriteLine("【案例 1】一般商品 - 低價值");
            DisplayInsuranceQuote(service, "furniture", 500);

            Console.WriteLine("\n" + new string('-', 50) + "\n");

            // 測試案例 2：電子產品
            Console.WriteLine("【案例 2】電子產品");
            DisplayInsuranceQuote(service, "electronics", 800);

            Console.WriteLine("\n" + new string('-', 50) + "\n");

            // 測試案例 3：高價值商品
            Console.WriteLine("【案例 3】高價值商品");
            DisplayInsuranceQuote(service, "jewelry", 2500);
        }

        /**
         * 顯示保險報價資訊
         * 
         * @param service 保費計算服務
         * @param itemType 商品類型
         * @param itemValue 商品價值
         */
        private void DisplayInsuranceQuote(CalculatePremiumService service, string itemType, double itemValue)
        {
            Console.WriteLine("保險報價資訊：");
            Console.WriteLine("--------------------------------------");
            
            var quote = service.GetInsuranceQuote(itemType, itemValue);
            Console.WriteLine(quote);
            
            Console.WriteLine("--------------------------------------");
        }
    }
}