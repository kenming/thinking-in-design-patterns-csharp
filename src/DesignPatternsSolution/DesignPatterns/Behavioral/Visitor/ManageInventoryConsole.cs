using System.Text;
using Thinksoft.Patterns.Behavioral.Visitor.Element;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.Visitor
{
    /**
     * 庫存盤點管理 Console 
     * 提供庫存盤點管理的 Visitor 模式展示
     */
    public class ManageInventoryConsole : IConsoleProgram
    {
        public void Start()
        {
            // 建立測試資料
            List<IInventoryItem> inventoryItems = CreateTestData();

            // 創建庫存管理服務實例
            ManageInventoryService service = new();

            // 執行庫存盤點作業
            service.ExecuteInventoryCount(inventoryItems);

            // 執行到期檢查作業
            service.ExecuteExpiryCheck(inventoryItems);

            Console.WriteLine("\n按任意鍵結束程式...");
            Console.ReadKey();
        }

        /**
         * 建立測試用的庫存資料
         * @return 庫存項目清單
         */
        private List<IInventoryItem> CreateTestData()
        {
            return new List<IInventoryItem>
            {
                // 一般商品
                new GeneralItem("筆記型電腦", 50, 25000),
                new GeneralItem("滑鼠", 200, 500),                
                new GeneralItem("鍵盤", 80, 800),
                new GeneralItem("螢幕", 25, 8000),
                
                // 易碎品 - 已過期
                new FragileItem("玻璃杯", 30, 150, DateTime.Today.AddDays(-2)),
                new FragileItem("陶瓷餐具", 20, 600, DateTime.Today.AddDays(-5)),
                
                // 易碎品 - 即將到期
                new FragileItem("陶瓷盤", 25, 300, DateTime.Today.AddDays(3)),
                new FragileItem("精緻茶具", 12, 1500, DateTime.Today.AddDays(6)),
                
                // 易碎品 - 正常狀態
                new FragileItem("水晶花瓶", 10, 800, DateTime.Today.AddDays(30)),
                new FragileItem("藝術擺飾", 8, 2200, DateTime.Today.AddDays(45)),
                new FragileItem("古董瓷器", 5, 3500, DateTime.Today.AddDays(60))
            };
        }
    }
}