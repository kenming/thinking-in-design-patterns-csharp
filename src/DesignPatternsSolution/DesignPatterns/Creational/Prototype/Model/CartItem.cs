using Thinksoft.Patterns.Creational.Prototype.Prototype;

namespace Thinksoft.Patterns.Creational.Prototype.Model
{
    /*
     * 'Concrete' Prototype Class
     *  購物車明細資料類別
     */    
    public class CartItem : IFormCloneable<CartItem>
    {
        public string Name {  get; set; }           // 商品
        public int UnitPrice { get; set; }          // 單價
        public int Qty { get; set; }                // 數量
        public int Subtotal                         // 分項金額
            { get { return UnitPrice * Qty; } }

        // The Shallow(淺層) Copy
        public CartItem Clone()
        {
            // 直接使用 .NET 內建的淺層複製方法複製物件
            return (CartItem)MemberwiseClone();
        }
    }
}
