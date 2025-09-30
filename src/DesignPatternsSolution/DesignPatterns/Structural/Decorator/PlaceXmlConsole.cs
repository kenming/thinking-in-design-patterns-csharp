using Thinksoft.Patterns.Structural.Decorator.Core;
using Thinksoft.Patterns.Structural.Decorator.Decorator;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Structural.Decorator
{
    public class PlaceXmlConsole : IConsoleProgram
    {
        public void Start()
        {
            Console.WriteLine("=== 商品資料處理 Decorator 模式展示 ===\n");

            // 取得原始 XML 字串
            string rawXml = GetXmlString();
            Console.WriteLine("-- 原始(未處理) XML 內容 ------");
            Console.WriteLine(rawXml);

            // 組合修飾鏈：驗證 → 編碼 → 序列化 (巢狀建構，由外到內)
            IDataSource outProcessor = new SerializeDecorator(
                                           new CodecDecorator(
                                               new BaseXmlProcessor()));

            // 處理傳送端資料
            string serializedXml = outProcessor.ProcessOut(rawXml);
            Console.WriteLine("\n-- 序列化並編碼後的 XML 內容 ------");
            Console.WriteLine(serializedXml);

            // 組合修飾鏈：反序列化 → 解碼 → 驗證 (逐步包裝，由內到外)
            IDataSource inProcessor = new BaseXmlProcessor();
            inProcessor = new CodecDecorator(inProcessor);
            inProcessor = new SerializeDecorator(inProcessor);            

            // 處理接收端資料
            string finalXml = inProcessor.ProcessIn(serializedXml);
            Console.WriteLine("\n-- 反序列化並解碼後的 XML 處理結果 ------");
            Console.WriteLine(finalXml);
        }

        private string GetXmlString()
        {   
            
            // return "<catalog>\r\n\t<product>\r\n\t\t<name>樹莓派4代</name>\r\n\t\t<price>3800</price>" +
            // "\r\n\t\t<description>ARM 架構、使用SD卡的單板電腦</description>\r\n\t\t<type>Maker</type>" +
            //  "\r\n\t</product>\r\n\t<product>\r\n\t\t<name>數位萬用表</name>\r\n\t\t<price>2600</price>" +
            //  "\r\n\t\t<description>可執行多元量測的數位顯示量錶</description>\r\n\t\t<type>電子儀器</type>" +
            //  \r\n\t</product>\t\r\n</catalog>";
                        
            return "<book><title>Design Patterns</title><author>GoF</author></book>";
        }
    }
}