using System.Collections.Generic;
using Dfc.ProviderPortal.FatProcessor.Domain.Interfaces;
using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.UnitTests
{
    public static class TestHelper
    {
        public static Organisation CreateOrg(int id, int ukprn, string name, string tradingName, bool national, string marketingInfo, string email, string website, string phone, double learnerSatisfaction, double employerSatisfaction, IEnumerable<IApprenticeship> apprenticeships)
        {
            return new Organisation(id, ukprn, name, tradingName, national, marketingInfo, email,
                website, phone, learnerSatisfaction, employerSatisfaction, apprenticeships);
        }
    }
}