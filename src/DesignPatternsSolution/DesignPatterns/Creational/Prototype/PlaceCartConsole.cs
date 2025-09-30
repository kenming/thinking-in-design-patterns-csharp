using System.Diagnostics;
using Thinksoft.Patterns.Creational.Prototype.Model;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Creational.Prototype
{
    public class PlaceCartConsole : IConsoleProgram
    {
        public void Start()
        {   
            // 創建原始購物車資料物件
            ShoppingCart cart1 = CreateSampleCart();
            Console.WriteLine("原始購物車資料 (Original Cart)：");
            DisplayCart(cart1);

            // 使用 Clone() 方法複製 cart1 購物車資料
            ShoppingCart cart2 = cart1.Clone();
            Console.WriteLine("\n複製的購物車 (Clone cart)：");
            DisplayCart(cart2);

            // 更改 Clone 後的 cart2 購物車資料
            Console.WriteLine("\n修改複製後的購物車 (增加新商品)：");
            cart2.Items.Add(new CartItem { Name = "微笑鋼筆", UnitPrice = 1200, Qty = 1 });
            cart2.CouponCode = "BlackMirror1224";            
            DisplayCart(cart2);
        }

        // Creating an Instance of ShoppingCart Class
        private ShoppingCart CreateSampleCart()
        {
            return new ShoppingCart()
            {
                CouponCode = "Ivy1018",
                Items = new List<CartItem> {
                    new CartItem { Name = "鈦合金剪刀", Qty = 1, UnitPrice = 300},
                    new CartItem { Name = "鈦合金美工刀", Qty = 2, UnitPrice = 150},
                    new CartItem { Name = "鈦合金刀片", Qty = 4, UnitPrice = 80}
                }
            };
        }

        private void DisplayCart(ShoppingCart cart)
        {
            Console.WriteLine("購物車內容 ： ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("商品明細：");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"　名稱 : {item.Name}" +
                                  $", 單價 : {item.UnitPrice}" +
                                  $", 數量 : {item.Qty}" +
                                  $", 分項金額 : {item.Subtotal}");                
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Coupon 折扣碼 : {cart.CouponCode}");
            Console.WriteLine($"購物車總額 : {cart.TotalAmount}");
        }
    }
}
