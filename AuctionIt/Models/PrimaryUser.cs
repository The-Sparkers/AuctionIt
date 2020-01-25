﻿using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            ExecuteQuery("AddPrimaryUser", SQLCommandTypes.StoredProcedure, new SqlParameter("@userId", System.Data.SqlDbType.BigInt)
            {
                Value = UserId
            },
            new SqlParameter("@cnic", System.Data.SqlDbType.NChar)
            {
                Value = cnic
            });
            this.cnic = cnic;
        }
        /// <summary>
        /// Rating for this user as a seller
        /// </summary>
        [DataMember]
        public double SellerRating
        {
            get
            {
                return sellerRating;
            }
        }

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
        }

        /// <summary>
        /// Gets the history of all th bids placed by this user
        /// </summary>
        /// <returns></returns>
        public List<Auction.Bid> GetBiddingHistory()
        {
            List<Auction.Bid> lstBids = new List<Auction.Bid>();
            var auctions = Auction.GetAllAuctions()
                .Where(x => x.GetBidsHistory()
                .Select(y => y.Bidder.UserId)
                .Contains(UserId))
                .ToList();
            auctions.Select(x => x.GetBidsHistory()).ToList()
                .ForEach(x => lstBids.AddRange(x
                .Where(y => y.Bidder.UserId == UserId)));
            return lstBids;
        }
        /// <summary>
        /// Gets a list of all advertisements posted by this user
        /// </summary>
        /// <returns></returns>
        public List<Advertisement> GetPostedAdvertisements()
        {
            return Advertisement.GetAllAdvertisements().Where(x => x.AdPoster.UserId == UserId).ToList();
        }
        /// <summary>
        /// Returns a list of ads that were added to its interest list by this user
        /// </summary>
        /// <returns></returns>
        public List<Advertisement> GetFavoriteAdvertisements()
        {
            List<Advertisement> advertisements = new List<Advertisement>();
            var data = GetIteratableData("GetInterestedAdvertisements", SQLCommandTypes.StoredProcedure, new SqlParameter("@userId", System.Data.SqlDbType.BigInt)
            {
                Value = UserId
            });
            foreach (var item in data)
            {
                advertisements.Add(new Advertisement(item.GetInt64(0)));
            }
            return advertisements;
        }
        /// <summary>
        /// Returns a user searched by its cnic number
        /// </summary>
        /// <param name="cnic"></param>
        /// <returns></returns>
        public static PrimaryUser GetPrimaryUser(string cnic)
        {
            return GetAllPrimaryUsers().Where(x => x.CNIC == cnic).First();
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
            PrimaryUser temp = new PrimaryUser(0);
            var data = temp.GetIteratableData("GetPrimaryUsers", SQLCommandTypes.StoredProcedure);
            foreach (var item in data)
            {
                lstUsers.Add(new PrimaryUser(item.GetInt64(0)));
            }
            
            return lstUsers.Where(x => x.FullName.FirstName.Contains(name)).ToList();
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
            var data = GetIteratableData("GetPrimaryUser", SQLCommandTypes.StoredProcedure, new SqlParameter("@id", System.Data.SqlDbType.BigInt)
            {
                Value = UserId
            });
            foreach (var item in data)
            {
                cnic = item.GetString(8);
            }
        }
    }
}