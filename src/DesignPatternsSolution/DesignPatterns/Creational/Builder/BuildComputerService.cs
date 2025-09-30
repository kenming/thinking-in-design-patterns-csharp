using Thinksoft.Patterns.Creational.Builder.Builder;
using Thinksoft.Patterns.Creational.Builder.Model;
using Thinksoft.Patterns.Creational.Builder.Product;

namespace Thinksoft.Patterns.Creational.Builder
{
    /**
     * Act as 'Director' role.
     * 依據Console傳入的參數調用對應的Builder來構建產品
     *
     * 設計說明：
     * 1. Director 負責協調建造過程，但不知道具體建造細節
     * 2. 對於特有屬性，Director 需要知道具體建造者類型
     * 3. 這是合理的設計妥協，保持了介面的簡潔性
     */
    public class BuildComputerService
    {
        /**
         * 根據傳入的電腦規格構建電腦
         * @param 電腦配置信息的資料模型
         * @return 構建好的電腦產品（ConsumerPC 或 EnterpriseServer）         
         */
        public IComputer BuildComputer(ComputerModel model)
        {
            if (model.BuildType == ComputerType.GamePC)
            {
                IComputerBuilder<ConsumerPC> builder = new GamePCBuilder();
                return BuildGamePC(builder, model);
            }
            else if (model.BuildType == ComputerType.Server)
            {
                IComputerBuilder<EnterpriseServer> builder = new ServerBuilder();
                return BuildServer(builder, model);
            }

            return null;
        }

        /**
         * 構建遊戲電腦
         */
        private ConsumerPC BuildGamePC(
            IComputerBuilder<ConsumerPC> builder, ComputerModel model)
        {
            // 基本組件
            return builder
                .BuildProcessor(model.Processor)
                .BuildMotherboard(model.Motherboard)
                .BuildMemory(model.Memory)
                .BuildStorage(model.Storage)
                .BuildGraphicsCard(model.GraphicsCard)
                .BuildCoolingSystem(model.CoolingSystem)
                .BuildAdditionalComponents(model.AdditionalComponents)
                .Build();
        }

        /**
         * 構建伺服器
         * 
         * 設計說明：
         * 1. 需要將通用建造者轉型為具體類型以調用特有方法
         * 2. 這種轉型是安全的，因為我們知道傳入的 builder 實際上是 ServerBuilder
         * 3. 這是處理產品特有屬性的常見模式
         */
        private EnterpriseServer BuildServer(
            IComputerBuilder<EnterpriseServer> builder,
            ComputerModel model)
        {
            // 設置伺服器特有屬性
            // 注意：這裡需要將 builder 轉型為具體類型以調用特有方法
            ((ServerBuilder)builder).SetRackUnits(model.RackUnits);

            // 基本組件
            return builder
                .BuildProcessor(model.Processor)
                .BuildMotherboard(model.Motherboard)
                .BuildMemory(model.Memory)
                .BuildStorage(model.Storage)
                .BuildAdditionalComponents(model.AdditionalComponents)
                .Build();
        }
    }
}