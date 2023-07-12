using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLogic
{
    public class DialAPI
    {
        public static string ScheduleCallback(string campaingName, string leadID, DateTime callbackDateTime, string agentID, string comment)
        {
            string retVal = string.Empty;

            try
            {
                string dialerAPI = ConfigurationManager.AppSettings.Get("DialerAPIa");
                string internalUser = ConfigurationManager.AppSettings.Get("internalUser");
                string internalUserPass = ConfigurationManager.AppSettings.Get("internalUserPass");

                string url = dialerAPI + "?" + string.Format("user={0}&pass={1}&function=update_lead&lead_id={2}&campaign_id={3}&callback=Y&callback_status=CALLBK&callback_datetime={4}&callback_type=USERONLY&callback_user={5}&callback_comments={6}&source=webapi",
                    internalUser, internalUserPass, leadID, campaingName, callbackDateTime.ToString("yyyy-MM-dd+HH:mm:ss"), agentID, comment.Replace(" ", "+"));

                retVal = DoCall(url);
            }
            catch(Exception ex)
            {
                retVal = "FAIL : " + ex.Message; 
            }

            return retVal;
        }

        private static async void DoAPICall(string url)
        {
            string retVal = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    if( response.Content.ToString().IndexOf("")>0)
                    {
                        retVal = "Success";
                    }
                    else
                    {
                        retVal = response.Content.ToString();
                    }
                }
                else
                {
                    retVal = "Fail";
                }
            }
        }

        private static string DoCall(string url)
        {
            string retVal = string.Empty;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    retVal = responseContent.ReadAsStringAsync().Result;
                }
            }
            return retVal;
        }
    }
}
