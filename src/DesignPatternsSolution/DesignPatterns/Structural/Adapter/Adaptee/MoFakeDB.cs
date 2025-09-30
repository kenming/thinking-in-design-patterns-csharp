namespace Thinksoft.Patterns.Structural.Adapter.Adaptee
{
    // Mo購物平台的模擬資料庫
    public class MoFakeDB
    {
        // Mo特有的資料結構
        public class MoProduct
        {
            public string ProductId { get; set; }
            public string Name { get; set; }
            public int AvailableQty { get; set; }
        }

        private readonly Dictionary<string, MoProduct> _products;

        public MoFakeDB()
        {
            // 初始化模擬資料
            _products = new Dictionary<string, MoProduct>
        {
            {
                "P001",
                new MoProduct {
                    ProductId = "P001",
                    Name = "Mo - 掌上型遊戲機",
                    AvailableQty = 35
                }
            },
            {
                "P002",
                new MoProduct {
                    ProductId = "P002",
                    Name = "Mo - 藍牙耳機",
                    AvailableQty = 20
                }
            },
            {
                "P003",
                new MoProduct {
                    ProductId = "P003",
                    Name = "Mo - 行動電源",
                    AvailableQty = 7
                }
            },
            {
                "P004",
                new MoProduct {
                    ProductId = "P004",
                    Name = "Mo - 智能手錶",
                    AvailableQty = 15
                }
            }
        };
        }

        public Dictionary<string, MoProduct> GetProducts(List<string> productIds)
        {
            return productIds.Where(id => _products.ContainsKey(id))
                             .ToDictionary(id => id, id => _products[id]);
        }
    }
}
