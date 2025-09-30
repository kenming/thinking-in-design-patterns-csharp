using Thinksoft.Patterns.Structural.Bridge.Implementor;
using Thinksoft.Patterns.Structural.Bridge.Model;

namespace Thinksoft.Patterns.Structural.Bridge.Abstraction
{
    /**
     * The 'RefinedAbstraction' Class
     * 支付實作具體類別
     * 擴展 Abstraction 定義的介面，實作具體的支付處理邏輯
     * ，透過 Bridge 將請求委派給對應的 Implementator
     */
    public class Payment : PaymentBase
    {
        /**
         * Constructor - 建立支付實例
         * @parm paymentType 支付類型(信用卡或電子錢包)
         * @parm gatewayType 閘道類型(藍新金流或綠界科技)
         */
        public Payment(PaymentType paymentType, GatewayType gatewayType)
            : base(paymentType, CreateGateway(gatewayType))
        {
        }

        /**
         * 處理支付請求 - Bridge 模式核心方法
         * @parm request 包含完整支付資訊的請求物件
         * @return 支付處理結果訊息，包含成功/失敗狀態
         */
        public override string ProcessPayment(PaymentRequest request)
        {
            // 驗證支付類型是否一致
            if (request.PaymentType != paymentType)
            {
                return $"錯誤: 支付類型不符 " +
                    $"(預期: {paymentType}, 實際: {request.PaymentType})";
            }

            // Bridge核心：根據支付類型委派給對應的Implementation方法
            return paymentType switch
            {
                PaymentType.CreditCard => gateway.ProcessCreditCard(request),
                PaymentType.EWallet => gateway.ProcessEWallet(request),
                _ => "不支援的支付類型"
            };
        }

        /**
         * 工廠方法 - 建立對應的閘道實例
         * @parm gatewayType - 閘道類型列舉值
         * @return 對應的閘道實作物件
         * 根據閘道類型建立具體的 Implementator 實例
         */
        private static IPaymentGateway CreateGateway(GatewayType gatewayType)
        {
            return gatewayType switch
            {
                GatewayType.NewebPay => new NewebPayGateway(),
                GatewayType.ECPay => new ECPayGateway(),
                _ => throw new ArgumentException("不支援的閘道類型")
            };
        }
    }
}
