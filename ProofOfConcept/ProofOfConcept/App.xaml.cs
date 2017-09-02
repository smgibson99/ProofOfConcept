using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

using Xamarin.Forms;
using ProofOfConcept.Views;
using ProofOfConcept.Interfaces;
using ProofOfConcept.Fakes;

namespace ProofOfConcept
{
    public partial class App : Application
    {
        // setup fakes
        public static ISettings settings = new FakeSettings();
        public static IWebService service = new FakeWebService();

		public static NavigationPage NavigationPage { get; private set; }
        public static HomePage HomePage;
		public static RootPage RootPage;
        public static MenuPage MenuPage;
		public static bool MenuIsPresented
		{
			get
			{
				return RootPage.IsPresented;
			}
			set
			{
				RootPage.IsPresented = value;
			}
		}

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new ProofOfConcept.MainPage());
            MenuPage = new MenuPage();
            HomePage = new HomePage();
            NavigationPage = new NavigationPage(HomePage);
			RootPage = new RootPage();
			RootPage.Master = MenuPage;
			RootPage.Detail = NavigationPage;
            if (settings?.User == null)
                
			MainPage = RootPage;
        }

        protected override void OnStart()
        {

            // Handle when your app starts
            MobileCenter.Start("ios=e1357532-cf71-48e0-ab94-fecc38e25174;",typeof(Analytics),typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
