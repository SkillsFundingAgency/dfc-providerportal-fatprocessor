using System.Collections.Generic;
using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.Domain.Interfaces
{
    public interface IApprenticeship
    {
        int Code { get; }
        string MarketingInfo { get; }
        string Url { get; }
        Contact Contact { get; }
        IEnumerable<ApprenticeshipLocation> Locations { get; }

        bool IsAvailable();
    }
}