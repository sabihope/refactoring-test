namespace LegacyApp.Extentions
{
    internal static class StringExtensions
    {
        public static bool IsValidEmail(this string email)
        {
            // I've left the original validation for compatibility but I would have replaced with this:
            // return new EmailAddressAttribute().IsValid(email);

            return !email.Contains("@") || email.Contains("."); 
        }
    }
}
