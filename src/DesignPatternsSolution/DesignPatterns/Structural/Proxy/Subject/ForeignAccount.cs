using Thinksoft.Patterns.Structural.Proxy.Model;

namespace Thinksoft.Patterns.Structural.Proxy.Subject
{
    /*
     *  The 'Real Subject' Class.
     *  處理境外用戶帳號註冊類別
     *  這裡使用 'internal' 修飾符代表無法被外界 (Client) 取用，
     *  僅能透過同一 Namespace 內的 Proxy 類別取用。
     */
    internal class ForeignAccount : IAccount
    {
        public string Register(User user)
        {
            string result;

            if (Check(user.Document))
                result = "已完成境外用戶身分查核\n";
            else
                result = "境外用戶身分驗證失敗!\n";            

            return result;
        }

        // 檢查所上傳境外用戶的文件是否正確
        private bool Check(string document)
        {
            // 僅模擬如有輸入 "身分證" 或 "護照" 兩個關鍵字，即可完成審核
            if (document.Contains("身分證") || document.Contains("護照"))
                return true;
            else
                return false;
        }
    }
}