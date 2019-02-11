using Newtonsoft.Json;

namespace HostOcean.Api.Infrastructure.GroupService
{
    public class IISGroup
    {
        [JsonProperty("id",Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("facultyId", NullValueHandling = NullValueHandling.Include)]
        public int? FacultyId { get; set; }

        [JsonProperty("specialityDepartmentEducationFormId",NullValueHandling = NullValueHandling.Include)]
        public int? SpecialityId { get; set; }

        [JsonProperty("course", NullValueHandling = NullValueHandling.Include)]
        public int? YearOfEducation { get; set; }

        [JsonProperty("calendarId",NullValueHandling = NullValueHandling.Include,Required = Required.AllowNull)]
        public string CalendarId { get; set; }
    }
}