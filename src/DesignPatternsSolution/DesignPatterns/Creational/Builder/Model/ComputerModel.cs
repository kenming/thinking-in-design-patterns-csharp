namespace Thinksoft.Patterns.Creational.Builder.Model
{
    /**
     * 電腦規格模型：用於存儲電腦配置信息
     * 其中 'BuildType' 可以是遊戲電腦和伺服器電腦
     * 
     * 設計說明：
     * 1. 此模型包含所有可能類型的電腦的屬性
     * 2. 並非所有屬性對所有類型的電腦都有意義
     * 3. Director 和具體建造者會根據類型決定如何使用這些屬性
     */
    public class ComputerModel
    {
        public ComputerType BuildType { get; set; }
        public string Processor { get; set; }
        public string Motherboard { get; set; }
        public string Memory { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }
        public string CoolingSystem { get; set; }
        public int RackUnits { get; set; }  // 伺服器特有屬性：機架單位數
        public List<string> AdditionalComponents { get; set; }
    }
}