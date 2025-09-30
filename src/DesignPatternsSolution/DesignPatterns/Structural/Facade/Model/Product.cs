namespace Thinksoft.Patterns.Structural.Facade.Model
{
    /**
     * 商品資料模型
     */
    public class Product
    {
        public string Id { get; set; }          // 商品編號
        public string Name { get; set; }        // 商品名稱
        public int Price { get; set; }          // 商品價格
        public string Description { get; set; } // 商品說明
    }
}
