using System;
using System.Collections.Generic;
using ProofOfConcept.Models;
using ProofOfConcept.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProofOfConcept.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdealMateDetailPage : ContentPage
    {
        //IdealMate _idealMate = null;
        IdealMateViewModel viewModel = null;
        bool isAdd = true;

        public IdealMateDetailPage()
        {
            InitializeComponent();
			viewModel = new IdealMateViewModel();

			BindingContext = viewModel;
            this.title.Text = "New Ideal Mate Quality";
            isAdd = true;

        }

        public IdealMateDetailPage(IdealMate idealMate)
        {
            InitializeComponent();

            viewModel = new IdealMateViewModel();
            BindingContext = viewModel;

            this.qualityName.Text = idealMate.QualityName;
            this.scoreValue.Text = String.Format("{0}",idealMate.ScoreValue);
            this.title.Text = "Update Ideal Mate Quality";
            this.qualityName.IsEnabled = false;
            isAdd = false;

        }

		async void OnOk(object sender, EventArgs e)
		{
			try
			{
                if (isAdd)
                    await viewModel.AddIdealMateAsync();
                else
                    await viewModel.UpdateIdealMateAsync();
				await this.Navigation.PopAsync();
			}
			catch (Exception ex)
			{
				this.ErrorMessage.Text = ex.Message;
			}
		}
    }
}
