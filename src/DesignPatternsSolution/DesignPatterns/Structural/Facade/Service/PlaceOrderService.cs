using Thinksoft.Patterns.Structural.Facade.Dao;
using Thinksoft.Patterns.Structural.Facade.Entity;
using Thinksoft.Patterns.Structural.Facade.Model;

namespace Thinksoft.Patterns.Structural.Facade.Service
{
    /*
     *  The 'Facade' Class.
     *  Service 類別為應用邏輯層的進入點 (entry point)，
	 *  負責接收來自展示層所傳入的請求，控制內部各物件的協作處理，
     *  並整合處理結果回傳至展示層。
     *  
     *  Service 負責：
     *    領域控制邏輯 (Domain Control Logic)
	 *    以及封裝：
     *      1. 資料存取 (Data Access)
     *      2. 業務邏輯 (Business Logic) 運算
     */
    public class PlaceOrderService
    {
        private ProductDao _productDao = new ProductDao();
        private OrderContext _orderContext = new OrderContext();
        private OrderDao _orderDao = new OrderDao();

        /**
         * 取得所有商品
         * @return 商品列表
         */
        public List<Product> GetAllProducts()
        {
            // 委派給 Dao 物件取得商品清單
            return _productDao.GetAllProducts();
        }

        /**
         * 處理訂單，包括計算折扣和最終金額
         * @param order 訂單實例
         * @param couponCode 折扣碼
         * @return 處理後的訂單實例
         */
        public Order ProcessOrder(Order order, string couponCode)
        {
            // 設定折扣碼
            order.CouponCode = couponCode;

            // 委派給 Entity (Business) 物件處理業務邏輯運算
            order.DiscountAmount = _orderContext.CalculateDiscount(order);

            // 計算實付金額
            order.ActualAmount = order.TotalItemsAmount + 
                order.ShippingFee - order.DiscountAmount;

            return order;
        }

        /**
         * 儲存訂單
         * @param order 訂單實例
         * @return 處理結果訊息
         */
        public string SaveOrder(Order order)
        {
            // 委派給 Dao 物件儲存訂單
            bool success = _orderDao.SaveOrder(order);

            if (success)
            {
                return "訂單已成功儲存，即將安排出貨...";
            }
            else
            {
                return "訂單處理失敗，請稍後再試！";
            }
        }
    }
}
