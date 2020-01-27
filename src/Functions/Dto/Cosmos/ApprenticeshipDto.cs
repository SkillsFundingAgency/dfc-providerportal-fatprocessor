using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.Azure.Documents;

namespace Dfc.ProviderPortal.FatProcessor.Functions.Dto.Cosmos
{
    /// <summary>
    /// Represents a record from the Apprenticeships collection in Cosmos
    /// </summary>
    [DataContract]
    public class ApprenticeshipDto : Document
    {
        public string ApprenticeshipTitle { get; set; }
        // ReSharper disable once InconsistentNaming (to match back end data model)
        public int ProviderUKPRN { get; set; }
        public int? StandardCode { get; set; }
        public int? FrameworkCode { get; set; }
        public int? ProgType { get; set; }
        public int? PathwayCode { get; set; }
        public string MarketingInformation { get; set; }
        public string Url { get; set; }
        public string ContactTelephone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactWebsite { get; set; }
        public IEnumerable<ApprenticeshipLocationDto> ApprenticeshipLocations { get; set; }
    }
}