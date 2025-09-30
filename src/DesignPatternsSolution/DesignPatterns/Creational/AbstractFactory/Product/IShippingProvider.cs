namespace Thinksoft.Patterns.Creational.AbstractFactory.Product
{
    /**
     * The 'AbstractProduct' Interface.
     * 抽象產品：運送提供者介面
     * 定義所有物流供應商必須實現的運送功能
     * 作為抽象工廠模式中的產品介面，統一不同供應商的運送操作
     */
    public interface IShippingProvider
    {
        /**
         * 處理訂單出貨
         * @param orderId 訂單編號
         */
        void Ship(string orderId);
    }
}
