namespace Thinksoft.Tutor.CarSample
{
    /* 
     * Console 程式
     * 提供互動式選單展示物件導向基礎概念
     */
    public class Program
    {
        static void Main(string[] args)
        {
            bool continueRunning = true;

            // 顯示歡迎訊息
            Console.WriteLine("===================================================");
            Console.WriteLine("    物件導向基礎概念展示程式    ");
            Console.WriteLine("===================================================");

            // 主選單迴圈
            while (continueRunning)
            {
                // 顯示選單
                Console.WriteLine("\n請選擇要展示的概念：");
                Console.WriteLine("1. 關聯 (Association)");
                Console.WriteLine("2. 整體-局部 (Whole-Parts)");
                Console.WriteLine("3. 一般化-特殊化 (Generalization-Specialization)");
                Console.WriteLine("0. 離開程式");
                Console.Write("\n您的選擇是: ");


                // 取得使用者輸入
                string choice = Console.ReadLine();

                // 處理使用者選擇
                switch (choice)
                {
                    case "1":
                        ShowAssociation();
                        break;
                    case "2":
                        ShowWholeParts();
                        break;
                    case "3":
                        ShowGenSpec();
                        break;
                    case "0":
                        continueRunning = false;
                        Console.WriteLine("\n感謝使用本程式，再見！");
                        break;
                    default:
                        Console.WriteLine("\n無效的選擇，請重新輸入！");
                        break;
                }

                // 如果還要繼續執行，則等待使用者按下任意鍵
                if (continueRunning && choice != "0")
                {
                    Console.WriteLine("\n按任意鍵返回主選單...");
                    Console.ReadKey();
                    Console.Clear(); // 清除畫面
                }

                /* 
                 * 展示關聯(Association)概念
                 * 展示Driver與Car之間的關聯關係
                 */
                static void ShowAssociation()
                {
                    Console.Clear();
                    Console.WriteLine("===================================================");
                    Console.WriteLine("    關聯 (Association) 概念展示    ");
                    Console.WriteLine("===================================================");
                    Console.WriteLine("關聯代表不同類別的物件之間的連結關係");
                    Console.WriteLine("例如：駕駛員(Driver)與汽車(Car)之間的關聯\n");

                    // 建立駕駛員物件
                    Console.WriteLine("建立駕駛員物件...");
                    Association.Driver driver1 = new("張三");
                    Console.WriteLine($"駕駛員名稱：{driver1.Name}");

                    // 展示關聯關係
                    Console.WriteLine("\n透過關聯取得車輛資訊：");
                    Console.WriteLine($"車輛型號：{driver1.aCar.Model}");
                    Console.WriteLine($"車輛車號：{driver1.aCar.LicensePlate}");

                    // 展示透過關聯呼叫方法
                    Console.WriteLine("\n透過關聯呼叫車輛方法：");
                    Console.WriteLine(driver1.aCar.Start());
                    Console.WriteLine(driver1.aCar.ShiftGear("D檔"));
                    Console.WriteLine(driver1.aCar.Accelerate());

                    // 展示駕駛方法
                    Console.WriteLine("\n展示駕駛方法（整合多個車輛操作）：");
                    Console.WriteLine(driver1.Drive());

                    // 建立第二個駕駛員，展示多對一關聯
                    Console.WriteLine("\n建立第二個駕駛員，展示多個駕駛員可以關聯到不同車輛：");
                    Association.Driver driver2 = new("李四");
                    Console.WriteLine($"駕駛員名稱：{driver2.Name}");
                    Console.WriteLine($"車輛車號：{driver2.aCar.LicensePlate}");
                }

                /**
                 * 展示整體-局部(Whole-Parts)概念
                 * 展示Car與其組件(引擎、輪胎)之間的組合關係
                 */
                static void ShowWholeParts()
                {
                    Console.Clear();
                    Console.WriteLine("===================================================");
                    Console.WriteLine("    整體-局部 (Whole-Parts) 概念展示    ");
                    Console.WriteLine("===================================================");
                    Console.WriteLine("整體-局部關係代表物件之間的組合或聚合關係");
                    Console.WriteLine("例如：汽車(Car)與其組件(引擎、輪胎)之間的關係\n\n");

                    // 建立汽車物件
                    Console.WriteLine("建立汽車物件...");
                    WholeParts.Car car = new WholeParts.Car("SUV", "WP-5678");

                    // 展示整體物件資訊
                    Console.WriteLine($"車輛型號：{car.Model}");
                    Console.WriteLine($"車輛車牌：{car.LicensePlate}");

                    // 展示與部件互動
                    Console.WriteLine("\n透過整體物件與部件互動：");
                    Console.WriteLine("取得引擎狀況：" + car.GetEngineStatus());
                    Console.WriteLine("踩油門（使所有輪胎滾動）：");
                    Console.WriteLine(car.Accelerate());

                    // 展示整體物件的完整狀態
                    Console.WriteLine("\n取得車輛完整狀態（整合所有部件狀態）：");
                    Console.WriteLine(car.GetVehicleStatus());

                    // 展示部件生命週期與整體綁定
                    Console.WriteLine("\n部件的生命週期與整體綁定：");
                    Console.WriteLine("當Car物件被銷毀時，其所有部件（引擎、輪胎）也會一同被銷毀");
                }

                /**
                 * 展示一般化-特殊化(Generalization-Specialization)概念
                 * 展示Car基類與其子類(轎車、卡車、坦克車)之間的繼承關係
                 */
                static void ShowGenSpec()
                {
                    Console.Clear();
                    Console.WriteLine("===================================================");
                    Console.WriteLine("    一般化-特殊化 (Generalization-Specialization) 概念展示    ");
                    Console.WriteLine("===================================================");
                    Console.WriteLine("一般化-特殊化關係代表類別之間的繼承關係");
                    Console.WriteLine("例如：Car基類與其子類(轎車、卡車、坦克車)之間的關係\n");

                    // 建立汽車工廠
                    Console.WriteLine("建立汽車工廠...");
                    GenSpec.CarFactory factory = new();

                    // 製造不同類型的車輛
                    Console.WriteLine("\n使用工廠製造不同類型的車輛：");

                    // 製造轎車
                    Console.WriteLine("\n製造轎車...");
                    GenSpec.Car car1 = factory.Manufacture(1, "GS-1111");
                    Console.WriteLine($"車輛資訊：{car1.GetCarInfo()}");
                    Console.WriteLine($"車輛馬力：{car1.CalculateHorsepower()} PS");
                    Console.WriteLine("車輛狀況檢查：");
                    Console.WriteLine(car1.CheckStatus());

                    // 製造卡車
                    Console.WriteLine("\n製造卡車...");
                    GenSpec.Car car2 = factory.Manufacture(2, "GS-2222");
                    Console.WriteLine($"車輛資訊：{car2.GetCarInfo()}");
                    Console.WriteLine($"車輛馬力：{car2.CalculateHorsepower()} PS");
                    Console.WriteLine("車輛狀況檢查：");
                    Console.WriteLine(car2.CheckStatus());

                    // 製造坦克車
                    Console.WriteLine("\n製造坦克車...");
                    GenSpec.Car car3 = factory.Manufacture(3, "GS-3333");
                    Console.WriteLine($"車輛資訊：{car3.GetCarInfo()}");
                    Console.WriteLine($"車輛馬力：{car3.CalculateHorsepower()} PS");
                    Console.WriteLine("車輛狀況檢查：");
                    Console.WriteLine(car3.CheckStatus());

                    // 展示多型
                    Console.WriteLine("\n展示多型(Polymorphism)：");
                    Console.WriteLine("同一個方法在不同子類中有不同的實作：");

                    Console.WriteLine("\n呼叫相同方法 CheckStatus()：");
                    Console.WriteLine("轎車：");
                    Console.WriteLine(car1.CheckStatus());
                    Console.WriteLine("卡車：");
                    Console.WriteLine(car2.CheckStatus());
                    Console.WriteLine("坦克車：");
                    Console.WriteLine(car3.CheckStatus());

                    // 展示特殊化方法
                    Console.WriteLine("\n展示特殊化方法（需要明確轉型）：");
                    Console.WriteLine("--------------------------------");

                    // 轉型為卡車並呼叫特有方法
                    if (car2 is GenSpec.Truck truck)
                    {
                        Console.WriteLine("卡車特有方法 - 裝載物資：");
                        Console.WriteLine(truck.LoadCargo(1500));
                    }

                    Console.WriteLine();

                    // 轉型為坦克車並呼叫特有方法
                    if (car3 is GenSpec.Tank tank)
                    {
                        Console.WriteLine("坦克車特有方法 - 發射大砲：");
                        Console.WriteLine(tank.FireCannon());
                        Console.WriteLine(tank.FireCannon());
                    }

                    // 展示工廠生產統計
                    Console.WriteLine("\n工廠生產統計：");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(factory.GetProductionStatistics());
                }
            }
        }
    }
}
