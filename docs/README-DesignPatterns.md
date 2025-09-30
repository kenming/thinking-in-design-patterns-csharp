# 《設計模式思維》C# 範例程式碼

## 概述
本專案提供 23 種 GoF (Gang of Four) 設計模式的 C# 實作範例，並以電子商務系統為背景情境，展示各種設計模式的應用。專案包含互動式選單，可以方便地執行和測試不同的設計模式實作。

## 專案結構

## 📖 書籍目錄與範例對照

```
DesignPatternsSolution/
└── DesignPatterns/
    ├── Program.cs                # 主程式入口點，提供互動式選單
    ├── Utils/                    # 工具類別
    │   └── IConsoleProgram.cs    # 定義通用的 Console 程式介面
    ├── Behavioral/               # 行為型設計模式
    │   ├── Command/              # 命令模式
    │   ├── CoR/                  # 責任鏈模式
    │   ├── Interpreter/          # 解釋器模式
    │   ├── Iterator/             # 迭代器模式
    │   ├── Mediator/             # 中介者模式
    │   ├── Memento/              # 備忘錄模式
    │   ├── Observer/             # 觀察者模式
    │   ├── State/                # 狀態模式
    │   ├── Strategy/             # 策略模式
    │   ├── TemplateMethod/       # 範本方法模式
    │   └── Visitor/              # 訪問者模式
    ├── Creational/               # 創建型設計模式
    │   ├── AbstractFactory/      # 抽象工廠模式
    │   ├── Builder/              # 建造者模式
    │   ├── FactoryMethod/        # 工廠方法模式
    │   ├── Prototype/            # 原型模式
    │   └── Singleton/            # 單例模式
    └── Structural/               # 結構型設計模式
        ├── Adapter/              # 適配器模式
        ├── Bridge/               # 橋接模式
        ├── Composite/            # 組合模式
        ├── Decorator/            # 裝飾器模式
        ├── Facade/               # 外觀模式
        ├── Flyweight/            # 享元模式
        └── Proxy/                # 代理模式
```

## 📖 書籍目錄與範例對照

### Part II：封裝與介面設計

| 章節 | 設計模式 | 業務場景 |
|------|----------|----------|
| Ch03 | Facade (門面模式) | 購物平台訂購商品 |
| Ch04 | Adapter (轉接器模式) | 多平台庫存管理 |
| Ch05 | Proxy (代理者模式) | 本地/境外用戶註冊 |

### Part III：行為的策略化設計

| 章節 | 設計模式 | 業務場景 |
|------|----------|----------|
| Ch06 | Strategy (策略模式) | 訂購折扣邏輯 |
| Ch07 | State (狀態模式) | 物流配送狀態追蹤 |
| Ch08 | Command (命令模式) | 用戶行為追蹤 |
| Ch09 | Memento (備忘錄模式) | 購物車備忘錄 |

### Part IV：物件的創建管理

| 章節 | 設計模式 | 業務場景 |
|------|----------|----------|
| Ch10 | Factory Method (工廠方法) | 物流保險試算器 |
| Ch11 | Abstract Factory (抽象工廠) | 跨物流服務整合 |
| Ch12 | Builder (建造者模式) | 電商電腦組裝服務 |

### Part V：單例與原型設計

| 章節 | 設計模式 | 業務場景 |
|------|----------|----------|
| Ch13 | Singleton (單例模式) | 表單ID產生器 |
| Ch14 | Prototype (原型模式) | 購物車表單物件 |

### Part VI：結構的組合與優化

| 章節 | 設計模式 | 業務場景 |
|------|----------|----------|
| Ch15 | Composite (複合模式) | 複合商品結構 |
| Ch16 | Decorator (裝飾者模式) | 商品資料XML解析器 |
| Ch17 | Bridge (橋接模式) | 電子支付整合 |
| Ch18 | Flyweight (享元模式) | 電商訂單狀態管理 |

### Part VII：物件間的協作機制

| 章節 | 設計模式 | 業務場景 |
|------|----------|----------|
| Ch19 | Observer (觀察者模式) | 店鋪商品訂閱通知 |
| Ch20 | Mediator (中介者模式) | 電商平台商品競標 |
| Ch21 | CoR (責任串鏈模式) | 客戶服務請求處理 |

### Part VIII：進階行為與解釋

| 章節 | 設計模式 | 業務場景 |
|------|----------|----------|
| Ch22 | Template Method (樣板方法) | 商品貸款處理流程 |
| Ch23 | Iterator (迭代模式) | 電商庫存盤點管理 |
| Ch24 | Visitor (訪問者模式) | 電商庫存盤點管理 |
| Ch25 | Interpreter (解譯器模式) | 優惠券規則解譯器 |

## 執行操作界面

### 主選單畫面

程式啟動後，將看到以下選單：

```
請選擇要執行的設計模式範例：
----------------------------------

[結構型設計模式]
  1. Facade - PlaceOrderConsole
  2. Proxy - PlaceRegisterConsole
  3. Adapter - PlaceStockConsole
  ...

[行為型設計模式]
  8. Strategy - PlaceOrderConsole  
  9. State - PlaceLogisticConsole
  10. Command - PlaceUserActivityConsole
  ...

[創建型設計模式]
  19. Singleton - PlaceFormIDConsole
  20. AbstractFactory - LogisticsProviderConsole
  21. Prototype - PlaceCartConsole
  ...

0. 離開程式

輸入選項: 
```

### 範例輸出畫面

例如當選擇 Template Method 模式時，將看到如下展示畫面：

```
=== ZeroInterestLoan 貸款流程開始 ===
🔍 檢查申請人 Alice 是否符合資格...
信用評等: A
✅ 資格通過
📊 計算零利率方案...
📝 產生貸款報表
申請人：Alice
貸款金額：$12,000.00
期數：12 期
每期應繳：$1,030.00
總利息：$360.00
=== 貸款流程結束 ===
```

每個範例執行完畢後，按任意鍵即可返回主選單。

[返回主 README →](../README.md)