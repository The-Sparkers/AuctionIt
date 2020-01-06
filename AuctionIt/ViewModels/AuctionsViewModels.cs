using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuctionIt.ViewModels
{
    public class IndexSearchViewModel
    {
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Bid Range")]
        public BidRange BidRange { get; set; }
        [Display(Name = "Ending Period")]
        public EndingPeriod EndingPeriod { get; set; }
        public IPagedList<AuctionItemViewModel> AuctionItems { get; set; }
    }
    public class AuctionDetailsViewModel
    {
        public AuctionDetailsViewModel()
        {
            Images = new List<string>();
            Attributes = new List<Attribute>();
        }
        public long AuctionId { get; set; }
        public long AdId { get; set; }
        [Display(Name = "Auction Title")]
        public string Title { get; set; }
        [Display(Name = "Item Description")]
        public string Description { get; set; }
        [Display(Name = "Opening Price")]
        public decimal ActualPrice { get; set; }
        [Display(Name = "Current Bid")]
        public decimal HighestBid { get; set; }
        [Display(Name = "Posted By")]
        public Models.User.NameFormat PosterName { get; set; }
        public List<string> Images { get; set; }
        public List<Attribute> Attributes { get; set; }
        public bool IsFavorite { get; set; }
        public long UserId { get; set; }
        public int NumberOfBids { get; set; }
        public TimeSpan RemainingTime { get; set; }
    }
    public class FinishedAuctionViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Display(Name = "Closing Price")]
        public decimal Price { get; set; }

        public string Image { get; set; }
    }
    public class AuctionItemViewModel
    {
        public long Id { get; set; }
        [Display(Name = "To End")]
        public TimeSpan TimeToEnd { get; set; }
        public string Image { get; set; }
        [Display(Name = "Opening Price")]
        public decimal ActualPrice { get; set; }
        [Display(Name = "Current Bid")]
        public decimal HighestBid { get; set; }
        [Display(Name = "Title")]
        public string ItemName { get; set; }
        [Display(Name = "Bids")]
        public int NumberOfBids { get; set; }
    }
    public class FavoriteAuctionItemViewModel
    {
        public AuctionItemViewModel AuctionItem { get; set; }
        public FinishedAuctionViewModel FinishedAuction { get; set; }
        public bool IsClosedOrEnded { get; set; }
    }
    public struct Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public enum BidRange
    {
        Any = 0,
        [Display(Name = "<5000")]
        LessThan5K = 4999,
        [Display(Name = "<15000")]
        LessThan15K = 14999,
        [Display(Name = "<50000")]
        LessThan50K = 49999,
        [Display(Name = ">=50000")]
        GreaterThan50K = short.MaxValue
    }
    public enum EndingPeriod
    {
        Any = 0,
        [Display(Name = "Ending Soon")]
        EndingSoon = 1,
        [Display(Name = "Started Recently")]
        StartedRecently = 2
    }
}