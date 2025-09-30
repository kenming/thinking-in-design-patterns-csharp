namespace Thinksoft.Tutor.CarSample.GenSpec
{
    /**
     * Tank 類別
     * Car 的子類別，代表重型軍用車輛
     */
    public class Tank : Car
    {
        // 坦克車特有屬性
        private int shellCount = 10;
        private string armorType = "重型裝甲";

        // 建構子
        public Tank(string model, string licensePlate) : base(model, licensePlate)
        {
        }

        // 覆寫父類別的抽象方法
        public override decimal CalculateHorsepower()
        {
            int torque = 24;
            int rpm = 7200;

            return torque * rpm / 60m;
        }

        // 覆寫父類別的抽象方法
        public override string CheckStatus()
        {
            System.Text.StringBuilder status = new System.Text.StringBuilder();

            status.AppendLine("油表檢查結果：OK");
            status.AppendLine("引擎檢查結果：OK");
            status.AppendLine("履帶檢查結果：OK");
            status.AppendLine("武器發射檢查結果：OK");

            return status.ToString();
        }

        /**
         * 坦克車特有方法
         * 只有當明確宣告為坦克車類型時才能使用此方法
         */
        public string FireCannon()
        {
            if (shellCount <= 0)
                return "砲彈已用盡！";

            shellCount--;
            return $"砲彈發射！剩餘砲彈：{shellCount}";
        }
    }
}
