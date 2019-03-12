using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HostOcean.Infrastructure.BsuirGroupService
{
    public class IISHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public IISHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetAuthCookie()
        {
            var username = _configuration["IISBsuirClient:Auth:Username"];
            var password = _configuration["IISBsuirClient:Auth:Password"];
            var json = JsonConvert.SerializeObject(new { username, password });

            var cookies = new CookieContainer();
            var client = new HttpClient(new HttpClientHandler
            {
                CookieContainer = cookies
            });

            client.BaseAddress = new Uri(_configuration["IISBsuirClient:UriBaseAddress"]);
            var uri = new Uri(client.BaseAddress + IISv1ApiUriBuilder.GetLoginUri);

            await client.PostAsync(IISv1ApiUriBuilder.GetLoginUri, new StringContent(json, Encoding.UTF8, "application/json"));

            var cookie = cookies.GetCookies(uri).Cast<Cookie>().FirstOrDefault();

            return $"{cookie.Name}={cookie.Value}";
        }

        public async Task<IReadOnlyCollection<IISGroup>> GetGroups()
        {
            var cookie = await GetAuthCookie();

            var message = new HttpRequestMessage(HttpMethod.Get, IISv1ApiUriBuilder.GetGroupsUri);
            message.Headers.Add("Cookie", cookie);

            var response = await _httpClient.SendAsync(message);
            response.EnsureSuccessStatusCode();

            var stringResponse = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IISGroupResponse>(stringResponse).Groups;
        }
    }
}