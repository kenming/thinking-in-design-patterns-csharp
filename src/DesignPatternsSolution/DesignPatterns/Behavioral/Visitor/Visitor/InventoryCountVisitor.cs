using Thinksoft.Patterns.Behavioral.Visitor.Element;

namespace Thinksoft.Patterns.Behavioral.Visitor.Visitor
{
    /**
     * The 'ConcreteVisitor' class.
     * 庫存盤點訪問者，負責計算所有物品的總數量與種類統計
     * 提供詳細的庫存統計資訊和摘要報告
     */
    public class InventoryCountVisitor : IInventoryVisitor
    {
        public int TotalItems { get; private set; } = 0;        // 所有物品的總數量
        public int GeneralItemCount { get; private set; } = 0;  // 一般物品的總數量
        public int FragileItemCount { get; private set; } = 0;  // 易碎物品的總數量

        /**
         * 訪問一般商品，進行數量統計和價值計算
         * @param item 要訪問的一般商品物件
         */
        public void Visit(GeneralItem item)
        {
            TotalItems += item.Quantity;
            GeneralItemCount += item.Quantity;
            Console.WriteLine($"盤點一般商品: {item.Name}, 數量: {item.Quantity}");
        }

        /**
         * 訪問易碎品，進行數量統計和價值計算
         * @param item 要訪問的易碎品物件
         */

        public void Visit(FragileItem item)
        {
            TotalItems += item.Quantity;
            FragileItemCount += item.Quantity;
            Console.WriteLine($"盤點易碎品: {item.Name}, 數量: {item.Quantity}, " +
                $"到期日: {item.ExpiryDate:yyyy-MM-dd}");
        }

        // 顯示庫存盤點的摘要報告
        public void DisplaySummary()
        {
            Console.WriteLine("\n=== 庫存盤點摘要 ===");
            Console.WriteLine($"總物品數量: {TotalItems}");
            Console.WriteLine($"一般商品: {GeneralItemCount}");
            Console.WriteLine($"易碎品: {FragileItemCount}");
        }
    }
}
