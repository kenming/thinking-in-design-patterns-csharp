using Thinksoft.Patterns.Creational.AbstractFactory.Product;

namespace Thinksoft.Patterns.Creational.AbstractFactory.Factory
{
    /**
     * The 'ConcreteFactory' Class.
     * 具體工廠：順豐物流工廠
     */
    public class SfExpressLogisticsFactory : ILogisticsProviderFactory
    {
        // 創建順豐運送提供者實例
        public IShippingProvider CreateShippingProvider()
        {
            return new SfShippingProvider();
        }

        // 創建順豐物流追蹤提供者實例
        public ITrackingProvider CreateTrackingProvider()
        {
            return new SfTrackingProvider();
        }
    }
}
