using System;
using System.Text.Json;
using Dfc.ProviderPortal.FatProcessor.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Dfc.ProviderPortal.FatProcessor.UnitTests
{
    public class AddressTests
    {
        private Location _location;

        public AddressTests()
        {
            var address = new TestAddress(
                "The Squirrel",
                "1 Greyfriars Ln",
                "Coventry",
                null,
                "CV1 2GY",
                52.40529,
                -1.51033,
                "Earth"
            );

            _location = new Location(address);
        }

        [Fact]
        public void CallingAKnownPropertyReturnsTheValue()
        {
            // arrange
            var sut = _location;
            var expected = "CV1 2GY";

            // act
            var actual = sut.Address.Postcode;

            // assert
            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void CallingAnEmptyFieldIsHandledGracefully()
        //{
        //    // arrange

        //    var sut = _location;

        //    // act
        //    var actual = sut.Address.County;

        //    // assert
        //    Assert.True(String.IsNullOrEmpty(actual));
        //}

        public class UkPartialAddressTests : AddressTests
        {
            public UkPartialAddressTests()
            {
                var address = new UkPartialAddress(
                    "CV1 2GY",
                    52.40529,
                    -1.51033
                );

                _location = new Location(address);
            }

            [Fact]
            public void MustHavePostcodeLatitudeAndLongitude()
            {
                // arrange
                var sut = _location;
                var expected = "{\"postcode\":\"CV1 2GY\",\"lat\":52.40529,\"long\":-1.51033}";

                // act
                var actual = JsonSerializer.Serialize(sut.Address);

                // assert
                Assert.Equal(expected, actual);
            }
        }


        public class UkFullAddressTests : AddressTests
        {
            public UkFullAddressTests()
            {
                var address = new UkFullAddress(
                    "The Squirrel",
                    "1 Greyfriars Ln",
                    "Coventry",
                    "East Midlands",
                    "CV1 2GY",
                    52.40529,
                    -1.51033
                );

                _location = new Location(address);
            }
            
            [Fact]
            public void MustHaveAStreetAddress()
            {
                var sut = _location;
                var expected =
                    "{\"address1\":\"The Squirrel\",\"address2\":\"1 Greyfriars Ln\",\"town\":\"Coventry\",\"county\":\"East Midlands\",\"postcode\":\"CV1 2GY\",\"lat\":52.40529,\"long\":-1.51033}";

                // act
                var actual = JsonSerializer.Serialize(sut.Address);

                // assert
                Assert.Equal(expected, actual);
            }
        }
    }
}