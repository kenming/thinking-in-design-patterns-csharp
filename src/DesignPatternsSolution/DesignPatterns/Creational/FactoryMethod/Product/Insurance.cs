namespace Thinksoft.Patterns.Creational.FactoryMethod.Product
{
    /**
     * The 'Product' Abstract Class
     * 保險產品抽象類別
     * 定義保險產品的基本結構，所有具體保險產品都必須繼承此類別
     */
    public abstract class Insurance
    {
        protected String itemType;
        protected double insuredValue;

        /**
         * 建構保險物件
         * 
         * @param itemType 商品類型
         * @param value 商品價值
         */
        public Insurance(String itemType, double value)
        {
            this.itemType = itemType;
            this.insuredValue = value;
        }

        /**
         * 計算保險費用
         * 
         * @return 保險費用金額
         */
        public abstract double CalculateCost();
        
        /**
         * 取得保險產品說明
         * 
         * @return 保險保障內容描述
         */
        public abstract String GetDescription();
    }
}
