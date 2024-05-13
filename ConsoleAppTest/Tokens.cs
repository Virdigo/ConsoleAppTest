/*using RestSharp;
using Bitrix24.Connector;
using Bitrix24.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace ConsoleAppTest
{
    public class Tokens
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }

    public class AccessToken
    {
        public void GetNewAccessToken()
        {
            Tokens localTokens = new Tokens();

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(3);
                string json = JsonConvert.SerializeObject(zad);
                var response = await client.PostAsync("https://steklm.bitrix24.ru/bizproc/processes/204/element/0/39248/?list_section_id=", new StringContent(json, Encoding.UTF8, "application/json"));

                string res = await response.Content.ReadAsStringAsync();


                //MessageBox.Show(await response.Content.ReadAsStringAsync());
            }
            var client = new RestClient("https://steklm.bitrix24.ru/bizproc/processes/204/element/0/39248/?list_section_id=");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=refresh_token&refresh_token=" + localTokens.refresh_token, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            var responseContent = response.Content;

            var newTokensList = JsonConvert.DeserializeObject<Tokens>(responseContent);

            localTokens.access_token = newTokensList.access_token;
            localTokens.refresh_token = newTokensList.refresh_token;
        }
    }
}
*/