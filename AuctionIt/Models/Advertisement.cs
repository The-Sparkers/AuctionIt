using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;

namespace AuctionIt.Models
{
    [DataContract]
    public class Advertisement : DbConnection
    {
        private readonly bool isSold;
        private bool isVerified;

        /// <summary>
        /// Initialize new Object from the db values using the primary key
        /// </summary>
        /// <param name="id">Primary Key</param>
        public Advertisement(long id)
        {
            this.Id = id;
            InitiateValues();
        }

        /// <summary>
        /// Checks that if this advertisement is hidden from the public 
        /// </summary>
        [DataMember]
        public bool IsHidden { get; set; }
        /// <summary>
        /// Winner of the auction who bid highest in the auction
        /// </summary>
        public User Winner { get; set; }

        /// <summary>
        /// Time of the advertisement posting
        /// </summary>
        [DataMember]
        public DateTime PostedTime { get; private set; }
        /// <summary>
        /// Check to represent if the advertisement is verified or not
        /// </summary>
        [DataMember]
        public bool IsVerified
        {
            get
            {
                return isVerified;
            }

            set
            {
                ExecuteQuery("VerifyAd", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@adId", System.Data.SqlDbType.BigInt)
                {
                    Value = Id
                });
                isVerified = value;
            }
        }
        /// <summary>
        /// Check to represent if the advertisement is sold or not
        /// </summary>
        [DataMember]
        public bool IsSold
        {
            get
            {
                return (Winner != null);
            }
        }

        /// <summary>
        /// Description of the ad. item
        /// </summary>
        [DataMember]
        public string Description { get; private set; }
        /// <summary>
        /// Tags which are associated with the ad.
        /// </summary>
        [DataMember]
        public List<string> Tags
        {
            get
            {
                List<string> lstTags = new List<string>();
                var data = GetIteratableData("SELECT Tag FROM ADVERTISEMENT_HAS_TAGS WHERE AdId=" + Id, SQLCommandTypes.Query);
                foreach (var item in data)
                {
                    lstTags.Add(item.GetString(0));
                }
                return lstTags;
            }
        }
        /// <summary>
        /// Images of the advertisement
        /// </summary>
        [DataMember]
        public List<Common.Image> Images
        {
            get
            {
                List<Common.Image> images = new List<Common.Image>();
                var data = GetIteratableData("SELECT ImageName FROM ADVERTISEMENT_HAS_IMAGE WHERE AdId=" + Id, SQLCommandTypes.Query);
                foreach (var item in data)
                {
                    images.Add(new Common.Image
                    {
                        FileName = item.GetString(0),
                        ParentId = Id
                    });
                }
                return images;
            }
        }
        /// <summary>
        /// The user who posted the ad.
        /// </summary>
        [DataMember]
        public PrimaryUser AdPoster { get; private set; }
        /// <summary>
        /// Category to which the ad. belongs
        /// </summary>
        [DataMember]
        public Category Category { get; private set; }
        /// <summary>
        /// Starting price set by the user
        /// </summary>
        [DataMember]
        public decimal StartingPrice { get; private set; }
        /// <summary>
        /// Title of the advertisement
        /// </summary>
        [DataMember]
        public string Title { get; private set; }
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public long Id { get; }
        [DataMember]
        public decimal SoldPrice { get; private set; }
        [DataMember]
        public Feedback Feedback { get; private set; }

