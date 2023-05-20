using Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.MobileServices
{
    internal class TourService
    {
        const string url = "https://d9eb-188-95-93-64.ngrok-free.app/";
        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Tour>> GetTours()
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Tour>>(result);
        }

    }
}
