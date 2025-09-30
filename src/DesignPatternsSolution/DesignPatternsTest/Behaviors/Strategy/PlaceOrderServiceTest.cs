using Thinksoft.Patterns.Behavioral.Strategy;
using Thinksoft.Patterns.Behavioral.Strategy.Model;

namespace DesignPatternsTest.Behaviors.Strategy
{
    [TestClass()]
    public class PlaceOrderServiceTest
    {
        // 宣告單元測試標的類別參考變數
        private PlaceOrderService orderService;

        [TestInitialize]
        // 初始環境設定。執行每一個 Test Method 之前，會執行本方法一次。
        public void Setup()
        {            
            orderService = new PlaceOrderService();
        }

        [TestMethod()]
        [Description("測試訂單總金額計算 - 無折扣")]
        public void TestTotalAmountNoDiscount()
        {
            // Act
            int Expected = 990;     // 期望值 - 商品總額(890) + 運費(100)
            int Actual;             // 實際運算值

            // Action
            // 取得實際運算後的訂購總額
            Actual = orderService.ProcOrder(createBaseOrderTestData()).ActualAmount;

            // Assert (斷言比對)
            Assert.AreEqual(Expected, Actual);
        }

        #region Bonus Discount Test Cases
        [TestMethod()]
        [Description("測試訂單折扣計算 - 紅利點數折扣")]
        public void TestTotalAmountWithBonusDiscount()
        {
            this.testBonusDiscountUnder1000();
            this.testBonusDiscountBetween1000_5000();
            this.testBonusDiscountAbove5000();
        }

        //  訂購總額1000元以內，扣除點數 50
        private void testBonusDiscountUnder1000() {
            // Act
            int Expected = 940;     // 期望值 - (890 + 100) - 50 (最高可折抵50點)
            int Actual;             // 實際運算值

            // Action
              // 設定測試資料，指定折扣類型為 Bouns，並取得現有 User Bonus 點數
            OrderModel orderModel = createBaseOrderTestData();
            orderModel.Discount.DiscountType = OrderDiscountType.Bonus;
            // 實際擁有100點，但1000元以下訂單最高折抵50點
            orderModel.Discount.Bonus = 100;

            // 取得實際運算後的訂購總額
            Actual = orderService.ProcOrder(orderModel).ActualAmount;

            // Assert (斷言比對)
            Assert.AreEqual(Expected, Actual);
        }

        //  訂購總額1000-5000元以內，扣除點數 300
        private void testBonusDiscountBetween1000_5000()
        {
            // Act
            int Expected = 1750;     // 期望值 - (1890 + 100) - 240
            int Actual;             // 實際運算值

            // Action
            // 設定測試資料，指定折扣類型為 Bouns，並取得現有 User Bonus 點數
            var orderModel = CreateOrderWithAmount1000To5000();
            orderModel.Discount = new OrderDiscount
            {
                DiscountType = OrderDiscountType.Bonus,
                Bonus = 240  // 1000-5000元訂單，最高折抵300點
            };

            // 取得實際運算後的訂購總額
            Actual = orderService.ProcOrder(orderModel).ActualAmount;

            // Assert (斷言比對)
            Assert.AreEqual(Expected, Actual);
        }

        //  訂購總額1000-5000元以內，扣除點數 1000
        private void testBonusDiscountAbove5000()
        {
            // Act
            int Expected = 4490;     // 期望值 - (5390 + 100) - 1000
            int Actual;              // 實際運算值

            // Action
            // 設定測試資料，指定折扣類型為 Bouns，並取得現有 User Bonus 點數
            var orderModel = CreateOrderWithAmountAbove5000();
            orderModel.Discount = new OrderDiscount
            {
                DiscountType = OrderDiscountType.Bonus,
                Bonus = 1200  // 5000元以上訂單，最高折抵1000點
            };

            // 取得實際運算後的訂購總額
            Actual = orderService.ProcOrder(orderModel).ActualAmount;

            // Assert (斷言比對)
            Assert.AreEqual(Expected, Actual);
        }

        #endregion

        #region Prepare TestData Methods
        // 建立訂單基本測試資料 (總金額890元)
        private static OrderModel createBaseOrderTestData()
        {
            return new OrderModel()
            {
                Items = [
                    new() { Name = "[書]股票作手回憶錄", Quantity = 1, UnitPrice = 350 },
                    new() { Name = "[文具]微笑原子筆", Quantity = 2, UnitPrice = 30 },
                    new() { Name = "[玩具]抒壓魔方", Quantity = 3, UnitPrice = 160 }
                ],
                Discount = new OrderDiscount()
                {
                    DiscountType = OrderDiscountType.None
                },
                ShippingFee = 100   // 運費
            };
        }

