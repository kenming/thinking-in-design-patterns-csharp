namespace Thinksoft.Tutor.CarSample.GenSpec
{
    /**
     * Truck 類別
     * Car 的子類別，代表中型載貨車輛
     */
    public class Truck : Car
    {
        // 卡車特有屬性
        private decimal loadCapacity = 2000;
        private bool isLoaded = false;

        // 建構子
        public Truck(string model, string licensePlate) : base(model, licensePlate)
        {
        }

        // 覆寫父類別的抽象方法
        public override decimal CalculateHorsepower()
        {
            int torque = 5;
            int rpm = 6800;

            return torque * rpm / 60m;
        }

        // 覆寫父類別的抽象方法
        public override string CheckStatus()
        {
            System.Text.StringBuilder status = new System.Text.StringBuilder();

            status.AppendLine("油表檢查結果：OK");
            status.AppendLine("引擎檢查結果：OK");
            status.AppendLine("輪胎檢查結果：OK");
            status.AppendLine("棚架檢查結果：OK");

            return status.ToString();
        }

        /**
         * 卡車特有方法
         * 只有當明確宣告為卡車類型時才能使用此方法
         * 展示特殊化(Specialization)的概念
         */
        public string LoadCargo(decimal weight)
        {
            if (weight > loadCapacity)
                return "超過最大載重量！";

            isLoaded = true;
            return $"已裝載 {weight}kg 的物資";
        }
    }
}
