namespace Thinksoft.Patterns.Structural.Bridge.Model
{
    /**
     * 支付請求資料模型     
     * 封裝支付交易所需的基本資訊，支援信用卡與電子錢包兩種支付方式
     */
    public class PaymentRequest
    {
        public string StoreId { get; set; }           // 商店代號
        public decimal Amount { get; set; }           // 支付金額
        public PaymentType PaymentType { get; set; }  // 支付類型
        public string PaymentData { get; set; }       // 支付資料(通用欄位)
    }
}
