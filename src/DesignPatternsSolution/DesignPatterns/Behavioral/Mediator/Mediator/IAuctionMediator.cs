using Thinksoft.Patterns.Behavioral.Mediator.Colleague;

namespace Thinksoft.Patterns.Behavioral.Mediator.Mediator
{
    /*
     * The 'Mediator' Interface
     * 制定 Auction Mediator (中介者) 的操作介面
     */
    public interface IAuctionMediator
    {
        void Register(AuctionColleague buyer);     // 註冊買家
        void Notify(AuctionColleague buyer, int bidPrice); // 處理買家的出價通知
        void ComputeHighestBidder();    // 取得最高價競標者
    }
}