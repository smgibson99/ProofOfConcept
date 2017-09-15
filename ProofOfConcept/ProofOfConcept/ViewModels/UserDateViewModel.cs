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

        // get all the user date records in database
        public async Task<ObservableCollection<UserDate>> GetUserDatesAsync()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                UserDates = await service.GetUserDatesAsync(settings.User.UserId);
            }
            finally
            {
                IsBusy = false;
            }
            return UserDates;
        }

        //get the user dates for only the specified candidate
        public async Task<ObservableCollection<UserDate>> GetUserDatesAsync(Candidate candidate)
		{
			if (settings.User == null)
			{
				throw new Exception("Not logged in.");
			}

            UserDates.Clear();

			IsBusy = true;
			try
			{
                var dates = await service.GetUserDatesAsync(settings.User.UserId);
                if (dates.Count() > 0)
                {
                    UserDates = new ObservableCollection<UserDate>(dates.Where(r => r.CandidateName.Equals(candidate.CandidateName)).OrderBy(c => c.CandidateName).ThenByDescending(c => c.DateOfDate).ThenBy(c => c.QualityName));
                }
			}
			finally
			{
				IsBusy = false;
			}
			return UserDates;
		}

		//get the user dates for only the specified candidate
        public async Task<ObservableCollection<UserDate>> GetUserDateDetailsAsync(string CandidateName, DateTime DateOfDate)
		{
			if (settings.User == null)
			{
				throw new Exception("Not logged in.");
			}

            UserDates.Clear();

			IsBusy = true;
			try
			{
				var dates = await service.GetUserDatesAsync(settings.User.UserId);
				if (dates.Count() > 0)
				{
                    UserDates = new ObservableCollection<UserDate>(dates.Where(r => r.CandidateName.Equals(CandidateName) && r.DateOfDate.Equals(DateOfDate)).OrderBy(c => c.QualityName));
				}
			}
			finally
			{
				IsBusy = false;
			}
			return UserDates;
		}

        public async Task<ObservableCollection<Candidate>> GetCandidatesAsync()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            Candidates.Clear();

            IsBusy = true;
            try
            {
                Candidates = await service.GetCandidatesAsync(settings.User.UserId);
            }
            finally
            {
                IsBusy = false;
            }
            return Candidates;
        }

        public async Task<ObservableCollection<Quality>> GetQualitiesAsync()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            Qualities.Clear();

            IsBusy = true;
            try
            {
                Qualities = await service.GetQualitiesAsync();
            }
            finally
            {
                IsBusy = false;
            }
            return Qualities;
        }

        public async Task AddUserDateAsync()
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
                var userdate= await service.AddUserDateAsync(new UserDate { UserId = settings.User.UserId, CandidateName = CandidateName, DateOfDate = DateOfDate, QualityName = QualityName, DateScore = DateScore });

                // update our local list of user dates
                var userdates = new List<UserDate>();
                if (UserDates != null)
                    userdates.AddRange(UserDates);
                userdates.Add(userdate);

                //return user dates detail in the collection
                UserDates = new ObservableCollection<UserDate>(userdates.OrderBy(c => c.CandidateName).ThenByDescending(c => c.DateOfDate).ThenBy(c => c.QualityName));
            }
            finally
            {
                IsBusy = false;
            }
        }

		public async Task UpdateUserDateAsync()
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
                UserDate userDate = new UserDate { UserId = settings.User.UserId, CandidateName = CandidateName, DateOfDate = DateOfDate, QualityName = QualityName, DateScore = DateScore };
				var result = await service.UpdateUserDateAsync(userDate);

                if (result)
                {
                    // update our local list of user dates detail
                   
                    await GetUserDateDetailsAsync(CandidateName, DateOfDate);
                }
			}
			finally
			{
				IsBusy = false;
			}
		}


		//TODO: Add other operations

        public async Task<bool> DeleteUserDateAsync(UserDate userDate)
		{
			bool result = false;

			if (settings.User == null)
			{
				throw new Exception("Not logged in.");
			}

            if (userDate == null)
				return result;

			IsBusy = true;
			try
			{
				result = await service.RemoveUserDateAsync(userDate);
                await GetUserDateDetailsAsync(userDate.CandidateName, userDate.DateOfDate);
			}
			finally
			{
				IsBusy = false;
			}

			return result;
		}

		public ICommand RefreshCommand
		{
			get
			{
				return new Command(async () =>
				{
					IsRefreshing = true;
					await GetUserDatesAsync();
					IsRefreshing = false;
				});
			}
		}

    }
}
