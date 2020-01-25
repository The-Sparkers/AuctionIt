using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    [DataContract]
    public class Auction : DbConnection
    {
        public Auction(long id)
        {
            this.Id1 = id;
            InitiateValues();
        }
        public Auction(decimal securityFee, decimal startingBidPrice, DateTime startTime, DateTime endTime, Advertisement advertisement)
        {
            Id1 = Convert.ToInt64(GetValue("AddAuction", SQLCommandTypes.StoredProcedure, new SqlParameter("@adId", System.Data.SqlDbType.BigInt)
            {
                Value = advertisement.Id
            }, new SqlParameter("@startingPrice", System.Data.SqlDbType.Money)
            {
                Value = advertisement.StartingPrice
            },
            new SqlParameter("@endTime", System.Data.SqlDbType.DateTime)
            {
                Value = endTime
            },
            new SqlParameter("@startTime", System.Data.SqlDbType.DateTime)
            {
                Value = startTime
            },
            new SqlParameter("@secutiryFee", System.Data.SqlDbType.Money)
            {
                Value = securityFee
            }));
            this.SecurityFee = securityFee;
            this.StartingBidPrice = startingBidPrice;
            this.StartTime = startTime;
            this.EndTime = endTime;
            Ad = advertisement;
        }
        /// <summary>
        /// The advertisement for which this auction has been opened
        /// </summary>
        [DataMember]
        public Advertisement Advertisement => Ad;

        /// <summary>
        /// Get the close status of the auction
        /// </summary>
        [DataMember]
        public bool IsClosed
        {
            get
            {
                try
                {
                    return Advertisement.IsSold;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public long Id => Id1;
        /// <summary>
        /// Expiry Time of the auction
        /// </summary>
        [DataMember]
        public DateTime EndTime { get; private set; }
        /// <summary>
        /// Starting Time of the auction
        /// </summary>
        [DataMember]
        public DateTime StartTime { get; private set; }
        /// <summary>
        /// Base price of the auction item
        /// </summary>
        [DataMember]
        public decimal StartingBidPrice { get; private set; }
        /// <summary>
        /// Security fee to be paid by the bidder to enter into the auction
        /// </summary>
        [DataMember]
        public decimal SecurityFee { get; private set; }
        /// <summary>
        /// Current Highest bid in the auction
        /// </summary>
        [DataMember]
        public Bid HighestBid
        {
            get
            {
                var bids = GetBidsHistory();
                bids.OrderByDescending(x => x.TimeStamp);
                return bids.First();
            }
        }
        /// <summary>
        /// Checks if the auction time is ended or not
        /// </summary>
        [DataMember]
        public bool IsEnded
        {
            get
            {
                if (IsClosed1)
                {
                    return true;
                }
                return (EndTime - DateTime.Now <= TimeSpan.Zero);
            }
        }
        /// <summary>
        /// Gets the remaining time in ending of the auction
        /// </summary>
        [DataMember]
        public TimeSpan RemainingTime
        {
            get
            {
                if (!IsEnded)
                {
                    return EndTime - DateTime.Now;
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
        }

        public bool IsClosed1 { get; }

        public long Id1 { get; set; }
        public Advertisement Ad { get; set; }

        /// <summary>
        /// Place a new Bid into the auction
        /// </summary>
        /// <param name="bid"></param>
        public bool PlaceBid(Bid bid)
        {
            if (bid.Price <= HighestBid.Price)
            {
                return false;
            }
            else
            {
                ExecuteQuery("BidToAuction", SQLCommandTypes.StoredProcedure, new SqlParameter("@userId", System.Data.SqlDbType.BigInt)
                {
                    Value = bid.Bidder.UserId
                }, new SqlParameter("@adId", System.Data.SqlDbType.BigInt)
                {
                    Value = bid.GetAuction().Advertisement.Id
                },
                new SqlParameter("@bid", System.Data.SqlDbType.Money)
                {
                    Value = bid.Price
                },
                new SqlParameter("@dateTime", System.Data.SqlDbType.DateTime)
                {
                    Value = bid.TimeStamp
                });
                return true;
            }
        }
        /// <summary>
        /// Returns true if security fee for this auction is paid or not
        /// </summary>
        /// <param name="bidder">User who paid the security fee</param>
        /// <returns></returns>
        public bool IsSecurityPaid(PrimaryUser bidder)
        {
            try
            {
                return (Token.GetToken(bidder.UserId + "_" + Id1).Auction.Id == Id1);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Pay security security fee and returns a token to be used for the auction
        /// </summary>
        /// <param name="bidder">Who is going to pay security fee</param>
        /// <returns></returns>
        public Token PaySecurity(PrimaryUser bidder)
        {
            if (!IsSecurityPaid(bidder))
            {
                return new Token(Token.GetHash(bidder.UserId.ToString() + "_" + Id1.ToString()), bidder, this);
            }
            return null;
        }
        /// <summary>
        /// Finat Payment for the auction
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public bool Pay(PrimaryUser buyer)
        {
            try
            {
                ExecuteQuery("PayForAuction", SQLCommandTypes.StoredProcedure, new SqlParameter("@userId", System.Data.SqlDbType.BigInt)
                {
                    Value = buyer.UserId
                },
                new SqlParameter("@aId", System.Data.SqlDbType.BigInt)
                {
                    Value = Ad.Id
                },
                new SqlParameter("@price", System.Data.SqlDbType.Money)
                {
                    Value = HighestBid.Price
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Gets a history of all the bids palced previously
        /// </summary>
        /// <returns></returns>
        public List<Bid> GetBidsHistory()
        {
            List<Bid> lstBids = new List<Bid>();
            var data = GetIteratableData("GetAuctionBids", SQLCommandTypes.StoredProcedure, new SqlParameter("@auctionId", System.Data.SqlDbType.BigInt)
            {
                Value = Id1
            });
            foreach (var item in data)
            {
                lstBids.Add(new Bid(new Auction(item.GetInt64(1)), new PrimaryUser(item.GetInt64(0)), item.GetDecimal(2), item.GetDateTime(3)));
            }
            return lstBids;
        }
        /// <summary>
        /// Returns a list of all auctions in the database
        /// </summary>
        /// <param name="max">Maximum results (zero means no limit)</param>
        /// <returns></returns>
        public static List<Auction> GetAllAuctions(int max = 0)
        {
            List<Auction> lstAuctions = new List<Auction>();
            Auction temp = new Auction(0);
            var data = temp.GetIteratableData("GetAuctions", SQLCommandTypes.StoredProcedure);
            foreach (var item in data)
            {
                lstAuctions.Add(new Auction(item.GetInt64(0)));
            }
            return lstAuctions;
        }

        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetAllAuctions());
            return lstData;
        }

        public override string GetPrimaryKey()
        {
            return Id1.ToString();
        }

        public override Type GetPrimaryKeyType()
        {
            return Id1.GetType();
        }

        public override string GetReferenceString()
        {
            return string.Format("Start Time: {0}, End Time: {1}, Start Price: {2}", StartTime, EndTime, StartingBidPrice);
        }

        public override void InitiateValues()
        {
            var data = GetIteratableData("GetAuction", SQLCommandTypes.StoredProcedure, new SqlParameter("@id", System.Data.SqlDbType.BigInt)
            {
                Value = Id1
            });
            foreach (var item in data)
            {
                StartingBidPrice =item.GetDecimal(1);
                StartTime = item.GetDateTime(2);
                SecurityFee = item.GetDecimal(3);
                EndTime = item.GetDateTime(4);
                Ad = new Advertisement(item.GetInt64(5));
            }
        }

        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetAllAuctions());
            return lstData;
        }

        public override Type GetObjectType()
        {
            return GetType();
        }

        /// <summary>
        /// A bid is a price value which is placed on an auction
        /// </summary>
        [DataContract]
        public class Bid
        {
            private readonly Auction auction;
            private readonly PrimaryUser bidder;
            private readonly decimal price;

            public Bid(Auction auction, PrimaryUser bidder, decimal price, DateTime timeStamp)
            {
                this.auction = auction;
                this.bidder = bidder;
                this.price = price;
                TimeStamp = timeStamp;
            }

            public DateTime TimeStamp { get; }

            /// <summary>
            /// Auction on which this bid has been placed
            /// </summary>
            public Auction GetAuction()
            {
                return auction;
            }
            /// <summary>
            /// The user who placed the bid
            /// </summary>
            [DataMember]
            public PrimaryUser Bidder => bidder;
            /// <summary>
            /// The value which is palced
            /// </summary>
            [DataMember]
            public decimal Price => price;
        }
    }
}