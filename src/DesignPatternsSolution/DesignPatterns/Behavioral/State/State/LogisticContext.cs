using Thinksoft.Patterns.Behavioral.State.Model;

namespace Thinksoft.Patterns.Behavioral.State.State
{
    /**
     * The 'Context' Class.
     * 物流Context，處理物流配送的狀態轉換邏輯
     */
    public class LogisticContext
    {
        // 當前狀態
        private ILogisticState _currentState;

        // 包裹資訊
        public string PackageId { get; private set; }

        // 客戶資訊
        public CustomerInfo Customer { get; private set; }

        // 處理訊息的集合
        public List<string> ProcessMessages 
                { get; private set; } = new List<string>();

        // 建構函式
        public LogisticContext(string packageId, CustomerInfo customer)
        {
            PackageId = packageId;
            Customer = customer;

            // 初始狀態設為待出貨
            _currentState = new PendingShipmentState();
        }

        // 設定當前狀態
        public void SetState(ILogisticState state)
        {
            _currentState = state;
            AddMessage($"狀態變更為: {_currentState.GetStateName()} ({_currentState.GetStateEnum()})");
        }

        // 外界呼叫的請求，會觸發狀態的處理行為
        public List<string> Request()
        {
            // 清空上一次處理的訊息
            ProcessMessages.Clear();

            AddMessage($"處理包裹 {PackageId} 的請求:");

            // 處理當前狀態
            _currentState.Handle(this);

            // 返回處理訊息集合的複本
            return new List<string>(ProcessMessages);
        }

        // 添加處理訊息
        public void AddMessage(string message)
        {
            ProcessMessages.Add(message);
        }

        // 通知客戶
        public void NotifyCustomer(string message)
        {
            AddMessage($"通知客戶 {Customer}: {message}");
        }

        // 獲取當前狀態名稱
        public string GetCurrentStateName()
        {
            return _currentState.GetStateName();
        }

        // 獲取當前狀態列舉值
        public LogisticStateEnum GetCurrentStateEnum()
        {
            return _currentState.GetStateEnum();
        }

        // 根據狀態列舉創建對應的狀態實例物件
        public static ILogisticState CreateStateInstance(LogisticStateEnum stateEnum)
        {
            switch (stateEnum)
            {
                case LogisticStateEnum.PendingShipment:
                    return new PendingShipmentState();
                case LogisticStateEnum.InTransit:
                    return new InTransitState();
                case LogisticStateEnum.AtDistributionCenter:
                    return new AtDistributionCenterState();
                case LogisticStateEnum.Delivered:
                    return new DeliveredState();
                default:
                    throw new System.ArgumentException($"未知的物流狀態枚舉值: {stateEnum}");
            }
        }
    }
}
