using System;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Options;

namespace HostOcean.Api.Infrastructure.GroupScheduleService
{
    public class GoogleCalendarV3Client : IGoogleCalendarClient
    {
        private readonly GoogleCalendarApiConfiguration _googleCalendarApiConfiguration;
        private readonly BaseClientService.Initializer _initializer;

        public GoogleCalendarV3Client(
            IOptions<GoogleCalendarApiConfiguration> googleCalendarApiConfigurationOptions)
        {
            _googleCalendarApiConfiguration = googleCalendarApiConfigurationOptions.Value;

            _initializer = new BaseClientService.Initializer
            {
                ApplicationName = _googleCalendarApiConfiguration.ApplicationName,
                ApiKey = _googleCalendarApiConfiguration.ApiKey
            };
        }

        public async Task<Events> GetLaboratoryWorkEvents(string calendarId, DateTime startDateTime,
            DateTime endDateTime)
        {
            using (var service = new CalendarService(_initializer))
            {
                var request = service.Events.List(calendarId);

                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
                request.TimeMin = startDateTime;
                request.TimeMax = endDateTime;
                request.Q = _googleCalendarApiConfiguration.LaboratoryWorkEventKey;
                request.ShowDeleted = false;
                request.TimeZone = TimeZoneInfo.Utc.Id;
                request.SingleEvents = true;

                return await request.ExecuteAsync();
            }
        }
    }
}
