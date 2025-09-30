using Thinksoft.Patterns.Structural.Bridge.Model;

namespace Thinksoft.Patterns.Structural.Bridge.Implementor
{
    /**
     * The 'Implementator' Interface
     * 支付閘道實作介面     
     * 功能：定義所有支付閘道必須實作的核心支付處理
     */
    public interface IPaymentGateway
    {
        /**
         * 處理信用卡支付
         * @param request 包含信用卡資訊的支付請求
         * @return 支付處理結果訊息
         */
        string ProcessCreditCard(PaymentRequest request);

        /**
         * 處理電子錢包支付
         * @param request 包含電子錢包資訊的支付請求
         * @return 支付處理結果訊息
         */
        string ProcessEWallet(PaymentRequest request);

        /**
         * 取得閘道名稱
         * @return 閘道的識別名稱
         */
        string GetGatewayName();
    }
}
