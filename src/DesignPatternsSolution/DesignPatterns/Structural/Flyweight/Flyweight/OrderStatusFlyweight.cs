using Thinksoft.Patterns.Structural.Flyweight.Model;

namespace Thinksoft.Patterns.Structural.Flyweight.Flyweight
{
    /**
     * The 'ConcreteFlyweight' Class
     * 實作 IOrderStatus 介面的具體狀態類別
     * 此類別所定義的屬性為內在 (Intrinsic) 狀態，且該物件
     * 必須是可被共用的，並且與具體的訂單環境無關
     * (不依賴特定的訂單編號、客戶資訊、訂單金額)。
     */
    public class OrderStatusFlyweight : IOrderStatus
    {
        /**
         * The 'Intrinsic State (內在狀態)'
         * 表達訂單狀態的圖示和名稱
         */
        public string Emoji { get; private set; }        // 狀態圖示
        public string StatusName { get; private set; }   // 狀態名稱

        /**
         * 建構子 - 設定內在狀態
         * 這些屬性在物件建立後不會改變，可安全地被多個外在狀態共享
         */
        public OrderStatusFlyweight(string emoji, string statusName)
        {
            this.Emoji = emoji;
            this.StatusName = statusName;
        }

        /**
         *  在 "Run-time (執行期間)" 由 Client 負責設定關於
         *  訂單的外部狀態資訊並傳入至該狀態物件用以操作/顯示
         */
        public void Display(OrderStatusContext context)
        {
            Console.WriteLine($"{Emoji} 訂單 #{context.OrderId} " +
                $"| {context.CustomerName} | ${context.Amount:N0} | {StatusName}");
        }
    }
}
