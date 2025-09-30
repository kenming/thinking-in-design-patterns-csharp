using Thinksoft.Patterns.Structural.Facade.Model;

namespace Thinksoft.Patterns.Structural.Facade.Dao
{
    /**
     * 訂單資料存取物件 (Dao, Data Access Object)
     * 負責訂單資訊的資料庫存取操作
     * 實務上會透過如 ADO.NET or E.F 框架存取關聯資料庫
     * 並可能定義其它相關操作，如查詢、更新、刪除訂單等
     */
    public class OrderDao
    {
        public bool SaveOrder(Order order)
        {
            // 實務上會將本次交易事件寫入至資料庫
            // 這裡簡化示範，直接返回成功
            return true;
        }
    }
}
