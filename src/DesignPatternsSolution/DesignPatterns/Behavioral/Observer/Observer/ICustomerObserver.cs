namespace Thinksoft.Patterns.Behavioral.Observer.Observer
{
    /**
     * The 'Observer' Interface.
     * 定義觀察者必須實作的更新方法
     * 在電子商務情境中代表顧客觀察者
     */
    public interface ICustomerObserver
    {
        /**
         * 接收商店通知的更新方法
         * @param storeName 商店名稱
         * @param notification 通知訊息
         */
        void Update(string storeName, string notification);
    }
}
