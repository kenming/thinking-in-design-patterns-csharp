using System;
using System.Text;
using Thinksoft.Patterns.Behavioral.TemplateMethod.Template;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.TemplateMethod
{
    /**
     * 商品貸款主控台應用程式
     */
    public class PlaceProductLoanConsole : IConsoleProgram
    {
        public void Start()
        {
            // 建立不同的貸款處理器
            ProductLoanTemplate zeroInterest = new ZeroInterestLoan();
            ProductLoanTemplate bankCooperation = new BankCooperationLoan();

            // 分隔線
            Console.WriteLine("==========================================");
            Console.WriteLine("          零利率貸款方案測試              ");
            Console.WriteLine("==========================================");

            // 模擬不同顧客的零利率貸款處理
            zeroInterest.Process("Alice", 12000, 'A');  // A級顧客
            zeroInterest.Process("Nancy", 8000, 'C');   // C級顧客

            // 分隔線
            Console.WriteLine("\n");
            Console.WriteLine("==========================================");
            Console.WriteLine("          銀行合作貸款方案測試            ");
            Console.WriteLine("==========================================");

            // 模擬不同顧客的銀行合作貸款處理
            bankCooperation.Process("Bob", 20000, 'B');   // B級顧客
            bankCooperation.Process("Charlie", 5000, 'C'); // C級顧客

            Console.WriteLine("\n按任意鍵結束...");
            Console.ReadKey();
        }
    }
}