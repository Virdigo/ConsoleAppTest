//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleAppTest
//{
//        public class API
//        {
//            public Data()
//            {
//            public void CallAPI()
//                {
//                    Tokens tokens = new Tokens();
//                    var client = new RestClient("www.example.com/api");
//                    var request = new RestRequest(Method.GET);
//                    request.AddHeader("authorization", "Bearer " + tokens.access_token);
//                    request.AddHeader("accept", "application/json; charset=utf-8");
//                    RestResponse response = client.Execute(request);

//                    var data = response.Content;
//                }
//            }
//        }
//}
