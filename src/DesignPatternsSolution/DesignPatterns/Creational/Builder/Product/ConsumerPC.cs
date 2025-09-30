namespace Thinksoft.Patterns.Creational.Builder.Product
{
    /**
     * 產品類 (Product)：ConsumerPC (消費級電腦)
     */
    public class ConsumerPC : IComputer
    {
        // 基本核心組件
        public string Processor { get; set; }
        public string Motherboard { get; set; }
        public string Memory { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }
        public string CoolingSystem { get; set; }

        // ---- 省略 case 與 power supply 等組件 ----

        // 額外組件
        public List<string> AdditionalComponents { get; set; }
            = new List<string>();

        /**
         * 顯示電腦配置資訊
         */
        public void DisplayConfiguration()
        {
            Console.WriteLine("=== 遊戲電腦配置 ===");
            Console.WriteLine($"處理器: {Processor ?? "未安裝"}");
            Console.WriteLine($"主機板: {Motherboard ?? "未安裝"}");
            Console.WriteLine($"記憶體: {Memory ?? "未安裝"}");
            Console.WriteLine($"儲存裝置: {Storage ?? "未安裝"}");
            Console.WriteLine($"顯示卡: {GraphicsCard ?? "未安裝"}");
            Console.WriteLine($"冷卻系統: {CoolingSystem ?? "未安裝"}");

            if (AdditionalComponents.Count > 0)
            {
                Console.WriteLine("額外組件:");
                foreach (var component in AdditionalComponents)
                {
                    Console.WriteLine($"- {component}");
                }
            }
        }
    }
}