using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace AuctionIt.Common
{
    public static class Functions
    {
        public static string GetPassedTimeSpanFromNow(DateTime time)
        {
            string s = time.ToString("dd-mmm-yyyy hh:mm:ss");
            TimeSpan span = DateTime.Now - time;
            var mins = decimal.Round(Convert.ToDecimal(span.TotalMinutes));
            var hrs = decimal.Round(Convert.ToDecimal(span.TotalHours));
            var days = decimal.Round(Convert.ToDecimal(span.TotalDays));
            if (mins < 1)
            {
                s = "Just Now";
            }
            else if (hrs < 1)
            {
                if (mins == 1)
                {
                    s = "1 minute ago";
                }
                else
                {
                    s = mins + " minutes ago";
                }
            }
            else if (days < 1)
            {
                if (hrs == 1)
                {
                    s = "1 hour ago";
                }
                else
                {
                    s = hrs + " hours ago";
                }
            }
            else if (days == 1)
            {
                s = "1 day ago";
            }
            else if (days < 31)
            {
                s = days + " days ago";
            }
            return s;
        }
        public static string GetPassedDateSpanFromNow(DateTime date)
        {
            string s = date.ToString("dd-mmm-yyyy");
            TimeSpan span = DateTime.Now - date;
            var days = decimal.Round(Convert.ToDecimal(span.TotalDays));
            if (days < 1)
            {
                s = "Less than a day";
            }
            else if (days < 31)
            {
                s = days + " days ago";
            }
            return s;
        }
        public static string ResolveServerUrl(string serverUrl, Uri originalUri, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
            {
                return serverUrl;
            }

            string newUrl = serverUrl;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                "://" + originalUri.Authority + newUrl;
            return newUrl;
        }
        public static async System.Threading.Tasks.Task<decimal> PKRToUSDAsync(decimal amountInPkr)
        {
            decimal convertedAmount = 0;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Strings.PKR_USD_EXCHANGE_RATE_API_URL);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(new Uri(Strings.PKR_USD_EXCHANGE_RATE_API_URL));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        JObject currencyResponse = JObject.Parse(content);
                        decimal exchangeRate = (decimal)currencyResponse["PKR_USD"];
                        convertedAmount = amountInPkr * exchangeRate;
                    }
                }
            }
            catch (Exception)
            {

            }
            return convertedAmount;
        }
        public static async System.Threading.Tasks.Task<decimal> USDToPKRAsync(decimal amountInUsd)
        {
            decimal convertedAmount = 0;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Strings.USD_PKR_EXCHANGE_RATE_API_URL);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(new Uri(Strings.USD_PKR_EXCHANGE_RATE_API_URL));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        JObject currencyResponse = JObject.Parse(content);
                        decimal exchangeRate = (decimal)currencyResponse["USD_PKR"];
                        convertedAmount = amountInUsd * exchangeRate;
                    }
                }
            }
            catch (Exception)
            {

            }
            return convertedAmount;
        }
        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient("smtp.live.com")
            {
                Credentials = new NetworkCredential(Strings.EMAIL_ADDRESS, SecreteKeys.EMAI_PASSWORD),
                Port = 587,
                EnableSsl = true
            };
            client.Send(mail);
        }
    }
}