using AuctionIt.Models;
using AuctionIt.ViewModels.AuctionsViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Attribute = AuctionIt.ViewModels.AuctionsViewModels.Attribute;

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
                PrimaryUser user = null;
                if (Request.IsAuthenticated)
                {
                    user = new PrimaryUser(Models.User.GetUser(User.Identity.Name).UserId); 
                }
                Auction auction = new Auction(id);
                AuctionDetailsViewModel model = new AuctionDetailsViewModel
                {
                    Price = new ActiveAuctionPriceViewModel
                    {
                        ActualPrice = auction.Advertisement.StartingPrice,
                        HighestBid = auction.HighestBid.Price,
                        IsFavorite = user == null ? false : user.GetFavoriteAdvertisements().Contains(auction.Advertisement),
                        NumberOfBids = auction.GetBidsHistory().Count,
                        Id = auction.Id
                    },
                    AdId = auction.Advertisement.Id,
                    AuctionId = auction.Id,
                    ProductDetails = new ProductDetailsViewModel
                    {
                        Description = auction.Advertisement.Description
                    },
                    PostedBy = new PostedByViewModel
                    {
                        Name = auction.Advertisement.AdPoster.FullName,
                        Id = auction.Advertisement.AdPoster.UserId,
                        ProfilePic = auction.Advertisement.AdPoster.ProfilePic.FileName
                    },
                    VerifyForm = new VerifyFormViewModel(),
                    Title = "Billieblush Girls Blue Fluffy Cardigan",

                    RemainingTime = auction.RemainingTime
                };
                foreach (var item in auction.Advertisement.Images)
                {
                    model.ProductDetails.Images.Add(item.FileName);
                }
                foreach (var item in auction.Advertisement.GetAdditionalAttributes())
                {
                    model.ProductDetails.Attributes.Add(new Attribute
                    {
                        Name = item.Attribute,
                        Value = item.Value
                    });
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error500", "Errors", new { message = ex.Message });
            }
        }

        public ActionResult Favorites(int? page)
        {
            try
            {
                List<FavoriteAuctionItemViewModel> favoriteAuctions = new List<FavoriteAuctionItemViewModel>
                {
                    //foreach (var item in user.GetFavoriteAdvertisements())
                    //{
                    //    var auction = item.GetAuction();
                    //    FavoriteAuctionItemViewModel favoriteAuction = new FavoriteAuctionItemViewModel
                    //    {
                    //        IsClosedOrEnded = (auction.IsEnded || auction.IsClosed)
                    //    };
                    //    if (favoriteAuction.IsClosedOrEnded)
                    //    {
                    //        favoriteAuction.FinishedAuction = new FinishedAuctionViewModel
                    //        {
                    //            Id = auction.Id,
                    //            Image = item.Images[0].FileName,
                    //            Name = item.Title,
                    //            Price = auction.HighestBid.Price
                    //        };
                    //    }
                    //    else
                    //    {
                    //        favoriteAuction.AuctionItem = new AuctionItemViewModel
                    //        {
                    //            ActualPrice = item.StartingPrice,
                    //            HighestBid = auction.HighestBid.Price,
                    //            Id = auction.Id,
                    //            Image = item.Images[0].FileName,
                    //            ItemName = item.Title,
                    //            NumberOfBids = auction.GetBidsHistory().Count,
                    //            TimeToEnd = auction.RemainingTime
                    //        };
                    //    }
                    //    favoriteAuctions.Add(favoriteAuction);
                    //}
                    new FavoriteAuctionItemViewModel
                    {
                        IsClosedOrEnded = false,
                        AuctionItem = new AuctionItemViewModel
                        {
                            ActualPrice = 2000,
                            HighestBid = 3500,
                            Id = 1,
                            Image = "page1_pic5-270x217.jpg",
                            ItemName = "Apple MacBook Air 13'' 1.8GHz 128GB",
                            NumberOfBids = 3,
                            TimeToEnd = TimeSpan.FromMinutes(20)
                        }
                    },
                    new FavoriteAuctionItemViewModel
                    {
                        IsClosedOrEnded = true,
                        FinishedAuction = new FinishedAuctionViewModel
                        {
                            Id = 10,
                            Name = "Apple MacBook Pro 13'' 2.3GHz 128GB Space Gray",
                            Price = 7800,
                            Image = "page1_pic1-270x271.jpg"
                        }
                    },
                    new FavoriteAuctionItemViewModel
                    {
                        IsClosedOrEnded = false,
                        AuctionItem = new AuctionItemViewModel
                        {
                            ActualPrice = 10000,
                            HighestBid = 13890,
                            Id = 3,
                            Image = "page1_pic7-270x217.jpg",
                            ItemName = "Apple Mac mini Late 2018 (MRTT2)",
                            NumberOfBids = 4,
                            TimeToEnd = TimeSpan.FromMinutes(45)
                        }
                    },
                    new FavoriteAuctionItemViewModel
                    {
                        IsClosedOrEnded = true,
                        FinishedAuction = new FinishedAuctionViewModel
                        {
                            Id = 11,
                            Name = "Apple iPad Pro 11” Wi-Fi 64GB Silver",
                            Price = 6700,
                            Image = "page1_pic2-270x271.jpg"
                        }
                    }
                };
                PagedList<FavoriteAuctionItemViewModel> model = new PagedList<FavoriteAuctionItemViewModel>(favoriteAuctions, page ?? 1, Common.Values.PAGE_SIZE);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error500", "Errors", new { message = ex.Message });
            }
        }
        public ActionResult FinishedDetails(long id)
        {
            try
            {
                Auction auction = new Auction(id);
                if (auction.IsClosed || auction.IsEnded)
                {
                    FinishedAuctionItemDetailViewModel model = new FinishedAuctionItemDetailViewModel
                    {
                        ActualPrice = auction.HighestBid.Price,
                        AdId = auction.Advertisement.Id,
                        AuctionId = auction.Id,
                        Bids = auction.GetBidsHistory(),
                        ProductDetails = new ProductDetailsViewModel
                        {
                            Attributes = new List<Attribute>(),
                            Description = auction.Advertisement.Description,
                            Images = auction.Advertisement.Images.Select(x => x.FileName).ToList()
                        },
                        EndingTime = Common.Functions.GetPassedTimeSpanFromNow(auction.EndTime),
                        HighestBid = auction.HighestBid.Price,
                        PostedBy = new PostedByViewModel
                        {
                            Id = auction.Advertisement.AdPoster.UserId,
                            Name = auction.Advertisement.AdPoster.FullName,
                            ProfilePic = auction.Advertisement.AdPoster.ProfilePic.FileName
                        },
                        StartingTime = Common.Functions.GetPassedTimeSpanFromNow(auction.StartTime),
                        Title = auction.Advertisement.Title
                    };
                    auction.Advertisement.GetAdditionalAttributes()
                        .ForEach(x => model.ProductDetails.Attributes
                        .Add(new Attribute { Name = x.Attribute, Value = x.Value }));
                    return View(model);
                }
                return RedirectToAction("Error404", "Errors");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error500", "Errors", new { message = ex.Message });
            }
        }
        public ActionResult MyAdvertisements(int? page)
        {
            try
            {
                bool isVerified = false, isSold = false, isEnded = true, isClosed = true;
                List<MyAdvertismentsViewModel> model = new List<MyAdvertismentsViewModel>
                {
                    new MyAdvertismentsViewModel
                    {
                        Category = "Mobile",
                        Id = 1,
                        Image = "page1_pic2-270x271.jpg",
                        PostedTime = Common.Functions.GetPassedTimeSpanFromNow(new DateTime(2020, 1, 6)),
                        Status = isSold?"Sold":(isVerified?"Verified":((isEnded||isClosed)?"Rejected":"Pending")),
                        Title="Lorem Ipsum Dolor"
                    },
                    new MyAdvertismentsViewModel
                    {
                         Category="Cloths",
                          Title="Ipsum Lorem",
                           Id=2,
                            Image="page1_pic6-270x217.jpg",
                             PostedTime=Common.Functions.GetPassedTimeSpanFromNow(new DateTime(2019,12,31)),
                              Status="Sold"
                    }
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error500", "Errors", new { message = ex.Message });
            }
        }
        [Authorize(Roles ="Franchise Manager")]
        public ActionResult UnverifiedAuctions()
        {
            List<UnverifiedAuctionsViewModel> model = new List<UnverifiedAuctionsViewModel>();
            foreach (var item in Advertisement.GetAllAdvertisements().Where(x=>!x.IsVerified))
            {
                model.Add(new UnverifiedAuctionsViewModel
                {
                    Id = item.Id,
                    Picture = item.Images[0].FileName,
                    Title = item.Title,
                    UserId = item.AdPoster.UserId,
                    UserName = item.AdPoster.FullName.FullName
                });
            }
            return View(model);
        }
        [Authorize(Roles ="Franchise Manager")]
        public ActionResult VerifyAdvertisement()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">primary key of the auction</param>
        /// <returns></returns>
        [Authorize(Roles ="Primary User")]
        public ActionResult PlaceBid(long id)
        {
            Auction auction = new Auction(id);
            PlaceBidDetailsViewModel model = new PlaceBidDetailsViewModel
            {
                BidPrice = auction.HighestBid.Price,
                AuctionId = auction.Id
            };
            return View(model);
        }

        [Authorize(Roles ="Primary User")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult PlaceBid(PlaceBidDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(); 
            }
            Auction auction = new Auction(model.AuctionId);
            if (model.BidPrice<=auction.HighestBid.Price)
            {
                return View();
            }
            auction.PlaceBid(new Auction.Bid(auction, new PrimaryUser(Models.User.GetUser(User.Identity.Name).UserId), model.BidPrice, DateTime.Now));
            return RedirectToAction("Index", "Home");
        }
    }
}