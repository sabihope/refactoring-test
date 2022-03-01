using LegacyApp.Models;

namespace LegacyApp.Extentions
{
    internal static class UserExtensions
    {
        public static int GetCreditLimit(this User user, int creditFactor = 1)
        {
            using var userCreditService = new UserCreditServiceClient();

            return userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth) * creditFactor;
        }

        public static bool IsCreditValid(this User user)
        {
            return !user.HasCreditLimit || user.CreditLimit >= 500;
        }
    }
}
