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
        UserDateViewModel viewModel = new UserDateViewModel();

        public CandidateDetailPage(Candidate candidate)
        {
            InitializeComponent();
        }
    }
}
