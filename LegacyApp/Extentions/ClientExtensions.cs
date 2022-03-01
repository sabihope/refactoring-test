using LegacyApp.Models;

namespace LegacyApp.Extentions
{
    internal static class ClientExtensions
    {
        public static bool HasCreditLimit(this Client client)
        {
            return client.Name != "VeryImportantClient";
        }

        public static int GetCreditFactor(this Client client)
        {
            return client.Name == "ImportantClient" ? 2 : 1;
        }
    }
}
