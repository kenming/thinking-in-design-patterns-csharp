using Thinksoft.Patterns.Behavioral.CoR.Model;

namespace Thinksoft.Patterns.Behavioral.CoR.Handler
{
    /**
     * The 'Handler' abstract class.
     * 處理者抽象類別
     */
    public abstract class AbstractHandler
    {
        // 下一個處理者
        protected AbstractHandler successorHandler;

        // 設定下一個後繼的處理者
        public void SetSuccessorHandler(AbstractHandler successor)
        {
            successorHandler = successor;
        }

        // 處理請求的抽象方法，由子類別實現
        public abstract void HandleRequest(CustomerRequest request);
    }
}