        /// <summary>
        /// 建立訂單測試資料 (總金額1890元)
        /// </summary>
        private static OrderModel CreateOrderWithAmount1000To5000()
        {
            var orderData = createBaseOrderTestData();
            orderData.Items.Add(new OrderItem
            {
                Name = "[寵物]狗堡貝毛衣",
                Quantity = 1,
                UnitPrice = 1000
            });
            return orderData;
        }

        /// <summary>
        /// 建立訂單測試資料 (總金額5390元)
        /// </summary>
        private static OrderModel CreateOrderWithAmountAbove5000()
        {
            var orderDat = createBaseOrderTestData();
            orderDat.Items.AddRange(new[]
            {
                new OrderItem { Name = "[寵物]狗堡貝毛衣", Quantity = 1, UnitPrice = 1000 },
                new OrderItem { Name = "[3C]無線充電器", Quantity = 2, UnitPrice = 1750 }
            });
            return orderDat;
        }

        #endregion

        #region Coupon Discount Test Cases
        [TestMethod()]
        [Description("測試訂單總金額計算 - 使用 Coupon 折扣碼")]
        public void TestTotalAmountWithCoupon()
        {
            // Act
            int Expected;              // 期望值
            int Actual;                // 實際運算值

            // Action
              // 設定測試資料，指定折扣類型為 Coupon，並取得現有 Coupon 折扣碼
            OrderModel orderModel = createBaseOrderTestData();
            orderModel.Discount.DiscountType = OrderDiscountType.Coupon;

            // Test by 'A' 開頭折扣碼
            {
                Expected = 890;     // (890+100)-100
                orderModel.Discount.Coupon = "A01234";              
                Actual = orderService.ProcOrder(orderModel).ActualAmount;
                Assert.AreEqual(Expected, Actual);
            }
            // Test by 'B' 開頭折扣碼
            {
                Expected = 940;     // (890+100)-50
                orderModel.Discount.Coupon = "B62237";
                Actual = orderService.ProcOrder(orderModel).ActualAmount;
                Assert.AreEqual(Expected, Actual);
            }
            // Test by 'C' 開頭折扣碼
            {
                Expected = 970;     // (890+100)-20
                orderModel.Discount.Coupon = "C16248";
                Actual = orderService.ProcOrder(orderModel).ActualAmount;
                Assert.AreEqual(Expected, Actual);
            }
        }
        #endregion

        #region Holiday Discount Test Cases
        [TestMethod()]
        [Description("測試訂單總金額計算 - 使用 Holdiday 折扣")]        
        public void TestTotalAmountWithHoliday()
        {
            this.testHolidayForMotherDay();
            this.testHolidayForSingleDay();
        }

        // 測試母親節折扣優惠
        private void testHolidayForMotherDay()
        {
            // Act
            int Expected = 33400;     // 期望值 (36000+100)-3600 = 33400
                                         // 商品總額 (890+36010) = 36000
                                         // 折扣金額 = 36000/10 = 3600
            int Actual;               // 實際運算值

            // Action
            // 設定測試資料，指定折扣類型為 Bouns，並取得現有 User Bonus 點數
            OrderModel orderModel = createBaseOrderTestData();
            // 新增一筆商品
            orderModel.Items.Add(new OrderItem()
            {
                Name = "[家電]電動按摩椅", Quantity = 1, UnitPrice = 36010
            });
            // 設定測試資料，指定折扣類型為 Holiday，並設定節日名稱
            orderModel.Discount.DiscountType = OrderDiscountType.Holiday;
            orderModel.Discount.Holiday = "母親節";    // 節日名稱

            // 取得實際運算後的訂購總額
            Actual = orderService.ProcOrder(orderModel).ActualAmount;

            // Assert (斷言比對)
            Assert.AreEqual(Expected, Actual);
        }

        // 測試光棍節折扣優惠
        private void testHolidayForSingleDay()
        {
            // Act
            int Expected = 13900;     // 期望值 (890+13010)
            int Actual;               // 實際運算值

            // Action
            // 設定測試資料，指定折扣類型為 Bouns，並取得現有 User Bonus 點數
            OrderModel orderModel = createBaseOrderTestData();
            // 新增一筆商品
            orderModel.Items.Add(new OrderItem()
            {
                Name = "[電玩]Steam Deck 掌機", Quantity = 1, UnitPrice = 13010
            });
            // 設定測試資料，指定折扣類型為 Holiday，並設定節日名稱
            orderModel.Discount.DiscountType = OrderDiscountType.Holiday;
            orderModel.Discount.Holiday = "光棍節";    // 節日名稱            

            // 取得實際運算後的訂購總額
            Actual = orderService.ProcOrder(orderModel).ActualAmount;

            // Assert (斷言比對)
            Assert.AreEqual(Expected, Actual);
        }
        #endregion
    }
}