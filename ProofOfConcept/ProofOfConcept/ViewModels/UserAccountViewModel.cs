using System;
using System.Threading.Tasks;

namespace ProofOfConcept.ViewModels
{
    public class UserAccountViewModel : BaseViewModel
    {

		public string UserId { get; set; }
		public string UserName { get; set; }
		public string UserEmail { get; set; }
		public string OldPassword { get; set; }
        public string NewPassword { get; set; }
		public string ConfirmPassword { get; set; }

        public UserAccountViewModel()
        {
            if (settings?.User != null)
            {
                UserId = settings.User.UserId;
                UserName = settings.User.UserName;
                UserEmail = settings.User.UserEmail;
            }
        }

        public async Task UpdateUserAsync()
        {
			if (string.IsNullOrEmpty(UserId))
				throw new Exception("UserId is blank.");

			if (string.IsNullOrEmpty(UserName))
				throw new Exception("User's name is blank.");

			IsBusy = true;

			try
			{
                settings.User.UserName = UserName;
                settings.User.UserEmail = UserEmail;

                bool result = await service.UpdateUserAsync(settings.User);
				settings.Save();
			}
			finally
			{
				IsBusy = false;
			}
        }

        public async Task ChangePasswordAsync()
		{
			if (string.IsNullOrEmpty(UserId))
				throw new Exception("UserId is blank.");

			if (string.IsNullOrEmpty(OldPassword))
				throw new Exception("Old Password is blank.");

			if (string.IsNullOrEmpty(NewPassword))
				throw new Exception("New Password is blank.");
            
			if (NewPassword != ConfirmPassword)
				throw new Exception("Passwords don't match.");

            IsBusy = true;

            try
            {
                bool result = await service.ChangePasswordAsync(UserId, OldPassword, NewPassword);
                settings.Save();
            } finally
            {
                IsBusy = false;
            }

		}
    }
}
