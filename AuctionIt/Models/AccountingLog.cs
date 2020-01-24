using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    /// <summary>
    /// Keeps record for the debit credit details for a user
    /// </summary>
    [DataContract]
    public class AccountingLog : DbConnection
    {
        private decimal debit;
        private decimal credit;
        private DateTime timeStamp;
        private readonly string detail;
        private User user;
        private long id;
        public AccountingLog(User user)
        {
            this.user = user;
        }
        public AccountingLog(long id)
        {
            this.id = id;
            InitiateValues();
        }
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public long Id => id;

        /// <summary>
        /// The User to which this log belongs
        /// </summary>
        [DataMember]
        public User User => user;
        /// <summary>
        /// Details about the transaction
        /// </summary>
        [DataMember]
        public string Detail => detail;
        /// <summary>
        /// Detail of date and time
        /// </summary>
        [DataMember]
        public DateTime TimeStamp => timeStamp;
        /// <summary>
        /// Credit amount
        /// </summary>
        [DataMember]
        public decimal Credit
        {
            get => credit;
            set => credit = value;
        }
        /// <summary>
        /// Debit amount
        /// </summary>
        [DataMember]
        public decimal Debit => debit;
        /// <summary>
        /// Method used to do transaction of amount for a user
        /// </summary>
        /// <param name="creditAmount">crediting amount</param>
        /// <param name="debitAmount">debiting amount</param>
        /// <param name="timeStamp">date time details</param>
        /// <param name="details">details about the transaction (comments, mode of transaction, etc.)</param>
        public void DoTransaction(decimal creditAmount, decimal debitAmount, DateTime timeStamp, string details = null)
        {
            GetValue("AddAccountRecord", SQLCommandTypes.StoredProcedure, new SqlParameter("@userId", System.Data.SqlDbType.BigInt)
            {
                Value = user.UserId
            },
            new SqlParameter("@debit", System.Data.SqlDbType.Money)
            {
                Value = debitAmount
            }, new SqlParameter("@credit", System.Data.SqlDbType.Money)
            {
                Value = creditAmount
            }, new SqlParameter("@dateTime", System.Data.SqlDbType.DateTime)
            {
                Value = timeStamp
            });
        }
        /// <summary>
        /// Return a log which contains all transactions by all users in a span of time
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<AccountingLog> GetDetailedLog(User user, DateTime startDate, DateTime endDate, int max = 0)
        {
            List<AccountingLog> lstLog = new List<AccountingLog>();
            var data = new AccountingLog(user).GetIteratableData("GetDetailedLog", SQLCommandTypes.StoredProcedure,
                new SqlParameter("@userId", System.Data.SqlDbType.BigInt)
                {
                    Value = user.UserId
                }, new SqlParameter("@startDate", System.Data.SqlDbType.DateTime)
                {
                    Value = startDate
                },
                new SqlParameter("@endDate", System.Data.SqlDbType.DateTime)
                {
                    Value = endDate
                });
            return lstLog;
        }
        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            foreach (var item in User.GetUsers())
            {
                lstData.AddRange(GetDetailedLog(item, DateTime.MinValue, DateTime.MaxValue));
            }
            return lstData;
        }

        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            foreach (var item in User.GetUsers())
            {
                lstData.AddRange(GetDetailedLog(item, DateTime.MinValue, DateTime.MaxValue));
            }
            return lstData;
        }

        public override Type GetObjectType()
        {
            return typeof(AccountingLog);
        }

        public override string GetPrimaryKey()
        {
            return id.ToString();
        }

        public override Type GetPrimaryKeyType()
        {
            return typeof(long);
        }

        public override string GetReferenceString()
        {
            return string.Format("Record for {0} of {1}, Debit Amount: {2}, Credit Amount: {3}", user.FullName, timeStamp.ToString(), debit, credit);
        }

        public override void InitiateValues()
        {
            var data = GetIteratableData("GetAccountingLog", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@userId", System.Data.SqlDbType.BigInt)
            {
                Value = id
            });
            while (data.Read())
            {
                timeStamp = (DateTime)data["DateTime"];
                debit = (decimal)data["Debit"];
                credit = (decimal)data["Credit"];
                user = new User((long)data["UserId"]);
            }
        }
    }
}