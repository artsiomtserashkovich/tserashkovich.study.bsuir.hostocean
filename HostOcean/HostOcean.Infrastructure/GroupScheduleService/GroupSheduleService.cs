using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Google.Apis.Calendar.v3.Data;
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
        public async Task<IEnumerable<LaboratoryWorkEvent>> GetEventsForPeriod(string calendarId, DateTime startDateTime, DateTime endDateTime)
        {
            var laboratoryWorkEvents = await 
                _googleCalendarClient.GetLaboratoryWorkEvents(calendarId, startDateTime, endDateTime);

            return _mapper.Map<IEnumerable<Event>, IEnumerable<LaboratoryWorkEvent>>(laboratoryWorkEvents.Items);
        }
    }
}
