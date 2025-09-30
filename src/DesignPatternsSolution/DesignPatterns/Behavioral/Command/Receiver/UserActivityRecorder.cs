namespace Thinksoft.Patterns.Behavioral.Command.Receiver
{
    /**
     * 'Receiver' - 用戶行為記錄器
     * 具體執行命令的操作邏輯
     */
    public class UserActivityRecorder
    {
        // 記錄用戶瀏覽商品行為，並返回操作訊息
        public string LogProductView(string userId, string productId)
        {
            // 實際應用中會儲存到資料庫或發送到分析元件
            return $"記錄：用戶 {userId} 瀏覽了商品 {productId}";
        }

        // 記錄用戶搜索行為，並返回操作訊息
        public string LogSearch(string userId, string keyword)
        {
            // 實際應用中會儲存到資料庫或發送到分析元件
            return $"記錄：用戶 {userId} 搜索了關鍵詞 '{keyword}'";
        }

        // 移除用戶瀏覽商品行為記錄，並返回操作訊息
        public string RemoveProductViewLog(string userId, string productId)
        {
            // 實際應用中會從資料庫刪除或標記為已撤銷
            return $"移除記錄：用戶 {userId} 瀏覽商品 {productId} 的記錄";
        }

        // 移除用戶搜索行為記錄，並返回操作訊息
        public string RemoveSearchLog(string userId, string keyword)
        {
            // 實際應用中會從資料庫刪除或標記為已撤銷
            return $"移除記錄：用戶 {userId} 搜索關鍵詞 '{keyword}' 的記錄";
        }

        // 補充：實際應用中還會有更多的用戶行為記錄方法，如：
        // - 記錄用戶加入/移除購物車行為
        // - 記錄/撤銷商品評論        
        // - 記錄/撤銷商品分享
        // - 記錄/撤銷商品收藏
    }
}