using System;

namespace AuctionIt.Models
{
    public class Feedback
    {
        private readonly short rating;
        private readonly string comment;
        /// <summary>
        /// Creates a new feedback into the database
        /// </summary>
        /// <param name="rating"></param>
        /// <param name="comment"></param>
        /// <param name="timeStamp"></param>
        /// <param name="user"></param>
        /// <param name="ad"></param>
        public Feedback(short rating, string comment)
        {
            this.rating = rating;
            this.comment = comment;
        }
        /// <summary>
        /// Comments given on the item in the advertisement
        /// </summary>
        public string Comment => comment;
        /// <summary>
        /// Rating given upon that item
        /// </summary>
        public short Rating => rating;
    }
}