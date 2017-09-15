using System;
using System.Collections.Generic;
using ProofOfConcept.ViewModels;

using Xamarin.Forms;

namespace ProofOfConcept.Views {
	public partial class MenuPage : ContentPage {
		public MenuPage() {
			BindingContext = new MenuPageViewModel();
			Title = "Menu";
			InitializeComponent();
		}

		public void DisableLogin()
		{
            //	this.btnLogin.IsEnabled = false;
            this.btnLogin.IsVisible = false;
            this.btnLogout.IsVisible = true;
            this.btnUserSettings.IsVisible = true;
            this.btnMyDates.IsVisible = true;
            this.btnIdealMates.IsVisible = true;
		}

        public void EnableLogin()
        {
            this.btnLogin.IsVisible = true;
            this.btnLogout.IsVisible = false;
            this.btnUserSettings.IsVisible = false;
            this.btnIdealMates.IsVisible = false;
            this.btnMyDates.IsVisible = false;
        }
	}
}

