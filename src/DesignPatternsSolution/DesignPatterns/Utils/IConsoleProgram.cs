namespace Thinksoft.Patterns.Utils
{
    /*
     * <summary>
     *  定義一個通用的 Console 程式介面。
     *  所有實作此介面的類別都需要實作 Start 方法，以執行其主要功能。
     * </summary>
     */
    public interface IConsoleProgram
    {
        /*
         * <summary>
         *  啟動 Console 程式的主要執行邏輯。
         *  實作類別需在此方法中實現具體的功能。
         * </summary>
         */
        void Start();
    }
}
