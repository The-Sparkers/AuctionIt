using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    [DataContract]
    public class PrimaryUser : User
    {
        private string cnic;
        private readonly double sellerRating;

        public PrimaryUser(long id) : base(id)
        {
            InitiateValues();
        }

        public PrimaryUser(NameFormat name, ContactNumberFormat phoneNumber, string city, string cnic) : base(name, phoneNumber, city)
        {
            this.cnic = cnic;
        }
        /// <summary>
        /// Rating for this user as a seller
        /// </summary>
        [DataMember]
        public double SellerRating => sellerRating;
        /// <summary>
        /// Unique CNIC of this user
        /// </summary>
        [DataMember]
        public string CNIC
        {
            get
            {
                return cnic;
            }
            set
            {
                cnic = value;
            }
        }
        /// <summary>
        /// Gets the history of all th bids placed by this user
        /// </summary>
        /// <returns></returns>
        public List<Auction.Bid> GetBiddingHistory()
        {
            List<Auction.Bid> lstBids = new List<Auction.Bid>();
            return lstBids;
        }
        /// <summary>
        /// Gets a list of all advertisements posted by this user
        /// </summary>
        /// <returns></returns>
        public List<Advertisement> GetPostedAdvertisements()
        {
            List<Advertisement> lstAd = new List<Advertisement>();
            return lstAd;
        }
        /// <summary>
        /// Returns a list of ads that were added to its interest list by this user
        /// </summary>
        /// <returns></returns>
        public List<Advertisement> GetFavoriteAdvertisements()
        {
            List<Advertisement> advertisements = new List<Advertisement>();
            return advertisements;
        }
        /// <summary>
        /// Returns a user searched by its cnic number
        /// </summary>
        /// <param name="cnic"></param>
        /// <returns></returns>
        public static PrimaryUser GetPrimaryUser(string cnic)
        {
            return null;
        }
        /// <summary>
        /// Returns a list of all primary users present in the database
        /// </summary>
        /// <param name="name">if want to be searched by the names</param>
        /// <param name="max">maximum number of results (0 means no limit).</param>
        /// <returns></returns>
        public static List<PrimaryUser> GetAllPrimaryUsers(string name = "", int max = 0)
        {
            List<PrimaryUser> lstUsers = new List<PrimaryUser>();
            return lstUsers;
        }
        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetAllPrimaryUsers());
            return lstData;
        }
        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetAllPrimaryUsers());
            return lstData;
        }
        public override Type GetObjectType()
        {
            return GetType();
        }
        public override void InitiateValues()
        {
            //initiates values from the database by using primary key
        }
    }
}