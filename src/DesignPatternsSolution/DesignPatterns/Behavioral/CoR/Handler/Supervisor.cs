using Thinksoft.Patterns.Behavioral.CoR.Model;

namespace Thinksoft.Patterns.Behavioral.CoR.Handler
{
    /**
     * The 'Concrete Handler' class.
     * 客服主管處理者
     */
    public class Supervisor : AbstractHandler
    {
        // 實現處理請求方法
        public override void HandleRequest(CustomerRequest request)
        {
            // 客服主管可以處理所有問題，包括投訴
            if (request.SeverityLevel <= 9)
            {
                Console.WriteLine($"[客服主管] 已處理您的{request.RequestType}" +
                    $"問題：{request.Description}");
            }
            else
            {
                // 超出處理範圍時 (嚴整等級大於9) 拋出例外
                throw new Exception("本次客服申訴均無法處理，需要另行立案特別處理");
            }
        }
    }
}
