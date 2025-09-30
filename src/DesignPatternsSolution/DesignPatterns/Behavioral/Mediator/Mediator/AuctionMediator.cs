using Thinksoft.Patterns.Behavioral.Mediator.Colleague;

namespace Thinksoft.Patterns.Behavioral.Mediator.Mediator
{
    /*
     * The 'Concrete Mediator' Class.
     * 實作 IAuctionMediator 介面的具體類別
     */
    public class AuctionMediator : IAuctionMediator
    {
        // 持有已註冊買家的列表
        private List<AuctionColleague> buyerList = new();
        public void Register(AuctionColleague buyer)
        { 
            buyerList.Add(buyer);   // 將買家添加到列表
        }
        /*
         * 處理買家出價通知的方法
         * 當買家出價時，此方法會被呼叫以更新買家的出價並進行相應處理
         * <param name="buyer">出價的買家</param>
         * <param name="bidPrice">出價金額</param>
         */
        public void Notify(AuctionColleague buyer, int bidPrice)
        {
            // 更新買家的出價
            buyer.BidPrice = bidPrice;

            // 檢查是否達到結束競標的條件
            CheckAuctionEndCondition(bidPrice);
        }

        /*
         * 檢查是否達到結束競標的條件
         * 如果出價超過某個閾值或所有買家都已出價，則可能結束競標
         * <param name="currentBidPrice">當前出價</param>
         */
        private void CheckAuctionEndCondition(int currentBidPrice)
        {
            // 如果出價超過特定閾值，可以自動結束競標
            const int AUTO_END_THRESHOLD = 50000;
            if (currentBidPrice >= AUTO_END_THRESHOLD)
            {
                ComputeHighestBidder();
                return;
            }

            // 檢查是否所有買家都已出價
            bool allBuyersBidded = true;
            foreach (var buyer in buyerList)
            {
                if (buyer.BidPrice <= 0) // 假設初始 BidPrice 為 0 或負數表示未出價
                {
                    allBuyersBidded = false;
                    break;
                }
            }
        }
        /*
         * 計算最高出價者並通知結果
         * 此方法會找出出價最高的買家並通知其贏得競標
         */
        public void ComputeHighestBidder()
        {
            // 使用 LINQ 獲取出價最高的買家
            AuctionColleague winner = buyerList.OrderByDescending(x => x.BidPrice).FirstOrDefault();

            if (winner != null)
            {
                // 通知獲勝者
                NotifyWinner("恭喜贏得競標!", winner);

                // 通知其他買家競標結果
                foreach (var buyer in buyerList.Where(b => b != winner))
                {
                    buyer.Receive($"競標結束，{winner.Name} 以 {winner.BidPrice} 贏得競標");
                }
            }
        }

        /*
         * 通知贏得競標的買家
         * <param name="message">通知訊息</param>
         * <param name="winner">獲勝的買家</param>
         */
        private void NotifyWinner(string message, AuctionColleague winner)
        {
            winner.Receive(message);
        }
    }
}