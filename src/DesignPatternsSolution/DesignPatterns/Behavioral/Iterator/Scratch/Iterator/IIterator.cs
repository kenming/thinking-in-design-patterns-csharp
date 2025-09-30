namespace Thinksoft.Patterns.Behavioral.Iterator.Scratch.Iterator
{
    /**
     * The 'Iterator' Interface
     * 定義 Iterator 的操作介面
     * <T> 為泛型(generic)參數，代表各操作回傳的型別
     */
    public interface IIterator<T>
    {
        T First();      // 傳回第一個元素
        T Next();       // 移至下一個元素
        bool IsDone();  // 是否已指向最後一個元素
        T Current();    // 目前所指向的元素
    }
}
