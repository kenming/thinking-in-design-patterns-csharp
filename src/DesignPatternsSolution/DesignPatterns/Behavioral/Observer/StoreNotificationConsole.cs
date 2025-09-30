using Thinksoft.Patterns.Behavioral.Observer.Observer;
using Thinksoft.Patterns.Behavioral.Observer.Publisher;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.Observer
{
    /**
     * The 'Client' Console 展示界面
     * 展示觀察者模式的完整使用流程
     * 包含建立觀察者、訂閱通知、發送通知和取消訂閱等操作
     */
    public class StoreNotificationConsole : IConsoleProgram
    {
        public void Start()
        {
            PlaceNotificationService service = new("3D模型專賣店");

            // Create Observers
            ICustomerObserver lineObs = new LineSubscriber("小高", "@xiaoqao123");
            ICustomerObserver appObs = new MobileApp("小華", "0912-345-678");

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("=== 顧客訂閱通知服務 ===");
            Console.WriteLine($"✅ 小高 訂閱Line通知");
            service.Subscribe(lineObs);
            Console.WriteLine($"✅ 小華 訂閱手機App通知");
            service.Subscribe(appObs);
            Console.WriteLine("Default : an Online Store Subject instance.");
            Console.WriteLine("--------------------------------------------");
            Console.ReadKey(false);

            string product1 = "鋼彈 RG Hi-Nu 逆襲的夏亞";
            Console.WriteLine("\nPublish NewProductArrival : ");
            service.NewProductArrival(product1);     // 新商品到貨            
            Console.ReadKey(false);

            string product2 = "Pokemon 皮卡丘 Figure-rise Standard";
            Console.WriteLine("\nPublish NewProductArrival : ");
            service.NewProductArrival(product2);     // 新商品到貨            
            Console.ReadKey(false);

            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("移除觀察者：MobileApp");
            service.UnSubscribe(appObs);
            Console.WriteLine("--------------------------------------------\n");
            Console.ReadKey(false);

            string product3 = "萬代 MG 自由鋼彈 Ver.2.0";
            Console.WriteLine("Publish PriceReduction : ");
            service.PriceReduction(product3, 2800, 2380);     // 商品降價            
            Console.ReadKey(false);

            Console.WriteLine("\n--------------------- The End ---------------------");
            Console.ReadKey();
        }
    }
}