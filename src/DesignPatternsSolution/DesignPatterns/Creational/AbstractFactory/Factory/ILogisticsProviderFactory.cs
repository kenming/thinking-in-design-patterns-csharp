using Thinksoft.Patterns.Creational.AbstractFactory.Product;

namespace Thinksoft.Patterns.Creational.AbstractFactory.Factory
{
    /**
     * The 'AbstractFactory' Interface.
     * 抽象工廠：物流供應商工廠介面
     * 定義創建物流服務一整族物件的抽象工廠
     * 每個具體工廠實現此介面，負責創建特定物流供應商的所有相關服務
     */
    public interface ILogisticsProviderFactory
    {
        /**
         * 創建運送提供者
         * @return IShippingProvider 型別實例
         */
        IShippingProvider CreateShippingProvider();

        /**
         * 創建物流追蹤提供者
         * @return ITrackingProvider 型別實例
         */
        ITrackingProvider CreateTrackingProvider();
    }
}
