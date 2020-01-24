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
        private string name;
        private int id;
        private Category category;
        public AdditionalAttribute(int id)
        {
            this.id = id;
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
            this.name = name;
            this.category = category;
        }
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id => id;
        /// <summary>
        /// Name of the attribute
        /// </summary>
        [DataMember]
        public string Name => name;
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
                        Value = id
                    },
                    new SqlParameter("@value", System.Data.SqlDbType.VarChar)
                    {
                        Value = value
                    });
                return new AttributeValue
                {
                    Name = name,
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
            return id.ToString();
        }

        public override Type GetPrimaryKeyType()
        {
            return id.GetType();
        }

        public override string GetReferenceString()
        {
            return string.Format("Attribute Name: {0}", name);
        }

        public override void InitiateValues()
        {
            var data = GetIteratableData("GetAdditionalAttribute", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.Int)
            {
                Value = id
            });
            while (data.Read())
            {
                name = (string)data[1];
                category = new Category((int)data[2]);
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