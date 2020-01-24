using System.Collections.Generic;

namespace Bds.TechTest.Services
{
    public static class RunSearchEngineService
    {
        public static List<string> Run(this List<SearchEngineService> engines, string searchTerm)
        {
            var allResults = new List<string>();
            foreach (var engine in engines)
            {
                var results = engine.Result(searchTerm);
                foreach (var result in results)
                {
                    allResults.Add(result);
                }
            }
            return allResults;
        }
    }
}