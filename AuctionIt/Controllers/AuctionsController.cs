using AuctionIt.Models;
using AuctionIt.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AuctionIt.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: Auctions
        public ActionResult Index(int? page)
        {
            List<AuctionItemViewModel> itemViewModels = new List<AuctionItemViewModel>();
            foreach (var item in Auction.GetAllAuctions().Where(x => x.IsClosed == false || x.IsEnded == false))
            {
                itemViewModels.Add(new AuctionItemViewModel
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
            itemViewModels.Add(new AuctionItemViewModel
            {
                ActualPrice = 2000,
                HighestBid = 3500,
                Id = 1,
                Image = "page1_pic5-270x217.jpg",
                ItemName = "Apple MacBook Air 13'' 1.8GHz 128GB",
                NumberOfBids = 3,
                TimeToEnd = TimeSpan.FromMinutes(20)
            });
            itemViewModels.Add(new AuctionItemViewModel
            {
                ActualPrice = 1000,
                HighestBid = 1200,
                Id = 2,
                Image = "page1_pic6-270x217.jpg",
                ItemName = "Billieblush Girls Blue Fluffy Cardigan",
                NumberOfBids = 2,
                TimeToEnd = TimeSpan.FromMinutes(23)
            });
            itemViewModels.Add(new AuctionItemViewModel
            {
                ActualPrice = 10000,
                HighestBid = 13890,
                Id = 3,
                Image = "page1_pic7-270x217.jpg",
                ItemName = "Apple Mac mini Late 2018 (MRTT2)",
                NumberOfBids = 4,
                TimeToEnd = TimeSpan.FromMinutes(45)
            });
            itemViewModels.Add(new AuctionItemViewModel
            {
                ActualPrice = 500,
                HighestBid = 789,
                Id = 4,
                Image = "page1_pic8-270x217.jpg",
                ItemName = "Lacoste Lerond Leather Trainers",
                NumberOfBids = 3,
                TimeToEnd = TimeSpan.FromMinutes(12)
            });
            itemViewModels.Add(new AuctionItemViewModel
            {
                ActualPrice = 2000,
                HighestBid = 3500,
                Id = 1,
                Image = "page1_pic5-270x217.jpg",
                ItemName = "Apple MacBook Air 13'' 1.8GHz 128GB",
                NumberOfBids = 3,
                TimeToEnd = TimeSpan.FromMinutes(20)
            });
            itemViewModels.Add(new AuctionItemViewModel
            {
                ActualPrice = 1000,
                HighestBid = 1200,
                Id = 2,
                Image = "page1_pic6-270x217.jpg",
                ItemName = "Billieblush Girls Blue Fluffy Cardigan",
                NumberOfBids = 2,
                TimeToEnd = TimeSpan.FromMinutes(23)
            });
            itemViewModels.Add(new AuctionItemViewModel
            {
                ActualPrice = 10000,
                HighestBid = 13890,
                Id = 3,
                Image = "page1_pic7-270x217.jpg",
                ItemName = "Apple Mac mini Late 2018 (MRTT2)",
                NumberOfBids = 4,
                TimeToEnd = TimeSpan.FromMinutes(45)
            });
            itemViewModels.Add(new AuctionItemViewModel
            {
                ActualPrice = 500,
                HighestBid = 789,
                Id = 4,
                Image = "page1_pic8-270x217.jpg",
                ItemName = "Lacoste Lerond Leather Trainers",
                NumberOfBids = 3,
                TimeToEnd = TimeSpan.FromMinutes(12)
            });
            IndexSearchViewModel model = new IndexSearchViewModel
            {
                AuctionItems = new PagedList<AuctionItemViewModel>(itemViewModels, page ?? 1, int.MaxValue)
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexSearchViewModel model)
        {
            if (model.CategoryId == 0 && model.EndingPeriod == EndingPeriod.Any && model.BidRange == BidRange.Any)
            {
                return Index(page: null);
            }
            return View();
        }
    }
}