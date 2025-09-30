using Thinksoft.Patterns.Behavioral.TemplateMethod.Model;

namespace Thinksoft.Patterns.Behavioral.TemplateMethod.Template
{
    /**
     * The 'Concrete Class'
     * 零利率貸款方案
     * 擴展(extend) ProductLoanTemplate 抽象類別
     */
    public class ZeroInterestLoan : ProductLoanTemplate
    {
        /**
         * 覆寫資格檢查方法，加入信用評等檢查
         */
        protected override bool FilterApplicant(string applicantName, decimal amount, char creditRating)
        {
            // 先執行基本檢查
            if (!base.FilterApplicant(applicantName, amount, creditRating))
            {
                return false;
            }

            // 零利率方案只接受 A 或 B 評等的顧客
            if (creditRating == 'C')
            {
                Console.WriteLine("零利率方案僅適用於 A 或 B 評等的顧客");
                return false;
            }

            return true;
        }

        /**
         * 實作計算零利率貸款方案的演算邏輯
         */
        protected override ProductLoan CalculateProductLoan(decimal amount, char creditRating)
        {
            Console.WriteLine("📊 計算零利率方案...");

            // 根據信用評等決定分期期數
            int months;
            if (creditRating == 'A')
                months = 12; // A級顧客可享12期零利率
            else
                months = 6;  // B級顧客只能享6期零利率

            // 計算每月還款金額
            decimal monthlyPayment = amount / months;

            // 零利率方案沒有利息，但有手續費
            decimal processingFee = amount * 0.03m; // 3%手續費

            return new ProductLoan
            {
                Amount = amount,
                Installments = months,
                // 手續費平均分攤到每期
                MonthlyPayment = monthlyPayment + (processingFee / months),
                TotalInterest = processingFee // 這裡的"利息"實際上是手續費
            };
        }
    }
}