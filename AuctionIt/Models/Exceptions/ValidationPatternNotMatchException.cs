using System;
using System.Runtime.Serialization;

namespace AuctionIt.Models.Exceptions
{
    /// <summary>
    /// Exception will be thrown whenever the string not matches the validation Pattern associated with it.
    /// </summary>
    [DataContract]
    public class ValidationPatternNotMatchException : Exception
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ValidationPatternNotMatchException(string stringValue, string pattern, string exampleWord) : base("Your string: " + stringValue + " failed to matched with the Pattern: " + pattern + ". Try using a word like: " + exampleWord + ".")
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {

        }
        [DataMember]
        public override string Message => base.Message;
    }
}