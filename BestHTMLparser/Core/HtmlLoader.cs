using System.Net.Http;
using System.Threading.Tasks;

namespace BestHTMLparser.Core
{
    /// <summary>
    /// Load html page according to settings
    /// </summary>
    class HtmlLoader
    {
        readonly HttpClient client;

        readonly string url;

        public HtmlLoader(iParserSettings parserSettings)
        {
            client = new HttpClient();
            url = $"{parserSettings.BaseUrl}/{parserSettings.Prefix}/";
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response != null && response.IsSuccessStatusCode)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
