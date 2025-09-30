using Thinksoft.Patterns.Structural.Composite.Model;

namespace Thinksoft.Patterns.Structural.Composite.Composite
{
    /*
     *  The 'Composite' Concrete Class
     *  商品複合結構具體類別
     */
    public class ProductComposite : ProductComponent
    {
        private List<ProductComponent> _children = new List<ProductComponent>();

        public ProductComposite(Product product)
        {
            _product = product;
        }

        public override void Add(ProductComponent component)
        {
            _children.Add(component);
            Console.WriteLine($"[Add] 已將「{component.GetProduct().Name}」加入「{_product.Name}」");
        }

        public override void Remove(ProductComponent component)
        {
            if (_children.Remove(component))
                Console.WriteLine($"[Remove] 已將「{component.GetProduct().Name}」自「{_product.Name}」移除");
            else
                Console.WriteLine($"[Remove] 「{component.GetProduct().Name}」不存在於「{_product.Name}」");
        }

        public override void Display(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}+ {_product.Name}（小計：{GetPrice()} 元）");
            foreach (var child in _children)
                child.Display(indent + 2);
        }

        public override int GetPrice()
        {
            // 計算所有子元件的價格總和
            return _children.Sum(child => child.GetPrice());
        }

        public override ProductComponent? FindByName(string componentName)
        {
            // 1. 先判斷自己的名稱是否與目標名稱相符，若相符則回傳自己
            if (_product.Name == componentName)
                return this;

            // 2. 遍歷所有子元件，遞迴呼叫 FindByName()
            foreach (var child in _children)
            {
                var found = child.FindByName(componentName);
                // 3. 若在子樹中找到相符節點，立即回傳該節點
                if (found != null)
                    return found;
            }

            // 4. 若自己與所有子元件皆不符，回傳 null
            return null;
        }
    }
}