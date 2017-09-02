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

			if (App.settings?.User == null)
			{
                DisplayLogin();
            } else
            {
                // load the data for the view
               LoadData();
            }

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // load the view

            viewModel = new CandidateViewModel();

			
            try
            {
                DateView.ItemsSource = await viewModel.GetCandidates();
            } catch (Exception e)
            {
                // do nothing
            }
			
        }

        async Task OnDisappearing(object sender, EventArgs e)
        {
            
        }

        async Task DisplayLogin()
        {
            await Navigation.PushAsync(new LoginPage());
            await LoadData();
        }

        public async Task LoadData()
        {
			try
			{
                DateView.ItemsSource = await viewModel.GetCandidates();
			}
			catch (Exception e)
			{
				// no processing
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
            // call the candidate detail page

            DateView.SelectedItem = null;
        }

		public async void OnDelete(object sender, SelectedItemChangedEventArgs e)
		{
			var mi = ((MenuItem)sender);
            var candidate = mi.CommandParameter as Candidate;
           // await viewModel.DeleteCandidate(candidate);
			// call the candidate detail function
		}
    }
}

