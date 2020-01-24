using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Web;

namespace Bds.TechTest.Services
{
    public class GoogleSearchService : SearchEngineService
    {
        private readonly List<string> SearchResultLinks;

        public GoogleSearchService() : base()
        {
            SearchResultLinks = new List<string>();
        }

        public override List<string> Result(string searchTerm)
        {
            try 
            {
                var htmlDocument = $"https://www.google.com/search?q={searchTerm}".ReturnHtmlDocument();
                
                var cites = htmlDocument.DocumentNode.SelectNodes("//cite");

                foreach (var cite in cites)
                {
                    SearchResultLinks.Add(HttpUtility.HtmlDecode(cite.InnerText));
                }
                return SearchResultLinks;
            }
            catch(Exception)
            {
                return new List<string>();
            }
        }
    }
}