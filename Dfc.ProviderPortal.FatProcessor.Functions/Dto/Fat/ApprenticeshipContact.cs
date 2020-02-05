using System.Text.Json.Serialization;

namespace Dfc.ProviderPortal.FatProcessor.Functions.Dto.Fat
{
    public class ApprenticeshipContact
    {
        public ApprenticeshipContact(string phone, string email, string url)
        {
            Phone = phone;
            Email = email;
            Url = url;
        }

        [JsonPropertyName("phone")] public string Phone { get; }
        [JsonPropertyName("email")] public string Email { get; }
        [JsonPropertyName("contactUsUrl")] public string Url { get; }
    }
}