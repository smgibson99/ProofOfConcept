using ProofOfConcept.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProofOfConcept.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
		// protected readonly IWebService service = ServiceContainer.Resolve<IWebService>();
		//  protected readonly ISettings settings = ServiceContainer.Resolve<ISettings>();

		private bool _isRefreshing = false;
		public bool IsRefreshing
		{
			get { return _isRefreshing; }
			set
			{
				_isRefreshing = value;
				OnPropertyChanged(nameof(IsRefreshing));
			}
		}

        protected readonly IWebService service = App.service;
        protected readonly ISettings settings = App.settings;

        public event EventHandler IsBusyChanged = delegate { };

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                IsBusyChanged(this, EventArgs.Empty);
            }
        }

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
    }
}
