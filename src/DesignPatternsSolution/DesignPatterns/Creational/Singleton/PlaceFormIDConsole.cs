using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Creational.Singleton
{
    /**
     * 表單編號產生器 Console
     */
    public class PlaceFormIDConsole : IConsoleProgram
    {
        public void Start()
        {
            char key = '0';

            while (key != 'q')
            {
                Console.WriteLine("請輸入表單類型：");
                Console.WriteLine("1. 訂購單");
                Console.WriteLine("2. 出貨單");
                Console.WriteLine("----------\n");

                var select = Console.ReadKey(true).KeyChar;
                string formType = GetFormType(select);

                if (!string.IsNullOrEmpty(formType))
                {
                    string id = IDGenerator.Instance.GetNextID(formType, DateTime.Today);
                    Console.WriteLine($"{formType} 所產生的單號為：{id}");
                }
                else
                {
                    Console.WriteLine("無效的選擇，請重試。");
                }

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("按任意鍵繼續，或按 'q' 退出\n");
                key = Console.ReadKey(true).KeyChar;
            }
        }

        /**
         * 根據使用者選擇返回對應的表單類型
         * @param select 使用者的選擇字符
         * @return 表單類型名稱，如果選擇無效則返回空字串
         */
        private string GetFormType(char select)
        {
            return select switch
            {
                '1' => "訂購單",
                '2' => "出貨單",
                _ => string.Empty
            };
        }
    }
}