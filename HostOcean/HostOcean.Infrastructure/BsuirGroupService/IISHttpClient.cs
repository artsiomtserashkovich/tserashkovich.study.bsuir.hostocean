using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HostOcean.Infrastructure.BsuirGroupService
{
    public class IISHttpClient
    {
        private readonly HttpClient _httpClient;

        public IISHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<IISGroup>> GetGroups()
        {
            var uri = IISv1ApiUriBuilder.GetGroups;
            var response = await _httpClient.GetStringAsync(uri);
            
            return JsonConvert.DeserializeObject<IReadOnlyCollection<IISGroup>>(response);
        }
    }
}