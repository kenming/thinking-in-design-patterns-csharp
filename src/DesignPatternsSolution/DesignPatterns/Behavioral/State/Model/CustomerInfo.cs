namespace Thinksoft.Patterns.Behavioral.State.Model
{
    /**
     * 客戶資訊資料類別
     * 包含客戶基本資訊和送貨地址
     */
    public class CustomerInfo
    {
        public string Name { get; set; }                // 客戶名稱
        public string Contact { get; set; }             // 客戶聯絡方式
        public string DeliveryAddress { get; set; }     // 送貨地址

        // 建構函式
        public CustomerInfo(string name, string contact, string deliveryAddress)
        {
            Name = name;
            Contact = contact;
            DeliveryAddress = deliveryAddress;
        }

        // 取得格式化的客戶資訊字串
        public override string ToString()
        {
            return $"{Name} ({Contact})";
        }
    }
}
