using System;
using AutoFixture;
using FluentAssertions;
using HostOcean.Infrastructure.BsuirGroupService;
using Xunit;
// ReSharper disable ExpressionIsAlwaysNull

namespace HostOcean.UnitTests.Infrastructure.BsuirGroupSchedule
{
    public class IISv1ApiUriBuilderTests
    {
        private readonly IFixture _fixture;

        public IISv1ApiUriBuilderTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void GetGroupsUri_ConstantPath_EqualsToApiDocumentation()
        {
            var expectUri = "/api/v1/groups";

            IISv1ApiUriBuilder.GetGroupsUri.Should().Be(expectUri);
        }

        [Fact]
        public void GetGroupScheduleByGroupNameUri_PassGroupName_EqualsToApiDocumentation()
        {
            var groupName = _fixture.Create<string>();
            var expectUri = $"/api/v1/studentGroup/schedule?studentGroup={groupName}";

            IISv1ApiUriBuilder.GetGroupScheduleByGroupNameUri(groupName).Should().Be(expectUri);
        }

        [Fact]
        public void GetGroupScheduleByGroupNameUri_PassEmptyString_throwArgumentException()
        {
            var groupName = string.Empty;
            Action act = () => IISv1ApiUriBuilder.GetGroupScheduleByGroupNameUri(groupName);

            act.Should().Throw<ArgumentException>().WithMessage(nameof(groupName));
        }

        [Fact]
        public void GetGroupScheduleByGroupNameUri_PassNull_throwArgumentException()
        {
            string groupName = null;
            Action act = () => IISv1ApiUriBuilder.GetGroupScheduleByGroupNameUri(groupName);

            act.Should().Throw<ArgumentException>().WithMessage(nameof(groupName));
        }

        [Fact]
        public void GetGroupScheduleByGroupIdUri_PassGroupId_EqualsToApiDocumentation()
        {
            var groupId = _fixture.Create<string>();
            var expectUri = $"/api/v1/studentGroup/schedule?id={groupId}";

            IISv1ApiUriBuilder.GetGroupScheduleByGroupIdUri(groupId).Should().Be(expectUri);
        }

        [Fact]
        public void GetGroupScheduleByGroupIdUri_PassEmptyString_throwArgumentException()
        {
            var groupId = string.Empty;
            Action act = () => IISv1ApiUriBuilder.GetGroupScheduleByGroupIdUri(groupId);

            act.Should().Throw<ArgumentException>().WithMessage(nameof(groupId));
        }

        [Fact]
        public void GetGroupScheduleByGroupIdUri_PassNull_throwArgumentException()
        {
            string groupId = null;
            Action act = () => IISv1ApiUriBuilder.GetGroupScheduleByGroupIdUri(groupId);

            act.Should().Throw<ArgumentException>().WithMessage(nameof(groupId));
        }
    }
}