using Thinksoft.Patterns.Structural.Composite.Composite;
using Thinksoft.Patterns.Structural.Composite.Model;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Structural.Composite
{
    public class PlaceProductBundleConsole : IConsoleProgram
    {
        public void Start()
        {
            Console.WriteLine("=============新增套裝商品===============");
            ProductComponent productBundle = CreateProductBundle();
            // 顯示 BOM 結構與總價
            Console.WriteLine("\n=========【樹莓派套件 BOM 結構】========");            
            productBundle.Display();
            Console.WriteLine($"\n總價：{productBundle.GetPrice()} 元");
            Console.WriteLine("========================================\n");
            // 找出擴充套件組節點並顯示
            Console.WriteLine("=========【準備移除擴充套件組】=========");            
            ProductComponent expansion = productBundle.FindByName("擴充套件組");
            expansion.Display();
            Console.WriteLine("========================================\n");
            // ...移除擴充套件組...
            Console.WriteLine("========【移除擴充套件後的套裝商品】====");            
            productBundle.Remove(expansion);
            productBundle.Display();
            Console.WriteLine($"\n總價：{productBundle.GetPrice()} 元");
            Console.WriteLine("========================================\n");
        }

        private ProductComponent CreateProductBundle()
        {
            // 建立套裝商品複合結構資料
            ProductComponent kit = new ProductComposite(new Product { Name = "樹莓派套件" });
            ProductComponent pi = new ProductLeaf(new Product { Name = "樹莓派主板", Price = 1800 });
            kit.Add(pi);

            ProductComponent power = new ProductComposite(new Product { Name = "電源組" });
            ProductComponent adapter = new ProductLeaf
                (new Product { Name = "USB變壓器", Price = 200 });
            ProductComponent cable = new ProductLeaf
                (new Product { Name = "USB電源線", Price = 100 });
            power.Add(adapter);
            power.Add(cable);
            kit.Add(power);

            ProductComponent expansion = new ProductComposite(new Product { Name = "擴充套件組" });
            ProductComponent camera = new ProductLeaf
                (new Product { Name = "相機模組", Price = 350 });
            expansion.Add(camera);
            ProductComponent sensors = new ProductComposite
                (new Product { Name = "傳感器包" });
            ProductComponent sensor1 = new ProductLeaf
                (new Product { Name = "超音波傳感器", Price = 120 });
            ProductComponent sensor2 = new ProductLeaf(new Product 
                { Name = "光傳感器", Price = 80 });
            sensors.Add(sensor1);
            sensors.Add(sensor2);
            expansion.Add(sensors);
            kit.Add(expansion);

            return kit;
        }
    }
}
