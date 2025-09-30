namespace Thinksoft.Patterns.Structural.Proxy.Model
{
    /*
     *  'User' 資料類型物件
     */
    public class User
    {
        public string Name { get; set; }        // 使用者名稱
        public string Password {  get; set; }   // 使用者密碼
        public bool IsForeign { get; set; }     // 是否為境外用戶
        public string Document {  get; set; }   // 境外用戶提供的證件資訊
    }
}
