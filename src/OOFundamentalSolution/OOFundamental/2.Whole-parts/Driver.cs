namespace Thinksoft.Tutor.CarSample.WholeParts
{
    /*
     * Driver 類別
     * 展示物件間的關聯關係 (Association)
     * 與Car類別形成關聯，但不是組合關係
     * Driver可以獨立存在，不依賴Car的生命週期
     */
    public class Driver
    {
        // 屬性區域 (Attributes)
        public string Name { get; }     // 駕駛員姓名(唯讀)
        public Car ACar { get; }        // 關聯的車輛物件(關聯關係的核心)

        /*
         * 建構子
         * 初始化駕駛員並建立與車輛的關聯
         * 注意：這裡建立的是關聯關係，不是組合關係
         */
        public Driver(string name)
        {
            Name = name;
            // 建立關聯：駕駛員與特定車輛的關聯
            ACar = new Car("BMW", "IS-1234");
        }

        /*
         * 展示駕駛員操作車輛的方法
         * 這是關聯關係的實際運用
         * 透過關聯的車輛物件執行駕駛行為
         */
        public string Drive()
        {
            // 透過關聯呼叫 Car 物件的方法
            string behavior = $"{Name} 開始駕駛\n";
            behavior += ACar.Start() + "\n";                    // 發動車輛
            behavior += ACar.ShiftGear("D檔") + "\n";           // 排檔
            behavior += ACar.Accelerate() + "\n";               // 踩油門
            behavior += ACar.PressAccelerator() + "\n";         // 展示與部件互動

            return behavior;
        }

        /*
         * 取得駕駛員與車輛資訊
         * 展示關聯關係中的資訊存取
         */
        public string GetDriverInfo()
        {
            string info = $"駕駛員: {Name}\n";
            info += $"駕駛車輛: {ACar.GetCarStatus()}\n";
            info += $"引擎狀況: {ACar.GetEngineStatus()}";

            return info;
        }
    }
}
