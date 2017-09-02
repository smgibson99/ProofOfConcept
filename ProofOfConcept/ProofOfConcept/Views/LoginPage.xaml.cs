using ProofOfConcept.Interfaces;
using ProofOfConcept.Models;
using ProofOfConcept.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProofOfConcept.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        private LoginViewModel viewModel = null;

        public LoginPage()
        {
            InitializeComponent();

            viewModel = new LoginViewModel();

            BindingContext = viewModel;

      //      settings.User = new User { UserId = "steve99", UserName = "Steve Gibson", Password = "Colt45" };
            
        }

        async void OnLogin(object sender, EventArgs e)
        {
            try
            {
                await viewModel.Login();

                if (App.settings?.User != null)
                {
                    App.HomePage.WelcomeMessage = "Welcome, " + App.settings.User.UserName + "!";
					App.MenuPage.DisableLogin();
                    await App.HomePage.LoadData();
                } else
                    App.HomePage.WelcomeMessage = "Not Logged In Yet!";

                await this.Navigation.PopToRootAsync();
            } catch (Exception ex)
            {
                this.ErrorMessage.Text = ex.Message;
            }
        }

        async void OnRegister(object sender, EventArgs e)
        {
            App.settings.User = null;
            await this.Navigation.PushAsync(new RegisterPage());
        }

        protected override async void OnAppearing()
        {
            if (App.settings?.User != null)
            {
				App.HomePage.WelcomeMessage = "Welcome, " + App.settings.User.UserName + "!";
				App.MenuPage.DisableLogin();
				await App.HomePage.LoadData();
				await this.Navigation.PopAsync();
            } else
				App.HomePage.WelcomeMessage = "Not Logged In Yet!";

        }
    }
}