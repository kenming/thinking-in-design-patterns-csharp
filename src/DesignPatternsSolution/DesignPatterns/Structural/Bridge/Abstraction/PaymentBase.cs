using Thinksoft.Patterns.Structural.Bridge.Implementor;
using Thinksoft.Patterns.Structural.Bridge.Model;

namespace Thinksoft.Patterns.Structural.Bridge.Abstraction
{
    /**
     * The 'Abstraction' Abstract Class
     * 支付抽象類別
     * 定義支付處理的高層介面，持有 Implementator 的參考
     * ，將 Client 端的請求委派給 Implementator 處理
     */
    public abstract class PaymentBase
    {
        protected IPaymentGateway gateway;   // Bridge連接：持有Implementator參考
        protected PaymentType paymentType;   // 支付類型

        // Constructor
        protected PaymentBase(PaymentType paymentType, IPaymentGateway gateway)
        {
            this.paymentType = paymentType;
            this.gateway = gateway;
        }

        /**
         * 抽象方法 - 處理支付請求
         * @parm request 支付請求資料
         * @return 支付處理結果
         */
        public abstract string ProcessPayment(PaymentRequest request);

        /**
         * 取得支付資訊
         * @return 支付方式與閘道的組合資訊
         */
        public virtual string GetPaymentInfo()
        {
            return $"支付方式: {paymentType}, 閘道: {gateway.GetGatewayName()}";
        }
    }
}
