using Thinksoft.Patterns.Behavioral.Mediator.Mediator;

namespace Thinksoft.Patterns.Behavioral.Mediator.Colleague
{
    /*
     *  The 'Colleague' Abstract Class.
     *  拍賣參與者抽象類別
     */
    public abstract class AuctionColleague
    {
        public string Name { get; private set; }    // 買家姓名
        public int BidPrice { get; set; }           // 競標價格

        // 持有中介者的參考
        public IAuctionMediator Mediator { get; set; }

        // 建構函式
        public AuctionColleague(string name)
        {
            this.Name = name;
        }

        // 實作向 Mediator 註冊的方法
        public void Register()
        {
            Mediator.Register(this);
        }

        /*
         * 定義參與者出價的方法
         * 使用 virtual 關鍵字允許衍生類別覆寫此方法，以提供特定的出價行為
         * 基礎實現會通知中介者有新的出價
         * <param>競標價格</param>
         */
        public virtual void Bid(int bidPrice)
        {
            // 通知中介者有新的出價
            Mediator.Notify(this, bidPrice);
        }

        // 定義接收訊息的抽象方法
        public abstract void Receive(string message);
    }
}