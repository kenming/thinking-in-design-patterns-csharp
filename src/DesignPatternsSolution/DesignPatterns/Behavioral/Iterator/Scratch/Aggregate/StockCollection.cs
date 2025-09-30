using Thinksoft.Patterns.Behavioral.Iterator.Model;
using Thinksoft.Patterns.Behavioral.Iterator.Scratch.Iterator;

namespace Thinksoft.Patterns.Behavioral.Iterator.Scratch.Aggregate
{
    /**
     * The 'Concrete Aggregate' Class
     * 庫存商品集合 - 實現 IAggregate<T> 的具體類別
     * 負責管理商品清單並提供迭代器建立功能
     */
    public class StockCollection : IAggregate<Product>
    {
        // 儲存商品的內部清單
        private List<Product> _products;
        
        // 初始化庫存商品集合         
        public StockCollection()
        {
            _products = new();
        }

        /**
         * 新增商品至集合中
         * @param name 商品名稱
         * @param stock 庫存數量
         */
        public void AddProduct(string name, int stock)
        {
            _products.Add(new Product(name, stock));
        }

        /**
         * 建立迭代器物件
         * @return 用於遍歷此集合的迭代器
         */
        public IIterator<Product> CreateIterator()
        {
            return new StockIterator(this);
        }

        /**
         * 取得集合中商品的總數量
         * @return 商品總數
         */
        public int Count => _products.Count;

        /**
         * 透過索引取得指定位置的商品
         * @param index 商品在集合中的索引位置
         * @return 指定位置的商品物件
         */
        public Product this[int index]
        {
            get { return _products[index]; }
        }
    }
}