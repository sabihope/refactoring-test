using LegacyApp.Extentions;
using LegacyApp.Repositories;
using System;

namespace LegacyApp
{
    public class UserService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Keep non static for backward compatibility")]
        public bool AddUser(string firstname, string surname, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(surname))
            {
                return false;
            }

            if (!email.IsValidEmail())
            {
                return false;
            }

            if (!dateOfBirth.HasMinimalAge())
            {
                return false;
            }

            var client = ClientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                Firstname = firstname,
                Surname = surname,
                HasCreditLimit = client.HasCreditLimit()
            };

            user.CreditLimit = user.GetCreditLimit(client.GetCreditFactor());

            if (user.IsCreditValid())
            {
                return false;
            }
            
            UserDataAccess.AddUser(user);

            return true;
        }
    }
}