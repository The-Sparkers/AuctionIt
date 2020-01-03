using System;
using System.Collections.Generic;
using ModelSQLHandler;

namespace AuctionIt.Models
{
    public class Feedback : DbConnection
    {
        private short rating;
        private string comment;
        private long id;
        private DateTime timeStamp;
        private PrimaryUser user;
        private Advertisement ad;
        /// <summary>
        /// Initialize by getting values from the dataabase by using a primary key
        /// </summary>
        /// <param name="id">Primary Key</param>
        public Feedback(long id)
        {
            this.id = id;
            InitiateValues();
        }
        /// <summary>
        /// Creates a new feedback into the database
        /// </summary>
        /// <param name="rating"></param>
        /// <param name="comment"></param>
        /// <param name="timeStamp"></param>
        /// <param name="user"></param>
        /// <param name="ad"></param>
        public Feedback(short rating, string comment, DateTime timeStamp, PrimaryUser user, Advertisement ad)
        {
            this.rating = rating;
            this.comment = comment;
            this.timeStamp = timeStamp;
            this.user = user;
            this.ad = ad;
        }
        /// <summary>
        /// Advertisement against which the feedback has been given
        /// </summary>
        public Advertisement Advertisement
        {
            get { return ad; }
        }
        /// <summary>
        /// User who has given the feedback
        /// </summary>
        public PrimaryUser User
        {
            get { return user; }
        }

        public DateTime TimeStamp
        {
            get { return timeStamp; }
        }
        /// <summary>
        /// Primary Key
        /// </summary>
        public long Id
        {
            get { return id; }
        }
        /// <summary>
        /// Comments given on the item in the advertisement
        /// </summary>
        public string Comment
        {
            get { return comment; }
        }
        /// <summary>
        /// Rating given upon that item
        /// </summary>
        public short Rating
        {
            get { return rating; }
        }
        /// <summary>
        /// Returns a list of feedbacks received by a seller(user) on different auctions
        /// </summary>
        /// <param name="seller"></param>
        /// <returns></returns>
        public static List<Feedback> GetFeedback(PrimaryUser seller)
        {
            List<Feedback> lstFeedback = new List<Feedback>();
            return lstFeedback;
        }
        /// <summary>
        /// Static Method to get all feedbacks present into the database
        /// </summary>
        /// <param name="max">Limit of the returned data (0 means no limit).</param>
        /// <returns></returns>
        public static List<Feedback> GetAllFeedbacks(int max = 0)
        {
            List<Feedback> lstFeedback = new List<Feedback>();
            return lstFeedback;
        }

        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstData = new List<ISQLData>();
            lstData.AddRange(GetAllFeedbacks());
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
            return String.Format("Rating: {0}, Comment: {1}, User: {2}, Ad: {3}", rating, comment, user.FullName, ad.Title);
        }

        public override void InitiateValues()
        {
            //initiate values from the dataabase by using the primary key
        }

        public override List<object> GetAllData()
        {
            List<object> lstData = new List<object>();
            lstData.AddRange(GetAllFeedbacks());
            return lstData;
        }

        public override Type GetObjectType()
        {
            return GetType();
        }
    }
}