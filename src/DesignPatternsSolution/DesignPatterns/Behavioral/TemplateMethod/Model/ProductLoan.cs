namespace Thinksoft.Patterns.Behavioral.TemplateMethod.Model
{
    /**
     * 商品貸款資料物件
     * 用於儲存貸款資訊
     */
    public class ProductLoan
    {
        public decimal Amount { get; set; }           // 貸款金額
        public int Installments { get; set; }         // 分期期數
        public decimal MonthlyPayment { get; set; }   // 每月應繳金額
        public decimal TotalInterest { get; set; }    // 總利息
    }
}
