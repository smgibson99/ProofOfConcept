using System;
using System.Collections.Generic;
using ProofOfConcept.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProofOfConcept.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSettingsPage : ContentPage
    {
        UserAccountViewModel viewModel = new UserAccountViewModel();

        public UserSettingsPage()
        {
            InitializeComponent();

            BindingContext = viewModel;

        }

        async void OnOk(object sender, EventArgs e)
        {
            
			try
			{
                await viewModel.UpdateUserAsync();
				await this.Navigation.PopAsync();
			}
			catch (Exception ex)
			{
				this.ErrorMessage.Text = ex.Message;
			}
        }

        async void OnChangePassword(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new ChangePasswordPage());
        }
    }
}
