using System.Collections.Generic;
using Models;

namespace Bds.TechTest.Services
{
    public static class RunSearchEngineService
    {
        public static List<SearchResult> Run(this List<SearchEngineService> engines, string searchTerm)
        {
            var allResults = new List<SearchResult>();
            foreach (var engine in engines)
            {
                var urlResults = engine.Result(searchTerm);
                foreach (var urlResult in urlResults)
                {
                    allResults.Add(new SearchResult() { Url = urlResult, Type= engine.Name});
                }
            }
            return allResults;
        }
    }
}