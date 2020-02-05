using System.Collections.Generic;
using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.Functions.Dto.Cosmos
{
    public class ApprenticeshipLocationDto
    {
        public int LocationId { get; set; }
        public string VenueId { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public IEnumerable<DeliveryMode> DeliveryModes { get; set; }
        public int Radius { get; set; }
    }
}