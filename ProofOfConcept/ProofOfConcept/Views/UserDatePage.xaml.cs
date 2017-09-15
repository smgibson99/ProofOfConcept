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
    public partial class UserDatePage : ContentPage
    {
		UserDateViewModel viewModel = new UserDateViewModel();
		bool InSelect { get; set; } = false;
        CandidateDate _candidateDate = null;

        //generic ctor
        public UserDatePage()
        {
            InitializeComponent();
        }

        //specific cstor
        public UserDatePage(CandidateDate candidateDate)
        {
            InitializeComponent();

            BindingContext = viewModel;
            this.lblCandidateName.Text = candidateDate.CandidateName;
            this.lblDateOfDate.Text = String.Format("{0:MM/dd/yy}",candidateDate.DateOfDate);
            _candidateDate = candidateDate;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await LoadDataAsync(_candidateDate);

        }

		public async Task LoadDataAsync(CandidateDate candidateDate)
		{
			try
			{
                DateView.ItemsSource = await viewModel.GetUserDateDetailsAsync(candidateDate.CandidateName, candidateDate.DateOfDate);
				ErrorMessage.Text = "";
			}
			catch (Exception e)
			{
				ErrorMessage.Text = e.Message;
			}
		}

		public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var userDate = e.SelectedItem as UserDate;
			
			DateView.SelectedItem = null;

			if (!InSelect)
			{
				InSelect = true;
				await Navigation.PushAsync(new UserDateDetailPage(userDate));
				InSelect = false;
			}
		}

		public async void OnDelete(object sender, SelectedItemChangedEventArgs e)
		{
			var mi = ((MenuItem)sender);
			var userDate = mi.CommandParameter as UserDate;
			try
			{
                await viewModel.DeleteUserDateAsync(userDate);
                DateView.ItemsSource = viewModel.UserDates;
				ErrorMessage.Text = "";
			}
			catch (Exception ex)
			{
				ErrorMessage.Text = ex.Message;
			}
		}
    }
}
