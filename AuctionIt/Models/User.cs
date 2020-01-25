using AuctionIt.Models.Exceptions;
using ModelSQLHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

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
            SqlParameter firstName = new SqlParameter("@firstName", System.Data.SqlDbType.VarChar)
            {
                Value = fullName.FirstName
            };
            SqlParameter lastName = new SqlParameter("@lastName", System.Data.SqlDbType.VarChar)
            {
                Value = fullName.LastName
            };
            SqlParameter phone = new SqlParameter("@pNumber", System.Data.SqlDbType.NChar)
            {
                Value = phoneNumber.PhoneNumber
            };
            SqlParameter countryCode = new SqlParameter("@pcountryCode", System.Data.SqlDbType.NChar)
            {
                Value = phoneNumber.CountryCode
            };
            SqlParameter companyCode = new SqlParameter("@pCompanyCode", System.Data.SqlDbType.NChar)
            {
                Value = phoneNumber.CompanyCode
            };
            SqlParameter pCity = new SqlParameter("@city", System.Data.SqlDbType.VarChar)
            {
                Value = city
            };
            try
            {
               id=Convert.ToInt64(GetValue("AddUser", SQLCommandTypes.StoredProcedure, firstName, lastName, countryCode, companyCode, phone, pCity));
            }
            catch (SqlException)
            {

            }
        }

        [DataMember]
        public Common.Image ProfilePic
        {
            get
            {
                return profilePic;
            }

            set
            {
                ExecuteQuery("UPDATE USERS SET ProfilePic='" + value + "' WHERE UserId=" + id, SQLCommandTypes.Query);
                profilePic = value;
            }
        }

        [DataMember]
        public ContactNumberFormat PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
        }

        [DataMember]
        public NameFormat FullName
        {
            get
            {
                return fullName;
            }
        }

        [DataMember]
        public string City
        {
            get
            {
                return city;
            }
        }

        [DataMember]
        public long UserId
        {
            get
            {
                return id;
            }
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
        public decimal Balance => AccountingLog.GetDetailedLog(this, DateTime.MinValue, DateTime.MaxValue)
                    .Select(x => x.Credit).Sum()
                    - AccountingLog.GetDetailedLog(this, DateTime.MinValue, DateTime.MaxValue)
                    .Select(x => x.Debit).Sum();
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
            catch (SqlException)
            {

            }
        }
        /// <summary>
        /// Register the user identity to the system
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void RegisterIdentity(string identityId)
        {
            ExecuteQuery("insert into USER_HAS_IDENTITY(UserId, IdentityId) values(" + id + ", '" + identityId + "')", SQLCommandTypes.Query);
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
            var data = GetIteratableData("SELECT * FROM USERS WHERE UserId=" + id, SQLCommandTypes.Query);
            foreach (var item in data)
            {
                fullName = new NameFormat { FirstName = item.GetString(1), LastName = item.GetString(2) };
                phoneNumber = new ContactNumberFormat(item.GetString(3), item.GetString(4), item.GetString(5));
                city = item.GetString(6);
                profilePic = new Common.Image { FileName = item.GetString(7), ParentId = id };
            }
        }
        /// <summary>
        /// Returns a list of all user record from the database
        /// </summary>
        /// <param name="max">maximum number of data (0 means no limit)</param>
        /// <returns></returns>
        public static List<User> GetUsers(int max = 0)
        {
            List<User> lstUser = new List<User>();
            User temp = new User(0);
            var data = temp.GetIteratableData("GetUsers", SQLCommandTypes.StoredProcedure);
            foreach (var item in data)
            {
                lstUser.Add(new User(item.GetInt64(0))); 
            }
            return lstUser;
        }
        /// <summary>
        /// Returns a user, searched by its username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static User GetUser(string username)
        {
            User temp = new User(0);
            return new User(id: Convert.ToInt64(
                temp.GetValue("GetUserByUserName", SQLCommandTypes.StoredProcedure,
                new SqlParameter("@username", System.Data.SqlDbType.NVarChar) {
                    Value = username })));
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
            return GetUsers().Where(x => x.FullName.FullName.Contains(name)).ToList();
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
            readonly string phoneNumber, countryCode, companyCode;
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

            public string CountryCode => countryCode;
            public string CompanyCode => companyCode;
            public string PhoneNumber => phoneNumber;
            /// <summary>
            /// Method which will return the full phone number.
            /// </summary>
            /// <returns></returns>
            [DataMember]
            public string PhoneNumberFormat => countryCode + companyCode + phoneNumber;

            /// <summary>
            /// Method to get phone number in (+xx-xxx-xxxxxxx) format
            /// </summary>
            /// <returns></returns>
            [DataMember]
            public string InternationalFormatedPhoneNumber => countryCode + "-" + companyCode + "-" + phoneNumber;

            /// <summary>
            /// Method to get phone number in (0xxx-xxxxxxx)
            /// </summary>
            /// <returns></returns>
            [DataMember]
            public string LocalFormatedPhoneNumber => "0" + companyCode + "-" + phoneNumber;
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
            public string FullName => firstName + " " + lastName;
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