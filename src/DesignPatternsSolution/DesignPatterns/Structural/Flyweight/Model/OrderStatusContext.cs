using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinksoft.Patterns.Structural.Flyweight.Model
{
    /**
     * 'OrderStatusContext' 類別
     * 包含訂單狀態的外在狀態 (具體訂單資訊)
     * 這些資訊不會被 Flyweight 物件儲存，而是在操作時傳入
     */
    public class OrderStatusContext
    {
        public string OrderId { get; set; }      // 訂單編號
        public string CustomerName { get; set; } // 客戶姓名
        public decimal Amount { get; set; }      // 訂單金額
        public DateTime OrderDate { get; set; }  // 訂單日期

        public OrderStatusContext(string orderId, string customerName, 
                decimal amount, DateTime orderDate)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Amount = amount;
            OrderDate = orderDate;
        }
    }
}
