namespace Thinksoft.Patterns.Creational.FactoryMethod.Product
{
    /**
     * The 'Concrete Product' Class
     * 基本保具體類別
     * 基本保險適用於一般商品，保費較低但保障範圍有限
     */
    public class BasicInsurance : Insurance
    {
        /**
         * 建構基本保險物件
         * 
         * @param itemType 商品類型
         * @param value 商品價值
         */
        public BasicInsurance(string itemType, double value) 
                : base(itemType, value)
        {
        }

        /**
         * 計算基本保險費用
         * 
         * @return 保險費用（商品價值的 0.5%）
         */
        public override double CalculateCost()
        {
            // 基本保險：商品價值的 0.5%
            return insuredValue * 0.005;
        }

        /**
         * 取得基本保險的保障說明
         * 
         * @return 保險保障範圍描述
         */
        public override string GetDescription()
        {
            return "基本保險 - 涵蓋運送途中遺失、損壞";
        }
    }
}
