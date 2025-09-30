namespace Thinksoft.Patterns.Creational.AbstractFactory.Product
{
    /**
     * The 'ConcreteProduct' Class.
     * 具體產品：順豐物流追蹤提供者
     */
    public class SfTrackingProvider : ITrackingProvider
    {
        // 實現物流追蹤作業
        public void Track(string trackingNo)
        {
            // 模擬順豐速運的物流追蹤流程
            Console.WriteLine($"📦 順豐物流追蹤：貨件 {trackingNo} 已抵達集散中心");
        }
    }
}
