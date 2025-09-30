using Thinksoft.Patterns.Behavioral.Observer.Observer;
using Thinksoft.Patterns.Behavioral.Observer.Publisher;

namespace Thinksoft.Patterns.Behavioral.Observer
{
    /**
     * 電子商務通知服務
     * 管理商店和顧客之間的訂閱關係
     * 展示 Observer 模式的實際應用
     */
    public class PlaceNotificationService
    {
        // declare a Subject (Publisher)
        private readonly IStoreSubject storeSubject;

        // Constructor - 初始化服務並建立線上商店發佈者
        public PlaceNotificationService(string storeName)
        {
            storeSubject = new OnlineStore(storeName);
        }

        // 加入訂閱者 (Observer)
        public void Subscribe(ICustomerObserver observer)
        {
            storeSubject.Subscribe(observer);
        }

        // 移除訂閱者 (Observer)
        public void UnSubscribe(ICustomerObserver observer)
        {
            storeSubject.UnSubscribe(observer);
        }

        // 新商品到貨通知
        public void NewProductArrival(string productName)
        {
            string notification = $"新商品上架：{productName}";
            storeSubject.NotifyObservers(notification);
        }

        // 商品降價通知
        public void PriceReduction(string productName, decimal oldPrice, decimal newPrice)
        {
            string notification = $"商品降價：{productName} " +
                $"原價 ${oldPrice} 現在只要 ${newPrice}";
            storeSubject.NotifyObservers(notification);
        }
    }
}
