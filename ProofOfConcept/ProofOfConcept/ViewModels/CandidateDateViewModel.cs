using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ProofOfConcept.Models;
using Xamarin.Forms;

namespace ProofOfConcept.ViewModels
{
    public class CandidateDateViewModel : BaseViewModel
    {
        private Candidate _candidate = null;
		private ObservableCollection<CandidateDate> _candidateDates = new ObservableCollection<CandidateDate>();
		public ObservableCollection<CandidateDate> CandidateDates
		{
			get { return _candidateDates; }
			set
			{
                _candidateDates = value;
                OnPropertyChanged(nameof(CandidateDates));

			}
		}

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

		//get the user dates for only the specified candidate
		public async Task<ObservableCollection<CandidateDate>>GetCandidateDatesAsync(Candidate candidate)
		{
            DateTime currentDate = DateTime.Now;
            int sumScore = 0;
            int count = 0;

            _candidate = candidate;

            CandidateDates.Clear();

			if (settings.User == null)
			{
				throw new Exception("Not logged in.");
			}

			IsBusy = true;
			try
			{
                // get all the date information from the user dates table
				var dates = await service.GetUserDatesAsync(settings.User.UserId);
				if (dates.Count > 0)
				{
                    var userDates = new ObservableCollection<UserDate>(dates
                                                                   .Where(r => r.CandidateName.Equals(candidate.CandidateName))
                                                                   .OrderByDescending(c => c.DateOfDate)
                                                                   .ThenBy(c => c.QualityName));
                    foreach (var udate in userDates)
                    {
                        if (udate.DateOfDate.CompareTo(currentDate)==0)
                        {
                            count++;
                            sumScore += udate.DateScore;

                        } else
                        {
                            if (count > 0)
                            {
                                // save off existing date
                                CandidateDates.Add(new CandidateDate { CandidateName = udate.CandidateName, DateOfDate = currentDate, DateScore = (sumScore/count) });
							} 

							currentDate = udate.DateOfDate;
							count = 1;
							sumScore = udate.DateScore;
                        }
                    }

                    // save off last date
					if (count > 0)
					{
						// save off existing date
                        CandidateDates.Add(new CandidateDate { CandidateName = candidate.CandidateName, DateOfDate = currentDate, DateScore = (sumScore / count) });
					}
				}
			}
			finally
			{
				IsBusy = false;
			}
			return CandidateDates;
		}

		public async Task DeleteCandidateDateAsync(CandidateDate candidateDate)
		{
            int count = 0;
            int sumScore = 0;

			if (settings.User == null)
			{
				throw new Exception("Not logged in.");
			}

            if (candidateDate == null)
				return;

			IsBusy = true;

			try
			{   //remove the candidate's dates first
				// get all the date information from the user dates table
				var dates = await service.GetUserDatesAsync(settings.User.UserId);
				if (dates.Count > 0)
				{
                    var userDates = new ObservableCollection<UserDate>(dates
                                                                       .Where(r => r.CandidateName.Equals(candidateDate.CandidateName) && r.DateOfDate.Equals(candidateDate.DateOfDate)));

                    foreach (var udate in userDates)
                    {
                        // delete each user date
                        await service.RemoveUserDateAsync(udate);
                    }
                    // now search for next recent candidate date and either update the Candidate record, or remove it from the list
                    dates = await service.GetUserDatesAsync(settings.User.UserId);
                    if (dates.Count > 0)
                    {
                        var userDate = dates.Where(r => r.CandidateName.Equals(candidateDate.CandidateName))
                                            .OrderByDescending(c => c.DateOfDate).FirstOrDefault();
                                                                       
                        if (userDate!= null)
                        {
							//get average of the user date's scores
							userDates = new ObservableCollection<UserDate>(dates
                                                                           .Where(r => r.CandidateName.Equals(userDate.CandidateName) && r.DateOfDate.Equals(userDate.DateOfDate)));
                            foreach (var uDate in userDates)
                            {
                                count++;
                                sumScore += uDate.DateScore;
                            }

                            // found at least one existing date, update the candidate record with its date of date
                            var candidate = await service.GetCandidateAsync(settings.User.UserId, candidateDate.CandidateName);
                            if (candidate != null)
                            {
                                candidate.LastDate = userDate.DateOfDate;
                                candidate.DateScore = (int)(sumScore / count);
                                await service.UpdateCandidateAsync(candidate);
                            }
                        } else
                        {
                            // no candidate dates exist, delete from candidates table
                            await service.RemoveCandidateAsync(new Candidate { UserId = settings.User.UserId, CandidateName = candidateDate.CandidateName });
                        }
                    }

                    // now delete the CandidateDate record
                    CandidateDates.Remove(candidateDate);

				}
			}
			finally
			{
				IsBusy = false;
			}
		}

		public ICommand RefreshCommand
		{
			get
			{
				return new Command(async () =>
				{
					IsRefreshing = true;
                    await GetCandidateDatesAsync(_candidate);
					IsRefreshing = false;
				});
			}
		}

    }
}
