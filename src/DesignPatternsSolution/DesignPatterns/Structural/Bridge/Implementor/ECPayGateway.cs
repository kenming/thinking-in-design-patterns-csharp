using Thinksoft.Patterns.Structural.Bridge.Model;

namespace Thinksoft.Patterns.Structural.Bridge.Implementor
{
    /**
     * The 'ConcreteImplementator' Class
     * 綠界科技閘道具體類別
     * 實作綠界科技的支付處理邏輯，包含信用卡與電子錢包支付
     */
    public class ECPayGateway : IPaymentGateway
    {
        /**
         * 處理信用卡支付(綠界科技版本)
         * @parm request 支付請求，PaymentData格式為"卡號|到期日|CVV"
         * @return 綠界科技的信用卡支付處理結果
         */
        public string ProcessCreditCard(PaymentRequest request)
        {
            // 解析信用卡資料格式: "卡號|到期日|CVV"
            var cardData = request.PaymentData.Split('|');
            return $"綠界科技處理信用卡支付:\n" +
                   $"  商店: {request.StoreId}\n" +
                   $"  金額: NT$ {request.Amount:N0}\n" +
                   $"  卡號: {cardData[0]}\n" +
                   $"  狀態: 付款完成 (綠界科技)";
        }

        /**
         * 處理電子錢包支付(綠界科技版本)
         * @parm request 支付請求，PaymentData格式為"錢包類型|授權令牌|用戶ID"
         * @return 綠界科技的電子錢包支付處理結果
         */
        public string ProcessEWallet(PaymentRequest request)
        {
            // 解析電子錢包資料格式: "錢包類型|授權令牌|用戶ID"
            var walletData = request.PaymentData.Split('|');
            return $"綠界科技處理電子錢包支付:\n" +
                   $"  商店: {request.StoreId}\n" +
                   $"  金額: NT$ {request.Amount:N0}\n" +
                   $"  錢包: {walletData[0]}\n" +
                   $"  用戶: {walletData[2]}\n" +
                   $"  狀態: 付款完成 (綠界科技)";
        }

        /**
         * 取得閘道名稱
         * @return 綠界科技的識別名稱
         */
        public string GetGatewayName() => "綠界科技 (ECPay)";
    }
}
