using Thinksoft.Patterns.Behavioral.Command.Command;
using Thinksoft.Patterns.Behavioral.Command.Receiver;

namespace Thinksoft.Patterns.Behavioral.Command.Factory
{
    /**
     * 'CommandFactory' 命令工廠
     * 負責創建命令物件，使用單例模式管理命令實例
     */
    public class CommandFactory
    {
        private readonly UserActivityRecorder _recorder;

        // 單例命令實例
        private LogProductViewCommand _logProductViewCommand;
        private LogSearchCommand _logSearchCommand;

        /**
         * 建構函式
         * 初始化工廠並創建接收者實例
         */
        public CommandFactory()
        {
            // 創建接收者實例
            _recorder = new UserActivityRecorder();
        }

        /**
         * 獲取接收者實例
         * @return 用戶活動記錄器實例
         */
        public UserActivityRecorder GetRecorder()
        {
            return _recorder;
        }

        /**
         * 獲取記錄商品瀏覽命令 (單例)
         * @return 記錄商品瀏覽命令
         */
        public LogProductViewCommand GetLogProductViewCommand()
        {
            if (_logProductViewCommand == null)
            {
                _logProductViewCommand = new LogProductViewCommand(_recorder);
            }
            return _logProductViewCommand;
        }

        /**
         * 獲取記錄搜索命令 (單例)
         * @return 記錄搜索命令
         */
        public LogSearchCommand GetLogSearchCommand()
        {
            if (_logSearchCommand == null)
            {
                _logSearchCommand = new LogSearchCommand(_recorder);
            }
            return _logSearchCommand;
        }
    }
}