using System.Collections.Generic;

namespace Bds.TechTest.Services
{
    public abstract class SearchEngineService
    {
        public string Name { get; protected set;  }

        public abstract List<string> Result(string searchTerm);

        protected SearchEngineService(string name)
        {
            Name = name;
        }
    }
}