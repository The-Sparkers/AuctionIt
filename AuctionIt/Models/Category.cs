using System;
using System.Collections.Generic;
using ModelSQLHandler;
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
        private List<AdditionalAttribute> additionalAttributes;

        public Category(int id)
        {
            this.id = id;

        }

        public Category(string name)
        {
            //add new category to the database
        }
        [DataMember]
        public List<AdditionalAttribute> AdditionalAttributes
        {
            get { return additionalAttributes; }
        }

        /// <summary>
        /// Name of the category
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
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
        public AdditionalAttribute AddAdditionalAttribute(string name, AdditionalAttribute.AttributeType type, string defaultVal = "")
        {
            return new AdditionalAttribute(name, type, defaultVal);
        }
        /// <summary>
        /// Search a category by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Category> SearchByName(string name)
        {
            List<Category> lstCategories = new List<Category>();
            return lstCategories;
        }
        /// <summary>
        /// Static Method to return all the categories present into the database
        /// </summary>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<Category> GetAllCategories(int max = 0)
        {
            List<Category> lstCategories = new List<Category>();
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
            throw new NotImplementedException();
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