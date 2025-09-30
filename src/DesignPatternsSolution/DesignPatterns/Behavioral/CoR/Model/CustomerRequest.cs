namespace Thinksoft.Patterns.Behavioral.CoR.Model
{
    /**
     * 客戶服務請求資料模型
     */
    public class CustomerRequest
    {
        // 請求類型
        public string RequestType { get; set; }

        // 請求描述
        public string Description { get; set; }

        // 嚴重等級 (1-10)
        public int SeverityLevel { get; set; }

        // Constructor
        public CustomerRequest(string type, string desc, int severity)
        {
            RequestType = type;
            Description = desc;
            SeverityLevel = severity;
        }
    }
}
