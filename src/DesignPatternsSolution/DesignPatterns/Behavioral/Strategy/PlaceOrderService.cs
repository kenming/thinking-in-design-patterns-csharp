using Thinksoft.Patterns.Behavioral.Strategy.Model;

namespace Thinksoft.Patterns.Behavioral.Strategy
{
    /**
     * 訂單服務類別
     * 負責處理訂單計算，並可依據選擇使用不同策略模式實作（集中式或分散式）
     */
    public class PlaceOrderService
    {
        private readonly bool _useDistributedStrategy;

        /**
         * 建構子
         * @param useDistributedStrategy 是否使用分散式策略模式實作
         */
        public PlaceOrderService(bool useDistributedStrategy = false)
        {
            _useDistributedStrategy = useDistributedStrategy;
        }

        /**
         * 處理訂單
         * 處理從 Client 傳入的訂購表單資料，並依據購買商品以及折扣類型計算
         * 商品分項金額與折扣後的商品總額
         * @param orderModel 訂購資料物件
         * @return 處理後的訂購資料物件
         */
        public OrderModel ProcOrder(OrderModel orderModel)
        {
            if (_useDistributedStrategy)
            {
                // 使用策略模式 (strategy pattern)
                var distributedContext = new Distributed.OrderContext();
                return distributedContext.CalcOrderTotalPrice(orderModel);
            }
            else
            {
                // 使用集中式的寫法
                var centralizedContext = new Centratized.OrderContext();
                return centralizedContext.CalcOrderTotalPrice(orderModel);
            }
        }
    }
}