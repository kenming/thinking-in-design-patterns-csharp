using Thinksoft.Patterns.Behavioral.TemplateMethod.Model;

namespace Thinksoft.Patterns.Behavioral.TemplateMethod.Template
{
    /**
     * The 'Abstract Class'
     * 商品貸款處理抽象類別
     * 定義貸款處理的模板方法和流程步驟
     */
    public abstract class ProductLoanTemplate
    {
        /**
         * Template Method
         * 處理商品貸款申請流程
         * @param applicantName 申請人姓名
         * @param amount 貸款金額
         * @param creditRating 信用評等 ('A', 'B', 'C')
         */
        public void Process(string applicantName, decimal amount, char creditRating)
        {
            Console.WriteLine($"\n=== {GetType().Name} 貸款流程開始 ===");

            // Step 1: 過濾申請資格
            if (!FilterApplicant(applicantName, amount, creditRating))
            {
                Console.WriteLine("❌ 申請資格不符，流程結束");
                return;
            }

            // Step 2: 計算貸款方案內容
            var plan = CalculateProductLoan(amount, creditRating);

            // Step 3: 產出貸款申請報表
            GenerateReport(applicantName, plan);

            Console.WriteLine("=== 貸款流程結束 ===");
        }

        /**
         * 固定流程：資格檢查
         * 可被子類別覆寫，但提供預設實作
         */
        protected virtual bool FilterApplicant(string applicantName, 
            decimal amount, char creditRating)
        {
            Console.WriteLine($"🔍 檢查申請人 {applicantName} 是否符合資格...");
            Console.WriteLine($"信用評等: {creditRating}");

            if (amount < 1000)
            {
                Console.WriteLine("金額過低，不符合貸款條件");
                return false;
            }

            Console.WriteLine("✅ 資格通過");
            return true;
        }

        /**
         * 可變流程：不同貸款方案的計算邏輯 (抽象方法)
         * 由子類別實作特定的貸款計算邏輯
         */
        protected abstract ProductLoan CalculateProductLoan(decimal amount, char creditRating);

        /**
         * 固定流程：產生報表
         * 可被子類別覆寫，但提供預設實作
         */
        protected virtual void GenerateReport(string applicantName, ProductLoan pLoan)
        {
            Console.WriteLine("📝 產生貸款報表");
            Console.WriteLine($"申請人：{applicantName}");
            Console.WriteLine($"貸款金額：{pLoan.Amount:C}");
            Console.WriteLine($"期數：{pLoan.Installments} 期");
            Console.WriteLine($"每期應繳：{pLoan.MonthlyPayment:C}");
            Console.WriteLine($"總利息：{pLoan.TotalInterest:C}");
        }
    }
}