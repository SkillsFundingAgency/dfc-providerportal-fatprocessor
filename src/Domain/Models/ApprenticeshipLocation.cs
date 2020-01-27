using System.Collections.Generic;

namespace Dfc.ProviderPortal.FatProcessor.Domain.Models
{
    public class ApprenticeshipLocation
    {
        public ApprenticeshipLocation(int id, IEnumerable<DeliveryMode> deliveryModes, int radius)
        {
            Id = id;
            DeliveryModes = deliveryModes;
            Radius = radius;
        }

        public int Id { get; }
        public IEnumerable<DeliveryMode> DeliveryModes { get; }
        public int Radius { get; }
    }

    public enum DeliveryMode
    {
        Undefined = 0,
        ClassroomBased = 1,
        Online = 2,
        WorkBased = 3
    }
}