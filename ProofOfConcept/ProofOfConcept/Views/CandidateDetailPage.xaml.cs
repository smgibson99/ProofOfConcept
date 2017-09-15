using System;
using System.Collections.Generic;
using ProofOfConcept.Models;
using ProofOfConcept.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProofOfConcept.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CandidateDetailPage : ContentPage
    {
        CandidateViewModel viewModel = new CandidateViewModel();
		bool isAdd = true;

		public CandidateDetailPage()
		{
			InitializeComponent();

			BindingContext = viewModel;
			this.title.Text = "New Date";
            this.lastDate.Date = DateTime.Now;
			isAdd = true;
		}

        public CandidateDetailPage(Candidate candidate)
        {
            InitializeComponent();

            BindingContext = viewModel;

            this.candidateName.Text = candidate.CandidateName;
            this.lastDate.Date = candidate.LastDate;
            this.dateScore.Text = String.Format("{0}", candidate.DateScore);
			this.title.Text = "Update Date";
            this.candidateName.IsEnabled = false;
			isAdd = false;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

		async void OnOk(object sender, EventArgs e)
		{
			try
			{
                if (isAdd)
                    await viewModel.AddCandidateAsync();
                else
                {
                    await viewModel.UpdateCandidateAsync();
                }
				await this.Navigation.PopAsync();
			}
			catch (Exception ex)
			{
				this.ErrorMessage.Text = ex.Message;
			}
		}
    }
}
