using Thinksoft.Patterns.Behavioral.Visitor.Visitor;

namespace Thinksoft.Patterns.Behavioral.Visitor.Element
{
    /**
     * The 'Element' interface.
     * 制定可以讓 Visitor 物件訪查的元素介面
     */
    public interface IInventoryItem
    {
        /**
         * 接受訪問者的方法，實現 Visitor 模式的核心機制
         * @param visitor 要接受的訪問者物件
         */
        void Accept(IInventoryVisitor visitor);
    }
}
