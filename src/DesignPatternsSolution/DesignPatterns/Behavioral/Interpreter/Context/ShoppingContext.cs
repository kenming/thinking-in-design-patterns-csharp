namespace Thinksoft.Patterns.Behavioral.Interpreter.Context
{
    /** 
     * The 'Context' Class
     * 購物上下文類別
     * 儲存購物過程中的狀態資訊，包括總金額、商品類別、數量等
     * 提供統一的方法讓解釋器檢索和設定這些值
     */
    public class ShoppingContext
    {
        private Dictionary<string, object> _propertyDict;

        // Constructor
        public ShoppingContext()
        {
            // 初始化屬性字典
            _propertyDict = new Dictionary<string, object>();
        }

        /**
         * 設定購物上下文屬性值
         * @param key 屬性名稱
         * @param value 屬性值
         */
        public void SetValue(string key, object value)
        {
            _propertyDict[key] = value;
        }

        /**
         * 取得購物上下文屬性值
         * @param key 屬性名稱
         * @return 屬性值，如果不存在則返回null
         */
        public object GetValue(string key)
        {
            return _propertyDict.ContainsKey(key) ? _propertyDict[key] : null;
        }
    }
}
