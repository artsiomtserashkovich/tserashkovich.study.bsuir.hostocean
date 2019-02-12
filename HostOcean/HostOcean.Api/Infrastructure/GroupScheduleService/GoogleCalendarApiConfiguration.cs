namespace HostOcean.Api.Infrastructure.GroupScheduleService
{
    public class GoogleCalendarApiConfiguration
    {
        public GoogleCalendarApiConfiguration()
        {
            LaboratoryWorkEventKey = "(ЛР)";
        }

        public string ApplicationName { get; set; }
        public string ApiKey { get; set; }
        public string LaboratoryWorkEventKey { get; set; }
    }
}