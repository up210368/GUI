using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AuthJWTService
    {
        private readonly HttpClient _httpClient;
        private readonly string _authUrl = "http://localhost:8000/api/token/";

        public string AccessToken { get; private set; }

        public AuthJWTService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var credentials = new
            {
                username = username,
                password = password
            };

            var response = await _httpClient.PostAsJsonAsync(_authUrl, credentials);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadFromJsonAsync<JwtTokenResponse>();
                AccessToken = tokenResponse?.access;
                return true;
            }

            return false;
        }

        public HttpClient GetAuthenticatedClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            return client;
        }
    }
    public class JwtTokenResponse
    {
        public string access { get; set; }
        public string refresh { get; set; }
    }
}
