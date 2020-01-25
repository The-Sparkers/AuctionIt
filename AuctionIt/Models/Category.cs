using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    /// <summary>
    /// A category is to which different ads are belonged
    /// </summary>
    [DataContract]
    public class Category : DbConnection
    {
        private int id;
        private string name;
        private readonly List<AdditionalAttribute> additionalAttributes;

        public Category(int id)
        {
            this.id = id;
            InitiateValues();
        }

        public Category(string name)
        {
            //add new category to the database
            ExecuteQuery("AddCategory", SQLCommandTypes.StoredProcedure,
                new SqlParameter("@name", System.Data.SqlDbType.VarChar) { Value = name });
            this.name = name;
        }
        [DataMember]
        public List<AdditionalAttribute> AdditionalAttributes
        {
            get
            {
                List<AdditionalAttribute> additionalAttributes = new List<AdditionalAttribute>();
                var data = GetIteratableData("GetAdditionalAttributes", SQLCommandTypes.StoredProcedure, new SqlParameter("@catId", System.Data.SqlDbType.Int)
                {
                    Value = id
                });
                foreach (var item in data)
                {
                    additionalAttributes.Add(new AdditionalAttribute(item.GetInt32(0)));
                }
                return additionalAttributes;
            }
        }

        /// <summary>
        /// Name of the category
        /// </summary>
        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]

        public int Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Returns a list of advertisements belong to this category
        /// </summary>
        /// <param name="endDate"></param>
        /// <param name="startDate"></param>
        /// <param name="max">Maximum results</param>
        /// <returns></returns>
        public List<Advertisement> GetAdvertisements(DateTime startDate, DateTime endDate, int max = 0)
        {
            List<Advertisement> lstAds = new List<Advertisement>();
            return lstAds;
        }
        /// <summary>
        /// Method to delete the category
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return false;
        }
        /// <summary>
        /// Adds new additional attribute for this category
        /// </summary>
        /// <param name="name">name of the attribute</param>
        /// <param name="type">type of the data</param>
        /// <param name="defaultVal">default value</param>
        public AdditionalAttribute AddAdditionalAttribute(string name)
        {
            return new AdditionalAttribute(name, this);
        }
        /// <summary>
        /// Search a category by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Category> SearchByName(string name)
        {
            List<Category> lstCategories = new List<Category>();
            return GetAllCategories().Where(x => x.Name.StartsWith(name)).ToList();
        }
        /// <summary>
        /// Static Method to return all the categories present into the database
        /// </summary>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<Category> GetAllCategories(int max = 0)
        {
            List<Category> lstCategories = new List<Category>();
            Category temp = new Category(0);
            var data = temp.GetIteratableData("GetCategories", SQLCommandTypes.StoredProcedure);
            foreach (var item in data)
            {
                lstCategories.Add(new Category(item.GetInt32(0)));
            }
            return lstCategories;
        }

        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetAllCategories());
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
            return name;
        }

        public override void InitiateValues()
        {
            var data = GetIteratableData("GetCategory", SQLCommandTypes.StoredProcedure, new SqlParameter("@id", System.Data.SqlDbType.Int)
            {
                Value = id
            });
            foreach (var item in data)
            {
                name = item.GetString(1);
            }
        }

        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetAllCategories());
            return lstData;
        }

        public override Type GetObjectType()
        {
            return GetType();
        }
    }
}