using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ModelSQLHandler;

namespace AuctionIt.Models
{
    [DataContract]
    public class Auction : DbConnection
    {
        private decimal securityFee;
        private decimal startingBidPrice;
        private DateTime startTime;
        private DateTime endTime;
        private bool isClosed;
        private long id;

        public Auction(long id)
        {
            this.id = id;
            InitiateValues();
        }
        public Auction(decimal securityFee, decimal startingBidPrice, DateTime startTime, DateTime endTime, Advertisement advertisement)
        {

        }
        private Advertisement ad;
        /// <summary>
        /// The advertisement for which this auction has been opened
        /// </summary>
        [DataMember]
        public Advertisement Advertisement
        {
            get { return ad; }
        }

        /// <summary>
        /// Get the close status of the auction
        /// </summary>
        [DataMember]
        public bool IsClosed
        {
            get { return isClosed; }
            set { isClosed = value; }
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
        /// Expiry Time of the auction
        /// </summary>
        [DataMember]
        public DateTime EndTime
        {
            get { return endTime; }
        }
        /// <summary>
        /// Starting Time of the auction
        /// </summary>
        [DataMember]
        public DateTime StartTime
        {
            get { return startTime; }
        }
        /// <summary>
        /// Base price of the auction item
        /// </summary>
        [DataMember]
        public decimal StartingBidPrice
        {
            get { return startingBidPrice; }
        }
        /// <summary>
        /// Security fee to be paid by the bidder to enter into the auction
        /// </summary>
        [DataMember]
        public decimal SecurityFee
        {
            get { return securityFee; }
        }
        /// <summary>
        /// Current Highest bid in the auction
        /// </summary>
        [DataMember]
        public Bid HighestBid { get; }
        /// <summary>
        /// Checks if the auction time is ended or not
        /// </summary>
        [DataMember]
        public bool IsEnded
        {
            get
            {
                if (isClosed)
                {
                    return true;
                }
                return (endTime - DateTime.Now <= TimeSpan.Zero);
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
                    return endTime - DateTime.Now;
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
        }
        /// <summary>
        /// Place a new Bid into the auction
        /// </summary>
        /// <param name="bid"></param>
        public void PlaceBid(Bid bid)
        {

        }
        /// <summary>
        /// Returns true if security fee for this auction is paid or not
        /// </summary>
        /// <param name="bidder">User who paid the security fee</param>
        /// <returns></returns>
        public bool IsSecurityPaid(PrimaryUser bidder)
        {
            return (Token.GetToken(bidder.UserId + "_" + id).Auction == this);
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
                return new Token(Token.GetHash(bidder.UserId.ToString() + "_" + id.ToString()), bidder, this);
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
            return true;
        }
        /// <summary>
        /// Gets a history of all the bids palced previously
        /// </summary>
        /// <returns></returns>
        public List<Bid> GetBidsHistory()
        {
            List<Bid> lstBids = new List<Bid>();
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
            return id.ToString();
        }

        public override Type GetPrimaryKeyType()
        {
            return id.GetType();
        }

        public override string GetReferenceString()
        {
            return String.Format("Start Time: {0}, End Time: {1}, Start Price: {2}", startTime, endTime, startingBidPrice);
        }

        public override void InitiateValues()
        {
            //initiates values from the database by using primary key
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
            Auction auction;
            PrimaryUser bidder;
            decimal price;
            private DateTime timeStamp;
            public Bid(Auction auction, PrimaryUser bidder, decimal price, DateTime timeStamp)
            {
                this.auction = auction;
                this.bidder = bidder;
                this.price = price;
            }

            public DateTime TimeStamp
            {
                get { return timeStamp; }
            }

            /// <summary>
            /// Auction on which this bid has been placed
            /// </summary>
            [DataMember]
            public Auction Auction
            {
                get
                {
                    return auction;
                }
            }
            /// <summary>
            /// The user who placed the bid
            /// </summary>
            [DataMember]
            public PrimaryUser Bidder
            {
                get
                {
                    return bidder;
                }
            }
            /// <summary>
            /// The value which is palced
            /// </summary>
            [DataMember]
            public decimal Price
            {
                get
                {
                    return price;
                }
            }
        }
    }
}