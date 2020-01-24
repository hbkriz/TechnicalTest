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
        public ActionResult<IEnumerable<string>> Search(string searchTerm)
        {
            var searchEngines = new List<SearchEngineService> {new GoogleSearchService(), new DuckDuckGoSearchService()};
            return searchEngines.Run(searchTerm);
        }
    }
}
