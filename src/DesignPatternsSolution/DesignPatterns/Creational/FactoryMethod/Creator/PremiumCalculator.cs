using Thinksoft.Patterns.Creational.FactoryMethod.Product;

namespace Thinksoft.Patterns.Creational.FactoryMethod.Creator
{
    /**
     * The 'Creator' Abstract Class
     * 保費計算器抽象類別     
     * 定義保費計算的基本架構，將保險產品的創建委託給子類別決定
     */
    public abstract class PremiumCalculator
    {        
        /**
         * Factory Method：創建保險產品
         * 
         * @param itemType 商品類型
         * @param value 商品價值
         * @return 對應的保險產品實例
         */
        public abstract Insurance CreateInsurance(String itemType, double value);
        
        /**
         * 計算保險費用
         * 
         * @param itemType 商品類型
         * @param value 商品價值
         * @return 計算出的保險費用
         */
        public double calculatePremium(String itemType, double value)
        {
            Insurance insurance = CreateInsurance(itemType, value);
            return insurance.CalculateCost();
        }
    }
}
