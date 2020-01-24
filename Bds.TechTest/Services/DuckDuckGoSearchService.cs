using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Web;

namespace Bds.TechTest.Services
{
    public class DuckDuckGoSearchService : SearchEngineService
    {
        private readonly List<string> SearchResultLinks;
        public DuckDuckGoSearchService() : base()
        {
            SearchResultLinks = new List<string>();
        }

        public override List<string> Result(string searchTerm)
        {
            var htmlDocument = $"https://duckduckgo.com/html/?q={searchTerm}".ReturnHtmlDocument();

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//a[@class='result__a']");
            foreach (var resultA in resultNodes)
            {
                var uriString = resultA.Attributes["href"].Value.Substring(19);
                SearchResultLinks.Add(HttpUtility.UrlDecode(uriString));
            }
            return SearchResultLinks;
        }
    }
}