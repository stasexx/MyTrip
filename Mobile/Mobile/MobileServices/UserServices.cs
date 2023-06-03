using Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.MobileServices
{
    internal class UserService
    {
        const string url = "https://5adb-188-95-93-64.ngrok-free.app/Users/api/checkForEmail?email=somebody@gmail.com";
        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<User> GetUser()
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(result);
        }

    }
}
