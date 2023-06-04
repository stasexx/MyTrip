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
        string url = "https://a118-188-95-93-64.ngrok-free.app/api/Users/get/userByEmail=";
        //string regUrl = $"https://a118-188-95-93-64.ngrok-free.app/api/Users/registration/email={email}/password={password}/firstname={firstName}/lastname={lastName}";
        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<User> GetUser(string email)
        {
            url += email;
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            url = url.Replace(email, string.Empty);
            return JsonConvert.DeserializeObject<User>(result);
        }

        public async Task<IEnumerable<User>> RegUser(string email, string password, string firstName, string lastName)
        {
            string regUrl = $"https://a118-188-95-93-64.ngrok-free.app/api/Users/registration/email={Uri.EscapeUriString(email)}/password={Uri.EscapeUriString(password)}/firstname={Uri.EscapeUriString(firstName)}/lastname={Uri.EscapeUriString(lastName)}";
            HttpClient client = GetClient();

            HttpResponseMessage response = await client.PostAsync(regUrl, null);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<User>>(result);
        }

        public async void ChangePassword(string email, string newPassword, string oldPassword)
        {
            string regUrl = $"https://a118-188-95-93-64.ngrok-free.app/api/Users/change/oldPassword={Uri.EscapeUriString(oldPassword)}/newPassword={Uri.EscapeUriString(newPassword)}/email={Uri.EscapeUriString(email)}";
            HttpClient client = GetClient();

            HttpResponseMessage response = await client.PostAsync(regUrl, null);
            response.EnsureSuccessStatusCode();
        }
        public async void ChangePhone(string email, string newPhone)
        {
            string regUrl = $"https://a118-188-95-93-64.ngrok-free.app/api/Users/change/newPhoneNumber={Uri.EscapeUriString(newPhone)}/email={Uri.EscapeUriString(email)}";
            HttpClient client = GetClient();

            HttpResponseMessage response = await client.PostAsync(regUrl, null);
            response.EnsureSuccessStatusCode();
        }
        public async void ChangeUsername(string email, string newUsername)
        {
            string regUrl = $"https://a118-188-95-93-64.ngrok-free.app/api/Users/change/newLogin={Uri.EscapeUriString(newUsername)}/email={Uri.EscapeUriString(email)}";
            HttpClient client = GetClient();

            HttpResponseMessage response = await client.PostAsync(regUrl, null);
            response.EnsureSuccessStatusCode();
        }
        public async void ChangeEmail(string email, string password, string newEmail)
        {
            string regUrl = $"https://a118-188-95-93-64.ngrok-free.app/api/Users/change/email={Uri.EscapeUriString(email)}/password={Uri.EscapeUriString(password)}/newEmail={Uri.EscapeUriString(newEmail)}";
            HttpClient client = GetClient();

            HttpResponseMessage response = await client.PostAsync(regUrl, null);
            response.EnsureSuccessStatusCode();
        }
    }
}
