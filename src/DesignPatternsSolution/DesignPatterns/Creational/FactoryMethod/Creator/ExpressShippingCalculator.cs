using Thinksoft.Patterns.Creational.FactoryMethod.Product;

namespace Thinksoft.Patterns.Creational.FactoryMethod.Creator
{
    /**
     * The 'ConcreteCreator' Class
     * 快遞保費計算器
     * 專門處理快遞運送的保費計算，根據商品特性決定創建適當的保險產品
     */
    public class ExpressShippingCalculator : PremiumCalculator
    {
        /**
         * 實作 Factory Method，創建適當的保險產品
         * 
         * @param itemType 商品類型
         * @param value 商品價值
         * @return 適合的保險產品實例
         */
        public override Insurance CreateInsurance(string itemType, double value)
        {
            // 根據商品類型決定創建哪種保險
            if (itemType == "electronics" || value > 1000)
            {
                return new ValueAddedInsurance(itemType, value);
            }
            else
            {
                return new BasicInsurance(itemType, value);
            }
        }
    }
}
