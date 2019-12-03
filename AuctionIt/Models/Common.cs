using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AuctionIt.Models
{
    [DataContract]
    public static class Common
    {
        [DataContract]
        public struct Location
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public decimal Latitude { get; set; }
            [DataMember]
            public decimal Longitude { get; set; }
        }
        [DataContract]
        public struct Image
        {
            [DataMember]
            public string FileName { get; set; }
            [DataMember]
            public string ParentId { get; set; }
            public string GetSaveLocation()
            {
                return null;
            }
            public string GetFilePath()
            {
                return null;
            }
        }
    }
}