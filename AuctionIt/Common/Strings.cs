using System.Configuration;

namespace AuctionIt.Common
{
    public static class Strings
    {
        public static readonly string APP_NAME = "Auction-It";
        public static readonly string IMAGES_UPLOAD_PATH = "~/images_upload/";
        public static readonly string CURRENCY_UNIT = "Rs.";
        public static readonly string PAYPAL_CLIIENT_ID = "AfY7e5ExHn6CzuMtVsRFmxSvGQ3UqE2odBpqwpOGmoxfRKYASyNObZ7G2xI0WwZXs3FrOHWWJZoW1vqQ";
        public static readonly string PAYPAL_SECRET_KEY = "EIMqnLnaAg8qFaxBxK9OHNTkDiigJzqWt94v4hhAnkzlo-AZ8_FlQnNIcK7cPFqNaxfq8MnAPKkFabrl";
        public static readonly string PAYPAL_SANDBOX_ACCOUNT = "sb-jlk43e928916@business.example.com";
        public static readonly string PAYPAT_AUTH_TOKEN = "access_token$sandbox$bmjn9pzj55kdbbkv$9679ec4da0303504dc7c6af1b59a3680";
        public static readonly string CURRENCY_CONVERTER_KEY = "0922005b5fac5f3eaeda";
        public static readonly string PKR_USD_EXCHANGE_RATE_API_URL = "http://free.currconv.com/api/v7/convert?q=PKR_USD&compact=ultra&apiKey=0922005b5fac5f3eaeda";
        public static readonly string USD_PKR_EXCHANGE_RATE_API_URL = "http://free.currconv.com/api/v7/convert?q=USD_PKR&compact=ultra&apiKey=0922005b5fac5f3eaeda";
        public static readonly string EMAIL_ADDRESS = "nobelhighschool@hotmail.com";
        public static readonly string CONNECTION_STRING;
        static Strings()
        {
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}