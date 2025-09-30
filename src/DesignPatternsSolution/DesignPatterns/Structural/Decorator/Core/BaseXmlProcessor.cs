using System.Xml.Linq;

namespace Thinksoft.Patterns.Structural.Decorator.Core
{
    /*
     *  The 'Concrete Component' Class.
     *  基本 XML 解析器，驗證輸出/輸入的 XML 字串
     */
    public class BaseXmlProcessor : IDataSource
    {
        public string ProcessOut(string outgoingXml)
        {
            try
            {
                // Convert the XML string into an XML element
                XElement xmlElement = XElement.Parse(outgoingXml);

                return xmlElement.ToString();
            }
            catch (Exception ex)
            {
                throw new("XML String Parse Error : " + ex.Message);
            }
        }
        public string ProcessIn(string incomingXml)
        {
            try
            {
                // Convert the XML string into an XML element
                XElement xmlElement = XElement.Parse(incomingXml);

                return xmlElement.ToString();
            }
            catch (Exception ex)
            {
                throw new("XML String Parse Error : " + ex.Message);
            }
        }
    }
}
