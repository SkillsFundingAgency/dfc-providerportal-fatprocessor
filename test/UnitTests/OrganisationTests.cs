using System.Collections.Generic;
using System.Linq;
using Dfc.ProviderPortal.FatProcessor.Domain.Interfaces;
using Dfc.ProviderPortal.FatProcessor.Domain.Models;
using Xunit;

namespace Dfc.ProviderPortal.FatProcessor.UnitTests
{
    public class OrganisationTests
    {
        private readonly Organisation _provider;
        
        public OrganisationTests()
        {
            var apprenticeships = ExampleApprenticeships.All();

            _provider = ExampleProviders.ProviderA;
        }

        [Fact]
        public void StandardsShouldReturnStandards()
        {
            // arrange
            var expected = new List<IApprenticeship>()
            {
                ExampleApprenticeships.StandardA,
                ExampleApprenticeships.StandardB
            };

            // act
            var actual = _provider.AvailableStandards.ToList();

            //assert
            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count, actual.Count());
            Assert.Equal(expected, actual);
        }
    }
}