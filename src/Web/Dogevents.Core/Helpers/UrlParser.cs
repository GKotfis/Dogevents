using System.Text.RegularExpressions;

namespace Dogevents.Core.Helpers
{
    public static class UrlParser
    {
        public static string GetEventId(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            return Regex.Match(url, @"(?:events)?(?:/)?(?'id'\d+)").Groups["id"].Value;
        }
    }
}