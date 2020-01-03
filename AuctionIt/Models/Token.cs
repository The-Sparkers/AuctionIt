using System;
using System.Collections.Generic;
using System.Data.HashFunction;
using System.Data.HashFunction.CityHash;
using ModelSQLHandler;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    /// <summary>
    /// Require to verify a user to enter into auction
    /// </summary>
    [DataContract]
    public class Token : DbConnection
    {
        private string hashKey;
        private PrimaryUser bidder;
        private Auction auction;

        public Token(string hashKey)
        {
            this.hashKey = hashKey;
            InitiateValues();
        }
        internal Token(string hashKey, PrimaryUser bidder, Auction auction)
        {
            this.hashKey = hashKey;
            this.bidder = bidder;
            this.auction = auction;
        }
        /// <summary>
        /// Auction to which this token belongs
        /// </summary>
        [DataMember]
        public Auction Auction
        {
            get { return auction; }
        }
        /// <summary>
        /// User who owned this token
        /// </summary>
        [DataMember]
        public PrimaryUser Bidder
        {
            get { return bidder; }
        }
        /// <summary>
        /// Hashed Key for the token, Primary Key
        /// </summary>
        [DataMember]
        public string HashKey
        {
            get { return hashKey; }
        }
        /// <summary>
        /// Method to verify a token for a bidder against an auction
        /// </summary>
        /// <param name="hashKey"></param>
        /// <param name="auction"></param>
        /// <param name="bidder"></param>
        /// <returns></returns>
        public bool VerifyToken(string hashKey, Auction auction, PrimaryUser bidder)
        {
            if (hashKey == this.hashKey && auction.Id == this.auction.Id && bidder.UserId == this.bidder.UserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Static Method to get token against the hashed key
        /// </summary>
        /// <param name="hashKey"></param>
        /// <returns></returns>
        public static Token GetToken(string hashKey)
        {
            return null;
        }
        /// <summary>
        /// Static Method to get a hash for a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetHash(string s)
        {
            ICityHash cityHash = CityHashFactory.Instance.Create();
            var hashValue = cityHash.ComputeHash(s);
            return hashValue.AsHexString();
        }
        /// <summary>
        /// Static method to get hash for a number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetHash(long n)
        {
            ICityHash cityHash = CityHashFactory.Instance.Create();
            var hashValue = cityHash.ComputeHash(n);
            return hashValue.AsHexString();
        }
        /// <summary>
        /// Method to get all tokens in the database
        /// </summary>
        /// <param name="max">maximum number of records (0 means no limit)</param>
        /// <returns></returns>
        public static List<Token> GetAllTokens(int max = 0)
        {
            List<Token> lstTokens = new List<Token>();
            return lstTokens;
        }
        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetAllTokens());
            return lstData;
        }

        public override string GetPrimaryKey()
        {
            return hashKey;
        }

        public override Type GetPrimaryKeyType()
        {
            return hashKey.GetType();
        }

        public override string GetReferenceString()
        {
            return String.Format("Hash Key: {0}", hashKey);
        }

        public override void InitiateValues()
        {
            //initialize values from the database
        }

        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetAllTokens());
            return lstData;
        }

        public override Type GetObjectType()
        {
            return GetType();
        }
    }
}