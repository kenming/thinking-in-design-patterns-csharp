using Thinksoft.Patterns.Behavioral.Visitor.Element;

namespace Thinksoft.Patterns.Behavioral.Visitor.Visitor
{
    /**
     * The 'ConcreteVisitor' class.
     * 到期檢查訪問者，專門檢查易碎品等有保存期限的物品是否過期
     * 提供過期警示和即將到期的預警提示
     */
    public class ExpiryCheckVisitor : IInventoryVisitor
    {
        public List<string> ExpiredItems { get; private set; } 
            = new();    // 已過期商品清單
        public List<string> NearExpiryItems { get; private set; } 
            = new();    // 即將到期商品清單 (7天內到期)

        /**
         * 訪問一般商品，由於一般商品無到期日，僅記錄檢查狀態
         * @param item 要訪問的一般商品物件
         */
        public void Visit(GeneralItem item)
        {
            // 一般商品無到期日，不需檢查
            Console.WriteLine($"一般商品 {item.Name} 無需檢查到期日");
        }

        /**
         * 訪問易碎品，檢查到期狀況並分類處理
         * @param item 要訪問的易碎品物件
         */
        public void Visit(FragileItem item)
        {
            DateTime today = DateTime.Today;
            DateTime warningDate = today.AddDays(7); // 7天內到期的商品需要警告

            if (item.ExpiryDate < today)
            {
                ExpiredItems.Add(item.Name);
                Console.WriteLine($"⚠️ 易碎品 {item.Name} 已過期! 到期日:" +
                    $" {item.ExpiryDate:yyyy-MM-dd}");
            }
            else if (item.ExpiryDate <= warningDate)
            {
                NearExpiryItems.Add(item.Name);
                Console.WriteLine($"🔔 易碎品 {item.Name} 即將到期! 到期日: " +
                    $"{item.ExpiryDate:yyyy-MM-dd}");
            }
            else
            {
                Console.WriteLine($"✅ 易碎品 {item.Name} 狀態正常，到期日: " +
                    $"{item.ExpiryDate:yyyy-MM-dd}");
            }
        }

        /**
         * 顯示到期檢查的摘要報告
         * 包含過期商品和即將到期商品的統計資訊
         */

        public void DisplaySummary()
        {
            Console.WriteLine("\n=== 到期檢查摘要 ===");
            Console.WriteLine($"已過期商品數量: {ExpiredItems.Count}");
            Console.WriteLine($"即將到期商品數量: {NearExpiryItems.Count}");

            if (ExpiredItems.Count > 0)
            {
                Console.WriteLine("已過期商品:");
                foreach (var item in ExpiredItems)
                {
                    Console.WriteLine($"  - {item}");
                }
            }

            if (NearExpiryItems.Count > 0)
            {
                Console.WriteLine("即將到期商品:");
                foreach (var item in NearExpiryItems)
                {
                    Console.WriteLine($"  - {item}");
                }
            }
        }
    }
}
