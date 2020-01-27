using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.UnitTests
{
    public static class ExampleLocations
    {
        public static ApprenticeshipLocation Classroom = new ApprenticeshipLocation(
            001, new[] { DeliveryMode.ClassroomBased }, 25);

        public static ApprenticeshipLocation Online = new ApprenticeshipLocation(
            002, new[] { DeliveryMode.Online }, 999);

        public static ApprenticeshipLocation Workplace = new ApprenticeshipLocation(
            003, new[] { DeliveryMode.WorkBased }, 100);

        public static ApprenticeshipLocation Mixed = new ApprenticeshipLocation(
            004, new[] { DeliveryMode.ClassroomBased, DeliveryMode.Online, DeliveryMode.WorkBased }, 200);

        public static ApprenticeshipLocation Undefined = new ApprenticeshipLocation(
            005, new[] { DeliveryMode.Undefined }, 10);
    }
}