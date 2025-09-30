namespace Thinksoft.Patterns.Creational.AbstractFactory.Product
{
    /**
     * The 'AbstractProduct' Interface.
     * 抽象產品：物流追蹤提供者介面
     * 定義所有物流供應商必須實現的物流追蹤功能
     * 作為抽象工廠模式中的產品介面，統一不同供應商的物流追蹤操作
     */
    public interface ITrackingProvider
    {
        /**
         * 查詢貨件追蹤資訊
         * @param trackingNo 追蹤編號
         */
        void Track(string trackingNo);
    }
}
