using Dfc.ProviderPortal.FatProcessor.Domain.Models;

namespace Dfc.ProviderPortal.FatProcessor.UnitTests
{
    public static class ExampleContacts
    {
        public static Contact ContactA = new Contact("07890123456", "contacta@localhost", "https://localhost:8099/contacts/a");
        public static Contact ContactB = new Contact("01234 567 890", "contactb@localhost", "https://localhost:8099/contacts/b");
        public static Contact ContactC = new Contact("+44 9876 543210", "contactc@localhost", "https://localhost:8099/contacts/c");
    }
}