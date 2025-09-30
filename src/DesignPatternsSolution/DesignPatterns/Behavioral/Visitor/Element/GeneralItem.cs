using Thinksoft.Patterns.Behavioral.Visitor.Visitor;

namespace Thinksoft.Patterns.Behavioral.Visitor.Element
{
    /**
     * The 'ConcreteElement' class.
     * 一般商品類別，代表沒有特殊屬性的標準庫存項目
     * 包含基本的商品資訊如名稱、數量和價格
     */
    public class GeneralItem : IInventoryItem
    {
        public string Name { get; set; }    // 商品名稱
        public int Quantity { get; set; }   // 商品數量
        public decimal Price { get; set; }  // 商品價格

        public GeneralItem(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
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
