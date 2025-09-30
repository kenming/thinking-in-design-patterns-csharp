using Thinksoft.Patterns.Behavioral.Command.Receiver;

namespace Thinksoft.Patterns.Behavioral.Command.Command
{
    /**
     * 'ConcreteCommand' - 記錄商品瀏覽
     * 實現ICommand和IParameter介面
     */
    public class LogProductViewCommand : ICommand, 
        IParameter<(string UserId, string ProductId)>
    {
        private readonly UserActivityRecorder _recorder;
        private string _userId;
        private string _productId;

        /**
         * 建構函式
         * @param recorder 用戶活動記錄器
         */
        public LogProductViewCommand(UserActivityRecorder recorder)
        {
            _recorder = recorder;
        }

        // 執行命令 - 記錄商品瀏覽，並回傳處理結果
        public string Execute()
        {
            if (string.IsNullOrEmpty(_userId) || string.IsNullOrEmpty(_productId))
            {
                return "錯誤: 用戶ID或商品ID未設置";
            }
            return _recorder.LogProductView(_userId, _productId);
        }

        // 撤銷命令 - 移除商品瀏覽記錄，並回傳處理結果
        public string Undo()
        {
            if (string.IsNullOrEmpty(_userId) || string.IsNullOrEmpty(_productId))
            {
                return "錯誤: 用戶ID或商品ID未設置";
            }
            return _recorder.RemoveProductViewLog(_userId, _productId);
        }

        // 獲取命令描述
        public string GetDescription()
        {
            return $"記錄商品瀏覽命令 [用戶: {_userId}, 商品: {_productId}]";
        }

        // 設置屬性值 - 用戶ID和商品ID
        public void SetProperty((string UserId, string ProductId) value)
        {
            _userId = value.UserId;
            _productId = value.ProductId;
        }

        // 獲取屬性值
        public (string UserId, string ProductId) GetProperty()
        {
            return (_userId, _productId);
        }
    }
}