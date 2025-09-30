namespace Thinksoft.Tutor.CarSample.WholeParts
{
    /*
     * Car 類別
     * 展示組合關係(Composition)的設計模式
     * 整體(Whole)與部件(Parts)的生命週期綁定
     * 當Car物件被銷毀時，其內部的Engine和Tire物件也會被銷毀
     */
    public class Car
    {
        // 屬性區域 (Attributes) - 汽車基本資訊
        public string Model { get; }                // 車輛型號(唯讀)
        public string LicensePlate { get; set; }    // 車牌號碼(可讀寫)
        private int mileage;                        // 里程數(私有)
        private int fuelLevel;                      // 油量(私有)

        // 組合關係中的部件 - 這些部件的生命週期與Car綁定
        private Engine aEngine;    // 一個引擎組件
        private Tire[] aTiresArray;     // 四個輪胎組件陣列

        /*
         * 建構子 (Constructor)
         * 初始化汽車物件並建立與部件的組合關係
         */
        public Car(string model, string licensePlate)
        {
            // 初始化汽車基本資訊
            Model = model;
            LicensePlate = licensePlate;

            // 建立組合關係的部件 - 在此處創建部件物件
            aEngine = new Engine();        // 建立一個引擎實例
            aTiresArray = new Tire[4];          // 準備四個輪胎的空間

            // 初始化所有輪胎
            for (int i = 0; i < aTiresArray.Length; i++)
            {
                aTiresArray[i] = new Tire();    // 建立每個輪胎實例
            }
        }

        // 操作方法區域 (Operations) - 汽車狀態查詢方法

        /*
         * 取得里程數方法
         * 模擬從里程記錄器取得資料
         */
        public int GetMileage()
        {
            mileage = 58000;    // 模擬數據
            return mileage;
        }

        /*
         * 取得油量方法
         * 模擬從油表監控器取得現存油量
         */
        public int GetFuelLevel()
        {
            fuelLevel = 12;     // 剩餘 12 公升
            return fuelLevel;
        }

        /*
         * 取得車況資訊方法
         * 整合汽車基本資訊
         */
        public string GetCarStatus()
        {
            return $"型號：{Model}；車牌：{LicensePlate}";
        }

        // 車輛操作方法群組 - 使用表達式體方法簡化程式碼

        /*
         * 發動方法 - 啟動引擎並讓輪胎開始運轉
         * 展示與部件的互動(組合關係的運用)
         */
        public string Start()
        {
            // 委派(Delegation): 透過引擎物件啟動引擎
            aEngine.Start();
            return "動作： 發動";
        }

        public string Accelerate() => "動作： 踩油門";
        public string ShiftGear(string gear) => $"動作： 排檔-> {gear}";
        public string TurnSteeringWheel() => "動作： 轉動方向盤";
        public string Brake() => "動作： 煞車";
        public string ShutDown() => "動作： 關閉";

        /*
         * 取得引擎狀況方法
         * 委派給引擎組件處理 - 展示組合關係中的委派模式
         */
        public string GetEngineStatus()
        {
            // 委派(Delegation): 透過引擎物件取得引擎的狀況
            return aEngine.GetEngineStatus();
        }

        /*
         * 踩油門方法 - 展示與多個部件的協作
         * 同時操作引擎和輪胎組件
         */
        public string PressAccelerator()
        {
            // 啟動引擎
            aEngine.Start();

            // 讓所有輪胎開始滾動
            string rollResult = "所有輪胎開始滾動: ";

            // 透過迴圈操作所有輪胎
            for (int i = 0; i < aTiresArray.Length; i++)
            {
                // 累加每個輪胎的滾動狀態
                rollResult += $"輪胎{i + 1}: {aTiresArray[i].Roll()}; ";
            }

            return rollResult;
        }

        /*
         * 取得車輛完整狀態方法
         * 整合所有部件的狀態資訊
         */
        public string GetVehicleStatus()
        {
            // 整合各部件狀態
            string status = $"車輛資訊 - 型號: {Model}, 車牌: {LicensePlate}\n";
            status += $"引擎狀態: {GetEngineStatus()}\n";
            status += "輪胎狀態:\n";

            // 取得所有輪胎狀態
            for (int i = 0; i < aTiresArray.Length; i++)
            {
                status += $"  輪胎{i + 1}: {aTiresArray[i].CheckStatus()}\n";
            }

            return status;
        }
    }
}
