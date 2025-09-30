using System;
using System.Collections.Generic;
using System.Text;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.Memento
{
    /*
     *  購物車操作展示控制台
     *  展示使用 Memento 模式實現購物車操作歷史的儲存與復原
     */
    public class PlaceCartConsole : IConsoleProgram
    {
        private ShoppingCart cart = new();           // Originator
        private CartCareTaker careTaker = new();     // Caretaker

        public void Start()
        {
            Console.WriteLine("===== 購物車操作歷史示範 =====");
            Console.WriteLine("展示使用 Memento 模式實現購物車操作的復原與重做\n");

            // 初始狀態
            Console.WriteLine("初始狀態：");
            cart.ListCart();
            SaveState("初始狀態");

            // 執行一系列購物車操作
            AddProduct("筆記型電腦", 1, "加入筆電");
            AddProduct("滑鼠", 2, "加入滑鼠");
            RemoveProduct("滑鼠", "移除滑鼠");
            AddProduct("鍵盤", 1, "加入鍵盤");

            // 測試復原功能 - 只展示兩個操作
            Console.WriteLine("\n===== 開始測試復原功能 =====");

            Console.WriteLine("\n執行復原操作 (回到操作 3)：");
            UndoOperation();
            cart.ListCart();

            Console.WriteLine("\n再次執行復原操作 (回到操作 2)：");
            UndoOperation();
            cart.ListCart();

            // 測試重做功能
            Console.WriteLine("\n===== 開始測試重做功能 =====");

            Console.WriteLine("\n執行重做操作 (前進到操作 3)：");
            RedoOperation();
            cart.ListCart();

            Console.WriteLine("\n執行重做操作 (前進到操作 4)：");
            RedoOperation();
            cart.ListCart();

            // 在中間狀態執行新操作，測試歷史分支處理
            Console.WriteLine("\n===== 測試在歷史中間執行新操作 =====");

            Console.WriteLine("\n在當前狀態加入新商品：");
            AddProduct("耳機", 1, "加入耳機");

            // 嘗試重做，應該無法執行
            Console.WriteLine("\n嘗試執行重做操作 (應該無法執行)：");
            RedoOperation();

            // 執行復原回到加入耳機前
            Console.WriteLine("\n執行復原操作 (回到加入耳機前)：");
            UndoOperation();
            cart.ListCart();

            Console.WriteLine("\n\n按任意鍵結束...");
            Console.ReadKey();
        }

        // 加入商品到購物車
        private void AddProduct(string productName, int quantity, string operationName)
        {
            Console.WriteLine($"\n操作: 加入商品 {productName}");
            cart.AddItem(productName, quantity);
            cart.ListCart();
            SaveState(operationName);
        }

        // 從購物車移除商品
        private void RemoveProduct(string productName, string operationName)
        {
            Console.WriteLine($"\n操作: 移除商品 {productName}");
            cart.RemoveItem(productName);
            cart.ListCart();
            SaveState(operationName);
        }

        // 儲存購物車狀態
        private void SaveState(string operationName)
        {
            careTaker.SaveState(cart);
            Console.WriteLine($"[系統] 已儲存狀態：{operationName} (歷史記錄 #{careTaker.GetCurrentIndex()})");
        }

        // 執行復原操作
        private void UndoOperation()
        {
            if (careTaker.Undo(cart))
            {
                Console.WriteLine($"[系統] 已復原到歷史記錄 #{careTaker.GetCurrentIndex()}");
            }
        }

        // 執行重做操作
        private void RedoOperation()
        {
            if (careTaker.Redo(cart))
            {
                Console.WriteLine($"[系統] 已重做到歷史記錄 #{careTaker.GetCurrentIndex()}");
            }
        }
    }
}