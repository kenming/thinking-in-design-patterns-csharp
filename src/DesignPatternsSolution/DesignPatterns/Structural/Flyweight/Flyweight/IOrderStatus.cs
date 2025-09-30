using Thinksoft.Patterns.Structural.Flyweight.Model;

namespace Thinksoft.Patterns.Structural.Flyweight.Flyweight
{
    /**
     * The 'Flyweight' Interface
     * 定義訂單狀態操作介面
     * 此介面的實作類別將成為 Flyweight 物件
     */
    public interface IOrderStatus
    {
        /**
         * 顯示訂單狀態資訊
         * context: 外在狀態(訂單的具體資訊)
         */
        void Display(OrderStatusContext context);
    }
}
