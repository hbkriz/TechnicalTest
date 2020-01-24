using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HtmlAgilityPack;
using System.Text;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Web;
using Bds.TechTest.Services;

namespace Bds.TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation($"Searching for values");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<IEnumerable<string>> Post(string searchTerm)
        {
            _logger.LogInformation($"Searching for {searchTerm}");

            var searchEngines = new List<SearchEngineService> {new GoogleSearchService(), new DuckDuckGoSearchService()};

            var combinedResults = searchEngines.Run(searchTerm);

            _logger.LogDebug($"Found {combinedResults.Count} results for {searchTerm}");

            return combinedResults;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
