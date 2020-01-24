using NUnit.Framework;
using System.Collections.Generic;
using Bds.TechTest.Services;

namespace Bds.TechTest.Tests
{
    public class DuckDuckGoSearchServiceTest
    {
        private DuckDuckGoSearchService _duckDuckGoSearchService;
        [SetUp]
        public void Setup()
        {
            _duckDuckGoSearchService = new DuckDuckGoSearchService();
        }


        [TestCase("pogo")]
        [TestCase("bbc")]
        [TestCase("bds")]
        [TestCase("haribalakrishnan@live.com")]
        [TestCase("chris.stokoe@blackdotsolutions.com")]
        [TestCase("kkkkkk")]
        [TestCase("123444")]
        [TestCase("111111")]
        [TestCase("this-is-incredible")]
        [TestCase("Surprise!")]
        [TestCase("facebook.com")]
        [TestCase("Brien O'Connors")]
        public void HappyScenarioTest_For_DuckDuckGoSearch(string searchTerm)
        {
            var result = _duckDuckGoSearchService.Result(searchTerm);
            Assert.That(result.Count > 0, "Search Result failed");
        }

        [TestCase(" ")]
        [TestCase("freetrial26372376273@affpartners.com")]
        [TestCase("mvhs43478@9a9k3pe0h1jr0n.w723-1319.lktrd6u.ga")]
        [TestCase("1+2")]
        public void NegativeScenarioTest_For_DuckDuckGoSearch(string searchTerm)
        {
            var result = _duckDuckGoSearchService.Result(searchTerm);
            Assert.That(result.Count == 0, "Search Result should not return value");
        }
    }
}