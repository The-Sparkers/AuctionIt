using ModelSQLHandler;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    [DataContract]
    public abstract class DbConnection : SQLData
    {
        public static readonly string CONNECTION_STRING;
        static DbConnection()
        {
            CONNECTION_STRING = AuctionIt.Common.Strings.CONNECTION_STRING;
        }
        public DbConnection() : base(CONNECTION_STRING)
        {
        }
    }
}