using Thinksoft.Patterns.Creational.Prototype.Prototype;

namespace Thinksoft.Patterns.Creational.Prototype.Model
{
    /*
     * 'Concrete' Prototype Class
     *  購物車資料類別
     */
    public class ShoppingCart : IFormCloneable<ShoppingCart>
    {
        public List<CartItem> Items { get; set; }  // 購物車明細
        public string CouponCode { get; set; }     // 優惠代碼,只供測試
        public int TotalAmount {                   // 購物車總額
            get {
                if (Items == null) return 0;
                else
                {
                    return Items.Sum(x => x.Subtotal);
                }                
            }
        }

        // The Deep (深層) Copy
        public ShoppingCart Clone()
        {
            ShoppingCart cart = new();
            cart.Items = new List<CartItem>();
            foreach (var item in this.Items)
            {
                // 使用 CartItem 的 Clone() 複製實例
                cart.Items.Add(item.Clone());
            }
            cart.CouponCode = this.CouponCode;
            return cart;
        }
    }
}
