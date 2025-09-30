using Thinksoft.Patterns.Structural.Decorator.Core;
using Thinksoft.Patterns.Structural.Decorator.Decorator;

/*
 * The 'Concrete Decorator' Class.
 * Log 修飾者具體類別
 * 本範例僅以 Console.WriteLine() 方式簡單記錄處理流程，不使用真實 Log 框架
 */
public class LoggerDecorator : DataSourceDecorator
{
    public LoggerDecorator(IDataSource dataSource) : base(dataSource)
    {
    }

    public override string ProcessOut(string outgoingXml)
    {
        Console.WriteLine("[LoggerDecorator] 處理輸出資料開始...");
        Console.WriteLine(outgoingXml); // 輸出原始資料內容
        string result = base.ProcessOut(outgoingXml);
        Console.WriteLine("[LoggerDecorator] 處理輸出資料結束。");
        return result;
    }

    public override string ProcessIn(string incomingXml)
    {
        Console.WriteLine("[LoggerDecorator] 處理輸入資料開始...");
        Console.WriteLine(incomingXml); // 輸入資料內容
        string result = base.ProcessIn(incomingXml);
        Console.WriteLine("[LoggerDecorator] 處理輸入資料結束。");
        return result;
    }
}