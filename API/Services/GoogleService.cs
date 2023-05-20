using System.Net.Http.Headers;
using Newtonsoft.Json;
using API.Services.Interfaces;

namespace API.Services;

public class GoogleService : IGoogleService
{
    public async Task<GmailUserInfo> GetGmailUserInfo(string accessToken)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve user information from Google OAuth.");
            }

            
            var json = await response.Content.ReadAsStringAsync();
            var userInfo = JsonConvert.DeserializeObject<GmailUserInfo>(json);
            
            
            return userInfo;
        }
    }
    
    
}

public class GmailUserInfo
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string given_name { get; set; }
    public string family_name { get; set; }
    public string picture { get; set; }
}