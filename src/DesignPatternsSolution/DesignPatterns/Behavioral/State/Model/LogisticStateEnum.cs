namespace Thinksoft.Patterns.Behavioral.State.Model
{
    /*
     *  物流配送狀態列舉
     *  定義物流配送過程的狀態
     */
    public enum LogisticStateEnum
    {
        PendingShipment,        // 待出貨
        InTransit,              // 運送中
        AtDistributionCenter,   // 到達配送中心
        Delivered               // 已送達
    }
}