        /// <summary>
        /// Method to add image for the advertisement
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public Common.Image AddImage(Common.Image image)
        {
            ExecuteQuery("AddAdvertisementImage", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@image", System.Data.SqlDbType.VarChar)
            {
                Value = image.FileName
            },
            new System.Data.SqlClient.SqlParameter("@adId", System.Data.SqlDbType.BigInt)
            {
                Value = Id
            });
            return image;
        }
        /// <summary>
        /// Method to add tag to make an advertisement searchable
        /// </summary>
        /// <param name="tag">Keyword</param>
        public void AddTag(string tag)
        {
            ExecuteQuery("AddAdvertisementImage", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@tag", System.Data.SqlDbType.VarChar)
            {
                Value = tag
            },
            new System.Data.SqlClient.SqlParameter("@adId", System.Data.SqlDbType.BigInt)
            {
                Value = Id
            });
        }
        /// <summary>
        /// Gets the Image which will be used as the first image for an ad.
        /// </summary>
        /// <returns></returns>
        public Common.Image GetPrimaryImage()
        {
            return Images[0];
        }
        /// <summary>
        /// Gets the user who have verfied this add
        /// </summary>
        /// <returns></returns>
        public FranchiseManager GetVerifier()
        {
            if (isVerified)
            {
                //returns the franchise manager who verified the advertisement
            }
            return null;
        }
        /// <summary>
        /// Verify the advertisement 
        /// </summary>
        /// <param name="verifier">The user who verified the advertisement</param>
        /// <param name="securityFee">Fee which a user have to pay to enter into the bidding process</param>
        /// <param name="startingBidPrice">Starting price for the bid</param>
        /// <param name="startTime">Starting time of the auction process</param>
        /// <param name="endTime">Ending time of the auction process</param>
        /// <returns>The details about the auction for this advertisement</returns>
        public Auction VerifyAdvertisement(FranchiseManager verifier, decimal startingBidPrice, DateTime startTime, DateTime endTime)
        {
            decimal securityFee = StartingPrice * 0.25m;
            ExecuteQuery("VerifyAd", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("adId", System.Data.SqlDbType.BigInt)
            {
                Value = Id
            });
            return new Auction(securityFee, startingBidPrice, startTime, endTime, this);
        }
        /// <summary>
        /// Deletes or hides the ad.
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return true;
        }
        /// <summary>
        /// A user adds an advertisement to his interest list
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddToInterest(PrimaryUser user)
        {
            try
            {
                ExecuteQuery("AddToInterest", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@userId", System.Data.SqlDbType.BigInt)
                {
                    Value = user.UserId
                },
                new System.Data.SqlClient.SqlParameter("@adId", System.Data.SqlDbType.BigInt)
                {
                    Value = Id
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// A user gives rating anfd feedback after the successful buying process
        /// </summary>
        /// <param name="user"></param>
        /// <param name="rating"></param>
        /// <param name="comment"></param>
        public void GiveFeedback(PrimaryUser user, short rating, string comment = null)
        {
            ExecuteQuery("UPDATE ADVERTISEMENTS SET Rating = " + rating + ", Comment = '" + comment + "' WHERE AdId = " + Id, SQLCommandTypes.Query);
        }
        /// <summary>
        /// Sell item(s) to a buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="price"></param>
        public void SellItem(PrimaryUser buyer, decimal price)
        {
            ExecuteQuery("UpdateAdWinner", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@adId", System.Data.SqlDbType.BigInt)
            {
                Value = Id
            },
            new System.Data.SqlClient.SqlParameter("@userId", System.Data.SqlDbType.BigInt)
            {
                Value = buyer.UserId
            },
            new System.Data.SqlClient.SqlParameter("@soldPrice", System.Data.SqlDbType.Money)
            {
                Value = price
            });
        }
        /// <summary>
        /// Gets the auction deatils for the current advertisement
        /// </summary>
        /// <returns></returns>
        public Auction GetAuction()
        {
            if (isVerified)
            {
                //auction will be created only if the advertisement is verified
                return Auction.GetAllAuctions().Where(x => x.Advertisement.Id == Id).First();
            }
            return null;
        }
        /// <summary>
        /// Gets a lst of the users who are interested in the item(s) on this advertisement
        /// </summary>
        /// <returns></returns>
        public List<PrimaryUser> GetInterestedUsers()
        {
            return PrimaryUser.GetAllPrimaryUsers().Where(x => x.GetFavoriteAdvertisements().Exists(y => y.Id == Id)).OrderBy(x => x.FullName.FirstName).ToList();
        }
        /// <summary>
        /// Returns a list of values of additional attributes imposed by the Category
        /// </summary>
        /// <returns></returns>
        public List<AdditionalAttributeValue> GetAdditionalAttributes()
        {
            List<AdditionalAttributeValue> additionalAttributes = new List<AdditionalAttributeValue>();
            var data = GetIteratableData("GetAttributesValuesForAdvertisement", SQLCommandTypes.Query, new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.BigInt)
            {
                Value = Id
            });
            foreach (var item in data)
            {
                additionalAttributes.Add(new AdditionalAttributeValue
                {
                    Attribute = item.GetString(0),
                    Value = item.GetString(1)
                });
            }
            return additionalAttributes;
        }
        /// <summary>
        /// Static method to create an advertisement
        /// </summary>
        /// <param name="user">who is creating the advertisement</param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="startingPrice">price from which the auction will start</param>
        /// <param name="additionalAttibutes">additional attibutes from the category</param>
        /// <returns></returns>
        public Advertisement(PrimaryUser user, string title, string description, decimal startingPrice, Category category, List<AdditionalAttribute.AttributeValue> additionalAttibutes)
        {
            DateTime postingTime = DateTime.Now;
            Id = Convert.ToInt64(GetValue("AddAdvertisement", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@posterId", System.Data.SqlDbType.BigInt)
            {
                Value = user.UserId
            },
            new SqlParameter("@title", System.Data.SqlDbType.VarChar)
            {
                Value = title
            },
            new SqlParameter("@postedDateTime", System.Data.SqlDbType.DateTime)
            {
                Value = postingTime
            },
            new SqlParameter("@description", System.Data.SqlDbType.Text)
            {
                Value = description
            },
            new SqlParameter("@categoryId", System.Data.SqlDbType.Int)
            {
                Value = category.Id
            },
            new SqlParameter("@price", System.Data.SqlDbType.Money)
            {
                Value = startingPrice
            }));
            additionalAttibutes.
            ForEach(x => (category.AdditionalAttributes.
            Find(y => y.Name == x.Name)).
            AddAttributeValue(x.Value, this));
            this.Title = title;
            this.Category = category;
            AdPoster = user;
            this.Description = description;
            this.StartingPrice = startingPrice;
        }
        /// <summary>
        /// This method will help in searching an advertisement
        /// </summary>
        /// <param name="keyword">could be a tag or a title</param>
        /// <returns></returns>
        public static List<Advertisement> Search(string keyword)
        {
            return GetAllAdvertisements()
                .Where(x => x.Title.Contains(keyword)
                || x.Tags.Contains(keyword)).ToList();
        }
        /// <summary>
        /// Static method to get a list of all advertisements from the database
        /// </summary>
        /// <param name="max">:Limit of the item count</param>
        /// <returns></returns>
        public static List<Advertisement> GetAllAdvertisements(int max = 0)
        {
            List<Advertisement> lstAdvertisments = new List<Advertisement>();
            Advertisement temp = new Advertisement(0);
            var data = temp.GetIteratableData("GetAdvertisements", SQLCommandTypes.StoredProcedure);
            foreach (var item in data)
            {
                lstAdvertisments.Add(new Advertisement(item.GetInt64(0)));
            }
            return lstAdvertisments;
        }

        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetAllAdvertisements());
            return lstData;
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
            return string.Format("Title: {0}, Price: {1}, Sold: {2}, Verified: {3}", Title, StartingPrice, isSold, isVerified);
        }

        public override void InitiateValues()
        {
            //Initiate Values from db
            var data = GetIteratableData("GetAdvertisement", SQLCommandTypes.StoredProcedure, new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.BigInt)
            {
                Value = Id
            });
            foreach (var item in data)
            {
                StartingPrice = item.GetDecimal(1);
                Title = item.GetString(2);
                PostedTime = item.GetDateTime(3);
                isVerified = item.GetBoolean(4);
                Description = item.GetString(5);
                AdPoster = new PrimaryUser(item.GetInt64(6));
                Category = new Category(item.GetInt32(7));
                Winner = item.GetValue(8) == null ? null : new User(item.GetInt64(8));
                Feedback = new Feedback(item.GetValue(9) == null 
                    ? short.Parse("0") : item.GetInt16(9), 
                    item.GetValue(10) == null 
                    ? string.Empty : item.GetString(10));
                SoldPrice = item.GetValue(11) == null ? 0.0m : item.GetDecimal(11);
            }
        }

        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetAllAdvertisements());
            return lstData;
        }

        public override Type GetObjectType()
        {
            return GetType();
        }
    }

    public class AdditionalAttributeValue
    {
        public string Attribute { get; set; }
        public string Value { get; set; }
    }
}