using Thinksoft.Patterns.Behavioral.TemplateMethod.Model;

namespace Thinksoft.Patterns.Behavioral.TemplateMethod.Template
{
    /**
     * The 'Concrete Class'
     * 銀行合作貸款方案
     * 擴展(extend) ProductLoanTemplate 抽象類別
     */
    public class BankCooperationLoan : ProductLoanTemplate
    {
        /**
         * 實作計算銀行合作貸款方案的演算邏輯
         */
        protected override ProductLoan CalculateProductLoan(decimal amount, char creditRating)
        {
            Console.WriteLine("📊 計算銀行合作方案...");

            // 根據信用評等決定年利率
            decimal annualRate;
            switch (creditRating)
            {
                case 'A':
                    annualRate = 0.03m; // A級顧客享3%年利率
                    break;
                case 'B':
                    annualRate = 0.05m; // B級顧客享5%年利率
                    break;
                default:
                    annualRate = 0.08m; // C級顧客只能獲得8%年利率
                    break;
            }

            // 根據貸款金額決定分期期數
            int months;
            if (amount >= 20000)
                months = 36;
            else if (amount >= 10000)
                months = 24;
            else
                months = 12;

            // 計算月利率
            decimal monthlyRate = annualRate / 12;

            // 使用分期付款公式計算每月還款金額
            // 公式：P = L * [r(1+r)^n] / [(1+r)^n - 1]
            double temp = Math.Pow(1 + (double)monthlyRate, months);
            decimal monthlyPayment = amount * 
                (monthlyRate * (decimal)temp) / ((decimal)temp - 1);

            // 計算總利息
            decimal totalInterest = (monthlyPayment * months) - amount;

            return new ProductLoan
            {
                Amount = amount,
                Installments = months,
                MonthlyPayment = Math.Round(monthlyPayment, 2),
                TotalInterest = Math.Round(totalInterest, 2)
            };
        }
    }
}