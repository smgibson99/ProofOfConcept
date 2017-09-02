using System;
using System.Collections.Generic;
using ProofOfConcept.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProofOfConcept.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
		private RegisterViewModel viewModel = null;

        public RegisterPage()
        {
            InitializeComponent();

			viewModel = new RegisterViewModel();

			BindingContext = viewModel;
        }

		async void OnOk(object sender, EventArgs e)
		{
			try
			{
                await viewModel.Register();
                await this.Navigation.PopAsync();
			}
			catch (Exception ex)
			{
				this.ErrorMessage.Text = ex.Message;
            }
		}
    }
}
