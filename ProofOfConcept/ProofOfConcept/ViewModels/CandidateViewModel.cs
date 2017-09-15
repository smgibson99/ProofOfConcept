using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProofOfConcept.ViewModels
{
    public class CandidateViewModel : BaseViewModel
    {
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

		
        public string CandidateName {get; set;}
        public DateTime LastDate { get; set; }
        public int DateScore { get; set; }

        public async Task<ObservableCollection<Candidate>> GetCandidatesAsync()
        {
            if (settings?.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                var allcandidates = await service.GetCandidatesAsync(settings.User.UserId);
                var sortedcandidates = new ObservableCollection<Candidate>(allcandidates.OrderByDescending(r => r.LastDate).ThenBy(r => r.CandidateName));
                Candidates = sortedcandidates;
            } finally
            {
                IsBusy = false;
            }
            return Candidates;
        }

		public async Task<ObservableCollection<Candidate>> GetCandidatesWithDatesAsync(int max = 5)
		{
            
			if (settings?.User == null)
			{
				throw new Exception("Not logged in.");
			}

			IsBusy = true;
			try
			{
				var allCandidates = await service.GetCandidatesAsync(settings.User.UserId);
                //sort by lastdate desc, candidateName
                var candidates = new ObservableCollection<Candidate>(allCandidates.OrderByDescending(r => r.LastDate).ThenBy(r => r.CandidateName));
                Candidates.Clear();
                int count = 0;
                foreach (var candidate in candidates)
                {
                    if (candidate.LastDate != null)
                    {
                        Candidates.Add(candidate);
                        count++;
                    }
                    if (count == max)
                        break;
                }
			}
			finally
			{
				IsBusy = false;
			}
			return Candidates;
		}

        public async Task AddCandidateAsync()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            if (string.IsNullOrEmpty(CandidateName))
                throw new Exception("Candidate Name is blank.");

			if (DateScore < 0 || DateScore > 10)
			{
				throw new Exception("Date Score Value must be in range 0 to 10");
			}

			
            IsBusy = true;
            try
            {
                var candidate = await service.AddCandidateAsync(new Candidate { UserId = settings.User.UserId, CandidateName = CandidateName, DateScore = DateScore, LastDate = LastDate });

                // update our local list of candidates
                var candidates = new List<Candidate>();
                if (Candidates != null)
                    candidates.AddRange(Candidates);
                candidates.Add(candidate);

                Candidates = new ObservableCollection<Candidate>(candidates.OrderByDescending(c => c.LastDate).ThenBy(c => c.CandidateName));
            }
            finally
            {
                IsBusy = false;
            }
        }

		//TODO: Add other operations

		public async Task UpdateCandidateAsync()
		{
			if (settings.User == null)
			{
				throw new Exception("Not logged in.");
			}

			if (string.IsNullOrEmpty(CandidateName))
				throw new Exception("Candidate Name is blank.");

			if (DateScore < 0 || DateScore > 10)
			{
				throw new Exception("Date Score Value must be in range 0 to 10");
			}

			IsBusy = true;
			try
			{
                Candidate candidate = new Candidate { UserId = settings.User.UserId, CandidateName = CandidateName, LastDate=LastDate, DateScore = DateScore };

                var result = await service.UpdateCandidateAsync(candidate);

				if (result)
				{
					await GetCandidatesWithDatesAsync();
				}
			}
			finally
			{
				IsBusy = false;
			}
		}


		public async Task<bool> DeleteCandidateAsync(Candidate candidate)
        {
            bool result = false;

			if (settings.User == null)
			{
				throw new Exception("Not logged in.");
			}

            if (candidate == null)
                return result;

            IsBusy = true;
            try
            {
                result = await service.RemoveCandidateAsync(candidate);
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
                    try
                    {
                        await GetCandidatesAsync();
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        IsRefreshing = false;
                    }
				});
			}
		}
    }
}
