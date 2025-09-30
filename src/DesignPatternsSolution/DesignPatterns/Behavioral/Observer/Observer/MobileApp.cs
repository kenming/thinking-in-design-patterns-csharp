namespace Thinksoft.Patterns.Behavioral.Observer.Observer
{
    /**
     * The 'ConcreteObserver' class.
     * 具體觀察者 - 手機App顧客
     * 實作 ICustomerObserver 介面
     * 透過手機App接收商店通知
     */
    public class MobileApp : ICustomerObserver
    {
        private string Name;
        private string PhoneNo;


        public MobileApp(string name, string phoneNo)
        {
            this.Name = name;
            PhoneNo = phoneNo;
        }

        /**
         * 接收商店通知並透過手機App顯示
         * @param storeName 商店名稱
         * @param notification 通知訊息
         */
        public void Update(string storeName, string notification)
        {
            Console.WriteLine($"📱 [手機App通知] {Name} " +
                $"收到來自 {storeName}");
            Console.WriteLine($"   {notification}");
        }
    }
}
