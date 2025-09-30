namespace Thinksoft.Tutor.CarSample.Association
{
    /**
     * Driver 類別
     * 展示物件間的關聯關係 (Association)
     */
    public class Driver
    {
        // 屬性區域 (Attributes)
        public string Name { get; }
        public Car aCar { get; }    // 關聯關係：Driver 擁有一個 Car 物件的參考

        /**
         * 建構子
         * 初始化駕駛員並建立與車輛的關聯
         */
        public Driver(string name)
        {
            Name = name;
            aCar = new Car("BMW", "IS-1234");
        }

        /**
         * 展示駕駛員操作車輛的方法
         * 這是關聯關係的實際運用
         */
        public string Drive()
        {
            string behavior = $"{Name} 開始駕駛\n";
            behavior += aCar.Start() + "\n";
            behavior += aCar.ShiftGear("D檔") + "\n";
            behavior += aCar.Accelerate() + "\n";

            return behavior;
        }
    }
}
