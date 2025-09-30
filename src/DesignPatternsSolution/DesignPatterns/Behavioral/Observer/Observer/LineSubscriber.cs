using Thinksoft.Patterns.Structural.Bridge.Model;

namespace Thinksoft.Patterns.Behavioral.Observer.Observer
{
    /**
     * The 'ConcreteObserver' class.
     * 具體觀察者 - Line訂閱者
     * 實作 ICustomerObserver 介面
     * 透過 Line 接收商店通知
     */
    public class LineSubscriber : ICustomerObserver
    {
        private string Name;
        private string LineID;

        public LineSubscriber(string name, string lineId)
        {
            this.Name = name;
            this.LineID = lineId;
        }

        /**
         * 接收商店通知並透過 Line 發送
         * @param storeName 商店名稱
         * @param notification 通知訊息
         */
        public void Update(string storeName, string notification)
        {
            Console.WriteLine($"💬 [Line通知] 發送至 {LineID} (" +
                $"{Name})：來自 {storeName}");
            Console.WriteLine($"   {notification}");
        }
    }
}
