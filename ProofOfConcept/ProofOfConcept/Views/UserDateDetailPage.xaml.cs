using System;
using System.Collections.Generic;
using ProofOfConcept.Models;
using ProofOfConcept.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProofOfConcept.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDateDetailPage : ContentPage
    {
		UserDateViewModel viewModel = new UserDateViewModel();
		bool isAdd = true;

        public UserDateDetailPage()
        {
            InitializeComponent();

            BindingContext = viewModel;
			this.title.Text = "New Candidate Date Quality";
			isAdd = true;
        }

        public UserDateDetailPage(string candidateName, DateTime dateOfDate)
		{
			InitializeComponent();

			BindingContext = viewModel;

			this.candidateName.Text = candidateName;
            this.dateOfDate.Text = String.Format("{0:MM/dd/yy}", dateOfDate);
			this.title.Text = "New Candidate Date Quality";
            this.candidateName.IsEnabled = false;
            this.dateOfDate.IsEnabled = false;
			isAdd = false;
		}

		public UserDateDetailPage(UserDate userDate)
		{
			InitializeComponent();

			BindingContext = viewModel;

            this.candidateName.Text = userDate.CandidateName;
            this.dateOfDate.Text = String.Format("{0:MM/dd/yy}",userDate.DateOfDate);
            this.qualityName.Text = userDate.QualityName;
            this.dateScore.Text = String.Format("{0}", userDate.DateScore);
			this.title.Text = "Update Candidate Date Quality";
			this.candidateName.IsEnabled = false;
			this.dateOfDate.IsEnabled = false;
			this.qualityName.IsEnabled = false;
			isAdd = false;
		}

		async void OnOk(object sender, EventArgs e)
		{
			try
			{
				if (isAdd)
					await viewModel.AddUserDateAsync();
				else
					await viewModel.UpdateUserDateAsync();
				await this.Navigation.PopAsync();
			}
			catch (Exception ex)
			{
				this.ErrorMessage.Text = ex.Message;
			}
		}
    }
}
