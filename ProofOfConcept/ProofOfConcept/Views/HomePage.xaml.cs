using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProofOfConcept.Models;
using ProofOfConcept.ViewModels;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ProofOfConcept.Views {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        Config configuration { get; set; }
        bool InSelect { get; set; } = false;

        CandidateViewModel viewModel = new CandidateViewModel();
       

        public string WelcomeMessage 
        {
            get { return this.lblWelcomeMessage.Text; }
            set { this.lblWelcomeMessage.Text = value; }
        }

        public HomePage()
        {
            InitializeComponent();

            BindingContext = viewModel;

			

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // load the viewdata
            ErrorMessage.Text = "";
			
            try
            {
				if (App.settings?.User == null)
				{
					await DisplayLoginAsync();
				}
				else
				{
					// load the data for the view
					await LoadDataAsync();
				}
                DateView.ItemsSource = await viewModel.GetCandidatesWithDatesAsync();

            } catch (Exception e)
            {
                ErrorMessage.Text = e.Message;
            }
			
        }


        async Task DisplayLoginAsync()
        {
            await Navigation.PushAsync(new LoginPage());
            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
			try
			{
                DateView.ItemsSource = await viewModel.GetCandidatesWithDatesAsync();
                ErrorMessage.Text = "";
			}
			catch (Exception e)
			{
                ErrorMessage.Text = e.Message;
			}
        }

        public void ClearList()
        {
            viewModel.Candidates.Clear();

            DateView.ItemsSource = null;
        }

        public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var candidate = e.SelectedItem as Candidate;
            // call the candidate dates page

            DateView.SelectedItem = null;

            if (!InSelect)
            {
                InSelect = true;
                ErrorMessage.Text = "";
                await Navigation.PushAsync(new CandidateDatesPage(candidate));
                InSelect = false;
            }
        }

		public async void OnNew(object sender, SelectedItemChangedEventArgs e)
		{
			ErrorMessage.Text = "";
			try
			{
				await Navigation.PushAsync(new CandidateDetailPage());
				ErrorMessage.Text = "";
			}
			catch (Exception ex)
			{
				ErrorMessage.Text = ex.Message;
			}
		}

		public async void OnEdit(object sender, SelectedItemChangedEventArgs e)
		{
			var mi = ((MenuItem)sender);
			var candidate = mi.CommandParameter as Candidate;
			ErrorMessage.Text = "";
			try
			{
                await Navigation.PushAsync(new CandidateDetailPage(candidate));
				ErrorMessage.Text = "";
			}
			catch (Exception ex)
			{
				ErrorMessage.Text = ex.Message;
			}
		}

		public async void OnDelete(object sender, SelectedItemChangedEventArgs e)
		{
			var mi = ((MenuItem)sender);
            var candidate = mi.CommandParameter as Candidate;
            ErrorMessage.Text = "";
            try
            {
                await viewModel.DeleteCandidateAsync(candidate);
                ErrorMessage.Text = "";
            } catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
		}
    }
}

