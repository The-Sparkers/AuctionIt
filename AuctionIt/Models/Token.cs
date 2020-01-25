using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.Data.HashFunction;
using System.Data.HashFunction.CityHash;
using System.Data.SqlClient;
using System.Linq;
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
        private readonly PrimaryUser bidder;
        private readonly Auction auction;
        private long id;

        public Token(long id)
        {
            this.id = id;
            InitiateValues();
        }
        internal Token(string hashKey, PrimaryUser bidder, Auction auction)
        {
            ExecuteQuery("CreateToken", SQLCommandTypes.StoredProcedure, new SqlParameter("@hash", System.Data.SqlDbType.VarChar)
            {
                Value = Guid.NewGuid()
            },
            new SqlParameter("UserId", System.Data.SqlDbType.BigInt)
            {
                Value = bidder.UserId
            },
            new SqlParameter("@auctionId", System.Data.SqlDbType.BigInt)
            {
                Value = auction.Id
            });
            this.hashKey = hashKey;
            this.bidder = bidder;
            this.auction = auction;
        }
        /// <summary>
        /// Auction to which this token belongs
        /// </summary>
        [DataMember]
        public Auction Auction => auction;
        /// <summary>
        /// User who owned this token
        /// </summary>
        [DataMember]
        public PrimaryUser Bidder => bidder;
        /// <summary>
        /// Hashed Key for the token, Primary Key
        /// </summary>
        [DataMember]
        public string HashKey => hashKey;
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
            return GetAllTokens().Where(x => x.HashKey == hashKey).First();
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
            Token temp = new Token(0);
            var data = temp.GetIteratableData("SELECT TokenId FROM TOKENS", SQLCommandTypes.StoredProcedure);
            while (data.Read())
            {
                lstTokens.Add(new Token((long)data[0]));
            }
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
            return string.Format("Hash Key: {0}", hashKey);
        }

        public override void InitiateValues()
        {
            //initialize values from the database
            var data = GetIteratableData("GetToken", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.BigInt)
            {
                Value = id
            });
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