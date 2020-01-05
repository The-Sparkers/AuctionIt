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
            try
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
                    AuctionItems = new PagedList<AuctionItemViewModel>(itemViewModels, page ?? 1, Common.Values.PAGE_SIZE)
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error500", "Errors", new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexSearchViewModel model)
        {
            if (model.CategoryId == 0 && model.EndingPeriod == EndingPeriod.Any && model.BidRange == BidRange.Any)
            {
                return Index(page: null);
            }
            else if (model.CategoryId > 0)
            {
                List<Auction> auctions = Auction.GetAllAuctions()
                    .Where(x => (x.IsClosed == false || x.IsEnded == false) && x.Advertisement.Category.Id == model.CategoryId)
                    .OrderByDescending(x => x.Advertisement.PostedTime).ToList();

                if (model.EndingPeriod != EndingPeriod.Any)
                {
                    if (model.EndingPeriod == EndingPeriod.EndingSoon)
                    {
                        auctions.OrderBy(x => x.RemainingTime);
                    }
                    else
                    {
                        auctions.OrderByDescending(x => x.RemainingTime);
                    }
                }

                if (model.BidRange != BidRange.Any)
                {
                    auctions = auctions
                        .Where(x => x.HighestBid.Price < Convert.ToDecimal((int)model.BidRange))
                        .OrderByDescending(x => x.HighestBid.Price).ToList();
                }
                List<AuctionItemViewModel> auctionItems = new List<AuctionItemViewModel>();
                foreach (var item in auctions)
                {
                    auctionItems.Add(new AuctionItemViewModel
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
                model.AuctionItems = new PagedList<AuctionItemViewModel>(auctionItems, 1, Common.Values.PAGE_SIZE);
                return View(model);
            }
            return null;
        }

        public ActionResult Details(long id)
        {
            try
            {
                //Auction auction = new Auction(id);
                //AuctionDetailsViewModel model = new AuctionDetailsViewModel
                //{
                //    ActualPrice = auction.Advertisement.StartingPrice,
                //    AdId = auction.Advertisement.Id,
                //    AuctionId = auction.Id,
                //    Description = auction.Advertisement.Description,
                //    HighestBid = auction.HighestBid.Price,
                //    PosterName = auction.Advertisement.AdPoster.FullName.ToString(),
                //    Title = auction.Advertisement.Title
                //};
                AuctionDetailsViewModel model = new AuctionDetailsViewModel
                {
                    ActualPrice = 2000,
                    AdId = 1,
                    AuctionId = 1,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam consectetur velit eget turpis elementum consequat. Curabitur lectus sapien, porta eget turpis quis, interdum consectetur orci. Aenean in lorem consequat, feugiat eros in, iaculis purus. Vivamus accumsan augue in urna molestie facilisis. Donec dolor eros, iaculis a condimentum imperdiet, hendrerit et leo. Vivamus dignissim fringilla volutpat. Sed imperdiet mi eget libero molestie, vitae tempor erat pharetra. Ut metus neque, luctus iaculis eros vitae, dignissim auctor elit. Integer vel tellus tincidunt, fermentum lacus non, fringilla nisi. Ut eget mattis lorem, sit amet blandit risus. Nullam vitae est elit. Donec ipsum ex, vestibulum vel augue et, euismod cursus est. Pellentesque facilisis libero urna, ut tristique tellus porttitor at.",
                    HighestBid = 4000,
                    PosterName = new User.NameFormat { FirstName = "Umair", LastName = "Tahir" },
                    Title = "Billieblush Girls Blue Fluffy Cardigan",
                    IsFavorite = false,
                    NumberOfBids = 10
                };
                model.Images.Add("page1_pic6-270x217.jpg");
                model.Images.Add("page1_pic7-270x217.jpg");
                model.Images.Add("page1_pic8-270x217.jpg");
                model.Attributes.Add(new ViewModels.Attribute
                {
                    Name = "Brand",
                    Value = "Levis"
                });
                model.Attributes.Add(new ViewModels.Attribute
                {
                    Name = "Color",
                    Value = "Blue"
                });
                model.Attributes.Add(new ViewModels.Attribute
                {
                    Name = "Condition",
                    Value = "New"
                });
                model.Attributes.Add(new ViewModels.Attribute
                {
                    Name = "Lorem",
                    Value = "Ipsum"
                });
                //foreach (var item in auction.Advertisement.Images)
                //{
                //    model.Images.Add(item.FileName);
                //}
                //foreach (var item in auction.Advertisement.GetAdditionalAttributes())
                //{
                //    model.Attributes.Add(new ViewModels.Attribute
                //    {
                //        Name = item.Attribute.Name,
                //        Value = item.Value
                //    });
                //}
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error500", "Errors", new { message = ex.Message });
            }
        }
    }
}