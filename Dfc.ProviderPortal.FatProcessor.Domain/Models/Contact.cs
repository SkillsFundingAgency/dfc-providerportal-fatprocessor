namespace Dfc.ProviderPortal.FatProcessor.Domain.Models
{
    public class Contact
    {
        public Contact(string phone, string email, string url)
        {
            Phone = phone;
            Email = email;
            Url = url;
        }

        public string Phone { get; }
        public string Email { get; }
        public string Url { get; }
    }
}