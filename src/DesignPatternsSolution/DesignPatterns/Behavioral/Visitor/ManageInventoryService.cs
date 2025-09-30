using Thinksoft.Patterns.Behavioral.Visitor.Element;
using Thinksoft.Patterns.Behavioral.Visitor.Visitor;
using Thinksoft.Patterns.Structural.Facade.Model;

namespace Thinksoft.Patterns.Behavioral.Visitor
{
    /**
     * The 'Service' Class.
     * 庫存盤點管理服務類別，負責協調不同類型的訪問者執行庫存相關操作
     * 操作兩類 Visitor：計算庫存數量以及檢查商品到期狀況
     */
    public class ManageInventoryService
    {
        private InventoryCountVisitor _inventoryCountVisitor;   // 計算庫存數量的 Visitor
        private ExpiryCheckVisitor _expiryCheckVisitor;         // 檢查商品到期的 Visitor

        // Constructor
        public ManageInventoryService()
        {
            _inventoryCountVisitor = new InventoryCountVisitor();
            _expiryCheckVisitor = new ExpiryCheckVisitor();
        }

        /**
         * 執行庫存盤點
         * 使用 InventoryCountVisitor 統計所有庫存項目的數量和價值
         * @param items 要盤點的庫存項目清單
         */
        public void ExecuteInventoryCount(List<IInventoryItem> items)
        {
            Console.WriteLine("=== 開始執行庫存盤點 ===");
            foreach (var item in items)
            {
                item.Accept(_inventoryCountVisitor);
            }
            _inventoryCountVisitor.DisplaySummary();
        }

        /**
         * 執行到期檢查
         * 使用 ExpiryCheckVisitor 檢查所有庫存項目的到期狀況
         * @param items 要檢查的庫存項目清單
         */
        public void ExecuteExpiryCheck(List<IInventoryItem> items)
        {
            Console.WriteLine("\n=== 開始執行到期檢查 ===");
            foreach (var item in items)
            {
                item.Accept(_expiryCheckVisitor);
            }
            _expiryCheckVisitor.DisplaySummary();
        }
    }
}
