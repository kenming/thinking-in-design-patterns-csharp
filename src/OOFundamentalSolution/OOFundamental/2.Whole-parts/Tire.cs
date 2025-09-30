namespace Thinksoft.Tutor.CarSample.WholeParts
{
    /*
     * Tire 類別
     * 代表汽車的輪胎組件
     * 作為組合關係(Composition)中的部件(Part)
     * 展示部件的狀態檢查與動作執行
     */
    public class Tire
    {
        // 私有屬性 - 輪胎內部狀態
        private int pressure;           // 輪胎氣壓
        private double treadDepth;      // 胎紋深度

        /*
         * 建構子
         * 初始化輪胎的預設狀態
         */
        public Tire()
        {
            pressure = 32;          // 設定標準氣壓 32 PSI
            treadDepth = 7.5;       // 設定新輪胎胎紋深度 7.5mm
        }

        /*
         * 輪胎滾動方法
         * 模擬輪胎的滾動動作
         */
        public string Roll()
        {
            return "滾動中...";
        }

        /*
         * 檢查輪胎狀態方法
         * 回傳輪胎的詳細狀態資訊
         */
        public string CheckStatus()
        {
            return $"氣壓: {pressure} PSI, 胎紋深度: {treadDepth} mm";
        }
    }
}
