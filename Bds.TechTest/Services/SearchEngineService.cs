using System.Collections.Generic;

namespace Bds.TechTest.Services
{
    public abstract class SearchEngineService
    {
        public abstract List<string> Result(string searchTerm);
    }
}