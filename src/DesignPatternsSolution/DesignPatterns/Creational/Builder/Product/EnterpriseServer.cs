
namespace Thinksoft.Patterns.Creational.Builder.Product
{
    /**
     * 產品類 (Product)：EnterpriseServer (企業級伺服器)
     */
    public class EnterpriseServer : IComputer
    {
        // 基本組件
        public string Processor { get; set; }
        public string Motherboard { get; set; }
        public string Memory { get; set; }
        public string Storage { get; set; }

        // ---- 省略 case 與 power supply 等組件 ----

        // 伺服器特有屬性
        public int RackUnits { get; set; }  // 機架單位數

        // 額外組件
        public List<string> AdditionalComponents { get; set; }
            = new List<string>();

        /**
         * 顯示電腦配置資訊
         */
        public void DisplayConfiguration()
        {
            Console.WriteLine("=== 伺服器配置 ===");
            Console.WriteLine($"處理器: {Processor ?? "未安裝"}");
            Console.WriteLine($"主機板: {Motherboard ?? "未安裝"}");
            Console.WriteLine($"記憶體: {Memory ?? "未安裝"}");
            Console.WriteLine($"儲存裝置: {Storage ?? "未安裝"}");
            Console.WriteLine($"機架單位數: {RackUnits}U");

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