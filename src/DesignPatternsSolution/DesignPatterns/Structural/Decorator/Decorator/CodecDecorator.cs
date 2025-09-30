using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using Thinksoft.Patterns.Structural.Decorator.Core;

namespace Thinksoft.Patterns.Structural.Decorator.Decorator
{
    /*
     * The 'Concrete Decorator' Class.
     * 編/解碼修飾者具體類別
     */
    public class CodecDecorator : DataSourceDecorator
    {
        private IDataSource _dataSource;

        /**
         * 建構函式
         * @param 被裝飾的資料來源物件，傳遞給基底類別初始化
         */
        public CodecDecorator(IDataSource dataSource) : base(dataSource)
        {          
        }
        public override string ProcessOut(string outgoingXml)
        {
            // 先呼叫基底 (被修飾物件) 的 ProcessOut 方法，
            // 取得前一階段處理後的 XML
            string processedXml = base.ProcessOut(outgoingXml);

            // 將處理後的 XML 進行編碼，再回傳
            return Encode(processedXml);
        }
        public override string ProcessIn(string incomingXml)
        {
            // 對傳入的 XML 進行解碼
            string decodeXml = Decode(incomingXml);

            // 呼叫基底 (被修飾物件) 的 ProcessIn 方法，
            // 用以處理解碼後的 XML 並回傳結果
            return base.ProcessIn(decodeXml);
        }

        // The Simple Encode & Decode example is referenced by :
        // https://hackernoon.com/
        // a-beginners-guide-formatting-strings-as-base64-in-csharp
        private string Encode(string outgoingXml)
        {
            byte[] xmlBytes = Encoding.UTF8.GetBytes(outgoingXml);
            string encodedXml = Convert.ToBase64String(xmlBytes);

            return encodedXml;
        }
        private string Decode(string encryptString)
        {
            byte[] encryptbytes = Convert.FromBase64String(encryptString);
            string decodedString = Encoding.UTF8.GetString(encryptbytes);

            return decodedString;
        }
    }
}