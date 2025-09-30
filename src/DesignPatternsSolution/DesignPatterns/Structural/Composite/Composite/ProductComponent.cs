using Thinksoft.Patterns.Structural.Composite.Model;

namespace Thinksoft.Patterns.Structural.Composite.Composite
{
    /*
     *  The 'Component' Abstract Class.
     *  定義商品元件的抽象類別
     */
    public abstract class ProductComponent
    {        
        protected Product _product;

        public Product GetProduct() => _product;    // 取得商品資料

        // === Composite 結構基本操作 ===

        /**
         * 新增子元件
         * @param component 欲加入的子元件 (Composite/Leaf)
         */
        public abstract void Add(ProductComponent component);
        /**
         * 移除子元件
         * @param component 欲移除的子元件 (Composite/Leaf)
         */
        public abstract void Remove(ProductComponent component);

        // === 業務邏輯相關 Operation ===

        /**
         * 取得價格（Leaf 回傳自身價格，Composite 遞迴加總所有子元件價格）
         * @return int 總價
         */
        public abstract int GetPrice();
        /**
         * 樹狀結構顯示
         * @param indent 縮排層級，預設為 0
         */
        public abstract void Display(int indent = 0);   // ident 用於縮排顯示
        /**
         * 根據名稱尋找節點（Composite/Leaf）
         * @param componentName 欲尋找的元件名稱
         * @return ProductComponent? 找到則回傳該節點，否則回傳 null
         */
        public abstract ProductComponent? FindByName(string componentName);
    }
}
