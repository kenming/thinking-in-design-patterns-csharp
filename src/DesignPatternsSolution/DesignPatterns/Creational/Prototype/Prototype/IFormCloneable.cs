namespace Thinksoft.Patterns.Creational.Prototype.Prototype
{
    /*     
     * The 'Prototype' Interface
     * 制定具有複合結構的表單物件 可以制定自我複製的操作介面
     * <T> 為泛型 (generic) 型別，代表複製型別
     */
    public interface IFormCloneable<T>
    {
        /*
         * 定義自我複製的操作         
         * <return>回傳所複製的泛型型別</return>
         */
        T Clone();
    }
}
