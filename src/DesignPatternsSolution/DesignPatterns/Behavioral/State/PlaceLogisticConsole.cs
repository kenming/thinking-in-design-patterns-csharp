using Thinksoft.Patterns.Behavioral.State.Model;
using Thinksoft.Patterns.Behavioral.State.State;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.State
{
    /**
     * 物流狀態模式的控制台演示程式
     */
    public class PlaceLogisticConsole : IConsoleProgram
    {
        public void Start()
        {
            System.Console.WriteLine("==== 物流狀態模式演示 ====\n");

            // 創建客戶資訊
            CustomerInfo customer = new CustomerInfo(
                "謝小娟",
                "電話: 0912-345-678",
                "新北市土城區承天路二段18號"
            );

            // 創建物流上下文
            LogisticContext logistic = new LogisticContext("PKG-20250518-001", customer);

            // 顯示初始狀態
            System.Console.WriteLine($"包裹編號: {logistic.PackageId}");
            System.Console.WriteLine($"客戶資訊: {logistic.Customer}");
            System.Console.WriteLine($"送貨地址: {logistic.Customer.DeliveryAddress}");
            System.Console.WriteLine($"初始狀態: {logistic.GetCurrentStateName()}\n");

            // 模擬物流狀態的變化
            SimulateLogisticProcess(logistic);

            // 展示手動設置特定狀態
            System.Console.WriteLine("\n==== 手動設置狀態演示 ====\n");

            // 重新創建物流上下文
            logistic = new LogisticContext("PKG-20250519-002", customer);

            // 手動設置為「到達配送中心」狀態
            ILogisticState distributionCenterState = LogisticContext.CreateStateInstance(LogisticStateEnum.AtDistributionCenter);
            logistic.SetState(distributionCenterState);

            System.Console.WriteLine($"已手動設置狀態為: {logistic.GetCurrentStateName()}");

            // 處理當前狀態
            List<string> messages = logistic.Request();

            // 顯示處理訊息
            System.Console.WriteLine("\n處理結果:");
            foreach (string message in messages)
            {
                System.Console.WriteLine($"  - {message}");
            }

            System.Console.WriteLine("\n按任意鍵結束...");
            System.Console.ReadKey();
        }

        /**
         * 模擬物流配送過程中的狀態變化
         */
        private static void SimulateLogisticProcess(LogisticContext logistic)
        {
            // 模擬完整的物流過程
            System.Console.WriteLine("開始模擬物流過程...\n");

            // 處理所有狀態直到最終狀態
            bool isCompleted = false;
            int step = 1;

            while (!isCompleted)
            {
                System.Console.WriteLine($"步驟 {step}: 處理 '{logistic.GetCurrentStateName()}' 狀態");

                // 處理當前狀態
                List<string> messages = logistic.Request();

                // 顯示處理訊息
                foreach (string message in messages)
                {
                    System.Console.WriteLine($"  - {message}");
                }

                System.Console.WriteLine();

                // 檢查是否為最終狀態
                if (logistic.GetCurrentStateEnum() == LogisticStateEnum.Delivered)
                {
                    isCompleted = true;
                    System.Console.WriteLine("物流過程已完成!");
                }

                step++;
            }
        }
    }
}
