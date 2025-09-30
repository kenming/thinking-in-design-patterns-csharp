namespace Thinksoft.Patterns.Creational.Builder.Product
{
    /**
     * 電腦產品介面：定義所有電腦產品共有的屬性和方法
     */
    public interface IComputer
    {
        string Processor { get; set; }
        string Motherboard { get; set; }
        string Memory { get; set; }
        string Storage { get; set; }

        // 額外組件
        List<string> AdditionalComponents { get; set; }

        /**
         * 顯示電腦配置資訊
         */
        void DisplayConfiguration();
    }
}
