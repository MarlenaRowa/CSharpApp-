using System;
using System.Net.Http;
using System.Text.Json;
using ConsoleApp1;
using Nancy.Json;
using Newtonsoft.Json;
using RestSharp;

namespace RestApiTest

{
    class Program

    {
        static void Main(string[] args)

        {
            //for (; ; )
                getdata();
        }

        public static void getdata()

        {
            var client = new RestClient("http://localhost:5011/");
            var request = new RestRequest("/test");
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content; 
                Console.WriteLine(rawResponse);
                DataSub1 datumDto = new JavaScriptSerializer().Deserialize<DataSub1>(rawResponse); ;
                foreach (var item in datumDto.data)
                {
                    Console.WriteLine("Co wyszlo:" + item.id);
                }
            }
            else
            {
                Console.Write("chuj"); 
            }

        }

        public class DataSub1
        {
            public List<DatumDto> data { get; set; }

        }
        public class DatumDto
        {
            public string id { get; set; }
        }

            public static void Postdata()
        {
            var client = new RestClient("http://localhost:5010/");
    ;
            var request = new RestRequest("v2/entities", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = new Post {

                id = "dsdf",
                name = "asdas",
                type = "Program",
                versionOnRobot = 1
            };
            request.AddJsonBody(body);

            var response1 = client.Post(request);
            Console.WriteLine(response1.Content);

        }
    }




}