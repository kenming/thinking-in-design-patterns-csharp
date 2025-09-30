using Thinksoft.Patterns.Behavioral.State.Model;

namespace Thinksoft.Patterns.Behavioral.State.State
{
    /**
     * ConcreteState: 待出貨狀態
     * 實現 State 介面，針對待出貨狀態實作特定行為
     */
    public class PendingShipmentState : ILogisticState
    {
        public void Handle(LogisticContext context)
        {
            // 待出貨狀態的處理行為
            PrepareShipment(context);
            context.NotifyCustomer("您的包裹已準備出貨");

            // 處理完成後，轉換到下一個狀態
            context.AddMessage("包裹已出貨，狀態轉移到「運送中」");
            context.SetState(new InTransitState());
        }

        // 準備出貨的具體實現
        private void PrepareShipment(LogisticContext context)
        {
            context.AddMessage($"包裹 {context.PackageId} 準備出貨中");
            context.AddMessage("檢查包裹內容...");
            context.AddMessage("包裝商品...");
            context.AddMessage("準備運送單據...");
        }

        public string GetStateName()
        {
            return "待出貨";
        }

        public LogisticStateEnum GetStateEnum()
        {
            return LogisticStateEnum.PendingShipment;
        }
    }
}
