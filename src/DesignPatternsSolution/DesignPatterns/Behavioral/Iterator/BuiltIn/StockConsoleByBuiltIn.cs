using Thinksoft.Patterns.Behavioral.Iterator.Model;

namespace Thinksoft.Patterns.Behavioral.Iterator.BuiltIn
{
    /**
     * 庫存盤點Console展示界面
     * 使用 C# 內建 Iterator 的應用
     */
    public class StockInventoryBuiltInConsole
    {
        /**
         * 啟動庫存盤點程序
         * 建立商品集合並使用內建迭代器進行遍歷
         */
        public void Start()
        {
            StockCollection stock = new();

            Console.WriteLine("倉庫商品盤點系統（內建迭代器版本）：");
            Console.WriteLine("--------------------------------------");

            // 初始化商品資料
            InitializeProducts(stock);

            // 使用 C# 內建的 foreach 進行盤點
            Console.WriteLine("開始進行庫存盤點...");
            Console.WriteLine();

            int itemCount = 0;
            foreach (var product in stock)
            {
                itemCount++;
                Console.WriteLine($"{itemCount}. {product}");
            }

            Console.WriteLine();
            Console.WriteLine($"盤點完成！總共檢查了 {stock.Count} 項商品");
            Console.WriteLine($"檢視第一筆庫存項目：{stock[0]}");
        }

        /**
         * 初始化商品資料
         * 建立倉庫商品清單
         * @param stock 庫存商品集合
         */
        private void InitializeProducts(StockCollection stock)
        {
            stock.AddProduct("筆記型電腦", 15);
            stock.AddProduct("無線滑鼠", 50);
            stock.AddProduct("機械鍵盤", 25);
            stock.AddProduct("顯示器", 8);
            stock.AddProduct("網路攝影機", 30);
            stock.AddProduct("藍牙耳機", 40);
            stock.AddProduct("行動電源", 60);
        }
    }
}

