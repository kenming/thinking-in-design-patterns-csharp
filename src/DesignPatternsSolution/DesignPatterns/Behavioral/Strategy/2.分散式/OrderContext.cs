using Thinksoft.Patterns.Behavioral.Strategy.Model;

namespace Thinksoft.Patterns.Behavioral.Strategy.Distributed
{
    /**
     * 分散式訂單處理上下文類別
     * 使用策略模式，將不同折扣邏輯分散在各個策略類別中
     */
    public class OrderContext
    {
        /**
         * 計算訂購總額
         * 依所傳入的折扣類型，以及購買商品總額，計算實際購買的總額
         * @param orderModel 訂單資料物件
         * @return 處理後的訂單資料物件
         */
        public OrderModel CalcOrderTotalPrice(OrderModel orderModel)
        {
            // 計算訂購商品總額與商品分項金額
            orderModel = CalcOrderAmountNoDiscount(orderModel);
            // 設定折扣的運費為預設的訂購運費
            orderModel.Discount.ShippingDiscount = orderModel.ShippingFee;

            // 依據折扣類型計算商品折扣金額
            orderModel.Discount = this.CalcOrderDiscount(orderModel.Discount, orderModel.ActualAmount);

            // 訂購總額 = 訂購總額 - 折扣金額 + 運費金額
            orderModel.ActualAmount += -(orderModel.Discount.DiscountAmount) +
                orderModel.Discount.ShippingDiscount;  // 折扣後的運費
            return orderModel;
        }

        /**
         * 計算訂購商品總額與分項金額
         * @param orderModel 訂單資料物件
         * @return 處理後的訂單資料物件
         */
        private OrderModel CalcOrderAmountNoDiscount(OrderModel orderModel)
        {
            int _orderAmount = 0;

            // for 每一筆訂單的商品明細，計算分項金額並加總訂購總額
            foreach (OrderItem _item in orderModel.Items)
            {
                int subtotal;

                subtotal = _item.Quantity * _item.UnitPrice;
                _item.SubTotal = subtotal;
                _orderAmount += subtotal;
            }
            orderModel.ActualAmount = _orderAmount;       // 設定未扣除折扣前的訂購總額

            return orderModel;
        }

        /**
         * 根據折扣類型選擇並應用對應的折扣策略
         * @param orderDiscount 折扣資料物件
         * @param orderAmount 訂單金額
         * @return 處理後的折扣資料物件
         */
        private OrderDiscount CalcOrderDiscount(OrderDiscount orderDiscount, int orderAmount)
        {
            // 依據折扣類型，計算折扣費用
            switch (orderDiscount.DiscountType)
            {
                case OrderDiscountType.None:     // No Discount
                    break;

                case OrderDiscountType.Bonus:
                    {
                        // new BonusDiscount 具體物件，回傳 IDiscountPrice 介面
                        IDiscountPrice _bonusDiscount = new BonusDiscount();
                        // 透過介面的公有操作，但執行運算的邏輯由該具體物件實作
                        orderDiscount = _bonusDiscount.CalcDiscountAmount(orderDiscount, orderAmount);

                        break;
                    }

                case OrderDiscountType.Coupon:
                    {
                        // new CouponDiscount 具體物件，回傳 IDiscountPrice 介面
                        IDiscountPrice _couponDiscount = new CouponDiscount();
                        // 透過介面的公有操作，但執行運算的邏輯由該具體物件實作
                        orderDiscount = _couponDiscount.CalcDiscountAmount(orderDiscount, orderAmount);

                        break;
                    }
                case OrderDiscountType.Holiday:
                    {
                        // new HolidayDiscount 具體物件，回傳 IDiscountPrice 介面
                        IDiscountPrice _holidayDiscount = new HolidayDiscount();
                        // 透過介面的公有操作，但執行運算的邏輯由該具體物件實作
                        orderDiscount = _holidayDiscount.CalcDiscountAmount(orderDiscount, orderAmount);

                        break;
                    }
            }

            return orderDiscount;
        }
    }
}