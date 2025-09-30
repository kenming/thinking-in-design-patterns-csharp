using Thinksoft.Patterns.Behavioral.Observer.Observer;

namespace Thinksoft.Patterns.Behavioral.Observer.Publisher
{
    /**
     * The 'ConcreteSubject' class.
     * 具體主題 - 電子商店
     * 實作 IStoreSubject 介面
     * 維護訂閱顧客清單並發送通知
     */
    public class OnlineStore : IStoreSubject
    {
        private string storeName;                     // 商店名稱
        private List<ICustomerObserver> subscribers;  // 儲存所有訂閱的顧客        

        public OnlineStore(string name)
        {
            this.storeName = name;
            this.subscribers = new List<ICustomerObserver>();
        }

        /**
         * 顧客訂閱商店通知
         * @param observer 顧客觀察者
         */
        public void Subscribe(ICustomerObserver observer)
        {
            subscribers.Add(observer);
            Console.WriteLine($"✅ 新顧客已訂閱 {storeName} 的通知");
        }

        /**
         * 顧客取消訂閱商店通知
         * @param observer 顧客觀察者
         */
        public void UnSubscribe(ICustomerObserver observer)
        {
            subscribers.Remove(observer);
            Console.WriteLine($"❌ 顧客已取消訂閱 {storeName} 的通知");
        }

        /**
         * 通知所有訂閱的顧客
         * @param notification 通知訊息
         */
        public void NotifyObservers(string notification)
        {
            Console.WriteLine($"\n🔔 {storeName} " +
                $"發送通知給 {subscribers.Count} 位訂閱顧客");
            foreach (ICustomerObserver customer in subscribers)
            {
                customer.Update(storeName, notification);
            }
        }
    }
}
