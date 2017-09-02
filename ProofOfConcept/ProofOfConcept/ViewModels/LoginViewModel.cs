using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public async Task Login()
        {
            if (string.IsNullOrEmpty(UserId))
                throw new Exception("UserId is blank.");
            
            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password is blank.");

            IsBusy = true;
            try
            {
                settings.User = await service.Login(UserId, Password);
                if (settings?.User == null)
                    throw new Exception("User Not Found!");
                settings.Save();
            } 
            finally
            {
                IsBusy = false;
            }
        }
    }
}
