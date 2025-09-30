using Thinksoft.Patterns.Creational.Builder.Product;

namespace Thinksoft.Patterns.Creational.Builder.Builder
{
    /**
     * 'Concrete Builder'
     * 具體建造者：建造伺服器電腦Builder
     * 
     * 設計說明：
     * 1. 實現 IComputerBuilder 介面的共通方法
     * 2. 擴展伺服器特有方法 SetRackUnits()
     * 3. 對於不需要的方法 (如 BuildGraphicsCard) 提供空實現
     * 4. 這種設計允許保持介面簡潔，同時支持產品特有功能     
     */
    public class ServerBuilder : IComputerBuilder<EnterpriseServer>
    {
        private EnterpriseServer _server = new EnterpriseServer();

        public IComputerBuilder<EnterpriseServer> BuildProcessor(string processor)
        {
            _server.Processor = processor;
            return this;
        }
        public IComputerBuilder<EnterpriseServer> BuildMotherboard(string motherboard)
        {
            _server.Motherboard = motherboard;
            return this;
        }
        public IComputerBuilder<EnterpriseServer> BuildMemory(string memory)
        {
            _server.Memory = memory;
            return this;
        }
        public IComputerBuilder<EnterpriseServer> BuildStorage(string storage)
        {
            _server.Storage = storage;
            return this;
        }
        public IComputerBuilder<EnterpriseServer> BuildGraphicsCard(string graphicsCard)
        {
            // 伺服器通常不需要獨立顯示卡，所以這個方法在伺服器建造者中不做任何事
            return this;
        }
        public IComputerBuilder<EnterpriseServer> BuildCoolingSystem(string coolingSystem)
        {
            // 伺服器的冷卻系統與普通電腦不同，在此實現中將其作為額外組件處理
            return this;
        }
         /**
         * 設置伺服器特有屬性：機架單位數
         * 此為擴展方法，不在 IComputerBuilder 介面中定義，
         * 因為它僅適用於伺服器建造者。
         */
        public ServerBuilder SetRackUnits(int rackUnits)
        {
            _server.RackUnits = rackUnits;
            return this;
        }
        //建置額外組件         
        public IComputerBuilder<EnterpriseServer> BuildAdditionalComponents(List<string> components)
        {
            // 添加額外的自定義組件
            if (components != null)
            {
                foreach (var component in components)
                {
                    _server.AdditionalComponents.Add(component);
                }
            }
            return this;
        }
        public EnterpriseServer Build()
        {
            return _server;
        }
        // 重置Builder
        public IComputerBuilder<EnterpriseServer> Reset()
        {
            _server = new EnterpriseServer();
            return this;
        }
    }
}