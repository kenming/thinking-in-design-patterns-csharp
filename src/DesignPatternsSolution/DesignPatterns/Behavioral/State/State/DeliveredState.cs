using Thinksoft.Patterns.Behavioral.State.Model;

namespace Thinksoft.Patterns.Behavioral.State.State
{
    /**
     * ConcreteState: 已送達狀態
     * 實現 State 介面，針對已送達狀態實作特定行為
     */
    public class DeliveredState : ILogisticState
    {
        public void Handle(LogisticContext context)
        {
            // 已送達狀態的處理行為
            DeliverPackage(context);
            CompleteDelivery(context);
            context.NotifyCustomer("您的包裹已成功送達，感謝您的使用");

            // 已送達是最終狀態，不再轉換
            context.AddMessage("包裹配送完成，這是最終狀態");
        }

        // 配送包裹的具體實現
        private void DeliverPackage(LogisticContext context)
        {
            context.AddMessage($"包裹 {context.PackageId} 進行最後一哩路配送");
            context.AddMessage("配送員正在前往送貨地址...");
            context.AddMessage($"到達目的地：{context.Customer.DeliveryAddress}");
        }

        // 完成配送的具體實現
        private void CompleteDelivery(LogisticContext context)
        {
            context.AddMessage($"包裹 {context.PackageId} 已完成配送");
            context.AddMessage("客戶簽收包裹...");
            context.AddMessage("更新配送狀態為已完成...");
            context.AddMessage("生成配送報告...");
        }

        public string GetStateName()
        {
            return "已送達";
        }

        public LogisticStateEnum GetStateEnum()
        {
            return LogisticStateEnum.Delivered;
        }
    }
}
