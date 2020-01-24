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
                    Price = new ActiveAuctionPriceViewModel
                    {
                        ActualPrice = 2000,
                        HighestBid = 4000,
                        IsFavorite = false,
                        NumberOfBids = 10,
                        Id = 1
                    },
                    AdId = 1,
                    AuctionId = 1,
                    ProductDetails = new ProductDetailsViewModel
                    {
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam consectetur velit eget turpis elementum consequat. Curabitur lectus sapien, porta eget turpis quis, interdum consectetur orci. Aenean in lorem consequat, feugiat eros in, iaculis purus. Vivamus accumsan augue in urna molestie facilisis. Donec dolor eros, iaculis a condimentum imperdiet, hendrerit et leo. Vivamus dignissim fringilla volutpat. Sed imperdiet mi eget libero molestie, vitae tempor erat pharetra. Ut metus neque, luctus iaculis eros vitae, dignissim auctor elit. Integer vel tellus tincidunt, fermentum lacus non, fringilla nisi. Ut eget mattis lorem, sit amet blandit risus. Nullam vitae est elit. Donec ipsum ex, vestibulum vel augue et, euismod cursus est. Pellentesque facilisis libero urna, ut tristique tellus porttitor at."
                    },
                    PostedBy = new PostedByViewModel
                    {
                        Name = new User.NameFormat { FirstName = "Umair", LastName = "Tahir" },
                        Id = 199,
                        ProfilePic = "team-01-270x270.jpg"
                    },
                    VerifyForm = new VerifyFormViewModel(),
                    Title = "Billieblush Girls Blue Fluffy Cardigan",

                    RemainingTime = TimeSpan.FromMinutes(30.4)
                };
                model.ProductDetails.Images.Add("page1_pic6-270x217.jpg");
                model.ProductDetails.Images.Add("page1_pic7-270x217.jpg");
                model.ProductDetails.Images.Add("page1_pic8-270x217.jpg");
                model.ProductDetails.Attributes.Add(new Attribute
                {
                    Name = "Brand",
                    Value = "Levis"
                });
                model.ProductDetails.Attributes.Add(new Attribute
                {
                    Name = "Color",
                    Value = "Blue"
                });
                model.ProductDetails.Attributes.Add(new Attribute
                {
                    Name = "Condition",
                    Value = "New"
                });
                model.ProductDetails.Attributes.Add(new Attribute
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
        public ActionResult FinishedDetails(long? id)
        {
            try
            {
                //Auction auction = new Auction(id);
                //if (auction.IsClosed || auction.IsEnded)
                //{
                //    FinishedAuctionItemDetailViewModel model = new FinishedAuctionItemDetailViewModel
                //    {
                //        ActualPrice = auction.HighestBid.Price,
                //        AdId = auction.Advertisement.Id,
                //        AuctionId = auction.Id,
                //        Bids = auction.GetBidsHistory(),
                //        Description = auction.Advertisement.Description,
                //        EndingTime = Common.Functions.GetPassedTimeSpanFromNow(auction.EndTime),
                //        HighestBid = auction.HighestBid.Price,
                //        Images = auction.Advertisement.Images.Select(x => x.FileName).ToList(),
                //        PosterId = auction.Advertisement.AdPoster.UserId,
                //        PosterName = auction.Advertisement.AdPoster.FullName,
                //        StartingTime = Common.Functions.GetPassedTimeSpanFromNow(auction.StartTime),
                //        Title = auction.Advertisement.Title
                //    };
                //    foreach (var item in auction.Advertisement.GetAdditionalAttributes())
                //    {
                //        model.Attributes.Add(new ViewModels.Attribute
                //        {
                //            Name = item.Attribute.Name,
                //            Value = item.Value
                //        });
                //    }
                //    return View(model);
                //}
                if (true)
                {
                    FinishedAuctionItemDetailViewModel model = new FinishedAuctionItemDetailViewModel
                    {
                        ActualPrice = 2000,
                        AdId = 1,
                        AuctionId = 101,
                        Bids = new List<Auction.Bid>(),
                        ProductDetails = new ProductDetailsViewModel
                        {
                            Description = "Lorem ipsum dolor sit amet, consectetur " +
                        "adipiscing elit. Nulla sodales porta diam a vulputate. " +
                        "Etiam vitae varius mi. Curabitur arcu libero, efficitur vitae ornare in, " +
                        "ullamcorper a sapien. In volutpat varius dui, ac tempus enim pretium sed. " +
                        "Phasellus molestie convallis lorem, viverra pharetra felis bibendum at. " +
                        "Proin eros eros, facilisis non dignissim hendrerit, " +
                        "faucibus sit amet nunc. Vestibulum id porttitor leo, et facilisis urna. " +
                        "Curabitur ac malesuada diam. Ut volutpat felis vel lacus vehicula aliquet."
                        },
                        EndingTime = Common.Functions.GetPassedTimeSpanFromNow(new DateTime(2020, 1, 6)),
                        HighestBid = 4000,
                        PostedBy = new PostedByViewModel
                        {
                            Id = 10,
                            Name = new User.NameFormat { FirstName = "Umair", LastName = "Tahir" },
                            ProfilePic = "team-01-270x270.jpg"
                        },
                        StartingTime = Common.Functions.GetPassedDateSpanFromNow(new DateTime(2020, 1, 3)),
                        Title = "Lorem ipsum dolor"
                    };
                    model.Bids.Add(new Auction.Bid(null, null, 2200, new DateTime(2020, 1, 4, 1, 45, 0, 0)));
                    model.Bids.Add(new Auction.Bid(null, null, 2300, new DateTime(2020, 1, 4, 6, 34, 0, 0)));
                    model.Bids.Add(new Auction.Bid(null, null, 2400, new DateTime(2020, 1, 4, 12, 56, 0, 0)));
                    model.Bids.Add(new Auction.Bid(null, null, 2800, new DateTime(2020, 1, 4, 20, 13, 0, 0)));
                    model.Bids.Add(new Auction.Bid(null, null, 3200, new DateTime(2020, 1, 5, 4, 11, 0, 0)));
                    model.Bids.Add(new Auction.Bid(null, null, 3500, new DateTime(2020, 1, 5, 6, 8, 0, 0)));
                    model.Bids.Add(new Auction.Bid(null, null, 4000, new DateTime(2020, 1, 6, 5, 18, 0, 0)));
                    model.Bids = model.Bids.OrderByDescending(x => x.Price).ToList();
                    model.ProductDetails.Images.Add("page1_pic7-270x217.jpg");
                    model.ProductDetails.Images.Add("page1_pic8-270x217.jpg");
                    model.ProductDetails.Attributes.Add(new Attribute
                    {
                        Name = "Fusce auctor",
                        Value = "ipsum id"
                    });
                    model.ProductDetails.Attributes.Add(new Attribute
                    {
                        Name = "Donec tempor",
                        Value = "ex eget"
                    });
                    return View(model);
                }
                //return RedirectToAction("Error404", "Errors");
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
        public ActionResult UnverifiedAuctions()
        {
            List<UnverifiedAuctionsViewModel> model = new List<UnverifiedAuctionsViewModel>
            {
                new UnverifiedAuctionsViewModel
                {
                    Id = 1,
                    Picture = "page1_pic1-270x271.jpg",
                    Title = "Lorem Ipsum",
                    UserName = "Umair Tahir"
                }
            };
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">primary key of the auction</param>
        /// <returns></returns>
        public ActionResult PlaceBid(long id)
        {
            return View();
        }
    }
}