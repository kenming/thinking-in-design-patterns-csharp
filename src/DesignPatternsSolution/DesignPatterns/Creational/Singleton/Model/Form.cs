namespace Thinksoft.Patterns.Creational.Singleton.Model
{
    /**
     *  自訂表單的資料物件
     */
    public class Form
    {
        public string FormType { get; set; }        // 表單類型
        public string FormDateStr { get; set; }     // 表單日期字串

        /**
         * 重寫 Equals 方法，比較兩個 Form 對象是否相等
         * 比較規則：當兩個對象類型相同且 FormType 和 
         *           FormDateStr 屬性值相等時視為相等
         */
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;
            return ((Form)obj).FormType.Equals(FormType) &&
                ((Form)obj).FormDateStr.Equals(FormDateStr);
        }

        /**
         * 覆寫 GetHashCode 方法，計算物件的 HashCode
         * 將 FormType 和 FormDateStr 屬性的 HashCode 進行 XOR 運算來生成
         * 這確保了相等的物件具有相同的哈希碼
         */
        public override int GetHashCode()
        {
            return FormType.GetHashCode() ^ FormDateStr.GetHashCode();
        }
    }
}
