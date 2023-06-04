using Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.MobileServices
{
    public class TourService
    {
        const string urlAllTours = "https://a118-188-95-93-64.ngrok-free.app/api/Tours/get/allTours";
        const string urlAllOrgTours = "https://a118-188-95-93-64.ngrok-free.app/api/OrgTour/get/getAllOrgTours";
        const string urlAllHandTours = "https://a118-188-95-93-64.ngrok-free.app/api/HandTour/get/getAllHandTours";
        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Tour>> GetTours()
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(urlAllTours);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Tour>>(result);
        }
        public async Task<IEnumerable<OrgTour>> GetOrgTours()
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(urlAllOrgTours);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<OrgTour>>(result);
        }
        public async Task<IEnumerable<HandTour>> GetHandTours()
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(urlAllHandTours);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<HandTour>>(result);
        }
    }
}
