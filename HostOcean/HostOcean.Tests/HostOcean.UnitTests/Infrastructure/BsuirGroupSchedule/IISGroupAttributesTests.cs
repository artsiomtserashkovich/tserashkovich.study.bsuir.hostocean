using AutoFixture;
using FluentAssertions;
using HostOcean.Infrastructure.BsuirGroupService;
using Newtonsoft.Json;
using Xunit;

namespace HostOcean.UnitTests.Infrastructure.BsuirGroupSchedule
{
    public class IISGroupAttributesTests
    {
        public IISGroupAttributesTests()
        {
            _fixture = new Fixture();
        }

        private readonly IFixture _fixture;

        [Fact]
        public void IISGroupDeserialize_ObjectWithWholeDefinedProperties_SerializeAndDeserializeResultSame()
        {
            //Arrange
            var groupExpect = _fixture.Create<IISGroup>();
            var jsonIISGroupArrange =JsonConvert.SerializeObject(groupExpect);

            //Act
            var act = JsonConvert.DeserializeObject<IISGroup>(jsonIISGroupArrange);

            //Assert
            act.Should().BeEquivalentTo(groupExpect);
        }

        [Fact]
        public void IISGroupDeserialize_JSONFromApiDocumentation_DeserilizedWholeEntity()
        {
            //Arrange
            var groupExpect = new IISGroup
            {
                Name = "611802",
                FacultyId = 20017,
                SpecialityId = 20012,
                YearOfEducation = 2,
                CalendarId = "qth60vnitiofu354f3rdbgmeeo@group.calendar.google.com",
                Id = 22046
            };
            var jsonIISGroupArrange =
                "{\r\n    \"name\": \"611802\"," +
                "\r\n    \"facultyId\": 20017," +
                "\r\n    \"specialityDepartmentEducationFormId\": 20012," +
                "\r\n    \"course\": 2," +
                "\r\n    \"id\": 22046," +
                "\r\n    \"calendarId\": \"qth60vnitiofu354f3rdbgmeeo@group.calendar.google.com\"\r\n  }";

            //Act
            var act = JsonConvert.DeserializeObject<IISGroup>(jsonIISGroupArrange);

            //Assert
            act.Should().BeEquivalentTo(groupExpect);
        }

        [Fact]
        public void IISGroupDeserialize_JSONWithNullableCalendarId_CalendarIdPropertyEqualsNull()
        {
            //Arrange
            var groupExpect = new IISGroup
            {
                Name = "850509",
                FacultyId = 20026,
                SpecialityId = 20019,
                YearOfEducation = null,
                CalendarId = null,
                Id = 22755
            };
            var jsonIISGroupArrange =
                "{\r\n        \"name\": \"850509\"," +
                "\r\n        \"facultyId\": 20026," +
                "\r\n        \"facultyName\": null," +
                "\r\n        \"specialityDepartmentEducationFormId\": 20019," +
                "\r\n        \"specialityName\": null," +
                "\r\n        \"course\": null," +
                "\r\n        \"id\": 22755,\r\n        \"calendarId\": null\r\n    }";

            //Act
            var act = JsonConvert.DeserializeObject<IISGroup>(jsonIISGroupArrange);

            //Assert
            act.Should().BeEquivalentTo(groupExpect);
        }

        [Fact]
        public void IISGroupDeserialize_JSONWithWholeDefinitionProperties_NotNullWholePropertiesInEntity()
        {
            //Arrange
            var groupExpect = new IISGroup
            {
                Name = "767511",
                FacultyId = 20040,
                SpecialityId = 20200,
                YearOfEducation = 2,
                CalendarId = "p1q03qnfum3he356f069cml38g@group.calendar.google.com",
                Id = 22486
            };
            var jsonIISGroupArrange =
                "{\n        \"name\": \"767511\"," +
                "\n        \"facultyId\": 20040," +
                "\n        \"facultyName\": null," +
                "\n        \"specialityDepartmentEducationFormId\": 20200," +
                "\n        \"specialityName\": null," +
                "\n        \"course\": 2," +
                "\n        \"id\": 22486," +
                "\n        \"calendarId\": \"p1q03qnfum3he356f069cml38g@group.calendar.google.com\"\n    }";

            //Act
            var act = JsonConvert.DeserializeObject<IISGroup>(jsonIISGroupArrange);

            //Assert
            act.Should().BeEquivalentTo(groupExpect);
        }
    }
}
