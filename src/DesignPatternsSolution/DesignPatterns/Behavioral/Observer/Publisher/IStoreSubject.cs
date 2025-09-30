using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinksoft.Patterns.Behavioral.Observer.Observer;

namespace Thinksoft.Patterns.Behavioral.Observer.Publisher
{
    /**
     * The 'Subject' interface, syn. Publisher
     * 定義被觀察者 (商店) 必須實作的方法
     * 包含訂閱、取消訂閱和通知功能
     */
    public interface IStoreSubject
    {
        /**
         * 訂閱商店通知
         * @param observer 顧客觀察者
         */
        void Subscribe(ICustomerObserver observer);

        /**
         * 取消訂閱商店通知
         * @param observer 顧客觀察者
         */
        void UnSubscribe(ICustomerObserver observer);

        /**
         * 通知所有訂閱的顧客
         * @param notification 通知訊息
         */
        void NotifyObservers(string notification);
    }
}
