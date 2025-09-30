namespace Thinksoft.Tutor.CarSample.GenSpec
{
    /**
     * Sedan 類別
     * Car 的子類別，代表輕型民用車輛
     */
    public class Sedan : Car
    {
        // 轎車特有屬性
        private int seatingCapacity = 5;
        private bool hasSunroof = false;

        // 建構子
        public Sedan(string model, string licensePlate) : base(model, licensePlate)
        {
        }

        // 覆寫父類別的抽象方法
        public override decimal CalculateHorsepower()
        {
            int torque = 3;
            int rpm = 6000;

            return torque * rpm / 60m;
        }

        // 覆寫父類別的抽象方法
        public override string CheckStatus()
        {
            System.Text.StringBuilder status = new System.Text.StringBuilder();

            status.AppendLine("油表檢查結果：OK");
            status.AppendLine("引擎檢查結果：OK");
            status.AppendLine("輪胎檢查結果：OK");
            status.AppendLine("氣囊檢查結果：OK");

            return status.ToString();
        }

        // 轎車特有方法
        public string OpenSunroof()
        {
            if (hasSunroof)
                return "天窗已開啟";
            else
                return "此車型無天窗";
        }
    }
}
