using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Dfc.ProviderPortal.FatProcessor.Domain.Interfaces;
using Dfc.ProviderPortal.FatProcessor.Functions.Dto.Cosmos;

namespace Dfc.ProviderPortal.FatProcessor.Functions.Dto.Fat
{
    public class FrameworkExport : IMessagePayload
    {
        public FrameworkExport(
            int frameworkCode,
            int pathwayCode,
            int progType,
            string marketingInfo,
            string url,
            ApprenticeshipContact contact = null,
            IEnumerable<ApprenticeshipLocation> locations = null)
        {
            FrameworkCode = frameworkCode;
            PathwayCode = pathwayCode;
            ProgType = progType;
            MarketingInfo = marketingInfo;
            Url = url;
            Contact = contact;
            Locations = locations;
        }

        [JsonPropertyName("frameworkCode")] public int FrameworkCode { get; }
        [JsonPropertyName("pathwayCode")] public int PathwayCode { get; }
        [JsonPropertyName("progType")] public int ProgType { get; }
        [JsonPropertyName("marketingInfo")] public string MarketingInfo { get; }
        [JsonPropertyName("frameworkInfoUrl")] public string Url { get; }
        [JsonPropertyName("contact")] public ApprenticeshipContact Contact { get; }
        [JsonPropertyName("locations")] public IEnumerable<ApprenticeshipLocation> Locations { get; }

        public static explicit operator FrameworkExport(ApprenticeshipDto dto)
        {
            try
            {
                if (!dto.FrameworkCode.HasValue 
                    || !dto.PathwayCode.HasValue
                    || !dto.ProgType.HasValue) 
                    throw new Exception("Frameword code not found. Is this a Standard?");

                var frameworkCode = dto.FrameworkCode.Value;
                var pathwayCode = dto.PathwayCode.Value;
                var progType = dto.ProgType.Value;
                var marketingInfo = dto.MarketingInformation;
                var url = dto.Url;

                var contactPhone = dto.ContactTelephone;
                var contactEmail = dto.ContactEmail;
                var contactWebsite = dto.ContactWebsite;

                var contact = new ApprenticeshipContact(contactPhone, contactEmail, contactWebsite);
                var locations = new List<ApprenticeshipLocation>();

                foreach (var loc in dto.ApprenticeshipLocations)
                    locations.Add(new ApprenticeshipLocation(loc.LocationId, loc.DeliveryModes, loc.Radius));

                var framework = new FrameworkExport(frameworkCode, pathwayCode, progType, marketingInfo, url, contact, locations);

                return framework;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }


    public class StandardExport : IMessagePayload
    {
        public StandardExport(
            int standardCode,
            string marketingInfo,
            string url,
            ApprenticeshipContact contact = null,
            IEnumerable<ApprenticeshipLocation> locations = null)
        {
            StandardCode = standardCode;
            MarketingInfo = marketingInfo;
            Url = url;
            Contact = contact;
            Locations = locations;
        }

        [JsonPropertyName("standardCode")] public int StandardCode { get; }
        [JsonPropertyName("marketingInfo")] public string MarketingInfo { get; }
        [JsonPropertyName("standardInfoUrl")] public string Url { get; }
        [JsonPropertyName("contact")] public ApprenticeshipContact Contact { get; }
        [JsonPropertyName("locations")] public IEnumerable<ApprenticeshipLocation> Locations { get; }

        // TODO: Automapper
        public static explicit operator StandardExport(ApprenticeshipDto dto)
        {
            try
            {
                if (!dto.StandardCode.HasValue) throw new Exception("Standard code not found. Is this a Framework?");

                var standardCode = dto.StandardCode.Value;
                var marketingInfo = dto.MarketingInformation;
                var url = dto.Url;

                var contactPhone = dto.ContactTelephone;
                var contactEmail = dto.ContactEmail;
                var contactWebsite = dto.ContactWebsite;

                var contact = new ApprenticeshipContact(contactPhone, contactEmail, contactWebsite);
                var locations = new List<ApprenticeshipLocation>();

                foreach (var loc in dto.ApprenticeshipLocations)
                    locations.Add(new ApprenticeshipLocation(loc.LocationId, loc.DeliveryModes, loc.Radius));

                var standard = new StandardExport(standardCode, marketingInfo, url, contact, locations);

                return standard;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}