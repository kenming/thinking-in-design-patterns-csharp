using Thinksoft.Patterns.Behavioral.Iterator.Model;

namespace Thinksoft.Patterns.Behavioral.Iterator.BuiltIn
{
    /**
     * 庫存商品集合類別
     * 實現 IEnumerable<Product> 介面，使用 C# 內建的迭代器支援
     */
    public class StockCollection : IEnumerable<Product>
    {
        private List<Product> _products = new List<Product>();

        /**
         * 新增商品到庫存集合
         * @param name 商品名稱
         * @param quantity 商品數量
         */
        public void AddProduct(string name, int quantity)
        {
            _products.Add(new Product(name, quantity));
        }

        /**
         * 實現泛型迭代器
         * 使用 yield return 提供延遲執行的迭代功能
         * @return 商品的迭代器
         */
        public IEnumerator<Product> GetEnumerator()
        {
            foreach (var product in _products)
            {
                // 每次即回傳一個元素，並暫停當前的狀態
                // 直至調用下一次的 MoveNext() 操作
                yield return product;
            }
        }

        /**
         * 實現非泛型迭代器（為了相容性）
         * @return 非泛型迭代器
         */
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /**
         * 取得集合元素的計數
         */
        public int Count => _products.Count;

        /**
         * 透過索引取得所在集合位置的元素
         * @param index 索引位置
         * @return 指定位置的商品
         */
        public Product this[int index]
        {
            get { return _products[index]; }
        }
    }
}
