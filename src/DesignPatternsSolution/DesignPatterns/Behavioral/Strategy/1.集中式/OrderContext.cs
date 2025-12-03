using Thinksoft.Patterns.Behavioral.Strategy.Model;

namespace Thinksoft.Patterns.Behavioral.Strategy.Centralized
{
    /**
     * 集中式訂單處理上下文類別
     * 所有折扣計算邏輯集中在單一類別中
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
            int _itemsAmount = 0;                // 購買商品總額
            int _discountAmount = 0;             // 折扣金額

            // for 每一筆訂單的商品明細，計算分項金額並加總訂購總額
            foreach (OrderItem _item in orderModel.Items)
            {
                int subtotal;

                subtotal = _item.Quantity * _item.UnitPrice;
                _item.SubTotal = subtotal;
                _itemsAmount += subtotal;
            }
            orderModel.TotalItemsAmount = _itemsAmount;   // 設定商品總額
            // 設定未扣除折扣前的訂購總額
            orderModel.ActualAmount = _itemsAmount;
            // 設定折扣的運費為預設的訂購運費
            orderModel.Discount.ShippingDiscount = orderModel.ShippingFee;

            // 依據折扣類型，計算折扣費用
            switch (orderModel.Discount.DiscountType)
            {

                case OrderDiscountType.None:       // No Discount
                    break;

                case OrderDiscountType.Bonus:      // Bonus 折扣
                                                   // 根據訂購總額，依序扣除 Bonus 點數費用
                                                   // 1. 1000元(含)以下，折抵最大點數：50
                                                   // 2. 5000元(含)以下，折抵最大點數：300
                                                   // 3. 5000元以上，折抵最大點數：1000

                    {
                        int bonus = orderModel.Discount.Bonus;      // 傳入 Customer 擁有的點數                    

                        if (_itemsAmount <= 1000)
                            _discountAmount = Math.Min(bonus, 50);
                        else if (_itemsAmount <= 5000)
                            _discountAmount = Math.Min(bonus, 300);
                        else
                            _discountAmount = Math.Min(bonus, 1000);

                        orderModel.Discount.DiscountAmount = _discountAmount;
                        break;
                    }

                case OrderDiscountType.Coupon:      // Coupon 折扣碼
                                                    // 'A' 開頭折扣碼，抵 100 元
                                                    // 'B' 開頭折扣碼，抵 50 元
                                                    // 'C' 開頭折扣碼，抵 20 元
                    {
                        string firstCharCode =
                        orderModel.Discount.Coupon.Substring(0, 1);

                        switch (firstCharCode)
                        {
                            case "A":
                                _discountAmount = 100;
                                break;
                            case "B":
                                _discountAmount = 50;
                                break;
                            case "C":
                                _discountAmount = 20;
                                break;
                        }
                        orderModel.Discount.DiscountAmount = _discountAmount;
                        break;
                    }

                case OrderDiscountType.Holiday:
                    {
                        switch (orderModel.Discount.Holiday)
                        {
                            case "母親節":     // 滿千送百
                                _discountAmount = (int)(_itemsAmount / 1000) * 100;
                                orderModel.Discount.DiscountAmount = _discountAmount;
                                break;
                            case "光棍節":     // 免運費
                                orderModel.Discount.ShippingDiscount = 0;
                                break;
                        }
                        break;
                    }
            }

            // 訂購總額 = 訂購總額 - 折扣金額 + 運費金額
            orderModel.ActualAmount += -(orderModel.Discount.DiscountAmount) +
                orderModel.Discount.ShippingDiscount;  // 折扣後的運費

            return orderModel;
        }
    }
}