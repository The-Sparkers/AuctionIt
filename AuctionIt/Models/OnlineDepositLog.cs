using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ModelSQLHandler;

namespace AuctionIt.Models
{
    /// <summary>
    /// Stores the information of the online deposits into the system for the user
    /// </summary>
    [DataContract]
    public class OnlineDepositLog : DbConnection
    {
        private decimal amount;
        private string refNumber;
        private Wallet.PaymentChannel channel;
        private DateTime timeStamp;
        private long id;
        private User user;

        public OnlineDepositLog(long id)
        {
            this.id = id;
            InitiateValues();
        }
        /// <summary>
        /// User which is associated to this deposit
        /// </summary>
        [DataMember]
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Date and Time Details for the transaction
        /// </summary>
        [DataMember]
        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
        /// <summary>
        /// Channel used for the transaction
        /// </summary>
        [DataMember]
        public Wallet.PaymentChannel Channel
        {
            get { return channel; }
            set { channel = value; }
        }
        /// <summary>
        /// Reference Number associated with the deposit
        /// </summary>
        [DataMember]
        public string RefNumber
        {
            get { return refNumber; }
            set { refNumber = value; }
        }
        /// <summary>
        /// Amount which have been depodited
        /// </summary>
        [DataMember]
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        /// <summary>
        /// Static method to get a list for the online selection
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<OnlineDepositLog> GetOnlineTransactions(User user)
        {
            List<OnlineDepositLog> lstLog = new List<OnlineDepositLog>();
            return lstLog;
        }
        /// <summary>
        /// Static Method to deposit funds into the user's Wallet
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="refNumber"></param>
        /// <param name="paymentChannel"></param>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static OnlineDepositLog DepositAmount(decimal amount, string refNumber, Wallet.PaymentChannel paymentChannel, DateTime timeStamp)
        {
            return null;
        }
        /// <summary>
        /// Static Method to get a list of online transactions within a date
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<OnlineDepositLog> GetOnlineTransactions(DateTime startDate, DateTime endDate, int max = 0)
        {
            List<OnlineDepositLog> lstLog = new List<OnlineDepositLog>();
            return lstLog;
        }
        /// <summary>
        /// Get a result for online transaction by entering the ref. number 
        /// </summary>
        /// <param name="refNumber"></param>
        /// <param name="paymentChannel"></param>
        /// <returns></returns>
        public static OnlineDepositLog GetOnlineTransaction(string refNumber, Wallet.PaymentChannel paymentChannel)
        {
            return null;
        }

        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetOnlineTransactions(DateTime.MinValue, DateTime.MaxValue));
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
            return String.Format("User: {0}, Amount: {1}, Ref.Number: {2}, Payment Channel: {3}, Date&Time: {4}", user.FullName, amount, refNumber, channel, timeStamp);
        }

        public override void InitiateValues()
        {
            throw new NotImplementedException();
        }

        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetOnlineTransactions(DateTime.MinValue, DateTime.MaxValue));
            return lstData;
        }

        public override Type GetObjectType()
        {
            return GetType();
        }
    }
}