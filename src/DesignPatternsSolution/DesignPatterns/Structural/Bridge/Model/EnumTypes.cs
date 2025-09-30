namespace Thinksoft.Patterns.Structural.Bridge.Model
{
    /**
     * 支付類型列舉
     * 定義系統支援的支付方式類型
     */
    public enum PaymentType
    {
        CreditCard,     // 信用卡支付
        EWallet         // 電子錢包支付
    }

    /**
     * 支付閘道類型列舉
     * 定義系統支援的第三方支付閘道
     */
    public enum GatewayType
    {
        NewebPay,      // 藍新金流
        ECPay          // 綠界科技
    }
}
