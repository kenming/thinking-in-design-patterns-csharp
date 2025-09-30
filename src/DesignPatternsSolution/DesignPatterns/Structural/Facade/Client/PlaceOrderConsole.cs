using Thinksoft.Patterns.Structural.Facade.Model;
using Thinksoft.Patterns.Structural.Facade.Service;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Structural.Facade.Client
{
    /*
     *  提供使用者的圖形界面 (GUI, Graphic User Interface)
     *  在系統分層架構位於 "展示層 (presentation tier)"
     *  Console, Windows Form, Web Page/Controller 均為展示層
     *  展示層僅接收使用者 "輸入" 的表單資訊，然後交由應用邏輯層的 Facade 物件
     *  (Service) 處理資料存取與邏輯運算等，再將處理後的結果 "呈現" 給使用者。
     */
    public class PlaceOrderConsole : IConsoleProgram
    {
        private PlaceOrderService _orderService = new PlaceOrderService();
        private List<Product> _products = new List<Product>();
        private Order _currentOrder;

        public void Start()
        {
            Console.WriteLine("===== 訂購系統示範 (Facade Pattern) =====\n");

            // 1. 顯示商品列表
            Console.WriteLine("1. 商品列表：");
            _products = _orderService.GetAllProducts();
            DisplayProducts();

            // 2. 建立訂單
            Console.WriteLine("\n2. 建立訂單：");
            _currentOrder = CreateSampleOrder();
            DisplayOrder(_currentOrder);

            // 3. 應用折扣碼
            Console.WriteLine("\n3. 輸入折扣碼 (1688 或 NoFee)：");
            string couponCode = GetCouponCode();
            _currentOrder = _orderService.ProcessOrder(_currentOrder, couponCode);

            // 4. 顯示最終訂單
            Console.WriteLine("\n4. 訂單處理結果：");
            DisplayOrder(_currentOrder);

            // 5. 提交訂單
            Console.WriteLine("\n5. 訂單提交結果：");
            string result = _orderService.SaveOrder(_currentOrder);
            Console.WriteLine(result);
        }

        /* 顯示購買商品列表
         * 格式化說明：
         * - 所有表格輸出使用固定寬度左對齊格式
         * - 負數表示左對齊，數字表示欄位寬度
         * - 如：商品編號(8)、商品名稱(15)、價格(8)、描述(20)
         */
        private void DisplayProducts()
        {
            // 輸出表格標題
            Console.WriteLine($"{"商品編號",-8}{"商品名稱",-15}{"價格",-8}{"描述",-20}");
            // 輸出分隔線
            Console.WriteLine(new string('-', 50));
            foreach (var product in _products)
            {
                Console.WriteLine($"{product.Id,-8}{product.Name,-15}" +
                    $"{product.Price,-8}{product.Description,-20}");
            }
        }

        // 模擬從表單畫面所輸入的購買商品資訊
        private Order CreateSampleOrder()
        {
            var orderItems = new List<OrderItem>
          {
              new OrderItem { IitemId = "001", Name = _products[0].Name, 
                  UnitPrice = _products[0].Price, Quantity = 1 },
              new OrderItem { IitemId = "005", Name = _products[4].Name, 
                  UnitPrice = _products[4].Price, Quantity = 2 },
              new OrderItem { IitemId = "004", Name = _products[3].Name, 
                  UnitPrice = _products[3].Price, Quantity = 12 }
          };

            return new Order
            {
                OrderItems = orderItems,
                ShippingFee = 100,
                CouponCode = ""
            };
        }

        /* 顯示訂購商品資訊
         * 格式化說明：
         * - 所有表格輸出使用固定寬度左對齊格式
         * - 負數表示左對齊，數字表示欄位寬度
         * - 如：商品名稱(-15)、單價(-8)、數量(-8)、數量(-8)
         */
        private void DisplayOrder(Order order)
        {
            Console.WriteLine($"{"商品名稱",-15}{"單價",-8}{"數量",-8}{"數量",-8}");
            Console.WriteLine(new string('-', 50));
            foreach (var item in order.OrderItems)
            {
                Console.WriteLine($"{item.Name,-15}{item.UnitPrice,-8}" +
                    $"{item.Quantity,-8}{item.SubTotal,-8}");
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"商品總額：",-24}{order.TotalItemsAmount,-8}");
            Console.WriteLine($"{"運費：",-24}{order.ShippingFee,-8}");

            if (order.DiscountAmount > 0)
            {
                Console.WriteLine($"折扣金額 ({order.CouponCode})：" +
                    $"{new string(' ', 8)}{order.DiscountAmount,-8}");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"{"實付金額：",-24}{order.ActualAmount,-8}");
            }
        }

        // 輸入折扣碼
        private string GetCouponCode()
        {
            Console.Write("請輸入折扣碼：");
            return Console.ReadLine();
        }
    }
}