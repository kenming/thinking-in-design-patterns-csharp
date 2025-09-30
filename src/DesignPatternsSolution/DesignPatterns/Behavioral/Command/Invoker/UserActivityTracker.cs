using System;
using System.Collections.Generic;
using Thinksoft.Patterns.Behavioral.Command.Command;
using Thinksoft.Patterns.Behavioral.Command.Factory;

namespace Thinksoft.Patterns.Behavioral.Command.Invoker
{
    /**
     * 'Invoker' - 用戶活動追蹤器
     * 負責執行命令並維護命令歷史記錄
     */
    public class UserActivityTracker
    {
        // 命令歷史記錄，保存命令類型和參數
        private readonly List<(Type CommandType, object Parameter)> 
                _commandHistory = new List<(Type, object)>();

        /**
         * 執行命令
         * @param command 要執行的命令
         * @return 命令執行結果
         */
        public string ExecuteCommand(ICommand command)
        {
            string result = command.Execute();

            // 記錄命令類型和參數
            if (command is IParameter<(string, string)> paramCommand)
            {
                _commandHistory.Add((command.GetType(), paramCommand.GetProperty()));
            }

            return result;
        }

        /**
         * 撤銷上一個命令
         * 注意：這裡需要通過工廠重新創建命令並設置參數
         * @param factory 命令工廠
         * @return 撤銷結果
         */
        public string UndoLastCommand(CommandFactory factory)
        {
            if (_commandHistory.Count > 0)
            {
                var lastCommand = _commandHistory[_commandHistory.Count - 1];
                _commandHistory.RemoveAt(_commandHistory.Count - 1);

                // 根據命令類型獲取相應的命令實例並設置參數
                if (lastCommand.CommandType == typeof(LogProductViewCommand))
                {
                    var command = factory.GetLogProductViewCommand();
                    command.SetProperty((ValueTuple<string, string>)lastCommand.Parameter);
                    return command.Undo();
                }
                else if (lastCommand.CommandType == typeof(LogSearchCommand))
                {
                    var command = factory.GetLogSearchCommand();
                    command.SetProperty((ValueTuple<string, string>)lastCommand.Parameter);
                    return command.Undo();
                }
            }

            return "沒有可以撤銷的命令";
        }

        /**
         * 獲取命令歷史記錄數量
         * @return 歷史記錄數量
         */
        public int GetHistoryCount()
        {
            return _commandHistory.Count;
        }
    }
}