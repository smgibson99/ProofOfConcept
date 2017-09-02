using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProofOfConcept.ViewModels
{
    public class UserDateViewModel : BaseViewModel
    {
        private ObservableCollection<UserDate> _userDates = new ObservableCollection<UserDate>();
        public ObservableCollection<UserDate> UserDates
        {
            get { return _userDates; }
            set 
            {
                _userDates = value;
                OnPropertyChanged(nameof(UserDates));

            }
        }

        private ObservableCollection<Candidate> _candidates = new ObservableCollection<Candidate>();
        public ObservableCollection<Candidate> Candidates 
        { 
            get { return _candidates; } 
            set
            {
                _candidates = value;
                OnPropertyChanged(nameof(Candidates));
            }
        }

        private ObservableCollection<Quality> _qualitities = new ObservableCollection<Quality>();
        public ObservableCollection<Quality> Qualities
        {
            get { return _qualitities; }
            set 
            {
                _qualitities = value;
                OnPropertyChanged(nameof(Qualities));
            }
        }

        public string CandidateName { get; set; }
        public DateTime DateOfDate { get; set; }
        public string QualityName { get; set; }
        public int DateScore { get; set; }
        public string AdviceGiven { get; set; }

        public async Task<ObservableCollection<UserDate>> GetUserDates()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                UserDates = await service.GetUserDates(settings.User.UserId);
            }
            finally
            {
                IsBusy = false;
            }
            return UserDates;
        }

        public async Task<ObservableCollection<Candidate>> GetCandidates()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                Candidates = await service.GetCandidates(settings.User.UserId);
            }
            finally
            {
                IsBusy = false;
            }
            return Candidates;
        }

        public async Task<ObservableCollection<Quality>> GetQualities()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                Qualities = await service.GetQualities();
            }
            finally
            {
                IsBusy = false;
            }
            return Qualities;
        }

        public async Task AddUserDate()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            if (string.IsNullOrEmpty(CandidateName))
                throw new Exception("Candidate Name is blank.");

            if (DateOfDate == null)
                throw new Exception("Date of Date must be specified");

            if (string.IsNullOrEmpty(QualityName))
                throw new Exception("Quality Name is blank");

            if (DateScore < 0 || DateScore > 10)
                throw new Exception("Date Score must be between 0 and 10");

            IsBusy = true;

            try
            {
                var userdate= await service.AddUserDate(new UserDate { UserId = settings.User.UserId, CandidateName = CandidateName, DateOfDate = DateOfDate, QualityName = QualityName, DateScore = DateScore });

                // update our local list of user dates
                var userdates = new List<UserDate>();
                if (UserDates != null)
                    userdates.AddRange(UserDates);
                userdates.Add(userdate);

                UserDates = new ObservableCollection<UserDate>(userdates.OrderBy(c => c.CandidateName).ThenByDescending(c => c.DateOfDate).ThenBy(c => c.QualityName));
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
					await GetUserDates();
					IsRefreshing = false;
				});
			}
		}

    }
}
