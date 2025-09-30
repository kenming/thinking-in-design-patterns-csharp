using System;
using System.Text.Json;
using Thinksoft.Patterns.Structural.Decorator.Core;

namespace Thinksoft.Patterns.Structural.Decorator.Decorator
{
    /**
     * The 'Concrete Decorator' Class.
     * 序列化/反序列化修飾者具體類別
     */
    public class SerializeDecorator : DataSourceDecorator
    {
        /**
         * 建構函式
         * @param 被裝飾的資料來源物件，傳遞給基底類別初始化
         */
        public SerializeDecorator(IDataSource dataSource) : base(dataSource)
        {
        }
        public override string ProcessOut(string outgoingXml)
        {
            // 先呼叫基底 (被修飾物件) 的 ProcessOut 方法
            string processedXml = base.ProcessOut(outgoingXml);
            // 將處理後的 XML 進行序列化，再回傳
            return Serialize(processedXml);
        }
        public override string ProcessIn(string incomingSerialized)
        {
            // 先反序列化
            string deserializedXml = Deserialize(incomingSerialized);
            // 呼叫基底 (被修飾物件) 的 ProcessIn 方法
            return base.ProcessIn(deserializedXml);
        }

        // 使用 .NET 標準函式庫進行序列化
        private string Serialize(string xml)
        {
            // 這裡以 JSON 字串包裝 XML 字串為例
            return JsonSerializer.Serialize(xml);
        }

        // 使用 .NET 標準函式庫進行反序列化
        private string Deserialize(string serialized)
        {
            return JsonSerializer.Deserialize<string>(serialized);
        }
    }
}