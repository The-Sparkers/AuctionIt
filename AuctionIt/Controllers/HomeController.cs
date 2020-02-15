using AuctionIt.Models;
using AuctionIt.ViewModels.AuctionsViewModels;
using AuctionIt.ViewModels.HomeControllerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
                    ActualPrice = decimal.Round(item.Advertisement.StartingPrice,2),
                    HighestBid = decimal.Round(item.HighestBid==null?0:item.HighestBid.Price,2),
                    Id = item.Id,
                    Image = item.Advertisement.Images[0].FileName,
                    ItemName = item.Advertisement.Title,
                    NumberOfBids = item.GetBidsHistory().Count,
                    TimeToEnd = item.RemainingTime
                });
            }
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
                    Price = decimal.Round(item.StartingBidPrice,2)
                });
            }
            model.FinishedAuctions = finishedAuctionsModel;
            return View(model);
        }
        public ActionResult TermsNConditions()
        {
            return View();
        }
        public JsonResult GetTagsForAutoComplete(string term)
        {
            try
            {
                List<string> items = Auction.GetAllAuctions().Select(x => x.Advertisement.Title).ToList();
                return Json(items.Where(x => x.ToUpper().StartsWith(term.ToUpper())).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }
    }
}
