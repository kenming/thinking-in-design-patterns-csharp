using Thinksoft.Patterns.Structural.Proxy.Model;

namespace Thinksoft.Patterns.Structural.Proxy.Subject
{
    /*
     *  The 'Proxy' Class.
     *  註冊帳戶類別，用以處理註冊事宜
     */
    public class Account : IAccount
    {
        // 如果註冊用戶居住地為本地，則由 Account 類別處理；
        // 如果註冊用戶居住地為境外，則會委派由 ForeignAccount 類別處理。
        public string Register(User user)
        {
            string result;

            if (!user.IsForeign)
            {
                result = "已完成用戶註冊！\n";                
            }
            else 
            {
                // delegate (委派) to RealSubject class to handle.
                result = ((IAccount)new ForeignAccount()).Register(user);
            }

            result += "\n註冊帳號資訊 : \n";
            result += $"  User Name : {user.Name}\n";
            if (!user.IsForeign)
                result += "  地區別 : 本地境內\n";
            else
            {
                result += "  地區別 : 境外用戶\n";
                result += $"  檢附文件 : {user.Document}";
            }

            return result;
        }
    }
}