using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bds.TechTest.Services;

namespace Bds.TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchEnginesController : ControllerBase
    {
        [HttpPost]
        public List<SearchResult> Search(string searchTerm)
        {
            var searchEngines = new List<SearchEngineService> {new GoogleSearchService(), new DuckDuckGoSearchService()};
            var combinedResult = searchEngines.Run(searchTerm);
            return combinedResult.Select(x => new SearchResult() { Url = x }).ToList();
        }
    }

    public class SearchResult
    {
        public string Url { get; set; }
    }
}
