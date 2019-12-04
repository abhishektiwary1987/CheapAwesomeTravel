using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume
{
   public class CallApi : ICallApi
    {
        public async Task<string> FetchHotelAsync(int destinationId, int noofnights, string SecretAuthCode, string ClientURL)
        {
            string apiResponse = "";
            try
            {
                /// Calling HttpClient For API
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(ClientURL);

                    var responseTask = client.GetAsync("findBargain?destinationid=" + destinationId + "&nights=" + noofnights + "&code=" + SecretAuthCode);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    apiResponse = result.Content.ReadAsStringAsync().Result;
                }
                    return apiResponse;
            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }
}
