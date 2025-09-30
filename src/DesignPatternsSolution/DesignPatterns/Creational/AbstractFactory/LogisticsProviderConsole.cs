using System.Text;
using Thinksoft.Patterns.Creational.AbstractFactory.Factory;
using Thinksoft.Patterns.Creational.AbstractFactory.Product;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Creational.AbstractFactory
{
    /**
     * 物流供應商抽象工廠模式示範 Console
     * 展示如何使用抽象工廠模式整合不同物流供應商的服務
     */
    public class LogisticsProviderConsole : IConsoleProgram
    {
        public void Start()
        {
            // 建立物流供應商工廠實例
            // 每個工廠負責創建特定物流供應商的所有相關服務
            ILogisticsProviderFactory blackCatFactory = new BlackCatLogisticsFactory();
            ILogisticsProviderFactory sfExpressFactory = new SfExpressLogisticsFactory();

            // 從工廠取得運送提供者和物流追蹤提供者
            // Note：Client端只與抽象介面互動，不依賴具體類別
            IShippingProvider blackCatShipping = blackCatFactory.CreateShippingProvider();
            ITrackingProvider blackCatTracking = blackCatFactory.CreateTrackingProvider();
            IShippingProvider sfShipping = sfExpressFactory.CreateShippingProvider();
            ITrackingProvider sfTracking = sfExpressFactory.CreateTrackingProvider();

            Console.WriteLine("-- 黑貓物流服務操作 ------");
            blackCatShipping.Ship("ORDER12345");
            blackCatTracking.Track("BC00098765");

            Console.WriteLine("\n" + new string('-', 48) + "\n");

            Console.WriteLine("-- 順豐物流服務操作 ------");
            sfShipping.Ship("ORDER67890");
            sfTracking.Track("SF00123456");
        }
    }
}
