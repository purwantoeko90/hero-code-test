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
    }

    public class BookingServices : IBookingServices
    {
        HttpClient _httpClient = new HttpClient();
        string url = "https://staging.hero.travel/api/v2";
        string apiKey = "5907faba-c11b-4f12-b8bb-28fbcd5c3803";

        public BookingServices ()
        {
        }

        public async Task<List<Product>> getProducts()
        {
            var client = new RestClient(url);
            client.AddDefaultHeader("apiKey", apiKey);
            client.AddDefaultHeader("Content-Type", "application-json");
            var request = new RestRequest("/products?cat=1");
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
    }
}
