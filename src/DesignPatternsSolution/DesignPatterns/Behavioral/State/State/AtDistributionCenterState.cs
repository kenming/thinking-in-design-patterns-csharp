using Thinksoft.Patterns.Behavioral.State.Model;

namespace Thinksoft.Patterns.Behavioral.State.State
{
    /**
     * ConcreteState: 到達配送中心狀態
     * 實現 State 介面，針對到達配送中心狀態實作特定行為
     */
    public class AtDistributionCenterState : ILogisticState
    {
        public void Handle(LogisticContext context)
        {
            // 到達配送中心狀態的處理行為
            ProcessAtCenter(context);
            context.NotifyCustomer("您的包裹已到達配送中心，即將派送");

            // 處理完成後，轉換到下一個狀態
            context.AddMessage("包裹已安排派送，狀態轉移到「已送達」");
            context.SetState(new DeliveredState());
        }

        // 在配送中心處理包裹的具體實現
        private void ProcessAtCenter(LogisticContext context)
        {
            context.AddMessage($"包裹 {context.PackageId} 在配送中心處理中");
            context.AddMessage("進行包裹分揀...");
            context.AddMessage($"確認收件地址：{context.Customer.DeliveryAddress}");
            context.AddMessage("安排最後區域路線配送...");
        }

        public string GetStateName()
        {
            return "到達配送中心";
        }

        public LogisticStateEnum GetStateEnum()
        {
            return LogisticStateEnum.AtDistributionCenter;
        }
    }
}
