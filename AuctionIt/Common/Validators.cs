using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AuctionIt.Common
{
    public class PhoneNumberValidationAttribute : ValidationAttribute
    {
        Regex regex = new Regex(@"[+]([1-9]{2})[3]([0-9]{7})");
        public override bool IsValid(object value)
        {
            string val = (string)value;
            return (val.Length == 13) ? (regex.IsMatch(val)) : false;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = (string)value;
            return (val.Length == 13)
                ? (regex.IsMatch(val)
                ? ValidationResult.Success
                : new ValidationResult(string.Format("The field {0} should be in the format like: +923001234567", validationContext.MemberName)))
                : new ValidationResult(string.Format("The field {0} must be consisted of 13 digits", validationContext.MemberName));
        }
    }
    public class CNICValidationAttribute : ValidationAttribute
    {
        readonly Regex regex = new Regex(@"([0-9]{5})[-]([0-9]{7})[-]([0-9])");
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = (string)value;
            return (val.Length == 15) ? (regex.IsMatch(val)
                ? ValidationResult.Success
                : new ValidationResult(string.Format("The Field {0} must be in the format like: XXXXX-XXXXXXX-X", validationContext.MemberName)))
                : new ValidationResult(string.Format("The Field {0} must be consisted of 15 digits", validationContext.MemberName));
        }
    }
    public class NoPastDateRange : RangeAttribute
    {
        public NoPastDateRange() : base(typeof(DateTime), DateTime.Now.ToString(), DateTime.MaxValue.ToString())
        {
        }
    }
}