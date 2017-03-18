using Dogevents.Core.Helpers;
using Xunit;

namespace Dogevents.Tests.Dogevents.Core.Helpers
{
    public class UrlParserTest
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("177791179390533", "177791179390533")]
        [InlineData("https://www.facebook.com/events/177791179390533/", "177791179390533")]
        public void GetEventId_Should_Return_Empty_Valid_Result(string url, string eventId)
        {
            Assert.Equal(UrlParser.GetEventId(url), eventId);
        }
    }
}