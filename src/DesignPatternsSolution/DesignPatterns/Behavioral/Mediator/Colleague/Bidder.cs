using Thinksoft.Patterns.Behavioral.Mediator.Mediator;

namespace Thinksoft.Patterns.Behavioral.Mediator.Colleague
{
    /*
     *  The 'Concrete Colleague' Class.
     *  拍賣場競標者具體類別
     */
    public class Bidder : AuctionColleague
    {
        // 參數化建構函式
        public Bidder(string name, IAuctionMediator mediator) : base(name)
        {
            base.Mediator = mediator;
        }

        /*
         * 覆寫基底類別的 Bid 方法，提供特定的出價行為
         * 在通知中介者前，先輸出出價信息
         * <param>競標價格</param>
         */
        public override void Bid(int bidPrice)
        {            
            base.BidPrice = bidPrice;                        // 設置出價金額
            base.Bid(bidPrice);                              // 呼叫基底類別方法通知中介者
        }

        /*
         * 實現接收訊息的方法
         * <param>接收到的訊息</param>
         */
        public override void Receive(string message)
        {
            // 本範例暫時保留Console輸出以便於演示。
            Console.WriteLine($"{Name} :: 接收訊息 : {message}");
        }
    }
}