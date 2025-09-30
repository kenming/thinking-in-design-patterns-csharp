namespace Thinksoft.Patterns.Behavioral.Memento
{
    /*
     *  Act as 'Originator' role.
     *  模擬購物車 (ShoppingCart) 的商品項目加入、移除的狀態變化
     */
    public class ShoppingCart
    {
        private Dictionary<string, int> _items = new();

        // 加入商品到購物車
        public void AddItem(string item, int quantity)
        {
            if (_items.ContainsKey(item))
            {
                _items[item] += quantity;
            }
            else
            {
                _items[item] = quantity;
            }
            Console.WriteLine($"已加入 {quantity} 個 {item} 到購物車");
        }

        // 從購物車移除商品
        public void RemoveItem(string item)
        {
            if (_items.ContainsKey(item))
            {
                _items.Remove(item);
                Console.WriteLine($"已從購物車移除 {item}");
            }
        }

        // 列出購物車內容
        public void ListCart()
        {
            Console.WriteLine("📦 購物車內容: " +
                (_items.Count == 0 ? "（空）" : string.Join
                    (", ", _items.Select(i => $"{i.Key}x{i.Value}"))));
        }

        // 創建 Memento
        public CartMemento SaveState()
        {
            return new CartMemento(new Dictionary<string, int>(_items));
        }

        // 從 Memento 恢復狀態
        public void RestoreState(CartMemento memento)
        {
            _items = memento.GetState();
        }
    }
}
