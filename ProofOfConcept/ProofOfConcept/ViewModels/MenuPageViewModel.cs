using System;
using System.Windows.Input;
using Xamarin.Forms;
using ProofOfConcept.Views;

namespace ProofOfConcept.ViewModels {
	public class MenuPageViewModel {

		public ICommand GoHomeCommand { get; set; }
		public ICommand GoLoginCommand { get; set; }
        public ICommand GoLogoutCommand { get; set; }
        public ICommand GoIdealMatesCommand { get; set; }
        public ICommand GoUserSettingsCommand { get; set; }
        public ICommand GoMyDatesCommand { get; set; }

		public MenuPageViewModel() {
			GoHomeCommand = new Command(GoHome);
			GoLoginCommand = new Command(GoLogin);
            GoLogoutCommand = new Command(GoLogout);
            GoUserSettingsCommand = new Command(GoUserSettings);
            GoIdealMatesCommand = new Command(GoIdealMates);
            GoMyDatesCommand = new Command(GoMyDates);
		}

		async void GoHome(object obj) {
			await App.NavigationPage.Navigation.PopToRootAsync();
			App.MenuIsPresented = false;
		}

		async void GoLogin(object obj) {
            await App.NavigationPage.Navigation.PushAsync(new LoginPage());
			App.MenuIsPresented = false;
		}

		async void GoLogout(object obj)
		{
            await App.service.Logout();

            App.MenuPage.EnableLogin();

            App.HomePage.WelcomeMessage = "Not Logged In Yet!";
		}

		async void GoUserSettings(object obj)
		{
            await App.NavigationPage.Navigation.PushAsync(new UserSettingsPage());
			App.MenuIsPresented = false;
		}

		async void GoIdealMates(object obj)
		{
		//	App.NavigationPage.Navigation.PushAsync(new IdealMatesPage());
			App.MenuIsPresented = false;
		}

        async void GoMyDates(object obj)
        {
            // App.NavigationPage.Navigation.PushAsync(new UserDates());
            App.MenuIsPresented = false;
        }
	}
}

