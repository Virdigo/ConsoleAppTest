using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleAppTest
{
    public class Program
    {
        public static async Task Main()
        {
            string accessToken = "tcy9poqn4dgtte48";
            int activityId = 89;
            int templateId = 211;
            int documentId = 47593;
            int userId = 757;
            var fields = new Dictionary<string, object>
                {
            { "TITLE", "Обновленное название активности" },
            { "DEADLINE_TIME", DateTime.Now },
            { "TESTDATE",DateTime.Now }
                };
            var bitrix24ApiClient = new Bitrix24ApiClient(accessToken);
            await bitrix24ApiClient.UpdateBusinessProcessActivity(activityId, templateId, documentId, userId, fields);
            Console.ReadKey();
        }
    }

    public class Bitrix24ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken;


        public Bitrix24ApiClient(string accessToken)
        {
            _httpClient = new HttpClient();
            _accessToken = accessToken;
        }

        public async Task UpdateBusinessProcessActivity(int activityId, int templateId, int documentId, int userId, Dictionary<string, object> fields)
        {
            string apiUrl = "https://steklm.bitrix24.ru/bizproc/processes/204/element/0/65285/?list_section_id=";

            var parameters = new Dictionary<string, object>
        {
            { "AUTH_ID", _accessToken },
            { "activityId", activityId },
            { "templateId", templateId },
            { "documentId", documentId },
            { "userId", userId },
            { "fields", fields }
        };
            
            var requestContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");

            string requestUrl = $"{apiUrl}?access_token={_accessToken}";

            var response = await _httpClient.PostAsync(apiUrl, requestContent);

            if (response.IsSuccessStatusCode)
            {
                // Обработка успешного ответа
                Console.WriteLine("Бизнес-процесс успешно обновлен.");
            }
            else
            {
                // Обработка ошибки
                Console.WriteLine($"Ошибка при обновлении бизнес-процесса. \n{ await response.Content.ReadAsStringAsync()}");
            }
        }
    }
}
