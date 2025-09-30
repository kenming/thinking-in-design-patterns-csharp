using Thinksoft.Patterns.Utils;
using Thinksoft.Patterns.Creational.Builder.Model;
using Thinksoft.Patterns.Creational.Builder.Product;

namespace Thinksoft.Patterns.Creational.Builder
{
    public class BuildComputerConsole : IConsoleProgram
    {
        public void Start()
        {
            Console.WriteLine("=== 電腦組裝操作範例 ===");
            Console.WriteLine();

            BuildComputerService service = new BuildComputerService();

            // 創建遊戲電腦
            Console.WriteLine("組裝遊戲電腦：");

            // 定義遊戲電腦配置
            ComputerModel gamePCModel = CreateGamePCModel();

            // 調用 Director 封裝組裝遊戲電腦的過程
            IComputer gamePC = service.BuildComputer(gamePCModel);

            Console.WriteLine("遊戲電腦組裝完成！");
            gamePC.DisplayConfiguration();

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            // 創建伺服器
            Console.WriteLine("組裝伺服器：");

            // 定義伺服器配置
            ComputerModel serverModel = CreateServerModel();

            // 調用 Director 封裝組裝伺服器電腦的過程
            IComputer server = service.BuildComputer(serverModel);

            Console.WriteLine("伺服器組裝完成！");
            server.DisplayConfiguration();
        }

        /**
         * 創建遊戲電腦規格資料模型
         */
        private ComputerModel CreateGamePCModel()
        {
            return new ComputerModel
            {
                BuildType = ComputerType.GamePC,
                Processor = "Intel Core i9-13900K",
                Motherboard = "ASUS ROG Z790 Gaming",
                Memory = "32GB DDR5-6000 RGB",
                Storage = "2TB NVMe SSD",
                GraphicsCard = "NVIDIA RTX 4090",
                CoolingSystem = "360mm RGB液冷",
                AdditionalComponents = new List<string>
                {
                    "XBox菁英手把",
                    "遊戲鍵盤滑鼠組"
                }
            };
        }

        /**
         * 創建伺服器規格資料模型
         */
        private ComputerModel CreateServerModel()
        {
            return new ComputerModel
            {
                BuildType = ComputerType.Server,
                Processor = "Intel Xeon Platinum 8380",
                Motherboard = "Supermicro X12DPi-NT6",
                Memory = "128GB ECC DDR4-3200",
                Storage = "4x 2TB Enterprise SSD (RAID 10)",
                RackUnits = 2,  // 設置伺服器特有屬性
                AdditionalComponents = new List<string>
                {
                    "Broadcom MegaRAID 9560-16i RAID控制器",
                    "Intel X710 10Gb 四埠網路卡",
                    "伺服器機架套件",
                    "企業級備份解決方案",
                    "冗余電源系統"
                }
            };
        }
    }
}