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
        public AccountingLog(User user)
        {
            this.User = user;
        }
        public AccountingLog(long id)
        {
            this.Id = id;
            InitiateValues();
        }
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public long Id { get; }

        /// <summary>
        /// The User to which this log belongs
        /// </summary>
        [DataMember]
        public User User { get; private set; }
        /// <summary>
        /// Details about the transaction
        /// </summary>
        [DataMember]
        public string Detail => Detail1;
        /// <summary>
        /// Detail of date and time
        /// </summary>
        [DataMember]
        public DateTime TimeStamp { get; private set; }
        /// <summary>
        /// Credit amount
        /// </summary>
        [DataMember]
        public decimal Credit
        {
            get
            {
                return Credit1;
            }

            set
            {
                Credit1 = value;
            }
        }
        /// <summary>
        /// Debit amount
        /// </summary>
        [DataMember]
        public decimal Debit { get; private set; }

        public string Detail1 { get; }

        public decimal Credit1 { get; set; }

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
                Value = User.UserId
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
            return Id.ToString();
        }

        public override Type GetPrimaryKeyType()
        {
            return typeof(long);
        }

        public override string GetReferenceString()
        {
            return string.Format("Record for {0} of {1}, Debit Amount: {2}, Credit Amount: {3}", User.FullName, TimeStamp.ToString(), Debit, Credit1);
        }

        public override void InitiateValues()
        {
            var data = GetIteratableData("GetAccountingLog", SQLCommandTypes.StoredProcedure, new SqlParameter("@userId", System.Data.SqlDbType.BigInt)
            {
                Value = Id
            });
            foreach (var item in data)
            {
                TimeStamp = item.GetDateTime(1);
                Debit = item.GetDecimal(2);
                Credit1 = item.GetDecimal(3);
                User = new User(item.GetInt64(4));
            }
        }
    }
}