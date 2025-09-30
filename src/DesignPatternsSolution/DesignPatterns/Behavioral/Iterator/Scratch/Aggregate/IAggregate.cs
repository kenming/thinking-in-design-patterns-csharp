using Thinksoft.Patterns.Behavioral.Iterator.Scratch.Iterator;

namespace Thinksoft.Patterns.Behavioral.Iterator.Scratch.Aggregate
{
    /**
     * The 'Aggregate' Interface
     * 定義創建 Iterator<T> 的操作介面
     * <T> 為泛型(generic)參數，代表Iterator所宣告的型別
     */
    public interface IAggregate<T>
    {
        /**
         * 創建 Iterator 的操作
         * <return>IIterator 泛型型別</return>
         */
        IIterator<T> CreateIterator();
    }
}
