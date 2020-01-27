using System.Collections.Generic;

namespace Dfc.ProviderPortal.FatProcessor.Domain.Models
{
    public class Standard : Apprenticeship
    {
        public Standard(int code, string marketingInfo, string url,
            Contact contact = null, IEnumerable<ApprenticeshipLocation> locations = null) : base(code, marketingInfo, url, contact, locations)
        {
        }
    }
}