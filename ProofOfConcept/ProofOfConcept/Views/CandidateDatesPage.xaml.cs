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
    public partial class CandidateDatesPage : ContentPage
    {
        CandidateDateViewModel viewModel = new CandidateDateViewModel();
        Candidate _candidate = null;

        bool InSelect { get; set; } = false;

		public CandidateDatesPage()
		{
			InitializeComponent();

		}

        public CandidateDatesPage(Candidate candidate)
        {
            InitializeComponent();

            _candidate = candidate;

            BindingContext = viewModel;

            this.lblCandidateName.Text = candidate.CandidateName;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await LoadDataAsync(_candidate);
        }

		public async Task LoadDataAsync(Candidate candidate)
		{
			try
			{
                DateView.ItemsSource = await viewModel.GetCandidateDatesAsync(candidate);
                ErrorMessage.Text = "";
			}
			catch (Exception e)
			{
				ErrorMessage.Text = e.Message;
			}
		}

		public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var candidateDate = e.SelectedItem as CandidateDate;
			// call the candidate dates page

			DateView.SelectedItem = null;

			if (!InSelect)
			{
				InSelect = true;
				await Navigation.PushAsync(new UserDatePage(candidateDate));
				InSelect = false;
			}
		}

		public async void OnDelete(object sender, SelectedItemChangedEventArgs e)
		{
			var mi = ((MenuItem)sender);
			var candidateDate = mi.CommandParameter as CandidateDate;
			try
			{
                // deletes the candidate date and all its qualities
				await viewModel.DeleteCandidateDateAsync(candidateDate);
                DateView.ItemsSource = viewModel.CandidateDates;
				ErrorMessage.Text = "";
			}
			catch (Exception ex)
			{
				ErrorMessage.Text = ex.Message;
			}
		}
    }
}
