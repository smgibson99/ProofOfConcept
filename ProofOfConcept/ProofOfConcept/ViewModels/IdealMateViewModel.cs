using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProofOfConcept.ViewModels
{
    public class IdealMateViewModel : BaseViewModel
    {
        private ObservableCollection<IdealMate> _idealmates = new ObservableCollection<IdealMate>();
        public ObservableCollection<IdealMate> IdealMates
		{
			get { return _idealmates; }
			set
			{
                _idealmates = value;
                OnPropertyChanged(nameof(IdealMates));

			}
		}

        public string QualityName { get; set; }
        public int ScoreValue { get; set; }

        public async Task<ObservableCollection<IdealMate>> GetIdealMates()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                IdealMates = await service.GetIdealMates(settings.User.UserId);
            }
            finally
            {
                IsBusy = false;
            }
            return IdealMates;
        }

        public async Task AddIdealMate()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            if (string.IsNullOrEmpty(QualityName))
                throw new Exception("Quality Name is blank.");

            if (ScoreValue < 0 || ScoreValue > 10)
            {
                throw new Exception("Score Value must be in range 0 to 10");
            }

            IsBusy = true;
            try
            {
                var idealmate = await service.AddIdealMate(new IdealMate { UserId = settings.User.UserId, QualityName = QualityName, ScoreValue = ScoreValue});

                // update our local list of candidates
                var idealmates = new List<IdealMate>();
                if (IdealMates != null)
                    idealmates.AddRange(IdealMates);
                idealmates.Add(idealmate);

                IdealMates = new ObservableCollection<IdealMate>(idealmates.OrderBy(c => c.QualityName));
            }
            finally
            {
                IsBusy = false;
            }
        }

		//TODO: Add other operations

		public ICommand RefreshCommand
		{
			get
			{
				return new Command(async () =>
				{
					IsRefreshing = true;
                    await GetIdealMates();
					IsRefreshing = false;
				});
			}
		}
    }
}
