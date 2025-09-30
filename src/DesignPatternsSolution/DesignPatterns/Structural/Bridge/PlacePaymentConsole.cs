using Thinksoft.Patterns.Structural.Bridge.Abstraction;
using Thinksoft.Patterns.Structural.Bridge.Model;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Structural.Bridge
{
    /**
     * 支付功能展示 Console     
     * 展示 Bridge 模式的設計，演示支付方式與閘道的靈活組合
     */
    public class PlacePaymentConsole : IConsoleProgram
    {        
        public void Start()
        {
            Console.WriteLine("=== Bridge Pattern 支付功能展示 ===\n");
            Console.WriteLine("展示支付方式與閘道的靈活組合\n");

            // 建立測試資料
            var creditCardRequest = CreateCreditCardTestData();
            var eWalletRequest = CreateEWalletTestData();

            // 展示所有支付組合 (2×2 = 4種組合)
            Console.WriteLine("🔸 組合1: 信用卡 × 藍新金流");
            var payment1 = new Payment(PaymentType.CreditCard, GatewayType.NewebPay);
            Console.WriteLine(payment1.GetPaymentInfo());
            Console.WriteLine(payment1.ProcessPayment(creditCardRequest));
            Console.WriteLine();

            Console.WriteLine("🔸 組合2: 信用卡 × 綠界科技");
            var payment2 = new Payment(PaymentType.CreditCard, GatewayType.ECPay);
            Console.WriteLine(payment2.GetPaymentInfo());
            Console.WriteLine(payment2.ProcessPayment(creditCardRequest));
            Console.WriteLine();

            Console.WriteLine("🔸 組合3: 電子錢包 × 藍新金流");
            var payment3 = new Payment(PaymentType.EWallet, GatewayType.NewebPay);
            Console.WriteLine(payment3.GetPaymentInfo());
            Console.WriteLine(payment3.ProcessPayment(eWalletRequest));
            Console.WriteLine();

            Console.WriteLine("🔸 組合4: 電子錢包 × 綠界科技");
            var payment4 = new Payment(PaymentType.EWallet, GatewayType.ECPay);
            Console.WriteLine(payment4.GetPaymentInfo());
            Console.WriteLine(payment4.ProcessPayment(eWalletRequest));
            Console.WriteLine();

            // 展示錯誤處理
            Console.WriteLine("🔸 錯誤處理展示:");
            var wrongTypePayment = new Payment(PaymentType.CreditCard, GatewayType.NewebPay);
            Console.WriteLine(wrongTypePayment.ProcessPayment(eWalletRequest)); // 類型不符測試
            Console.WriteLine();
        }

        /**
         * 建立信用卡測試資料
         * @return 信用卡支付請求物件
         * 產生用於測試信用卡支付的標準資料
         */
        private PaymentRequest CreateCreditCardTestData()
        {
            return new PaymentRequest
            {
                StoreId = "SHOP001",
                Amount = 1500,
                PaymentType = PaymentType.CreditCard,
                PaymentData = "4111-1111-1111-1111|12/25|123"  // 卡號|到期日|CVV
            };
        }

        /**
         * 建立電子錢包測試資料
         * 返回值：電子錢包支付請求物件
         * 功能：產生用於測試電子錢包支付的標準資料
         */
        private PaymentRequest CreateEWalletTestData()
        {
            return new PaymentRequest
            {
                StoreId = "SHOP002",
                Amount = 2000,
                PaymentType = PaymentType.EWallet,
                PaymentData = "ApplePay|token_abc123|user_001"  // 錢包類型|授權令牌|用戶ID
            };
        }
    }
}