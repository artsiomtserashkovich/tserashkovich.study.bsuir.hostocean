using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HostOcean.Application.Interfaces.Infrastructure;
using HostOcean.Domain.Entities;

namespace HostOcean.Infrastructure.GroupScheduleService
{
    public class GroupSheduleService : IGroupSheduleService
    {
        private readonly IGoogleCalendarClient _googleCalendarClient;
        private readonly IMapper _mapper;

        public GroupSheduleService(IGoogleCalendarClient googleCalendarClient, IMapper mapper)
        {
            _googleCalendarClient = googleCalendarClient;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LaboratoryWork>> GetLaboratoryWorksForPeriod(string calendarId,
            DateTime startDateTime, DateTime endDateTime)
        {
            var laboratoryWorkEvents = await 
                _googleCalendarClient.GetLaboratoryWorkEvents(calendarId, startDateTime, endDateTime);

            return _mapper.Map<IEnumerable<LaboratoryWork>>(laboratoryWorkEvents.Items);
        }
    }
}
