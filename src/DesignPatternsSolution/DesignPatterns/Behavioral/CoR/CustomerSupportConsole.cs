using Thinksoft.Patterns.Behavioral.CoR.Model;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.CoR
{
    /**
     * 'Client' - 客戶服務請求處理 Console
     * 模擬客戶提交不同類型與嚴重等級的服務申請單，
     * 展示責任串鏈模式如何依據請求性質分派處理者。
     * 
     */
    public class CustomerSupportConsole : IConsoleProgram
    {       
        public void Start()
        {
            Console.WriteLine("===== 客戶服務請求處理示範 =====");

            // 建立客戶服務類別
            var supportService = new CustomerSupportService();

            // 測試不同類型的請求
            var request1 = new CustomerRequest("密碼重置", "忘記密碼需要重置", 2);
            var request2 = new CustomerRequest("帳單問題", "帳單金額有誤", 5);
            var request3 = new CustomerRequest("投訴", "服務品質不佳", 7);
            var request4 = new CustomerRequest("系統故障", "整個系統無法使用", 10);

            // 處理每個請求
            supportService.ProcessRequest(request1);
            supportService.ProcessRequest(request2);
            supportService.ProcessRequest(request3);
            supportService.ProcessRequest(request4);

            Console.WriteLine("\n\n按任意鍵結束...");
            Console.ReadKey();
        }
    }
}
