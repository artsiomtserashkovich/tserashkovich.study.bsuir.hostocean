using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using HostOcean.Infrastructure.GroupScheduleService;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace HostOcean.UnitTests.Infrastructure.GroupSheduleService
{
    public class GoogleCalendarV3ClientTests
    {
        private readonly GoogleCalendarV3Client _sut;
        private readonly GoogleCalendarApiConfiguration _configuration;
        private readonly Mock<IOptions<GoogleCalendarApiConfiguration>> _configurationMock;
        private readonly IFixture _fixture;
        
        public GoogleCalendarV3ClientTests()
        {
            _fixture = new Fixture();
            _configuration = _fixture.Create<GoogleCalendarApiConfiguration>();

            _configurationMock = new Mock<IOptions<GoogleCalendarApiConfiguration>>();
            _configurationMock.Setup(x => x.Value).Returns(_configuration);

            _sut = new GoogleCalendarV3Client(_configurationMock.Object);
        }

        [Fact]
        public async Task GetLaboratoryWorkEvents_PassWrongStartTimeAndEndTime_ThrowArgumentExceptionAsync()
        {
            var calendarId = _fixture.Create<string>();
            var endDateTime = DateTime.Now;
            var startDateTime = endDateTime.AddDays(1);

            Func<Task> f = async () => { await _sut.GetLaboratoryWorkEvents(calendarId,startDateTime,endDateTime); };
            await f.Should().ThrowAsync<ArgumentException>();
        }
    }
}
