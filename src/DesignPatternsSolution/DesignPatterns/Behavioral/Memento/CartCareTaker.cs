namespace Thinksoft.Patterns.Behavioral.Memento
{
    /*
     *  The 'Caretaker' Class
     *  1. 封裝對 CartMemento 物件的存取
     *  2. 保護 CartMemento 無法被其它類型物件直接取用
     *     (除了 ShoppingCart 外)
     *  3. 提供復原和重做操作的功能
     */
    public class CartCareTaker
    {
        // 可以儲存多個 CartMemento 物件
        private readonly List<CartMemento> _mementos;

        // 記錄目前在歷史記錄中的位置
        private int _currentIndex = -1;

        // Constructor
        public CartCareTaker()
        {
            _mementos = new List<CartMemento>();
        }

        // 儲存購物車狀態
        public void SaveState(ShoppingCart cart)
        {
            // 如果在歷史記錄中間進行了新操作，則刪除當前位置之後的所有記錄
            if (_currentIndex < _mementos.Count - 1)
            {
                _mementos.RemoveRange(_currentIndex + 1, _mementos.Count - _currentIndex - 1);
            }

            _mementos.Add(cart.SaveState());
            _currentIndex = _mementos.Count - 1;
            Console.WriteLine("購物車狀態已保存");
        }

        // 復原操作 - 回到上一個狀態
        public bool Undo(ShoppingCart cart)
        {
            if (_currentIndex <= 0)
            {
                Console.WriteLine("無法復原：已經是最初狀態");
                return false;
            }

            _currentIndex--;
            cart.RestoreState(_mementos[_currentIndex]);
            Console.WriteLine("已復原到上一個狀態");
            return true;
        }

        // 重做操作 - 前進到下一個狀態
        public bool Redo(ShoppingCart cart)
        {
            if (_currentIndex >= _mementos.Count - 1)
            {
                Console.WriteLine("無法重做：已經是最新狀態");
                return false;
            }

            _currentIndex++;
            cart.RestoreState(_mementos[_currentIndex]);
            Console.WriteLine("已重做操作");
            return true;
        }

        // 取得所指定位置的 CartMemento 物件
        public CartMemento Get(int index)
        {
            if (index < 0 || index >= _mementos.Count)
            {
                throw new IndexOutOfRangeException("索引超出範圍");
            }
            return _mementos[index];
        }

        // 取得歷史記錄數量
        public int GetHistoryCount()
        {
            return _mementos.Count;
        }

        // 取得目前位置
        public int GetCurrentIndex()
        {
            return _currentIndex;
        }
    }
}