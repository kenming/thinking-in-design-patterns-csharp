namespace Thinksoft.Patterns.Creational.AbstractFactory.Product
{
    /**
     * The 'ConcreteProduct' Class.
     * 具體產品：黑貓物流追蹤提供者
     */
    public class BlackCatTrackingProvider : ITrackingProvider
    {
        // 實現物流追蹤作業
        public void Track(string trackingNo)
        {
            // 模擬黑貓宅配的物流追蹤流程
            Console.WriteLine($"🐈‍ 黑貓物流追蹤：貨件 {trackingNo} 已在配送中");
        }
    }
}
