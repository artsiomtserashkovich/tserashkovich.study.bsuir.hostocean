using System;

namespace HostOcean.Infrastructure.BsuirGroupService
{
    public static class IISv1ApiUriBuilder
    {
        public static string GetGroupsUri => "/api/v1/groups";

        public static string GetGroupScheduleByGroupNameUri(string groupName)
        {
            if(string.IsNullOrEmpty(groupName) || string.IsNullOrWhiteSpace(groupName))
                throw new ArgumentException(nameof(groupName));

            return $"/api/v1/studentGroup/schedule?studentGroup={groupName}";
        }

        public static string GetGroupScheduleByGroupIdUri(string groupId)
        {
            if (string.IsNullOrEmpty(groupId) || string.IsNullOrWhiteSpace(groupId))
                throw new ArgumentException(nameof(groupId));

           return $"/api/v1/studentGroup/schedule?id={groupId}";
        }
    }
}