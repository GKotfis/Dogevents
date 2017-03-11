using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dogevents.Core.Services
{
    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken;

        public FacebookClient(string accessToken)
        {
            _accessToken = accessToken;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v2.8/")
            };

            _httpClient.DefaultRequestHeaders
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string endpoint, string args = null)
        {
            var response = await _httpClient.GetAsync($"{endpoint}?access_token={_accessToken}&{args}");

            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}