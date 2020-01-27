using System.Text.Json.Serialization;
using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.UnitTests
{
    public class TestAddress : IAddress, IStreetAddressSchema, IPostcodeSchema, ILatLongSchema
    {
        [JsonPropertyName("address1")] public string Address1 { get; private set; }
        [JsonPropertyName("address2")] public string Address2 { get; private set; }
        [JsonPropertyName("town")] public string Town { get; private set; }
        [JsonPropertyName("county")] public string County { get; private set; }
        [JsonPropertyName("postcode")] public string Postcode { get; private set; }
        [JsonPropertyName("lat")] public double Latitude { get; private set; }
        [JsonPropertyName("long")] public double Longitude { get; private set; }
        [JsonPropertyName("planet")] public string Planet { get; private set; }

        public TestAddress(string address1, string address2, string town, string county, string postcode, double lat, double lon, string planet)
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.Town = town;
            this.County = county;
            this.Postcode = postcode;
            this.Latitude = lat;
            this.Longitude = lon;
            this.Planet = planet;
        }
    }
}
