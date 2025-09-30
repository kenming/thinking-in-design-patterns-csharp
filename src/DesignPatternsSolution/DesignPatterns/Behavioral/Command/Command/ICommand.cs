namespace Thinksoft.Patterns.Behavioral.Command.Command
{
    /**
     * 'Command' Interface.
     * 定義所有命令的基本操作
     */
    public interface ICommand
    {
        // 執行命令的操作
        string Execute();

        // 撤銷命令的操作 (擴展功能)
        string Undo();

        // 取得命令描述
        string GetDescription();
    }
}
