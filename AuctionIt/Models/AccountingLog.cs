using System;
using System.Collections.Generic;
using ModelSQLHandler;
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
        private string detail;
        private User user;
        private long id;

        public AccountingLog(User user)
        {
            this.user = user;
            InitiateValues();
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
        public long Id
        {
            get { return id; }
        }

        /// <summary>
        /// The User to which this log belongs
        /// </summary>
        [DataMember]
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        /// <summary>
        /// Details about the transaction
        /// </summary>
        [DataMember]
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }
        /// <summary>
        /// Detail of date and time
        /// </summary>
        [DataMember]
        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
        /// <summary>
        /// Credit amount
        /// </summary>
        [DataMember]
        public decimal Credit
        {
            get { return credit; }
            set { credit = value; }
        }
        /// <summary>
        /// Debit amount
        /// </summary>
        [DataMember]
        public decimal Debit
        {
            get { return debit; }
            set { debit = value; }
        }
        /// <summary>
        /// Method used to do transaction of amount for a user
        /// </summary>
        /// <param name="creditAmount">crediting amount</param>
        /// <param name="debitAmount">debiting amount</param>
        /// <param name="timeStamp">date time details</param>
        /// <param name="details">details about the transaction (comments, mode of transaction, etc.)</param>
        public void DoTransaction(decimal creditAmount, decimal debitAmount, DateTime timeStamp, string details = null)
        {

        }
        /// <summary>
        /// Return a log which contains all transactions by all users in a span of time
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<AccountingLog> GetDetailedLog(DateTime startDate, DateTime endDate, int max=0)
        {
            List<AccountingLog> lstLog = new List<AccountingLog>();
            return lstLog;
        }
        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetDetailedLog(DateTime.MinValue, DateTime.MaxValue));
            return lstData;
        }

        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetDetailedLog(DateTime.MinValue, DateTime.MinValue));
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
            return String.Format("Record for {0} of {1}, Debit Amount: {2}, Credit Amount: {3}", user.FullName, timeStamp.ToString(), debit, credit);
        }

        public override void InitiateValues()
        {
            throw new NotImplementedException();
        }
    }
}