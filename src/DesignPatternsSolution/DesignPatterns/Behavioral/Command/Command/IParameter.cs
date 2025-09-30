namespace Thinksoft.Patterns.Behavioral.Command.Command
{
    /**
     * 'Command Parameter' - 參數介面
     * 允許設置命令的參數，<T> 為指定的參數型別
     */
    public interface IParameter<T>
    {
        // 設置屬性值
        void SetProperty(T value);

        // 獲取屬性值，<T> 為泛型型別
        T GetProperty();
    }
}
