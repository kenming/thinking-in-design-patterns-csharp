using Thinksoft.Patterns.Behavioral.Mediator.Colleague;
using Thinksoft.Patterns.Behavioral.Mediator.Mediator;
using Thinksoft.Patterns.Utils;

namespace Thinksoft.Patterns.Behavioral.Mediator
{
    public class PlaceAuctionConsole : IConsoleProgram
    {
        public void Start()
        {
            // 建立中介者
            IAuctionMediator mediator = new AuctionMediator();

            // 建立三個買家
            AuctionColleague buyer1 = new Bidder("張三", mediator);
            AuctionColleague buyer2 = new Bidder("李四", mediator);
            AuctionColleague buyer3 = new Bidder("趙八", mediator);

            // 註冊買家
            buyer1.Register();
            buyer2.Register();
            buyer3.Register();

            // 拍賣商品資訊
            Console.WriteLine("競標商品 : 秦代出土持火箭筒兵馬俑公仔");
            Console.WriteLine("競標底價 : US$10,000");
            Console.WriteLine("---------------------------------------\n");

            // 開始競標
            Console.WriteLine("競標者開始出價 : ");
            Console.WriteLine("---------------------------------------"); 

            DisplayBid(buyer1, 12000);
            buyer1.Bid(12000);

            DisplayBid(buyer2, 16000);
            buyer2.Bid(16000);

            DisplayBid(buyer3, 24000);
            buyer3.Bid(24000);

            DisplayBid(buyer2, 26000);
            buyer2.Bid(26000);

            DisplayBid(buyer3, 38000);
            buyer3.Bid(38000);

            Console.WriteLine("---------------------------------------\n");

            // 競標結束
            Console.WriteLine("競標結束 : ");
            Console.WriteLine("=========================================");
            mediator.ComputeHighestBidder();
            Console.WriteLine("=========================================");
        }

        // 顯示出價信息
        private void DisplayBid(AuctionColleague buyer, int price)
        {
            Console.WriteLine($"{buyer.Name} 出價 : {price}");
        }
    }
}