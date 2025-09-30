// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Text;
using Thinksoft.Patterns.Utils;

class Program
{
    static void Main(string[] args)
    {
        // 設定控制台編碼為 UTF-8，以支援 emoji 顯示
        Console.OutputEncoding = Encoding.UTF8;

        // 分組的 Console 程式
        var groupedPrograms = new Dictionary<string, List<(string modeName, IConsoleProgram program)>>
        {
            {
                "結構型設計模式", new List<(string, IConsoleProgram)>
                {
                    ("Facade", new Thinksoft.Patterns.Structural
                                    .Facade.Client.PlaceOrderConsole()),
                    ("Proxy", new Thinksoft.Patterns.Structural
                                    .Proxy.PlaceRegisterConsole()),
                    ("Adapter", new Thinksoft.Patterns.Structural
                                    .Adapter.PlaceStockConsole()),
                    ("Composite", new Thinksoft.Patterns.Structural
                                    .Composite.PlaceProductBundleConsole()),
                    ("Bridge", new Thinksoft.Patterns.Structural
                                    .Bridge.PlacePaymentConsole()),
                    ("Decorator", new Thinksoft.Patterns.Structural
                                    .Decorator.PlaceXmlConsole()),
                    ("Flyweight", new Thinksoft.Patterns.Structural
                                    .Flyweight.PlaceOrderStatusConsole()),
                }
            },
            {
                "行為型設計模式", new List<(string, IConsoleProgram)>
                {
                   ("Strategy", new Thinksoft.Patterns.Behavioral
                                    .Strategy.PlaceOrderConsole()),
                   ("State", new Thinksoft.Patterns.Behavioral
                                    .State.PlaceLogisticConsole()),
                   ("Command", new Thinksoft.Patterns.Behavioral
                                    .Command.PlaceUserActivityConsole()),
                   ("CoR", new Thinksoft.Patterns.Behavioral
                                    .CoR.CustomerSupportConsole()),
                   ("Observer", new Thinksoft.Patterns.Behavioral
                                    .Observer.StoreNotificationConsole()),
                   ("Memento", new Thinksoft.Patterns.Behavioral
                                    .Memento.PlaceCartConsole()),
                   ("Mediator", new Thinksoft.Patterns.Behavioral
                                    .Mediator.PlaceAuctionConsole()),
                   ("Interpreter", new Thinksoft.Patterns.Behavioral
                                    .Interpreter.CouponInterpreterConsole()),
                   ("TemplateMethod", new Thinksoft.Patterns.Behavioral
                                    .TemplateMethod.PlaceProductLoanConsole()),
                   ("Iterator", new Thinksoft.Patterns.Behavioral
                                    .Iterator.Scratch.StockConsoleByScratch()),
                   ("Visitor", new Thinksoft.Patterns.Behavioral
                                    .Visitor.ManageInventoryConsole()),
                }
            },
            {
                "創建型設計模式", new List<(string, IConsoleProgram)>
                {
                    ("Singleton", new Thinksoft.Patterns.Creational
                                    .Singleton.PlaceFormIDConsole()),
                    ("AbstractFactory", new Thinksoft.Patterns.Creational
                                    .AbstractFactory.LogisticsProviderConsole()),
                    ("Prototype", new Thinksoft.Patterns.Creational
                                    .Prototype.PlaceCartConsole()),
                    ("Builder", new Thinksoft.Patterns.Creational
                                    .Builder.BuildComputerConsole()),
                    ("FactoryMethod", new Thinksoft.Patterns.Creational
                                    .FactoryMethod.CalculatePremiumConsole()),
                }
            }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("請選擇要執行的設計模式範例：");
            Console.WriteLine(new string('-', 50));     // 加入區隔線            

            // 動態生成選單
            int index = 1;
            var programMapping = new Dictionary<int, IConsoleProgram>();

            foreach (var group in groupedPrograms)
            {
                Console.WriteLine($"\n[{group.Key}]");
                foreach (var (modeName, program) in group.Value)
                {
                    string displayName = $"{modeName} - {program.GetType().Name}";
                    Console.WriteLine($"  {index}. {displayName}");
                    programMapping[index] = program;
                    index++;
                }
            }

            Console.WriteLine("\n\n" + new string('-', 50));     // 加入區隔線
            Console.WriteLine("\n0. 離開程式");

            // 讀取使用者輸入
            Console.Write("\n輸入選項: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0)
            {
                if (choice == 0)
                {
                    Console.WriteLine("退出程式...");
                    break;
                }

                if (programMapping.TryGetValue(choice, out var selectedProgram))
                {
                    Console.Clear();
                    Console.WriteLine($"\n執行 {selectedProgram.GetType().Name}...\n");
                    selectedProgram.Start();
                }
                else
                {
                    Console.WriteLine("無效選項，請重新選擇！");
                }
            }
            else
            {
                Console.WriteLine("請輸入有效數字！");
            }

            Console.WriteLine("\n按任意鍵返回選單...");
            Console.ReadKey();            
        }
    }
}