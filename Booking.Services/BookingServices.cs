using Booking.Services.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Booking.Services
{
    public interface IBookingServices
    {
        Task<List<Product>> getProducts();
        Task<Product> getProductById(int id);
        Task<List<Schedule>> getSchedule(int id, string startDt, string endDt = "");
    }

    public class BookingServices : IBookingServices
    {
        HttpClient _httpClient = new HttpClient();
        string url = "https://staging.hero.travel/api/v2";
        string apiKey = "";

        public BookingServices ()
        {
        }

        public async Task<List<Product>> getProducts()
        {
            var client = new RestClient(url);
            client.AddDefaultHeader("apiKey", apiKey);
            client.AddDefaultHeader("Content-Type", "application-json");
            var request = new RestRequest("/products?cat=1&pL=100");
            var response = await client.ExecuteAsync(request);
            var data = JsonConvert.DeserializeObject<RootobjectProduct>(response.Content);
            return data.products;
        }

        public async Task<Product> getProductById(int id)
        {
            var client = new RestClient(url);
            client.AddDefaultHeader("apiKey", apiKey);
            client.AddDefaultHeader("Content-Type", "application-json");
            var request = new RestRequest("/products/" + id + "?verbose=true");
            var response = await client.ExecuteAsync(request);
            var data = JsonConvert.DeserializeObject<RootobjectProduct>(response.Content);
            return data.products[0];
        }

        public async Task<List<Schedule>> getSchedule(int id, string startDt, string endDt = "")
        {
            var client = new RestClient(url);
            var data = new List<Schedule>();
            client.AddDefaultHeader("apiKey", apiKey);
            client.AddDefaultHeader("Content-Type", "application-json");
            var request = new RestRequest("/schedule/" + id + "/" + startDt + "/" + endDt);
            var response = await client.ExecuteAsync(request);
            if (!response.Content.Contains("not found"))
            {
                data = JsonConvert.DeserializeObject<List<Schedule>>(response.Content);
            }
            return data;
        }
    }
}
