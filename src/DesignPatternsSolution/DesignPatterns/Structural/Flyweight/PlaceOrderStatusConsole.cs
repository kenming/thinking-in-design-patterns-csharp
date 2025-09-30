using Thinksoft.Patterns.Structural.Flyweight.Flyweight;
using Thinksoft.Patterns.Structural.Flyweight.Model;
using Thinksoft.Patterns.Utils;
using System.Text;

namespace Thinksoft.Patterns.Structural.Flyweight
{
    public class PlaceOrderStatusConsole : IConsoleProgram
    {
        // 模擬訂單的總數量
        private const int TotalOrderCount = 10000;
        // 實際顯示的訂單數量
        private const int DisplayOrderCount = 3;

        public void Start()
        {
            Console.WriteLine("🎯 Flyweight Pattern 效益對比測試");
            PrintSeparator();

            // 1. 生成大量訂單資料
            Console.WriteLine($"\n📊 正在生成 {TotalOrderCount} 筆訂單資料...");
            var orderContexts = GenerateLargeOrderContexts(TotalOrderCount);
            Console.WriteLine($"✅ 已完成 {TotalOrderCount} 筆訂單資料生成\n");

            // 2. 使用 Flyweight 模式建立訂單狀態
            Console.WriteLine("🔄 使用 Flyweight 模式建立訂單狀態...");

            var orders = new List<Flyweight.OrderStatusComposite>();
            var random = new Random();
            var statusValues = Enum.GetValues(typeof(OrderStatusEnum));

            for (int i = 0; i < orderContexts.Count; i++)
            {
                var statusType = (OrderStatusEnum)statusValues.GetValue(random.Next(statusValues.Length));
                var flyweightStatus = OrderStatusFactory.GetOrderStatus(statusType);
                var order = new Flyweight.OrderStatusComposite(orderContexts[i], flyweightStatus);
                orders.Add(order);
            }

            // 3. 顯示 Flyweight Pool 狀態
            int flyweightCount = OrderStatusFactory.GetFlyweightCount();
            Console.WriteLine($"🏆 Flyweight 物件池中共有 {flyweightCount} 個共享物件");
            Console.WriteLine($"📋 訂單總數: {TotalOrderCount} 筆\n");

            // 4. 顯示前幾筆訂單資訊
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"📝 訂單狀態展示 (前 {DisplayOrderCount} 筆)");
            PrintSeparator();

            for (int i = 0; i < Math.Min(DisplayOrderCount, orders.Count); i++)
            {
                DisplayOrderStatus(orders[i]);
                Console.WriteLine();
            }

            // 5. 效益分析
            PrintSeparator();
            Console.WriteLine("📈 Flyweight 模式效益分析");
            PrintSeparator();

            // 記憶體使用分析
            AnalyzeFlyweightBenefits(TotalOrderCount, flyweightCount);

            Console.WriteLine("\n按任意鍵結束程式...");
            Console.ReadKey();
        }

        /**
         * 生成大量訂單資料
         */
        private List<OrderStatusContext> GenerateLargeOrderContexts(int count)
        {
            var contexts = new List<OrderStatusContext>(count);
            var random = new Random();
            var names = new[] { "謝小娟", "李小華", "孫大同", "陳美麗", "林志明" };

            for (int i = 0; i < count; i++)
            {
                var orderId = $"ORD{(i + 1):D5}";
                var customerName = names[random.Next(names.Length)];
                var amount = random.Next(500, 5000);
                var orderDate = DateTime.Now.AddHours(-random.Next(1, 48));
                contexts.Add(new OrderStatusContext(orderId, customerName, amount, orderDate));
            }

            return contexts;
        }

        /**
         * 顯示訂單狀態資訊
         */
        private static void DisplayOrderStatus(Flyweight.OrderStatusComposite order)
        {
            var context = order.Context;
            var status = order.Status as OrderStatusFlyweight;

            Console.WriteLine($"📋 訂單編號：{context.OrderId}");
            Console.WriteLine($"👤 客戶姓名：{context.CustomerName}");
            Console.WriteLine($"💰 訂單金額：${context.Amount:N0}");
            Console.WriteLine($"📅 建立時間：{context.OrderDate:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"📦 目前狀態：{status.Emoji} {status.StatusName}");

            // 呼叫 Flyweight 的 Display 方法來顯示狀態
            status.Display(context);
        }
        
        // 列印分隔線
        private static void PrintSeparator()
        {
            Console.WriteLine(new string('=', 60));
        }
        
        // 分析 Flyweight 模式的記憶體效益
        private static void AnalyzeFlyweightBenefits(int orderCount, int flyweightCount)
        {
            // 假設每個狀態物件佔用 200 bytes，外在狀態佔用 50 bytes
            const int statusObjectSize = 200;
            const int contextObjectSize = 50;

            // 計算記憶體使用 (轉換為 MB)
            double withoutFlyweightMB = (orderCount * statusObjectSize) / (1024.0 * 1024.0);
            double withFlyweightMB = (flyweightCount * statusObjectSize + orderCount * contextObjectSize) / (1024.0 * 1024.0);
            double memorySavedMB = withoutFlyweightMB - withFlyweightMB;
            double savingPercentage = (memorySavedMB / withoutFlyweightMB) * 100;

            Console.WriteLine($"🔢 物件數量比較:");
            Console.WriteLine($"- 不使用 Flyweight: {orderCount:N0} 個狀態物件");
            Console.WriteLine($"- 使用 Flyweight: {flyweightCount} 個共享狀態物件");
            Console.WriteLine($"- 物件減少數量: {orderCount - flyweightCount:N0} 個");
            Console.WriteLine($"- 物件減少比例: {((double)(orderCount - flyweightCount) / orderCount * 100):F2}%");

            Console.WriteLine($"\n💾 記憶體使用分析:");
            Console.WriteLine($"- 不使用 Flyweight: {withoutFlyweightMB:F2} MB");
            Console.WriteLine($"- 使用 Flyweight: {withFlyweightMB:F2} MB");
            Console.WriteLine($"- 節省空間: {memorySavedMB:F2} MB");
            Console.WriteLine($"- 節省比例: {savingPercentage:F2}%");            
        }
    }
}