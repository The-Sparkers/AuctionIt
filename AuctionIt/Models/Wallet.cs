using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    /// <summary>
    /// A Wallet hanldes a User's financials
    /// </summary>
    [DataContract]
    public class Wallet : DbConnection
    {
        private User user;
        public Wallet(User user)
        {
            this.user = user;
        }
        /// <summary>
        /// The user to which this Wallet belongs to
        /// </summary>
        [DataMember]
        public User User
        {
            get => user;
            set => user = value;
        }
        /// <summary>
        /// Total Balance in the wallet
        /// </summary>
        [DataMember]
        public decimal Balance => user.Balance;
        /// <summary>
        /// Deposits funds in to this wallet
        /// </summary>
        /// <param name="amount">amount which is being deposited</param>
        /// <param name="refNumber">reference number with the online transaction</param>
        /// <param name="channel">name of the payment service</param>
        /// <param name="timeStamp">date and time of the transaction</param>
        public void Deposit(decimal amount, string refNumber, PaymentChannel channel, DateTime timeStamp)
        {
            AccountingLog accountingLog = new AccountingLog(user);
            accountingLog.DoTransaction(amount, 0, timeStamp, channel.ToString());
        }
        /// <summary>
        /// Deposits funds in this wallet
        /// </summary>
        /// <param name="amount">amount which is being deposited</param>
        public void Deposit(decimal amount)
        {
            AccountingLog accountingLog = new AccountingLog(user);
            accountingLog.DoTransaction(amount, 0, DateTime.Now);
        }
        /// <summary>
        /// Do a payment using this wallet
        /// </summary>
        /// <param name="amount"></param>
        public void UseWallet(decimal amount)
        {
            AccountingLog accountingLog = new AccountingLog(user);
            accountingLog.DoTransaction(0, amount, DateTime.Now);
        }
        /// <summary>
        /// Get details of different transactions
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<AccountingLog> Statement(DateTime startDate, DateTime endDate)
        {
            return AccountingLog.GetDetailedLog(user, startDate, endDate);
        }
        /// <summary>
        /// Get a list of Online Deposits
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<OnlineDepositLog> GetOnlineDeposits(DateTime startDate, DateTime endDate)
        {
            List<OnlineDepositLog> lstDeposits = new List<OnlineDepositLog>();
            return lstDeposits;
        }
        public override List<ISQLData> GetAllSQLData()
        {
            return user.GetAllSQLData();
        }

        public override string GetPrimaryKey()
        {
            return user.GetPrimaryKey();
        }

        public override Type GetPrimaryKeyType()
        {
            return user.GetPrimaryKeyType();
        }

        public override string GetReferenceString()
        {
            return string.Format("Wallet holder name: {0}, Balance: {1}", user.FullName, Balance);
        }

        public override void InitiateValues()
        {
            //Not Implemented
        }

        public override List<object> GetAllData()
        {
            return user.GetAllData();
        }

        public override Type GetObjectType()
        {
            return user.GetObjectType();
        }

        public enum PaymentChannel
        {
            [Display(Name = "Jazz-Cash")]
            JazzCash,
            [Display(Name = "Easy-Pasia")]
            EasyPaisa
        }
    }
}