using System.Collections.Generic;

namespace Dfc.ProviderPortal.FatProcessor.Domain.Models
{
    public class Framework : Apprenticeship
    {
        public int Pathway { get; }
        public int ProgrammeType { get; }

        public Framework(int code, int pathway, int programmeType, string marketingInfo, string url,
            Contact contact = null, IEnumerable<ApprenticeshipLocation> locations = null) : base(code, marketingInfo, url, contact, locations)
        {
            Pathway = pathway;
            ProgrammeType = programmeType;
        }
    }
}