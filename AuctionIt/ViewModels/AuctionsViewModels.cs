using PagedList;
using System.ComponentModel.DataAnnotations;

namespace AuctionIt.ViewModels
{
    public class IndexSearchViewModel
    {
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        [Display(Name ="Bid Range")]
        public BidRange BidRange { get; set; }
        [Display(Name ="Ending Period")]
        public EndingPeriod EndingPeriod { get; set; }
        public IPagedList<AuctionItemViewModel> AuctionItems { get; set; }
    }

    public enum BidRange
    {
        Any=0,
        [Display(Name = "<5000")]
        LessThan5K = 4999,
        [Display(Name = ">=5000 & <15000")]
        LessThan15K = 14999,
        [Display(Name = ">=15000 & <50000")]
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