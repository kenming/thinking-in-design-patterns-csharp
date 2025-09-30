using Thinksoft.Patterns.Behavioral.Strategy.Model;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.Strategy
{
    /**
     * 訂單處理主控台類別
     * 提供使用者操作介面，可選擇使用集中式或分散式策略模式進行測試
     */
    public class PlaceOrderConsole : IConsoleProgram
    {
        public void Start()
        {
            Console.WriteLine("訂單折扣策略模式測試程式");
            Console.WriteLine("=======================\n");

            Console.WriteLine("請選擇策略模式實作方式：");
            Console.WriteLine("1. 集中式實作 (所有折扣邏輯集中在單一類別)");
            Console.WriteLine("2. 分散式實作 (策略模式，各折扣邏輯分散在獨立類別)");
            Console.Write("\n請輸入選項 (1-2): ");

            var strategyChoice = Console.ReadLine();
            bool useDistributedStrategy = strategyChoice == "2";
            var orderService = new PlaceOrderService(useDistributedStrategy);

            Console.WriteLine($"\n已選擇 {(useDistributedStrategy ? "分散式" : "集中式")} 實作\n");
            Console.WriteLine("按任意鍵繼續...");
            Console.ReadKey();
            Console.Clear();

            while (true)
            {
                ShowMenu();
                var choice = Console.ReadLine();
                if (choice == "5") break;

                switch (choice)
                {
                    case "1":
                        TestNoDiscount(orderService);
                        break;
                    case "2":
                        TestBonusDiscount(orderService);
                        break;
                    case "3":
                        TestCouponDiscount(orderService);
                        break;
                    case "4":
                        TestHolidayDiscount(orderService);
                        break;
                }

                Console.WriteLine("\n按任意鍵繼續...，或按 '5' 結束執行...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("請選擇測試項目：");
            Console.WriteLine("1. 測試無折扣訂單");
            Console.WriteLine("2. 測試紅利點數折扣");
            Console.WriteLine("3. 測試折價券折扣");
            Console.WriteLine("4. 測試節日折扣");
            Console.WriteLine("5. 離開");
            Console.Write("\n請輸入選項: ");
        }

        static void TestNoDiscount(PlaceOrderService orderService)
        {
            Console.WriteLine("\n【測試無折扣訂單】");

            var order = CreateBaseOrderTestData();
            var expected = 990; // 商品總額(890) + 運費(100)

            var result = orderService.ProcOrder(order);

            ShowTestResult("無折扣訂單測試", expected, result.ActualAmount);
            ShowOrderDetails(order, result.ActualAmount);
        }

        static void TestBonusDiscount(PlaceOrderService orderService)
        {
            Console.WriteLine("\n【測試紅利點數折扣】");

            // 測試案例 1: 1000元以內，扣除50點
            var order1 = CreateBaseOrderTestData();
            order1.Discount.DiscountType = OrderDiscountType.Bonus;
            order1.Discount.Bonus = 50;
            var result1 = orderService.ProcOrder(order1);

            ShowTestResult("紅利點數折扣 (50點)", 940, result1.ActualAmount);
            ShowOrderDetails(order1, result1.ActualAmount);
        }

        static void TestCouponDiscount(PlaceOrderService orderService)
        {
            Console.WriteLine("\n【測試折價券折扣】");

            // 測試案例: A開頭折扣碼，抵100元
            var order = CreateBaseOrderTestData();
            order.Discount.DiscountType = OrderDiscountType.Coupon;
            order.Discount.Coupon = "A12345";
            var result = orderService.ProcOrder(order);

            ShowTestResult("折價券折扣 (A開頭)", 890, result.ActualAmount);
            ShowOrderDetails(order, result.ActualAmount);
        }

        static void TestHolidayDiscount(PlaceOrderService orderService)
        {
            Console.WriteLine("\n【測試節日折扣】");

            // 測試案例: 母親節折扣
            var order = CreateBaseOrderTestData();
            order.Discount.DiscountType = OrderDiscountType.Holiday;
            order.Discount.Holiday = "母親節";
            var result = orderService.ProcOrder(order);

            ShowTestResult("節日折扣 (母親節)", 990, result.ActualAmount);
            ShowOrderDetails(order, result.ActualAmount);
        }

        static OrderModel CreateBaseOrderTestData()
        {
            return new OrderModel
            {
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "[書]股票作手回憶錄", Quantity = 1, UnitPrice = 350 },
                    new OrderItem { Name = "[文具]微笑原子筆", Quantity = 2, UnitPrice = 30 },
                    new OrderItem { Name = "[玩具]抒壓魔方", Quantity = 3, UnitPrice = 160 }
                },
                Discount = new OrderDiscount
                {
                    DiscountType = OrderDiscountType.None
                },
                ShippingFee = 100
            };
        }

        static void ShowTestResult(string testName, int expected, int actual)
        {
            Console.WriteLine($"\n測試案例：{testName}");
            Console.WriteLine($"預期金額: {expected}");
            Console.WriteLine($"實際金額: {actual}");
            Console.WriteLine($"測試結果: {(expected == actual ? "通過" : "失敗")}");
        }

        static void ShowOrderDetails(OrderModel order, int actualAmount)
        {
            Console.WriteLine("\n訂單明細：");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"- {item.Name} x {item.Quantity} (單價: {item.UnitPrice:C})");
            }

            var itemsTotal = order.Items.Sum(item => item.UnitPrice * item.Quantity);
            Console.WriteLine($"\n商品總額: {itemsTotal:C}");
            Console.WriteLine($"運費: {order.ShippingFee:C}");

            if (order.Discount.DiscountType != OrderDiscountType.None)
            {
                var discount = itemsTotal + order.ShippingFee - actualAmount;
                Console.WriteLine($"折扣金額: {discount:C}");
            }

            Console.WriteLine($"實付金額: {actualAmount:C}");
        }
    }
}