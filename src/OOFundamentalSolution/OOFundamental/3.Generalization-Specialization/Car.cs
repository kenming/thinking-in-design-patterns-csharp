namespace Thinksoft.Tutor.CarSample.GenSpec
{
    /**
     * Car 抽象類別
     * 作為車輛繼承體系的基礎類別
     * 定義所有車輛共有的屬性和行為
     */
    public abstract class Car
    {
        // 基本屬性
        public string Model { get; }
        public string LicensePlate { get; set; }

        // 建構子
        public Car(string model, string licensePlate)
        {
            Model = model;
            LicensePlate = licensePlate;
        }

        // 共用行為的具體實作
        public string GetCarInfo()
        {
            return $"車型：{Model}；車牌：{LicensePlate}";
        }

        // 抽象方法定義
        /**
         * 計算車輛馬力
         * 不同車型有不同的馬力計算方式
         * @return 車輛馬力值(PS)
         */
        public abstract decimal CalculateHorsepower();

        /**
         * 查詢車輛狀況
         * 不同車型有不同的檢查項目
         * @return 車況檢查結果字串
         */
        public abstract string CheckStatus();
    }
}
