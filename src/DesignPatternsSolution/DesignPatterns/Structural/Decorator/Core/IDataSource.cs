namespace Thinksoft.Patterns.Structural.Decorator.Core
{
    /*
     *  The 'Component' interface.
     *  制定資料源的處理的基本操作介面
     */
    public interface IDataSource
    {
        /*
         *  定義處理輸出的字串
         *  @param  準備發送的字串
         *  @return 處理後的字串
         */
        string ProcessOut(string outStr);

        /*
         *  定義處理輸入的字串
         *  @param  接收的字串
         *  @return 處理後的字串
         */
        string ProcessIn(string inStr);
    }
}
