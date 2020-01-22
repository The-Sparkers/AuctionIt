using AuctionIt.ViewModels.AuctionsViewModels;
using System.Collections.Generic;

namespace AuctionIt.ViewModels.HomeControllerViewModels
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
}