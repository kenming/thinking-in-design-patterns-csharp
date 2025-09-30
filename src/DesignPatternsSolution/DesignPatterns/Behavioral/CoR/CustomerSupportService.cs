using Thinksoft.Patterns.Behavioral.CoR.Handler;
using Thinksoft.Patterns.Behavioral.CoR.Model;

namespace Thinksoft.Patterns.Behavioral.CoR
{
    /**
     * 'Service' - 客戶服務類別
     * 負責建立和管理處理者 (Handler) 串鏈
     */
    public class CustomerSupportService
    {
        // 宣告 Handler 
        private AbstractHandler handler;
        
         // Constructor - 設置處理串鏈         
        public CustomerSupportService()
        {
            // 建立處理者鏈結
            var aiBot = new AIBot();
            var frontlineAgent = new FrontlineAgent();
            var supervisor = new Supervisor();

            // 設定鏈結順序：AI機器人 -> 一線客服 -> 客服主管
            aiBot.SetSuccessorHandler(frontlineAgent);
            frontlineAgent.SetSuccessorHandler(supervisor);
            handler = aiBot;
        }

        /**
         * 處理客戶服務請求
         */
        public void ProcessRequest(CustomerRequest request)
        {
            try
            {
                Console.WriteLine($"\n處理客戶請求：{request.RequestType} " +
                    $"(嚴重等級：{request.SeverityLevel})");
                handler.HandleRequest(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[無法處理] - {ex.Message}");
            }
        }
    }
}
