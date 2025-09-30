using System.Collections;
using Thinksoft.Patterns.Structural.Flyweight.Flyweight;
using Thinksoft.Patterns.Structural.Flyweight.Model;

namespace Thinksoft.Patterns.Structural.Flyweight
{
    /**
     * The 'FlyweightFactory' Class
     * 負責建立與管理關於訂單狀態的各元素實例
     * 確保各類型的狀態物件被確實共用。這些元素即為 Flyweight 物件
     */
    public class OrderStatusFactory
    {
        private static readonly Hashtable _statusPool = new Hashtable();
        private static int _objectCount = 0; // 追蹤建立的物件數量

        /**
         * 取得指定類型的訂單狀態 Flyweight 物件
         * 如果該類型的物件已存在於池中，直接返回；否則建立新物件並加入池中
         */
        public static IOrderStatus GetOrderStatus(OrderStatusEnum statusType)
        {
            IOrderStatus status = _statusPool[statusType] as IOrderStatus;

            if (status == null)
            {
                // 根據狀態類型建立對應的 Flyweight 物件
                switch (statusType)
                {
                    case OrderStatusEnum.Processing:
                        status = new OrderStatusFlyweight("📦", "處理中");
                        Console.WriteLine("🔧 建立新的 Flyweight: 📦 處理中狀態");
                        break;
                    case OrderStatusEnum.Shipping:
                        status = new OrderStatusFlyweight("🚚", "配送中");
                        Console.WriteLine("🔧 建立新的 Flyweight: 🚚 配送中狀態");
                        break;
                    case OrderStatusEnum.Completed:
                        status = new OrderStatusFlyweight("✅", "已完成");
                        Console.WriteLine("🔧 建立新的 Flyweight: ✅ 已完成狀態");
                        break;
                }

                _statusPool.Add(statusType, status);
                _objectCount++;
            }

            return status;
        }

        /**
         * 取得 Flyweight 池中的物件總數
         */
        public static int GetFlyweightCount()
        {
            return _objectCount;
        }

        /**
         * 顯示 Flyweight 池的狀態
         */
        public static void ShowPoolStatus()
        {
            Console.WriteLine($"\n=== Flyweight Pool 狀態 ===");
            Console.WriteLine($"共有 {_objectCount} 個 Flyweight 物件：");

            foreach (DictionaryEntry entry in _statusPool)
            {
                var status = entry.Value as OrderStatusFlyweight;
                Console.WriteLine($"  {status.Emoji} {status.StatusName}");
            }
            Console.WriteLine($"記憶體使用：約 {_objectCount * 100} bytes");
        }

        /**
         * 清空 Flyweight 池 (僅供測試使用)
         */
        public static void ClearPool()
        {
            _statusPool.Clear();
            _objectCount = 0;
            Console.WriteLine("🧹 Flyweight Pool 已清空");
        }
    }
}
