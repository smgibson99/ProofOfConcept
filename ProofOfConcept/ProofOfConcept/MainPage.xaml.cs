using ProofOfConcept.Interfaces;
using ProofOfConcept.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProofOfConcept
{
    public partial class MainPage : ContentPage
    {
        //  protected readonly ISettings settings = ServiceContainer.Resolve<ISettings>();

        protected readonly ISettings settings = App.settings;

        public MainPage()
        {
            BindingContext = this;

            InitializeComponent();

            if (settings?.User?.UserId == null)
            {
                this.LblStatusMessage.Text = "Not Logged In Yet!";
                Navigation.PushAsync(new LoginPage());
                if (settings?.User?.UserId != null)
                {
                    this.callLogin.IsEnabled = false;
                    this.LblStatusMessage.Text = "Logged In";
                }
            }
        }

        async void OnLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            if (settings?.User?.UserId != null)
            {
                this.callLogin.IsEnabled = false;
                this.LblStatusMessage.Text = "Logged In";
            }
        }
    }
}
