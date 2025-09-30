using Thinksoft.Patterns.Creational.Builder.Product;

namespace Thinksoft.Patterns.Creational.Builder.Builder
{
    /**
     * 'Concrete Builder'
     * 具體建造者：建造遊戲電腦Builder
     * 
     * 設計說明：
     * 1. 實現 IComputerBuilder 介面的所有方法
     * 2. 遊戲電腦需要所有組件，因此所有方法都有實際實現
     * 3. 無需擴展特有方法，因為所有需求已通過介面滿足
     */
    public class GamePCBuilder : IComputerBuilder<ConsumerPC>
    {
        private ConsumerPC _computer = new ConsumerPC();

        public IComputerBuilder<ConsumerPC> BuildProcessor(string processor)
        {
            _computer.Processor = processor;
            return this;
        }
        public IComputerBuilder<ConsumerPC> BuildMotherboard(string motherboard)
        {
            _computer.Motherboard = motherboard;
            return this;
        }
        public IComputerBuilder<ConsumerPC> BuildMemory(string memory)
        {
            _computer.Memory = memory;
            return this;
        }
        public IComputerBuilder<ConsumerPC> BuildStorage(string storage)
        {
            _computer.Storage = storage;
            return this;
        }
        public IComputerBuilder<ConsumerPC> BuildGraphicsCard(string graphicsCard)
        {
            _computer.GraphicsCard = graphicsCard;
            return this;
        }
        public IComputerBuilder<ConsumerPC> BuildCoolingSystem(string coolingSystem)
        {
            _computer.CoolingSystem = coolingSystem;
            return this;
        }
        public IComputerBuilder<ConsumerPC> BuildAdditionalComponents
            (List<string> components)
        {
            // 添加額外的自定義組件
            if (components != null)
            {
                foreach (var component in components)
                {
                    _computer.AdditionalComponents.Add(component);
                }
            }
            return this;
        }
        public ConsumerPC Build()
        {
            return _computer;
        }

        // 重置Builder
        public IComputerBuilder<ConsumerPC> Reset()
        {
            _computer = new ConsumerPC();
            return this;
        }
    }
}