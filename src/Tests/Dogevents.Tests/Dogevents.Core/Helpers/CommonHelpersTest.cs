using Dogevents.Core.Helpers;
using Shouldly;
using Xunit;

namespace Dogevents.Tests.Dogevents.Core.Helpers
{
    public class CommonHelpersTest
    {
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("    ", true)]
        [InlineData("someText", false)]
        public void IsEmpty_Test(string value, bool expectedResult)
        {
            value.IsEmpty().ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("    ", false)]
        [InlineData("someText", true)]
        public void IsNotEmpty_Test(string value, bool expectedResult)
        {
            value.IsNotEmpty().ShouldBe(expectedResult);
        }
    }
}