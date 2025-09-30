using Thinksoft.Patterns.Behavioral.Visitor.Visitor;

namespace Thinksoft.Patterns.Behavioral.Visitor.Element
{
    /**
     * The 'ConcreteElement' class.
     * 易碎品類別，代表具有保存期限的特殊庫存項目
     * 除了基本商品資訊外，還包含到期日資訊
     */
    public class FragileItem : IInventoryItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }    // 商品到期日

        public FragileItem(string name, int quantity, 
                decimal price, DateTime expiryDate)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            ExpiryDate = expiryDate;
        }

        /**
         * 實作 IInventoryItem 介面的 Accept 方法
         * 將自身 (self) 傳遞給訪問者的對應方法
         * @param visitor 要接受的訪問者物件
         */
        public void Accept(IInventoryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
