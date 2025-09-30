using Thinksoft.Patterns.Behavioral.Command.Receiver;

namespace Thinksoft.Patterns.Behavioral.Command.Command
{
    /**
     * 'CocreteCommand' - 記錄搜索行為
     * 實現 ICommand 和 IParameter 介面
     */
    public class LogSearchCommand : ICommand, 
        IParameter<(string UserId, string Keyword)>
    {
        private readonly UserActivityRecorder _recorder;
        private string _userId;
        private string _keyword;

        /**
         * 建構函式
         * @param recorder 用戶活動記錄器
         */
        public LogSearchCommand(UserActivityRecorder recorder)
        {
            _recorder = recorder;
        }

        // 執行命令 - 記錄搜索行為，並回傳處理結果
        public string Execute()
        {
            if (string.IsNullOrEmpty(_userId) || string.IsNullOrEmpty(_keyword))
            {
                return "錯誤: 用戶ID或搜索關鍵詞未設置";
            }
            return _recorder.LogSearch(_userId, _keyword);
        }

        // 撤銷命令 - 移除搜索行為記錄，並回傳處理結果
        public string Undo()
        {
            if (string.IsNullOrEmpty(_userId) || string.IsNullOrEmpty(_keyword))
            {
                return "錯誤: 用戶ID或搜索關鍵詞未設置";
            }
            return _recorder.RemoveSearchLog(_userId, _keyword);
        }

        // 獲取命令描述
        public string GetDescription()
        {
            return $"記錄搜索命令 [用戶: {_userId}, 關鍵詞: '{_keyword}']";
        }

        // 設置屬性值 - 用戶ID和搜索關鍵詞
        public void SetProperty((string UserId, string Keyword) value)
        {
            _userId = value.UserId;
            _keyword = value.Keyword;
        }

        // 獲取屬性值
        public (string UserId, string Keyword) GetProperty()
        {
            return (_userId, _keyword);
        }
    }
}