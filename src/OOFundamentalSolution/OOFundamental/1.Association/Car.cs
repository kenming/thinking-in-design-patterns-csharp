namespace Thinksoft.Tutor.CarSample.Association
{
    /* 
     * Car 類別
     * 展示屬性和行為的定義
     */
    public class Car
    {
        // 屬性區域 (Attributes)
        public string Model { get; }  // 唯讀屬性，一旦設定後不可變更
        public string LicensePlate { get; set; }  // 可讀寫屬性
        private int mileage;  // 私有欄位，僅能在類別內部存取
        private int fuelLevel;  // 私有欄位，僅能在類別內部存取

        // 建構子 (Constructor)
        public Car(string model, string licensePlate)
        {
            // 初始化物件狀態
            Model = model;  // 設定唯讀屬性
            LicensePlate = licensePlate;  // 設定可讀寫屬性
        }

        // 操作方法區域 (Operations)

        /* 
         * 取得車輛目前的里程數
         * 實際應用中會從里程記錄器取得資料
         */
        public int GetMileage()
        {
            // 需至里程記錄器取得資料
            mileage = 58000;  // 先給個測試數值
            return mileage;
        }

        /* 
         * 取得車輛目前的油表數
         * 實際應用中會從油表監控器取得資料
         */
        public int GetFuelLevel()
        {
            // 需至油表監控器取得現存油表數
            fuelLevel = 12;  // 剩餘 12 公升
            return fuelLevel;
        }

        /* 
         * 取得車輛基本資訊
         * 回傳型號與車牌的組合字串
         */
        public string GetCarStatus() 
        {
            // 使用字串插值提高可讀性
            string 車況 = $"型號：{Model}；車牌：{LicensePlate}";
            return 車況;
        }

        // 車輛操作方法群組
        // 以下方法使用表達式體方法簡化程式碼
        public string Start() => "動作： 發動"; 

        public string Accelerate() => "動作： 踩油門";

        public string ShiftGear(string gear) => $"動作： 排檔-> {gear}";

        public string TurnSteeringWheel() => "動作： 轉動方向盤";

        public string Brake() => "動作： 煞車";

        public string ShutDown() => "動作： 關閉";
    }
}
