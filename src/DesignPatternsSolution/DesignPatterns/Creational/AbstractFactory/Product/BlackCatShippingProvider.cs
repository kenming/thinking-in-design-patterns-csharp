namespace Thinksoft.Patterns.Creational.AbstractFactory.Product
{
    /**
     * The 'ConcreteProduct' Class.
     * 具體產品：黑貓運送提供者
     */
    public class BlackCatShippingProvider : IShippingProvider
    {        
        // 實現訂單出貨作業
        public void Ship(string orderId)
        {
            // 模擬黑貓宅配的出貨處理流程
            Console.WriteLine($"🚚 黑貓宅配已出貨，訂單編號：{orderId}");
        }
    }
}
