using System.Collections.Generic;
using System.Linq;
using Dfc.ProviderPortal.FatProcessor.Domain.Interfaces;

namespace Dfc.ProviderPortal.FatProcessor.Domain.Models
{
    public abstract class Apprenticeship : IApprenticeship
    {
        public int Code { get; }
        public string MarketingInfo { get; }
        public string Url { get; }
        public Contact Contact { get; }
        public IEnumerable<ApprenticeshipLocation> Locations { get; }

        /// <summary>
        /// Apprenticeships are only available if they have Locations, Contacts, Marketing Info and a URL.
        /// </summary>
        /// <returns>boolean indicating whether the apprenticeship is available for selection</returns>
        public bool IsAvailable()
        {
            return Locations.Any()
                   && Contact != null
                   && !string.IsNullOrEmpty(MarketingInfo)
                   && !string.IsNullOrEmpty(Url);
        }

        protected Apprenticeship()
        {
            Locations = new List<ApprenticeshipLocation>();
        }

        protected Apprenticeship(int code, string marketingInfo, string url, Contact contact = null,
            IEnumerable<ApprenticeshipLocation> locations = null)
        {
            Code = code;
            MarketingInfo = marketingInfo;
            Url = url;
            Contact = contact;
            Locations = locations ?? new List<ApprenticeshipLocation>();
        }
    }
}