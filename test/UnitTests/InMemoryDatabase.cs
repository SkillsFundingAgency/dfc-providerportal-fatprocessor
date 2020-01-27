using System.Collections.Generic;
using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.UnitTests
{
    public class InMemoryDatabase
    {
        private readonly List<Organisation> _providers;

        public InMemoryDatabase()
        {
            _providers = new List<Organisation>();
        }
    }
}