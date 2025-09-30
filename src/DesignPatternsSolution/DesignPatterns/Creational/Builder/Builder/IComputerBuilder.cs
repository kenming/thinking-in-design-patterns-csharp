using Thinksoft.Patterns.Creational.Builder.Product;

namespace Thinksoft.Patterns.Creational.Builder.Builder
{
    /**          
     * The 'Builder' Interface
     * 定義建構電腦 (Product) 的各個部件 (Parts) 建置的操作，
     * 以及可以取得最終已製造完成產品的操作。
     * <T> 為泛型參數，下列操作所回傳的即為在 
     * Concrete Builder 會定義的具體產品
     * 
     * 設計說明：
     * 1. 此介面僅定義所有類型電腦共通的建造步驟
     * 2. 具體建造者可以擴展特有步驟 (如設定伺服器的機架單位數)
     * 3. 這些特有步驟不在本介面中定義，以保持介面的通用性
     * 4. 對於某些建造者不需要的方法，提供預設實現 (空方法)
     */
    public interface IComputerBuilder<T> where T : IComputer
    {
        /**
         * 定義建置處理器的操作
         * @param 處理器參數型
         * @return 建造者介面型別
         */
        IComputerBuilder<T> BuildProcessor(string processor);

        /**
         * 定義建置主機板的操作
         * @param 主機板參數
         * @return 建造者介面型別
         */
        IComputerBuilder<T> BuildMotherboard(string motherboard);

        /**
         * 定義建置記憶體的操作
         * @param 記憶體參數
         * @return 建造者介面型別
         */
        IComputerBuilder<T> BuildMemory(string memory);

        /**
         * 定義建置儲存裝置的操作
         * @param 儲存裝置參數
         * @return 建造者介面型別
         */
        IComputerBuilder<T> BuildStorage(string storage);

        /**
         * 定義建置顯示卡的操作
         * @param 顯示卡參數
         * @return 建造者介面型別
         */
        IComputerBuilder<T> BuildGraphicsCard(string graphicsCard);

        /**
         * 定義建置冷卻系統的操作
         * @parm 冷卻系統參數
         * @return 建造者介面型別
         */
        IComputerBuilder<T> BuildCoolingSystem(string coolingSystem);

        /**
         * 定義建置額外組件的操作
         * @param 要添加的額外組件列表
         * @return 建造者介面型別
         */
        IComputerBuilder<T> BuildAdditionalComponents(List<string> components);

        /**
         * 定義最終完成建造的操作
         * @return 最終產品資料型別
         */
        T Build();

        /**
         * 重置建造者狀態，以便重新使用
         * @return 建造者介面型別
         */
        IComputerBuilder<T> Reset();
    }
}