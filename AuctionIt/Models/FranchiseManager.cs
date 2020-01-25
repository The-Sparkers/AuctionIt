using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AuctionIt.Models
{
    public class FranchiseManager : User
    {
        private string franchiseNumber;
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
        public FranchiseManager(NameFormat fullName, ContactNumberFormat phoneNumber, string city, string location, string franchiseNumber) : base(fullName, phoneNumber, city)
        {
            ExecuteQuery("AddFranchiseManager", SQLCommandTypes.StoredProcedure, new SqlParameter("@userId", System.Data.SqlDbType.BigInt)
            {
                Value = UserId
            },
            new SqlParameter("@fNumber", System.Data.SqlDbType.VarChar)
            {
                Value = franchiseNumber
            },
            new SqlParameter("@fLocation", System.Data.SqlDbType.VarChar)
            {
                Value = location
            });
        }

        public string Location { get; private set; }
        public string Franchisenumber
        {
            get
            {
                return franchiseNumber;
            }
        }
        /// <summary>
        /// Returns data of all Franchise Managers present in the database
        /// </summary>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<FranchiseManager> GetAllFranchiseManagers(int max = 0)
        {
            List<FranchiseManager> lstFranchiseManagers = new List<FranchiseManager>();
            FranchiseManager temp = new FranchiseManager(0);
            var data = temp.GetIteratableData("GetFranchiseManagers", SQLCommandTypes.StoredProcedure);
            foreach (var item in data)
            {
                lstFranchiseManagers.Add(new FranchiseManager(item.GetInt64(0)));
            }
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
            //initiate values from db
            var data = GetIteratableData("GetFranchiseManager", SQLCommandTypes.StoredProcedure, new SqlParameter("@id", System.Data.SqlDbType.BigInt)
            {
                Value = UserId
            });
            foreach (var item in data)
            {
                Location = item.GetString(8);
                franchiseNumber = item.GetString(9);
            }
        }
        public override Type GetObjectType()
        {
            return GetType();
        }
    }
}