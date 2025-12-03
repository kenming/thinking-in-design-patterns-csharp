namespace Thinksoft.Patterns.Behavioral.Memento
{
    /*
     *  The 'Memento' Class
     *  儲存購物車狀態
     *  只能被購物車本身 (Orginator) 與 CartCareTaker (管理者) 存取
     */
    public class CartMemento
    {
        // 儲存購物車內商品明細集合
        private readonly Dictionary<string, int> _items;

        public CartMemento(Dictionary<string, int> items)
        {
            // 創建深層拷貝以確保狀態不被外部修改
            _items = new Dictionary<string, int>(items);
        }

        // 取得儲存的狀態 - 返回深層拷貝保持封裝性
        public Dictionary<string, int> GetState()
        {
            return new Dictionary<string, int>(_items);
        }
    }
}