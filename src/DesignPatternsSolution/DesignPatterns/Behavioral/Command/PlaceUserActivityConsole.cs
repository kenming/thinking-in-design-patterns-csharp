using System;
using Thinksoft.Patterns.Behavioral.Command.Command;
using Thinksoft.Patterns.Behavioral.Command.Factory;
using Thinksoft.Patterns.Behavioral.Command.Invoker;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.Command
{
    /**
     * 'Client' - 命令模式 Demo by Console
     * 展示如何使用參數化命令模式記錄用戶活動
     */
    public class PlaceUserActivityConsole : IConsoleProgram
    {
        public void Start()
        {
            // 創建命令工廠
            CommandFactory commandFactory = new CommandFactory();

            // 創建調用者
            UserActivityTracker tracker = new UserActivityTracker();

            // 使用工廠獲取命令實例
            LogProductViewCommand viewProductCommand = commandFactory.GetLogProductViewCommand();
            LogSearchCommand searchCommand = commandFactory.GetLogSearchCommand();

            Console.WriteLine("=== 命令模式 Demo ===");
            Console.WriteLine("使用參數化命令模式記錄用戶活動 (瀏覽商品、搜索商品)...\n\n");

            // 設置參數並執行瀏覽商品命令
            viewProductCommand.SetProperty(("user123", "product456"));
            Console.WriteLine(tracker.ExecuteCommand(viewProductCommand));

            // 設置參數並執行搜索命令
            searchCommand.SetProperty(("user123", "筆記型電腦"));
            Console.WriteLine(tracker.ExecuteCommand(searchCommand));

            // 設置不同參數再次執行瀏覽商品命令
            viewProductCommand.SetProperty(("user123", "product789"));
            Console.WriteLine(tracker.ExecuteCommand(viewProductCommand));

            // 顯示命令歷史記錄數量
            Console.WriteLine($"\n目前命令歷史記錄數量: {tracker.GetHistoryCount()}");

            // 撤銷命令
            Console.WriteLine("\n\n=== 撤銷命令 ===\n");
            Console.WriteLine(tracker.UndoLastCommand(commandFactory)); // 撤銷搜索命令            
            Console.WriteLine(tracker.UndoLastCommand(commandFactory)); // 撤銷瀏覽商品命令

            // 顯示命令歷史記錄數量
            Console.WriteLine($"\n目前命令歷史記錄數量: {tracker.GetHistoryCount()}");

            Console.WriteLine("\n\n按任意鍵結束...");
            Console.ReadKey();
        }
    }
}