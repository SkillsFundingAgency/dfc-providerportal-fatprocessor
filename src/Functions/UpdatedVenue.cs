using Microsoft.Azure.Documents;

namespace Dfc.ProviderPortal.FatProcessor.Functions
{
    public class UpdatedVenue : Document
    {
        public int Ukprn { get; set; }
        public int ProviderId { get; set; }
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set;}
        public string Town { get; set; }
        public string County { get; set; }
    }
}
