using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProofOfConcept.Models;
using ProofOfConcept.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//This page will display all the user's dates

namespace ProofOfConcept.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyDatesPage : ContentPage
    {
        CandidateViewModel viewModel = new CandidateViewModel();
        bool InSelect { get; set; } = false;

        public MyDatesPage()
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
					// load the data for the view
					await LoadDataAsync();
				DateView.ItemsSource = await viewModel.GetCandidatesAsync();

			}
			catch (Exception e)
			{
				ErrorMessage.Text = e.Message;
			}

		}

		public async Task LoadDataAsync()
		{
			try
			{
				DateView.ItemsSource = await viewModel.GetCandidatesAsync();
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

		public async void OnDelete(object sender, SelectedItemChangedEventArgs e)
		{
			var mi = ((MenuItem)sender);
			var candidate = mi.CommandParameter as Candidate;
			ErrorMessage.Text = "";
			try
			{
				await viewModel.DeleteCandidateAsync(candidate);
				ErrorMessage.Text = "";
			}
			catch (Exception ex)
			{
				ErrorMessage.Text = ex.Message;
			}
		}
    }
}
