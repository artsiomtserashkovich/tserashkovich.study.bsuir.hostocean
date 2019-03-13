using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HostOcean.Domain.Entities;

namespace HostOcean.Infrastructure.BsuirGroupService
{
    public class BsuirGroupService : IBsuirGroupService
    {
        private readonly IISHttpClient _httpClient;
        private readonly IMapper _mapper;

        public BsuirGroupService(IMapper mapper, IISHttpClient httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Group>> GetGroupsFromBsuirIIS()
        {
            var iisGroups = await _httpClient.GetGroups();
            return _mapper.Map<IEnumerable<Group>>(iisGroups);
        }
    }
}
