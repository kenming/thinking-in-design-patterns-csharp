using Thinksoft.Patterns.Structural.Proxy.Model;

namespace Thinksoft.Patterns.Structural.Proxy.Subject
{
    /*
     *  The 'Subject' Interface.
     *  'RealSubject' 與 'Proxy' 類別均需實現該介面
     *  制定帳號註冊的介面     
     */
    public interface IAccount
    {
        /*
         *  提供註冊的操作
         *  @param  使用者註冊資訊
         *  @return 註冊結果
         */
        string Register(User user);
    }
}
