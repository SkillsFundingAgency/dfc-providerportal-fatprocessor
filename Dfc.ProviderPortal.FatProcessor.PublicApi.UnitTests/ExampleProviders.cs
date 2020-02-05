using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.UnitTests
{
    public static class ExampleProviders
    {
        public static Organisation ProviderA = 
            new Organisation(
                309386, 
                10082136, 
                "Projecting Success Ltd", 
                null, 
                false, 
                "Company blurb goes here", 
                "contact@email.test", 
                "http://www.website.test", 
                "+44123456789", 
                null, 
                null, 
                ExampleApprenticeships.All());
    }
}