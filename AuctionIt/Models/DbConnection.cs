using ModelSQLHandler;
using System.Configuration;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    [DataContract]
    public abstract class DbConnection : SQLData
    {
        public static readonly string CONNECTION_STRING;
        static DbConnection()
        {
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        public DbConnection() : base(CONNECTION_STRING)
        {
        }
    }
}