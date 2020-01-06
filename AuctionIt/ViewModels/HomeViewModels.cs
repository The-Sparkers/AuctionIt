using System;
using System.Collections.Generic;

namespace AuctionIt.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            CurrentAuctions = new List<AuctionItemViewModel>(4);
            FinishedAuctions = new List<FinishedAuctionViewModel>(4);
        }
        public List<AuctionItemViewModel> CurrentAuctions { get; set; }
        public List<FinishedAuctionViewModel> FinishedAuctions { get; set; }
    }

    public class FinishedAuctionViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
    public class AuctionItemViewModel
    {
        public long Id { get; set; }
        public TimeSpan TimeToEnd { get; set; }
        public string Image { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal HighestBid { get; set; }
        public string ItemName { get; set; }
        public int NumberOfBids { get; set; }
    }

}