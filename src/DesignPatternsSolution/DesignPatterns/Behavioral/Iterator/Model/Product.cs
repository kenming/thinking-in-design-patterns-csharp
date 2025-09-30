namespace Thinksoft.Patterns.Behavioral.Iterator.Model
{
    /**
     * 商品資料類別 - 包含商品基本資訊
     */
    public class Product
    {
        public string Name { get; set; }    // 商品名稱
        public int Stock { get; set; }      // 庫存數量

        public Product(string name, int stock)
        {
            Name = name;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"商品：{Name}, 庫存：{Stock}";
        }
    }
}
