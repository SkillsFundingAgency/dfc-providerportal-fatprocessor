using System.Dynamic;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dfc.ProviderPortal.FatProcessor.Domain.Models
{
    public interface ILatLongSchema 
    {
        double Latitude { get; }
        double Longitude { get; }
    }

    public interface IStreetAddressSchema
    {
        string Address1 { get; }
        string Address2 { get; }
        string Town { get; }
        string County { get; }
    }

    public interface IPostcodeSchema
    {
        string Postcode { get; }
    }


    public interface ILocation
    {
        int Id { get; }
        string Name { get; }
        string Email { get; }
        string Website { get; }
        string Phone { get; }
        
        dynamic Address { get; }
    }

    public class Location : ILocation
    {
        private readonly dynamic _address;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public Location()
        {
            _address = new ExpandoObject();
        }

        public Location(dynamic address) : base()
        {
            _address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public dynamic Address => _address;
    }

    public static class LocationFactory
    {
        public static Location Create<T>(T address)
            where T : IAddress
        {
            return new Location(address);
        }
    }

    public interface IAddress
    {

    }


    [DataContract]
    public class UkPartialAddress : IAddress, IPostcodeSchema, ILatLongSchema
    {
        [JsonPropertyName("postcode")] public string Postcode { get; private set; }
        [JsonPropertyName("lat")] public double Latitude { get; private set; }
        [JsonPropertyName("long")] public double Longitude { get; private set; }

        public UkPartialAddress(string postcode, double lat, double lon)
        {
            this.Postcode = postcode;
            this.Latitude = lat;
            this.Longitude = lon;
        }
    }

    [DataContract]
    public class UkFullAddress : IAddress, IStreetAddressSchema, IPostcodeSchema, ILatLongSchema
    {
        [JsonPropertyName("address1")] public string Address1 { get; private set; }
        [JsonPropertyName("address2")] public string Address2 { get; private set; }
        [JsonPropertyName("town")] public string Town { get; private set; }
        [JsonPropertyName("county")] public string County { get; private set; }
        [JsonPropertyName("postcode")] public string Postcode { get; private set; }
        [JsonPropertyName("lat")] public double Latitude { get; private set; }
        [JsonPropertyName("long")] public double Longitude { get; private set; }

        public UkFullAddress(string address1, string address2, string town, string county, string postcode, double lat,
            double lon)
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.Town = town;
            this.County = county;
            this.Postcode = postcode;
            this.Latitude = lat;
            this.Longitude = lon;
        }
    }
}