using System.Collections.Generic;
using Dfc.ProviderPortal.FatProcessor.Domain.Interfaces;
using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.UnitTests
{
    public static class ExampleApprenticeships
    {
        public static Standard StandardA = new Standard(
            2000001,
            "This is Standard A",
            "https://localhost:8099/apprenticeship/2000001",
            ExampleContacts.ContactA,
            new[] {ExampleLocations.Classroom});

        public static Standard StandardB = new Standard(
            2000002,
            "This is Standard B",
            "https://localhost:8099/apprenticeship/2000002",
            ExampleContacts.ContactB,
            new[] {ExampleLocations.Mixed});

        public static Standard StandardWithoutLocations = new Standard(
            2000002,
            "This is Standard B",
            "https://localhost:8099/apprenticeship/2000002",
            ExampleContacts.ContactC,
            null);


    public static Framework FrameworkA = new Framework(
            1000001, 100, 1,
            "This is framework 1",
            "https://localhost:8099/apprenticeship/1000001/100/1",
            ExampleContacts.ContactA,
            new[] {ExampleLocations.Classroom});

        public static Framework FrameworkB = new Framework(
            1000001, 100, 2,
            "Similar to framework 1 but uses a different programme type",
            "https://localhost:8099/apprenticeship/1000001/100/2",
            ExampleContacts.ContactB,
            new[] { ExampleLocations.Mixed });

        public static Framework FrameworkC = new Framework(
            1000001, 150, 1,
            "<p>This Frámewórk is comparable to Frameworks A & B but uses a different pathway\n\nThis is the 2nd line of this text</p>",
            "https://localhost:8099/apprenticeship/1000001/200/1",
            ExampleContacts.ContactC,
            new[] { ExampleLocations.Workplace });

        public static Framework FrameworkWithoutLocations = new Framework(
            1000002, 200, 2, 
            string.Empty, 
            string.Empty,
            ExampleContacts.ContactA);

        public static Framework FrameworkWithoutContacts = new Framework(
            1000003, 300, 3,
            string.Empty,
            string.Empty,
            null,
            new[] { ExampleLocations.Mixed });

        public static List<IApprenticeship> All()
        {
            return new List<IApprenticeship>()
            {
                StandardA,
                StandardB,
                StandardWithoutLocations,
                FrameworkA, 
                FrameworkB, 
                FrameworkC, 
                FrameworkWithoutContacts, 
                FrameworkWithoutLocations
            };
        }
    }
}