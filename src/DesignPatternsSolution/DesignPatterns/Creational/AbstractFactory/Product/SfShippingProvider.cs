namespace Thinksoft.Patterns.Creational.AbstractFactory.Product
{
    /**
     * The 'ConcreteProduct' Class.
     * 具體產品：順豐運送提供者
     */
    public class SfShippingProvider : IShippingProvider
    {
        // 實現訂單出貨作業
        public void Ship(string orderId)
        {
            // 模擬順豐速運的出貨處理流程
            Console.WriteLine($"🚚 順豐速運已受理，訂單編號：{orderId}");
        }
    }
}
