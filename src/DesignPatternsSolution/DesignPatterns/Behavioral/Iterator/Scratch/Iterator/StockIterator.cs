using Thinksoft.Patterns.Behavioral.Iterator.Model;
using Thinksoft.Patterns.Behavioral.Iterator.Scratch.Aggregate;

namespace Thinksoft.Patterns.Behavioral.Iterator.Scratch.Iterator
{
    /**
     * The 'Concrete Iterator' Class
     * 庫存商品迭代器 - 實現 IIterator<T> 的具體類別
     * 負責遍歷 (traverse) StockCollection 中的所有商品項目
     */
    public class StockIterator : IIterator<Product>
    {
        // 庫存商品集合的參考
        private readonly StockCollection _stocks;

        // 目前迭代位置的索引值
        private int _current = 0;

        /**
         * 初始化庫存商品迭代器
         * @param stocks 要走訪的庫存商品集合
         */
        public StockIterator(StockCollection stocks)
        {
            _stocks = stocks;
        }

        /**
         * 取得集合中的第一個商品
         * @return 第一個商品物件，若集合為空則可能拋出例外
         */
        public Product First()
        {
            return _stocks[0];
        }

        /**
         * 移動到下一個商品並回傳該商品
         * @return 下一個商品物件，若已到達集合末端則回傳 null
         */
        public Product Next()
        {
            if (IsDone())
                return null;

            Product current = _stocks[_current];  // 先取得當前元素
            _current++;                           // 再遞增位置
            return current;
        }

        /**
         * 檢查是否已遍歷完所有商品
         * @return true 表示已遍歷完成，false 表示還有商品未遍歷
         */
        public bool IsDone()
        {
            return (_current >= _stocks.Count);
        }

        /**
         * 取得目前位置的商品
         * @return 目前位置的商品物件
         */
        public Product Current()
        {
            return _stocks[_current];
        }
    }
}