using Thinksoft.Patterns.Behavioral.CoR.Model;

namespace Thinksoft.Patterns.Behavioral.CoR.Handler
{
    /**
     * The 'Concrete Handler' class.
     * AI機器人處理者
     */
    public class AIBot : AbstractHandler
    {
        // 實現處理請求方法
        public override void HandleRequest(CustomerRequest request)
        {
            // AI機器人只能處理簡單問題（嚴重等級1-3）
            if (request.SeverityLevel <= 3 && request.RequestType != "投訴")
            {
                Console.WriteLine($"[AI機器人] 已處理您的{request.RequestType}" +
                    $"問題：{request.Description}");
            }
            else if (successorHandler != null)
            {
                // 傳給下一個處理者
                successorHandler.HandleRequest(request);
            }
            else
            {
                // 沒有下一個處理者時拋出例外
                throw new Exception("本次客服申訴均無法處理，需要另行立案特別處理");
            }
        }
    }
}
