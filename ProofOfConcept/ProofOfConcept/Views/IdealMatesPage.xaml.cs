using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProofOfConcept.Models;
using ProofOfConcept.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProofOfConcept.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdealMatesPage : ContentPage
    {
		IdealMateViewModel viewModel = new IdealMateViewModel();

		bool InSelect { get; set; } = false;

        public IdealMatesPage()
        {
            InitializeComponent();

            BindingContext = viewModel;
            this.lblUserName.Text = App.settings.User.UserName;
        }

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await LoadDataAsync();
		}

		public async Task LoadDataAsync()
		{
			try
			{
                DateView.ItemsSource = await viewModel.GetIdealMatesAsync();
				ErrorMessage.Text = "";
			}
			catch (Exception e)
			{
				ErrorMessage.Text = e.Message;
			}
		}

		public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var idealMate = e.SelectedItem as IdealMate;
			// call the candidate dates page

			DateView.SelectedItem = null;

			if (!InSelect)
			{
				InSelect = true;
                await Navigation.PushAsync(new IdealMateDetailPage(idealMate));
				InSelect = false;
			}
		}

		public async void OnDelete(object sender, SelectedItemChangedEventArgs e)
		{
			var mi = ((MenuItem)sender);
            var idealMate = mi.CommandParameter as IdealMate;
			try
			{
                await viewModel.DeleteIdealMateAsync(idealMate);
                DateView.ItemsSource = viewModel.IdealMates;
				ErrorMessage.Text = "";
			}
			catch (Exception ex)
			{
				ErrorMessage.Text = ex.Message;
			}
		}
    }
}
