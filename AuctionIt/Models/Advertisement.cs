using System;
using System.Collections.Generic;
using ModelSQLHandler;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    [DataContract]
    public class Advertisement : DbConnection
    {
        private long id;
        private string title;
        private decimal startingPrice;
        private Category category;
        private PrimaryUser adPoster;
        private List<Common.Image> lstImages;
        private List<string> lstTags;
        private string description;
        private bool isSold;
        private bool isVerified;
        private DateTime postedTime;
        private bool isHidden;
        /// <summary>
        /// Initialize new Object from the db values using the primary key
        /// </summary>
        /// <param name="id">Primary Key</param>
        public Advertisement(long id)
        {
            this.id = id;
            InitiateValues();
        }

        /// <summary>
        /// Checks that if this advertisement is hidden from the public 
        /// </summary>
        [DataMember]
        public bool IsHidden
        {
            get { return isHidden; }
            set { isHidden = value; }
        }

        /// <summary>
        /// Time of the advertisement posting
        /// </summary>
        [DataMember]
        public DateTime PostedTime
        {
            get { return postedTime; }
        }
        /// <summary>
        /// Check to represent if the advertisement is verified or not
        /// </summary>
        [DataMember]
        public bool IsVerified
        {
            get { return isVerified; }
            set { isVerified = value; }
        }
        /// <summary>
        /// Check to represent if the advertisement is sold or not
        /// </summary>
        [DataMember]
        public bool IsSold
        {
            get { return isSold; }
            set { isSold = value; }
        }
        /// <summary>
        /// Description of the ad. item
        /// </summary>
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        /// <summary>
        /// Tags which are associated with the ad.
        /// </summary>
        [DataMember]
        public List<string> Tags
        {
            get { return lstTags; }
        }
        /// <summary>
        /// Images of the advertisement
        /// </summary>
        [DataMember]
        public List<Common.Image> Images
        {
            get { return lstImages; }
        }
        /// <summary>
        /// The user who posted the ad.
        /// </summary>
        [DataMember]
        public PrimaryUser AdPoster
        {
            get { return adPoster; }
            set { adPoster = value; }
        }
        /// <summary>
        /// Category to which the ad. belongs
        /// </summary>
        [DataMember]
        public Category Category
        {
            get { return category; }
            set { category = value; }
        }
        /// <summary>
        /// Starting price set by the user
        /// </summary>
        [DataMember]
        public decimal StartingPrice
        {
            get { return startingPrice; }
            set { startingPrice = value; }
        }
        /// <summary>
        /// Title of the advertisement
        /// </summary>
        [DataMember]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public long Id
        {
            get { return id; }
        }
        /// <summary>
        /// Method to add image for the advertisement
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public Common.Image AddImage(Common.Image image)
        {
            return image;
        }
        /// <summary>
        /// Method to add tag to make an advertisement searchable
        /// </summary>
        /// <param name="tag">Keyword</param>
        public void AddTag(string tag)
        {

        }
        /// <summary>
        /// Gets the Image which will be used as the first image for an ad.
        /// </summary>
        /// <returns></returns>
        public Common.Image GetPrimaryImage()
        {
            return new Common.Image();
        }
        /// <summary>
        /// Gets the user who have verfied this add
        /// </summary>
        /// <returns></returns>
        public FranchiseManager GetVerifier()
        {
            if (isVerified)
            {
                //returns the franchise manager who verified the advertisement
            }
            return null;
        }
        /// <summary>
        /// Verify the advertisement 
        /// </summary>
        /// <param name="verifier">The user who verified the advertisement</param>
        /// <param name="securityFee">Fee which a user have to pay to enter into the bidding process</param>
        /// <param name="startingBidPrice">Starting price for the bid</param>
        /// <param name="startTime">Starting time of the auction process</param>
        /// <param name="endTime">Ending time of the auction process</param>
        /// <returns>The details about the auction for this advertisement</returns>
        public Auction VerifyAdvertisement(FranchiseManager verifier, decimal securityFee, decimal startingBidPrice, DateTime startTime, DateTime endTime)
        {
            return new Auction(securityFee, startingBidPrice, startTime, endTime, this);
        }
        /// <summary>
        /// Deletes or hides the ad.
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return true;
        }
        /// <summary>
        /// A user adds an advertisement to his interest list
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddToInterest(PrimaryUser user)
        {
            return true;
        }
        /// <summary>
        /// A user gives rating anfd feedback after the successful buying process
        /// </summary>
        /// <param name="user"></param>
        /// <param name="rating"></param>
        /// <param name="comment"></param>
        public void GiveFeedback(PrimaryUser user, short rating, string comment = null)
        {
            new Feedback(rating, comment, DateTime.Now, user, this);
        }
        /// <summary>
        /// Sell item(s) to a buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="price"></param>
        public void SellItem(PrimaryUser buyer, decimal price)
        {

        }
        /// <summary>
        /// Gets the price at which the item(s) sold
        /// </summary>
        /// <returns></returns>
        public decimal GetSoldPrice()
        {
            return 0.0m;
        }
        /// <summary>
        /// Gets the auction deatils for the current advertisement
        /// </summary>
        /// <returns></returns>
        public Auction GetAuction()
        {
            if (isVerified)
            {
                //auction will be created only if the advertisement is verified
            }
            return null;
        }
        /// <summary>
        /// Gets a lst of the users who are interested in the item(s) on this advertisement
        /// </summary>
        /// <returns></returns>
        public List<PrimaryUser> GetInterestedUsers()
        {
            return null;
        }
        /// <summary>
        /// Get feedback provided on this advertisement
        /// </summary>
        /// <returns></returns>
        public Feedback GetFeedback()
        {
            return null;
        }
        /// <summary>
        /// Static method to create an advertisement
        /// </summary>
        /// <param name="user">who is creating the advertisement</param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="startingPrice">price from which the auction will start</param>
        /// <param name="additionalAttibutes">additional attibutes from the category</param>
        /// <returns></returns>
        public static Advertisement CreateAdvertisement(PrimaryUser user, string title, string description, decimal startingPrice, List<AdditionalAttributes.AttributeValue> additionalAttibutes)
        {
            DateTime postingTime = DateTime.Now;
            return null;
        }
        /// <summary>
        /// This method will help in searching an advertisement
        /// </summary>
        /// <param name="keyword">could be a tag or a title</param>
        /// <returns></returns>
        public static List<Advertisement> Search(string keyword)
        {
            List<Advertisement> lstAds = new List<Advertisement>();
            return lstAds;
        }
        /// <summary>
        /// Static method to get a list of all advertisements from the database
        /// </summary>
        /// <param name="max">:Limit of the item count</param>
        /// <returns></returns>
        public static List<Advertisement> GetAllAdvertisements(int max = 0)
        {
            List<Advertisement> lstAdvertisments = new List<Advertisement>();
            return lstAdvertisments;
        }

        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetAllAdvertisements());
            return lstData;
        }

        public override string GetPrimaryKey()
        {
            return id.ToString();
        }

        public override Type GetPrimaryKeyType()
        {
            return id.GetType();
        }

        public override string GetReferenceString()
        {
            return String.Format("Title: {0}, Price: {1}, Sold: {2}, Verified: {3}", title, startingPrice, isSold, isVerified);
        }

        public override void InitiateValues()
        {
            //Initiate Values from db
        }

        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetAllAdvertisements());
            return lstData;
        }

        public override Type GetObjectType()
        {
            return GetType();
        }
    }
}