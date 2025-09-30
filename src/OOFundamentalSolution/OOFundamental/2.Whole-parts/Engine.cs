namespace Thinksoft.Tutor.CarSample.WholeParts
{
    /*
     * Engine 類別
     * 代表汽車的動力來源組件
     * 作為組合關係(Composition)中的部件(Part)
     * 展示部件的內部狀態管理與操作方法
     */
    public class Engine
    {
        // 私有屬性 - 引擎內部狀態
        private int temperature;    // 引擎溫度
        private bool isRunning;     // 引擎運轉狀態

        /*
         * 建構子
         * 初始化引擎的預設狀態
         */
        public Engine()
        {
            temperature = 25;       // 設定初始溫度為室溫
            isRunning = false;      // 初始狀態為未運轉
        }

        /*
         * 取得引擎狀況的方法
         * 提供引擎當前狀態的資訊
         */
        public string GetEngineStatus()
        {
            return "引擎狀況良好...";
        }

        /*
         * 啟動引擎方法
         * 改變引擎的運轉狀態並提升溫度
         */
        public void Start()
        {
            isRunning = true;       // 設定為運轉狀態
            temperature += 10;      // 運轉時溫度上升
        }
    }
}
