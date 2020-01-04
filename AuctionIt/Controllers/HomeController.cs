using AuctionIt.Models;
using AuctionIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AuctionIt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            IndexViewModel model = new IndexViewModel();
            var auctions = Auction.GetAllAuctions();
            //Current Auctions
            List<AuctionItemViewModel> currentAuctionsModel = new List<AuctionItemViewModel>();
            var currentAuction = auctions.Where(x => x.IsClosed == false || x.IsEnded == false).ToList(); //returns a list of auctions which are not finished yet
            if (currentAuction.Count > 4)
            {
                //sort the list by the number of bids on it and gets the top 4 of them
                currentAuction = currentAuction.OrderBy(x => x.GetBidsHistory().Count).ToList().GetRange(0, 4);
            }

            foreach (var item in currentAuction)
            {
                currentAuctionsModel.Add(new AuctionItemViewModel
                {
                    ActualPrice = item.Advertisement.StartingPrice,
                    HighestBid = item.HighestBid.Price,
                    Id = item.Id,
                    Image = item.Advertisement.Images[0].FileName,
                    ItemName = item.Advertisement.Title,
                    NumberOfBids = item.GetBidsHistory().Count,
                    TimeToEnd = item.RemainingTime
                });
            }
            currentAuctionsModel.Add(new AuctionItemViewModel
            {
                ActualPrice = 2000,
                HighestBid = 3500,
                Id = 1,
                Image = "page1_pic5-270x217.jpg",
                ItemName = "Apple MacBook Air 13'' 1.8GHz 128GB",
                NumberOfBids = 3,
                TimeToEnd = TimeSpan.FromMinutes(20)
            });
            currentAuctionsModel.Add(new AuctionItemViewModel
            {
                ActualPrice = 1000,
                HighestBid = 1200,
                Id = 2,
                Image = "page1_pic6-270x217.jpg",
                ItemName = "Billieblush Girls Blue Fluffy Cardigan",
                NumberOfBids = 2,
                TimeToEnd = TimeSpan.FromMinutes(23)
            });
            currentAuctionsModel.Add(new AuctionItemViewModel
            {
                ActualPrice = 10000,
                HighestBid = 13890,
                Id = 3,
                Image = "page1_pic7-270x217.jpg",
                ItemName = "Apple Mac mini Late 2018 (MRTT2)",
                NumberOfBids = 4,
                TimeToEnd = TimeSpan.FromMinutes(45)
            });
            currentAuctionsModel.Add(new AuctionItemViewModel
            {
                ActualPrice = 500,
                HighestBid = 789,
                Id = 4,
                Image = "page1_pic8-270x217.jpg",
                ItemName = "Lacoste Lerond Leather Trainers",
                NumberOfBids = 3,
                TimeToEnd = TimeSpan.FromMinutes(12)
            });
            model.CurrentAuctions = currentAuctionsModel;
            //Finished Auctions
            List<FinishedAuctionViewModel> finishedAuctionsModel = new List<FinishedAuctionViewModel>();
            var finishedAuctions = auctions.Where(x => x.IsClosed == true && x.IsEnded == true).ToList(); //returns a list of auctions which have been finished
            if (finishedAuctions.Count > 4)
            {
                //sort the auctions in reverse order by their date and time & gets the top 4 of them
                finishedAuctions = finishedAuctions.OrderByDescending(x => x.Advertisement.PostedTime).ToList().GetRange(0, 4);
            }
            foreach (var item in finishedAuctions)
            {
                finishedAuctionsModel.Add(new FinishedAuctionViewModel
                {
                    Id = item.Id,
                    Name = item.Advertisement.Title,
                    Price = item.StartingBidPrice
                });
            }
            finishedAuctionsModel.Add(new FinishedAuctionViewModel
            {
                Id = 10,
                Name = "Apple MacBook Pro 13'' 2.3GHz 128GB Space Gray",
                Price = 7800,
                Image = "page1_pic1-270x271.jpg"
            });
            finishedAuctionsModel.Add(new FinishedAuctionViewModel
            {
                Id = 11,
                Name = "Apple iPad Pro 11” Wi-Fi 64GB Silver",
                Price = 6700,
                Image = "page1_pic2-270x271.jpg"
            });
            finishedAuctionsModel.Add(new FinishedAuctionViewModel
            {
                Id = 12,
                Name = "Ray-Ban High Street 54mm Sunglasses",
                Price = 9000,
                Image = "page1_pic3-270x271.jpg"
            });
            finishedAuctionsModel.Add(new FinishedAuctionViewModel
            {
                Id = 14,
                Name = "Pier One Classic Dark Blue Ankle Boots",
                Price = 7800,
                Image = "page1_pic4-270x271.jpg"
            });
            model.FinishedAuctions = finishedAuctionsModel;
            return View(model);
        }
    }
}
