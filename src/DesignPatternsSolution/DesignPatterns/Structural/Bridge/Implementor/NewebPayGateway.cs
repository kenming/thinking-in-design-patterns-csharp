using Thinksoft.Patterns.Structural.Bridge.Model;

namespace Thinksoft.Patterns.Structural.Bridge.Implementor
{
    /**
     * The 'ConcreteImplementator' Class
     * 藍新金流閘道具體類別
     * 實作藍新金流的支付處理邏輯，包含信用卡與電子錢包支付
     */
    public class NewebPayGateway : IPaymentGateway
    {
        /**
         * 處理信用卡支付(藍新金流版本)
         * @Parm request 支付請求，PaymentData格式為"卡號|到期日|CVV"
         * @return 藍新金流的信用卡支付處理結果
         */
        public string ProcessCreditCard(PaymentRequest request)
        {
            // 解析信用卡資料格式: "卡號|到期日|CVV"
            var cardData = request.PaymentData.Split('|');
            return $"藍新金流處理信用卡支付:\n" +
                   $"  商店: {request.StoreId}\n" +
                   $"  金額: NT$ {request.Amount:N0}\n" +
                   $"  卡號: {cardData[0]}\n" +
                   $"  狀態: 交易成功 (藍新金流)";
        }

        /**
         * 處理電子錢包支付(藍新金流版本)
         * @Parm request 支付請求，PaymentData格式為"錢包類型|授權令牌|用戶ID"
         * @return 藍新金流的電子錢包支付處理結果
         */
        public string ProcessEWallet(PaymentRequest request)
        {
            // 解析電子錢包資料格式: "錢包類型|授權令牌|用戶ID"
            var walletData = request.PaymentData.Split('|');
            return $"藍新金流處理電子錢包支付:\n" +
                   $"  商店: {request.StoreId}\n" +
                   $"  金額: NT$ {request.Amount:N0}\n" +
                   $"  錢包: {walletData[0]}\n" +
                   $"  用戶: {walletData[2]}\n" +
                   $"  狀態: 交易成功 (藍新金流)";
        }

        /**
         * 取得閘道名稱
         * @return 藍新金流的識別名稱
         */
        public string GetGatewayName() => "藍新金流 (NewebPay)";
    }
}
