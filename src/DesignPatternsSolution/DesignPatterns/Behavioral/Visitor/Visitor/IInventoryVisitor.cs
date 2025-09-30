using Thinksoft.Patterns.Behavioral.Visitor.Element;

namespace Thinksoft.Patterns.Behavioral.Visitor.Visitor
{
    /**
     * The 'Visitor' interface.
     * 定義庫存訪問者的介面
     * 為每種具體元素類型提供對應的 Visit 方法
     */
    public interface IInventoryVisitor
    {
        /**
         * 訪問一般商品的方法
         * @param item 要訪問的一般商品物件
         */
        void Visit(GeneralItem item);

        /**
         * 訪問易碎品的方法
         * @param item 要訪問的易碎品物件
         */
        void Visit(FragileItem item);
    }
}
