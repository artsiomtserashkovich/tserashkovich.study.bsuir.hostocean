using System;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3.Data;

namespace HostOcean.Api.Infrastructure.GroupScheduleService
{
    public interface IGoogleCalendarClient
    {
        Task<Events> GetLaboratoryWorkEvents(string calendarId, DateTime startDateTime, DateTime endDateTime);
    }
}
