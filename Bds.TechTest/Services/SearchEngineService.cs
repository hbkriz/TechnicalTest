using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Bds.TechTest.Services
{
    public abstract class SearchEngineService
    {
        public abstract List<string> Result(string searchTerm);
    }
}