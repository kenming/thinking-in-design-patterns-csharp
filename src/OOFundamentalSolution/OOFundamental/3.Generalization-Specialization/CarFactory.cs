namespace Thinksoft.Tutor.CarSample.GenSpec
{
    /**
     * CarFactory 類別
     * 實現工廠模式(Factory Pattern)
     * 負責建立不同類型的車輛物件
     */
    public class CarFactory
    {
        // 儲存所有製造的車輛
        private List<Car> carList;

        // 建構子
        public CarFactory()
        {
            carList = new List<Car>();
        }

        /**
         * 製造車輛的工廠方法
         * 依據傳入的車型編號，建立對應的車輛物件
         *
         * @param carType 車型編號：1=轎車、2=卡車、3=坦克車
         * @param licensePlate 車牌號碼
         * @return 建立的車輛物件，若車型編號不合法則回傳null
         */
        public Car Manufacture(int carType, string licensePlate)
        {
            Car car;

            switch (carType)
            {
                case 1:
                    car = new Sedan("轎車-輕型", licensePlate);
                    carList.Add(car);
                    return car;

                case 2:
                    car = new Truck("卡車-中型", licensePlate);
                    carList.Add(car);
                    return car;

                case 3:
                    car = new Tank("坦克車-重型", licensePlate);
                    carList.Add(car);
                    return car;

                default:
                    return null;
            }
        }

        /**
         * 取得所有已製造的車輛
         * @return 車輛清單
         */
        public List<Car> GetAllManufacturedCars()
        {
            return carList;
        }

        /**
         * 依車牌尋找特定車輛
         * @param licensePlate 車牌號碼
         * @return 找到的車輛，若未找到則回傳null
         */
        public Car FindCar(string licensePlate)
        {
            return carList.FirstOrDefault(car => car.LicensePlate == licensePlate);
        }

        /**
         * 取得工廠生產統計資訊
         * @return 統計資訊字串
         */
        public string GetProductionStatistics()
        {
            int sedanCount = carList.Count(car => car is Sedan);
            int truckCount = carList.Count(car => car is Truck);
            int tankCount = carList.Count(car => car is Tank);

            return $"生產統計：\n轎車：{sedanCount}台\n" +
                $"卡車：{truckCount}台\n" +
                $"坦克車：{tankCount}台\n" +
                $"總計：{carList.Count}台";
        }
    }
}
