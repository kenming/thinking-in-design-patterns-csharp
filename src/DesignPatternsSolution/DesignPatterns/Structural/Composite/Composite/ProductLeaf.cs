using Thinksoft.Patterns.Structural.Composite.Model;

namespace Thinksoft.Patterns.Structural.Composite.Composite
{
    /*
     *  The 'Leaf' Concrete Class.
     *  單一商品(無複合組成商品)的具體類別
     */
    public class ProductLeaf : ProductComponent
    {
        public ProductLeaf(Product product)
        {
            _product = product;
        }

        public override void Add(ProductComponent component)
        {
            // do nothing, leaf nodes cannot have children            
        }

        public override void Remove(ProductComponent component)
        {
            // do nothing, leaf nodes cannot have children
        }
        public override int GetPrice()
        {
            return _product.Price;
        }

        public override void Display(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}- {_product.Name}：{_product.Price} 元");
        }

        public override ProductComponent? FindByName(string componentName)
        {
            // 若名稱相符則回傳自己，否則回傳 null
            return _product.Name == componentName ? this : null;
        }
    }
}
