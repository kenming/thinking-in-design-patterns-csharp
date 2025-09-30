using Thinksoft.Patterns.Behavioral.State.Model;

namespace Thinksoft.Patterns.Behavioral.State.State
{
    /**
     * ConcreteState: 運送中狀態
     * 實現 State 介面，針對運送中狀態實作特定行為
     */
    public class InTransitState : ILogisticState
    {
        public void Handle(LogisticContext context)
        {
            // 運送中狀態的處理行為
            TransportPackage(context);
            context.NotifyCustomer("您的包裹正在運送中");

            // 處理完成後，轉換到下一個狀態
            context.AddMessage("包裹已到達配送中心，狀態轉移到「到達配送中心」");
            context.SetState(new AtDistributionCenterState());
        }

        // 運送包裹的具體實現
        private void TransportPackage(LogisticContext context)
        {
            context.AddMessage($"包裹 {context.PackageId} 正在運送中");
            context.AddMessage("包裹已裝載到運輸車輛...");
            context.AddMessage("運輸途中...");
            context.AddMessage("更新包裹位置資訊...");
        }

        public string GetStateName()
        {
            return "運送中";
        }

        public LogisticStateEnum GetStateEnum()
        {
            return LogisticStateEnum.InTransit;
        }
    }
}
