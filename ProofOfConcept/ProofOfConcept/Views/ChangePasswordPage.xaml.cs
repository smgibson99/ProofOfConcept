using System;
using System.Collections.Generic;
using ProofOfConcept.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProofOfConcept.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
		UserAccountViewModel viewModel = new UserAccountViewModel();

        public ChangePasswordPage()
        {
            InitializeComponent();

			BindingContext = viewModel;
        }

		async void OnOk(object sender, EventArgs e)
		{

			try
			{
                await viewModel.ChangePasswordAsync();
				await this.Navigation.PopAsync();
			}
			catch (Exception ex)
			{
				this.ErrorMessage.Text = ex.Message;
			}
		}
    }
}
