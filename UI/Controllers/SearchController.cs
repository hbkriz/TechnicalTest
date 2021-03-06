using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bds.TechTest.Controllers;
using Models;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private SearchEnginesController _apiController= new SearchEnginesController();

        [HttpGet("[action]")]
        public IEnumerable<SearchResult> TwoSearchEngines(string term)
        {
            return _apiController.Search(term).Select(
                x => new SearchResult() { Url = x.Url, Type= x.Type }
                ).ToList();
        }
    }
}
