using Thinksoft.Patterns.Creational.AbstractFactory.Product;

namespace Thinksoft.Patterns.Creational.AbstractFactory.Factory
{
    /**
     * The 'ConcreteFactory' Class.
     * 具體工廠：黑貓物流工廠 
     */
    public class BlackCatLogisticsFactory : ILogisticsProviderFactory
    {
        // 創建黑貓運送提供者
        public IShippingProvider CreateShippingProvider()
        {
            return new BlackCatShippingProvider();
        }

        // 創建黑貓物流追蹤提供者
        public ITrackingProvider CreateTrackingProvider()
        {
            return new BlackCatTrackingProvider();
        }
    }
}
