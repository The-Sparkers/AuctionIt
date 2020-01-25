using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    [DataContract]
    public class AdditionalAttribute : DbConnection
    {
        public AdditionalAttribute(int id)
        {
            Id = id;
            InitiateValues();
        }
        internal AdditionalAttribute(string name, Category category)
        {
            ExecuteQuery("AddAdditionalAttribute", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.VarChar)
            {
                Value = name
            },
            new SqlParameter("@catId", System.Data.SqlDbType.Int)
            {
                Value = category.Id
            });
            Name = name;
            this.Category = category;
        }
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; }
        /// <summary>
        /// Name of the attribute
        /// </summary>
        [DataMember]
        public string Name { get; private set; }
        public Category Category { get; set; }

        /// <summary>
        /// Add an Attribute value for this attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public AttributeValue AddAttributeValue(string value, Advertisement advertisement)
        {
            try
            {
                ExecuteQuery("AddValueForAdditionalAttribute", SQLCommandTypes.StoredProcedure, new SqlParameter("@adId", System.Data.SqlDbType.BigInt)
                {
                    Value = advertisement.Id
                },
                    new SqlParameter("@attId", System.Data.SqlDbType.Int)
                    {
                        Value = Id
                    },
                    new SqlParameter("@value", System.Data.SqlDbType.VarChar)
                    {
                        Value = value
                    });
                return new AttributeValue
                {
                    Name = Name,
                    Value = value
                };
            }
            catch (Exception)
            {
                return new AttributeValue
                {
                    Value = "",
                    Name = ""
                };
            }
        }
        /// <summary>
        /// Method to get all Additional Attributes in the database
        /// </summary>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<AdditionalAttribute> GetAllAdditionalAttributes(int max = 0)
        {
            List<AdditionalAttribute> lstAttributes = new List<AdditionalAttribute>();
            foreach (var item in Category.GetAllCategories())
            {
                lstAttributes.AddRange(item.AdditionalAttributes);
            }
            return lstAttributes;
        }
        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetAllAdditionalAttributes());
            return lstData;
        }

        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetAllAdditionalAttributes());
            return lstData;
        }

        public override Type GetObjectType()
        {
            return GetType();
        }

        public override string GetPrimaryKey()
        {
            return Id.ToString();
        }

        public override Type GetPrimaryKeyType()
        {
            return Id.GetType();
        }

        public override string GetReferenceString()
        {
            return string.Format("Attribute Name: {0}", Name);
        }

        public override void InitiateValues()
        {
            var data = GetIteratableData("GetAdditionalAttribute", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.Int)
            {
                Value = Id
            });
            foreach (var item in data)
            {
                Name = item.GetString(1);
                Category = new Category(item.GetInt32(2));
            }
        }
        /// <summary>
        /// Types of Data to be stored in the additional attributes
        /// </summary>
        [DataContract]
        public enum AttributeType
        {
            [DataMember]
            Number,
            [DataMember]
            Text,
            [DataMember]
            Check
        }
        /// <summary>
        /// Value for an advertisement against an additional attibute
        /// </summary>
        [DataContract]
        public struct AttributeValue
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string Value { get; set; }
        }
    }
}