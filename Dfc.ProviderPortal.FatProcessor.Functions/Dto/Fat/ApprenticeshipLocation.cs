using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.Functions.Dto.Fat
{
    public class ApprenticeshipLocation
    {
        public ApprenticeshipLocation(int id, IEnumerable<DeliveryMode> deliveryModes, int radius)
        {
            Id = id;
            DeliveryModes = deliveryModes.Select(e => e.ToString());
            Radius = radius;
        }

        [JsonPropertyName("id")] public int Id { get; }
        [JsonPropertyName("deliveryModes")] public IEnumerable<string> DeliveryModes { get; }
        [JsonPropertyName("radius")] public int Radius { get; }
    }
}