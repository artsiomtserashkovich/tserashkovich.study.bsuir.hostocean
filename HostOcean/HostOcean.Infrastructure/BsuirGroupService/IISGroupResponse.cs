using Newtonsoft.Json;
using System.Collections.Generic;

namespace HostOcean.Infrastructure.BsuirGroupService
{
    public class IISGroupResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("data")]
        public List<IISGroup> Groups { get; set; }
    }
}