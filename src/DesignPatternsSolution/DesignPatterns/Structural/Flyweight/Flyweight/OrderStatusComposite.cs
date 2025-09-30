using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinksoft.Patterns.Structural.Flyweight.Model;

namespace Thinksoft.Patterns.Structural.Flyweight.Flyweight
{
    /**
     * The 'UnsharedConcreteFlyweight' Class  
     * 'OrderStatus' 類別
     * 每一筆訂單都有各自的狀態資訊，並不需要所有訂單都共享同一內在狀態。
     * 包含外在狀態和對 Flyweight 狀態物件的參考。
     * 
     * 註：此類別未實作 IOrderStatus 介面，與 GoF 標準略有不同。
     * 採以 Wrapper 包裹組合物件設計，將內在狀態與外在狀態組合，職責更清晰。
     */
    public class OrderStatusComposite
    {
        private OrderStatusContext _context;   // 外在狀態
        private IOrderStatus _status;          // Flyweight 狀態物件參考

        public OrderStatusComposite(OrderStatusContext context, IOrderStatus status)
        {
            _context = context;
            _status = status;
        }
        
        // 顯示完整的訂單資訊         
        public void ShowOrderInfo()
        {
            _status.Display(_context);
        }

        // 更新訂單狀態
        public void UpdateStatus(IOrderStatus newStatus)
        {
            _status = newStatus;
        }

        public OrderStatusContext Context => _context;
        public IOrderStatus Status => _status;
    }
}
