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

        public async Task<ObservableCollection<Candidate>> GetCandidates()
        {
            if (settings?.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                Candidates = await service.GetCandidates(settings.User.UserId);
            } finally
            {
                IsBusy = false;
            }
            return Candidates;
        }

        public async Task AddCandidate()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            if (string.IsNullOrEmpty(CandidateName))
                throw new Exception("Candidate Name is blank.");

            IsBusy = true;
            try
            {
                var candidate = await service.AddCandidate(new Candidate { UserId = settings.User.UserId, CandidateName = CandidateName, DateScore = DateScore, LastDate = LastDate });

                // update our local list of candidates
                var candidates = new List<Candidate>();
                if (Candidates != null)
                    candidates.AddRange(Candidates);
                candidates.Add(candidate);

                Candidates = new ObservableCollection<Candidate>(candidates.OrderBy(c => c.CandidateName));
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
                    try
                    {
                        await GetCandidates();
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
