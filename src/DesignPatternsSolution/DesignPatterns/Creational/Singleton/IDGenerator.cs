using System.Diagnostics.Metrics;
using Thinksoft.Patterns.Creational.Singleton.Model;

namespace Thinksoft.Patterns.Creational.Singleton
{
    /**
     *  @Singleton
     *  表單單號產生器
     *  使用單例模式確保整個應用程序中只有一個實例負責生成單號
     */
    public class IDGenerator
    {                
        // 用於儲存單例實例的靜態欄位需要聲明為 static
        private static IDGenerator _instance;
        // 宣告 _idCounterDict 為 Dictionary<Form, int> 型別
        private Dictionary<Form, int> _idCounterDict;
        // 宣告並建立一個專用的鎖定物件
        static readonly object locker = new object();

        // 單例模式的建構函式應始終為私有，以
        // 防止使用 'new' 運算子直接建構實例
        private IDGenerator()
        {
            // initial the IDConuterDictionary instance.
            _idCounterDict = new Dictionary<Form, int>();
        }

        /**
         * 存取 Singleton 實例的靜態屬性
         * 這個屬性提供全局訪問點，確保整個應用程式中只有一個 IDGenerator 實例         
         * 
         * @return 返回 IDGenerator 的唯一實例
         */
        public static IDGenerator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        _instance = new IDGenerator();
                    }
                }
                return _instance;
            }
        }

        /**
         * 獲取下一個表單編號
         * 
         * 根據表單類型和日期生成唯一的表單編號。
         * 對於相同類型和相同日期的表單，編號會依序遞增
         * (例如：202405130001、202405130002、...)
         * 
         * 不同表單類型或不同日期有獨立的計數器序列
         * 
         * @param formType 表單類型，例如"訂購單"或"出貨單"
         * @param formDate 表單的日期，用於生成編號的日期前綴
         * @return 格式為"yyyyMMdd####"的表單編號，其中####為四位數的序號
         */
        public string GetNextID(string formType, DateTime formDate)
        {
            int currentId = 0;
            Form key = new Form()
            {
                FormType = formType,
                FormDateStr = formDate.ToString("yyyyMMdd")
            };
            
            if (!_idCounterDict.TryGetValue(key, out currentId))
            {
                _idCounterDict.Add(key, currentId);
            }
            currentId += 1;
            _idCounterDict[key] = currentId;

            return key.FormDateStr + currentId.ToString("D4");
        }
    }
}
