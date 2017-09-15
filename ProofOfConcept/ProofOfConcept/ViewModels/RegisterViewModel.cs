using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password
        { get; set; }

        public string ConfirmPassword { get; set; }

        public async Task RegisterAsync()
        {
            if (string.IsNullOrEmpty(UserId))
                throw new Exception("UserId is blank.");

            if (string.IsNullOrEmpty(UserName))
                throw new Exception("User's name is blank.");

            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password is blank.");

            if (Password != ConfirmPassword)
                throw new Exception("Passwords don't match.");

            IsBusy = true;
            try
            {
                settings.User = await service.RegisterAsync(new User { UserId = UserId, UserName = UserName, Password = Password, UserEmail = UserEmail, AccessLevel = 1 });
                settings.Save();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
