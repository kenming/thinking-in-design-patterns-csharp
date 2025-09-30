using Thinksoft.Patterns.Utils;
using Thinksoft.Patterns.Structural.Proxy.Model;
using Thinksoft.Patterns.Structural.Proxy.Subject;

namespace Thinksoft.Patterns.Structural.Proxy
{
    public class PlaceRegisterConsole : IConsoleProgram
    {
        public void Start()
        {
            IAccount account = new Account();
            User user = new();

            Console.WriteLine("-- 使用者註冊表單 ------");
            Console.Write("User Name : ");
            string name = Console.ReadLine();
            user.Name = name;
            /* -----------------------------------------*/
            Console.Write("User Password : ");
            string password = InputPasswordWithMasking();
            user.Password = password;
            /* -----------------------------------------*/
            Console.Write("\n是否為境外用戶？ ");
            char key = Console.ReadKey(false).KeyChar;
            if (key == 'N')
                user.IsForeign = false;
            else
            {
                user.IsForeign = true;
                Console.WriteLine("\n上傳相關證件 (身分證、護照) : " +
                        "\n(模擬: 輸入 \"身分證\" 或 \"護照\" 即完成驗證)");
                string doc = Console.ReadLine();
                user.Document = doc;
             }

            /* ----------  Register  -------------------*/
            string result = account.Register(user);
            Console.Write("\n\n註冊處理結果 : ");
            Console.WriteLine(result);
        }

        // Below code is adopted from :
        // http://stackoverflow.com/questions/3404421/password-masking-console-application
        private string InputPasswordWithMasking()
        {
            string pass = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);

            return pass;
        }
    }
}
