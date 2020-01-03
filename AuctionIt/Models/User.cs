using System;
using System.Collections.Generic;
using ModelSQLHandler;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using AuctionIt.Models.Exceptions;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace AuctionIt.Models
{
    public class User : DbConnection
    {
        private long id;
        private string city;
        private NameFormat fullName;
        private ContactNumberFormat phoneNumber;
        private Common.Image profilePic;
        /// <summary>
        /// Constructor to initialize new User instance by using the primary key.
        /// </summary>
        /// <param name="id">Primary Key</param>
        public User(long id)
        {
            this.id = id;
            InitiateValues();
        }
        /// <summary>
        /// Adds a new user data to the database
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="city"></param>
        protected User(NameFormat fullName, ContactNumberFormat phoneNumber, string city)
        {
            SqlParameter firstName = new SqlParameter("@fName", System.Data.SqlDbType.VarChar)
            {
                Value = fullName.FirstName
            };
            SqlParameter lastName = new SqlParameter("@lName", System.Data.SqlDbType.VarChar)
            {
                Value = fullName.LastName
            };
            SqlParameter phone = new SqlParameter("@pNumber", System.Data.SqlDbType.VarChar)
            {
                Value = phoneNumber
            };
            try
            {
                ExecuteQuery("AddNewUser", SQLCommandTypes.StoredProcedure, firstName, lastName, phone);
            }
            catch (SqlException ex)
            {

            }
        }

        [DataMember]
        public Common.Image ProfilePic
        {
            get { return profilePic; }
            set { profilePic = value; }
        }

        [DataMember]
        public ContactNumberFormat PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        [DataMember]
        public NameFormat FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        [DataMember]
        public long UserId
        {
            get { return id; }
        }
        [DataMember]
        public bool IsDisabled
        {
            get;

        }
        [DataMember]
        public Roles Role
        {
            get;
        }
        [DataMember]
        public string Username
        {
            get;
        }
        [DataMember]
        public decimal Balance { get; }
        /// <summary>
        /// Changes the disable flag into the database which is used to block/unblock user from the system activity.
        /// </summary>
        /// <param name="flag"></param>
        public void ChangeDisableFlag(bool flag)
        {
            try
            {
                SqlParameter disable = new SqlParameter("@disable", System.Data.SqlDbType.Bit)
                {
                    Value = flag
                };
                ExecuteQuery("ChangeDisableFlag", SQLCommandTypes.StoredProcedure, disable);
            }
            catch (SqlException ex)
            {

            }
        }
        /// <summary>
        /// Register the user identity to the system
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User RegisterIdentity(string username, string password, Roles role)
        {
            return null;
        }
        /// <summary>
        /// Checks the credentials enter by the user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool MatchCredentials(string username, string password)
        {
            return true;
        }
        /// <summary>
        /// Resets password of the user to some default password
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ResetPassword(string newPassword)
        {
            return true;
        }
        /// <summary>
        /// Changes the password of the user
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            return true;
        }
        public override List<object> GetAllData()
        {
            List<object> lstUser = new List<object>();
            lstUser.AddRange(GetUsers());
            return lstUser;
        }
        public Wallet GetWallet()
        {
            return new Wallet(this);
        }
        public override List<ISQLData> GetAllSQLData()
        {
            List<ISQLData> lstUser = new List<ISQLData>();
            lstUser.AddRange(GetUsers());
            return lstUser;
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
            return fullName.FullName + " " + phoneNumber.PhoneNumber + " " + city;
        }

        public override void InitiateValues()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns a list of all user record from the database
        /// </summary>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<User> GetUsers(int max = 0)
        {
            List<User> lstUser = new List<User>();
            return lstUser;
        }
        /// <summary>
        /// Returns a user, searched by its username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static User GetUser(string username)
        {
            return null;
        }
        /// <summary>
        /// Returns a user after checking its credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Login(string username, string password)
        {
            return null;
        }
        /// <summary>
        /// Returns a user, searched by its phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static User GetUser(ContactNumberFormat phoneNumber)
        {
            return null;
        }
        /// <summary>
        /// Returns a list of users, searched by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<User> SearchUser(string name)
        {
            List<User> lstUsers = new List<User>();
            return lstUsers;
        }

        public override Type GetObjectType()
        {
            return GetType();
        }

        /// <summary>
        /// Class to store user's contact details.
        /// </summary>
        [DataContract]
        public class ContactNumberFormat
        {
            string phoneNumber, countryCode, companyCode;
            /// <summary>
            /// Constructor to initiate contact number class values
            /// </summary>
            public ContactNumberFormat(string countryCode, string companyCode, string phoneNumber)
            {
                Regex regexForCountryCode = new Regex(@"[+][1-9][1-9]");
                if (!regexForCountryCode.IsMatch(countryCode))
                {
                    throw new ValidationPatternNotMatchException(countryCode, regexForCountryCode.ToString(), "+92");
                }
                Regex regexForCompanyCode = new Regex(@"[3][0-9][0-9]");
                if (!regexForCompanyCode.IsMatch(companyCode))
                {
                    throw new ValidationPatternNotMatchException(companyCode, regexForCompanyCode.ToString(), "301");
                }
                Regex regexForPhoneNumber = new Regex(@"\b\d{7,7}\b");
                if (!regexForPhoneNumber.IsMatch(phoneNumber))
                {
                    throw new ValidationPatternNotMatchException(phoneNumber, regexForPhoneNumber.ToString(), "1234567");
                }
                this.companyCode = companyCode;
                this.countryCode = countryCode;
                this.phoneNumber = phoneNumber;
            }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

            public string CountryCode
            {
                get
                {
                    return countryCode;
                }
            }
            public string CompanyCode
            {
                get
                {
                    return companyCode;
                }
            }
            public string PhoneNumber
            {
                get
                {
                    return phoneNumber;
                }
            }
            /// <summary>
            /// Method which will return the full phone number.
            /// </summary>
            /// <returns></returns>
            [DataMember]
            public string PhoneNumberFormat
            {
                get
                {
                    return countryCode + companyCode + phoneNumber;
                }
            }

            /// <summary>
            /// Method to get phone number in (+xx-xxx-xxxxxxx) format
            /// </summary>
            /// <returns></returns>
            [DataMember]
            public string InternationalFormatedPhoneNumber
            {
                get
                {
                    return countryCode + "-" + companyCode + "-" + phoneNumber;
                }
            }

            /// <summary>
            /// Method to get phone number in (0xxx-xxxxxxx)
            /// </summary>
            /// <returns></returns>
            [DataMember]
            public string LocalFormatedPhoneNumber
            {
                get
                {
                    return "0" + companyCode + "-" + phoneNumber;
                }
            }
        }
        /// <summary>
        /// Full name for a person
        /// </summary>
        [DataContract]
        public struct NameFormat
        {
            string firstName, lastName;
            /// <summary>
            /// Person's First Name.
            /// </summary>
            [DataMember]
            public string FirstName
            {
                get
                {
                    string firstLetterCapital = firstName.Substring(0, 1).ToUpper();
                    string restWordSmall = firstName.Substring(1).ToLower();
                    return firstLetterCapital + restWordSmall;
                }
                set
                {
                    Regex regexForFirstName = new Regex(@"([A-Z]|[a-z])+");
                    if (regexForFirstName.IsMatch(value))
                    {
                        firstName = value;
                    }
                    else
                    {
                        throw new ValidationPatternNotMatchException(firstName, regexForFirstName.ToString(), "Ahmed or ahmed");
                    }
                }
            }
            /// <summary>
            /// Person's Last Name.
            /// </summary>
            [DataMember]
            public string LastName
            {
                get
                {
                    string firstLetterCapital = lastName.Substring(0, 1).ToUpper();
                    string restWordSmall = lastName.Substring(1).ToLower();
                    return firstLetterCapital + restWordSmall;
                }
                set
                {
                    Regex regexForLastName = new Regex(@"([A-Z]|[a-z])+");
                    if (regexForLastName.IsMatch(value))
                    {
                        lastName = value;
                    }
                    else
                    {
                        throw new ValidationPatternNotMatchException(lastName, regexForLastName.ToString(), "Azam or azam");
                    }
                }
            }
            [DataMember]
            public string FullName
            {
                get
                {
                    return firstName + " " + lastName;
                }
            }
        }

        [DataContract]
        public enum Roles
        {
            [DataMember]
            Admin,
            [Display(Name = "Franchise Manager")]
            [DataMember]
            FranchiseManager,
            [Display(Name = "User")]
            [DataMember]
            PrimaryUser
        }
    }
}