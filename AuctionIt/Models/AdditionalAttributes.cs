using System;
using System.Collections.Generic;
using ModelSQLHandler;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    [DataContract]
    public class AdditionalAttributes : DbConnection
    {
        private string defaultVal;
        private string name;
        private AttributeType type;
        private int id;

        public AdditionalAttributes(int id)
        {
            this.id = id;
            InitiateValues();
        }
        internal AdditionalAttributes(string name, AttributeType type, string defaultVal)
        {
            this.name = name;
            this.type = type;
            this.defaultVal = defaultVal;
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
        /// Data Type of the attribute
        /// </summary>
        [DataMember]
        public AttributeType Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// Name of the attribute
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Default Value of the attribute
        /// </summary>
        [DataMember]
        public string DefaultValue
        {
            get { return defaultVal; }
            set { defaultVal = value; }
        }
        /// <summary>
        /// Add an Attribute value for this attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public AttributeValue AddAttributeValue(string value)
        {
            return new AttributeValue
            {
                Name = name,
                Value = value
            };
        }
        /// <summary>
        /// Method to get all Additional Attributes in the database
        /// </summary>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<AdditionalAttributes> GetAllAdditionalAttributes(int max = 0)
        {
            List<AdditionalAttributes> lstAttributes = new List<AdditionalAttributes>();
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
            return String.Format("Attribute Name: {0}, Type: {1}", name, type);
        }

        public override void InitiateValues()
        {
            throw new NotImplementedException();
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