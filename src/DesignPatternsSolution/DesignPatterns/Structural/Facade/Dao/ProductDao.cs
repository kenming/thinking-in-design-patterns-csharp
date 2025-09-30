using Thinksoft.Patterns.Structural.Facade.Model;

namespace Thinksoft.Patterns.Structural.Facade.Dao
{
    /**
     * 商品資料存取物件 (Dao, Data Access Object)
     * 負責管理商品資訊的資料庫存取
     * 實務上會透過如 ADO.NET or E.F 框架存取關聯資料庫
     * 並可能定義其它相關操作，如查詢、更新、刪除訂單等
     */
    public class ProductDao
    {
        public List<Product> GetAllProducts()
        {
            // 實務上會至資料庫取得商品資訊，這裡
            // 簡化示範，只傳回可以處理的測試資料
            return new List<Product>
            {
                new Product { Id = "001", Name = "寵物項圈", 
                    Price = 160, Description = "發光項圈" },
                new Product { Id = "002", Name = "寵物衣服", 
                    Price = 540, Description = "涼爽秋衣" },
                new Product { Id = "003", Name = "小狗牽繩", 
                    Price = 120, Description = "可伸縮尼龍製" },
                new Product { Id = "004", Name = "小狗罐頭", 
                    Price = 36, Description = "健康雞胸肉泥" },
                new Product { Id = "005", Name = "小狗玩具", 
                    Price = 99, Description = "啃咬不壞" },
                new Product { Id = "006", Name = "寵物水杯", 
                    Price = 180, Description = "方便攜帶" },
                new Product { Id = "007", Name = "寵物便便袋", 
                    Price = 3, Description = "環保可分解" },
                new Product { Id = "008", Name = "寵物窩墊", 
                    Price = 640, Description = "冬暖夏涼好溫馨" }
            };
        }
    }
}