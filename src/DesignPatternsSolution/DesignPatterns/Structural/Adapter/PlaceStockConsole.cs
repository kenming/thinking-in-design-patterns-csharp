using Thinksoft.Patterns.Structural.Adapter.Model;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Structural.Adapter
{
    /**
     * 'Client' - Adapter模式 Demo by Console
     * 展示多個購物平台的庫存查詢與統計
     */
    public class PlaceStockConsole : IConsoleProgram
    {
        public void Start()
        {
            Console.WriteLine("=== 電商代營運多平台庫存查詢與統計展示 ===\n");

            // 直接創建服務實例，內部已完成所有設置
            var stockService = new PlaceStockService();

            // 使用統一介面查詢不同平台庫存
            var productIds = new List<string> { "P001", "P002", "P003", "P004" };

            Console.WriteLine("\n===== 示範：查詢蝦購平台庫存 =====");
            var sopStock = stockService.GetPlatformStockAsync("蝦購", productIds).GetAwaiter().GetResult();
            DisplayStock(sopStock);

            Console.WriteLine("\n===== 示範：查詢 MO購 平台庫存 =====");
            var moStock = stockService.GetPlatformStockAsync("MO購", productIds).GetAwaiter().GetResult();
            DisplayStock(moStock);

            Console.WriteLine("\n===== 示範：查詢所有平台庫存並統計 =====");
            var allStock = stockService.GetAllPlatformsStockAsync(productIds).GetAwaiter().GetResult();
            DisplayStock(allStock);

            Console.WriteLine("\n===== 庫存總量統計 =====");
            var totalStock = stockService.CalculateTotalStockByProduct(allStock);
            foreach (var item in totalStock)
            {
                Console.WriteLine($"商品 {item.Key}: 總庫存 {item.Value} 件");
            }            
        }

        private static void DisplayStock(List<StockInfo> stockInfoList)
        {
            PrintDivider();
            foreach (var stock in stockInfoList)
            {
                Console.WriteLine($"平台: {stock.Platform} | 商品ID: {stock.ProductId} | 名稱: {stock.Name} | 庫存: {stock.Quantity}");
            }
            PrintDivider();
        }

        private static void PrintDivider()
        {
            Console.WriteLine(new string('-', 60));
        }
    }    
}
