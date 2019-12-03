using System;
using System.Collections.Generic;
using ModelSQLHandler;
using static AuctionIt.Models.Common;

namespace AuctionIt.Models
{
    public class FranchiseManager : User
    {
        private Location location;
        /// <summary>
        /// Initiates new instance of franchise manager by using the primary key
        /// </summary>
        /// <param name="id">Primary Key</param>
        public FranchiseManager(long id) : base(id)
        {
            InitiateValues();
        }
        /// <summary>
        /// Adds a new Franchise Manager record into the database
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="city"></param>
        /// <param name="location"></param>
        public FranchiseManager(NameFormat fullName, ContactNumberFormat phoneNumber, string city, Location location) : base(fullName, phoneNumber, city)
        {

        }

        public Location Location
        {
            get { return location; }
            set { location = value; }
        }
        /// <summary>
        /// Registers the franchise manager as a system identity
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public FranchiseManager RegisterIdentity(string username, string password)
        {
            User user = RegisterIdentity(username, password, Roles.FranchiseManager);
            return new FranchiseManager(user.UserId);
        }
        /// <summary>
        /// Returns data of all Franchise Managers present in the database
        /// </summary>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<FranchiseManager> GetAllFranchiseManagers(int max=0)
        {
            List<FranchiseManager> lstFranchiseManagers = new List<FranchiseManager>();
            return lstFranchiseManagers;
        }
        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetAllFranchiseManagers());
            return lstData;
        }
        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstSQLData = new List<ISQLData>();
            lstSQLData.AddRange(GetAllFranchiseManagers());
            return lstSQLData;
        }
        public override void InitiateValues()
        {
            //initate values from db
        }
        public override Type GetObjectType()
        {
            return GetType();
        }
    }
}