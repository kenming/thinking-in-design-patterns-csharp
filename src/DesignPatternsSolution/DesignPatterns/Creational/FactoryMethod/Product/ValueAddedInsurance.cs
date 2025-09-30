namespace Thinksoft.Patterns.Creational.FactoryMethod.Product
{
    /**
     * The 'ConcreteProduct' Class
     * 加值保險具體類別
     * 加值保險適用於高價值商品，保費較高但保障範圍完整
     */
    public class ValueAddedInsurance : Insurance
    {
        /**
         * 建構加值保險物件
         * 
         * @param itemType 商品類型
         * @param value 商品價值
         */
        public ValueAddedInsurance(string itemType, double value) 
                : base(itemType, value)
        {}
        
        /**
         * 計算加值保險費用
         * 
         * @return 保險費用（商品價值的 1.2% + 30 元手續費）
         */
        public override double CalculateCost()
        {
            // 加值保險：商品價值的 1.2% + 手續費
            return insuredValue * 0.012 + 30;
        }
        
        /**
         * 取得加值保險的保障說明
         * 
         * @return 保險保障範圍描述
         */
        public override string GetDescription()
        {
            return "加值保險 - 涵蓋遺失、損壞、延遲賠償、全額退款保障";
        }
    }
}
