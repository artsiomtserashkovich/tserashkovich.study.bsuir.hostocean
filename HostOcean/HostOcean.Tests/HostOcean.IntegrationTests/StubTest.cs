using Xunit;

namespace HostOcean.IntegrationTests
{
    public class StubTest
    {
        [Fact]
        public void Stub_Test()
        {
            Assert.True(true);
        }

        [Fact]
        public void Test_fail()
        {
            Assert.True(false);
        }
    }
}