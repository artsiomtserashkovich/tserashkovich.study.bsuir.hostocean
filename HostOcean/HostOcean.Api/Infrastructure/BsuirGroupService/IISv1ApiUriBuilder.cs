namespace HostOcean.Api.Infrastructure.BsuirGroupService
{
    public static class IISv1ApiUriBuilder
    {
        public static string GetGroups => "/api/v1/groups";
        public static string GetGroupScheduleByGroupName(string groupName) => $"/api/v1/studentGroup/schedule?studentGroup={groupName}";
        public static string GetGroupScheduleByGroupId(string groupId) => $"/api/v1/studentGroup/schedule?id={groupId}";
    }
}