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
			GoHomeCommand = new Command(GoHomeAsync);
			GoLoginCommand = new Command(GoLoginAsync);
            GoLogoutCommand = new Command(GoLogoutAsync);
            GoUserSettingsCommand = new Command(GoUserSettingsAsync);
            GoIdealMatesCommand = new Command(GoIdealMatesAsync);
            GoMyDatesCommand = new Command(GoMyDatesAsync);
		}

		async void GoHomeAsync(object obj) {
			await App.NavigationPage.Navigation.PopToRootAsync();
			App.MenuIsPresented = false;
		}

		async void GoLoginAsync(object obj) {
            await App.NavigationPage.Navigation.PushAsync(new LoginPage());
			App.MenuIsPresented = false;
		}

		async void GoLogoutAsync(object obj)
		{
            await App.service.LogoutAsync();

            App.MenuPage.EnableLogin();

            App.HomePage.WelcomeMessage = "Not Logged In Yet!";
		}

		async void GoUserSettingsAsync(object obj)
		{
            await App.NavigationPage.Navigation.PushAsync(new UserSettingsPage());
			App.MenuIsPresented = false;
		}

		async void GoIdealMatesAsync(object obj)
		{
			await App.NavigationPage.Navigation.PushAsync(new IdealMatesPage());
			App.MenuIsPresented = false;
		}

        async void GoMyDatesAsync(object obj)
        {
            await App.NavigationPage.Navigation.PushAsync(new MyDatesPage());
            App.MenuIsPresented = false;
        }
	}
}

