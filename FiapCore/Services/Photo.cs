using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiapCore.Services
{
    public class Photo
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }

        public static List<Photo> GetPhotos()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("photos", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            var photoList = JsonConvert.DeserializeObject<List<Photo>>(response.Content);
            return photoList.Take(20).ToList();
        }

        public async Task<List<Photo>> GetPhotosAsync()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("photos", Method.GET);
            var response = new RestResponse();

            response = await GetResponseContentAsync(client, request) as RestResponse;
            var photoList = JsonConvert.DeserializeObject<List<Photo>>(response.Content);

            return photoList.Take(20).ToList();
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }

}
