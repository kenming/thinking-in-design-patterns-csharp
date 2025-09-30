using Thinksoft.Patterns.Structural.Decorator.Core;

namespace Thinksoft.Patterns.Structural.Decorator.Decorator
{
    /*
     *  The 'Decorator' Abstract Class.
     *  資料源修飾者抽象類別，需制定符合 IDataSource 介面
     *  為基本XML解析器添加額外功能，具體裝飾者都需繼承此抽象類別
     */
    public abstract class DataSourceDecorator : IDataSource
    {
        private IDataSource _dataSrc;

        // Constructor.
        public DataSourceDecorator(IDataSource dataSource)
        { 
            this._dataSrc = dataSource;
        }

        /**
         * 處理準備輸出的XML資料
         * @param  outgoingXml 傳出的XML字串
         * @return 處理後的XML字串
         */
        public virtual string ProcessOut(string outgoingXml)
        {
            return _dataSrc.ProcessOut(outgoingXml);
        }

        /**
         * 處理接收到的XML資料
         * @param  incomingXml 傳入的XML字串
         * @return 處理後的XML字串
         */
        public virtual string ProcessIn(string incomingXml)
        {
            return _dataSrc.ProcessIn(incomingXml);
        }
    }
}
