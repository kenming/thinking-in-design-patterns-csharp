using Thinksoft.Patterns.Creational.FactoryMethod.Creator;

namespace Thinksoft.Patterns.Creational.FactoryMethod
{
    /**
     * The 'Service' Class
     * 保費計算服務類別     
     * 提供客戶端調用的保費計算功能，使用 Factory Method 模式創建保險產品
     */
    public class CalculatePremiumService
    {
        private readonly PremiumCalculator _calculator;

        /**
         * 建構保費計算服務
         * 
         * @param calculator 保費計算器實例
         */
        public CalculatePremiumService(PremiumCalculator calculator)
        {
            _calculator = calculator;
        }

        /**
         * 計算商品保險費用
         * 
         * @param itemType 商品類型
         * @param itemValue 商品價值
         * @return 計算出的保險費用
         */
        public double CalculateInsuranceCost(string itemType, double itemValue)
        {
            return _calculator.calculatePremium(itemType, itemValue);
        }

        /**
         * 取得保險產品說明
         * 
         * @param itemType 商品類型
         * @param itemValue 商品價值
         * @return 保險產品的詳細說明
         */
        public string GetInsuranceDescription(string itemType, double itemValue)
        {
            var insurance = _calculator.CreateInsurance(itemType, itemValue);
            return insurance.GetDescription();
        }

        /**
         * 取得完整的保險報價資訊
         * 
         * @param itemType 商品類型
         * @param itemValue 商品價值
         * @return 包含費用和說明的完整報價資訊
         */
        public string GetInsuranceQuote(string itemType, double itemValue)
        {
            var cost = CalculateInsuranceCost(itemType, itemValue);
            var description = GetInsuranceDescription(itemType, itemValue);
            
            return $"商品類型: {itemType}\n" +
                   $"商品價值: ${itemValue:F2}\n" +
                   $"保險方案: {description}\n" +
                   $"保險費用: ${cost:F2}";
        }
    }
}
