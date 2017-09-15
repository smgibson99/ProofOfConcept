using System;
using System.ComponentModel;

namespace ProofOfConcept.Models
{
    public class CandidateDate : INotifyPropertyChanged
    {
		private string _candidateName;
		public string CandidateName
		{
			get { return _candidateName; }
			set
			{
				_candidateName = value;
				RaisePropertyChanged("CandidateName");
			}
		}

		private DateTime _dateOfDate;
        public DateTime DateOfDate
		{
            get { return _dateOfDate; }
			set
			{
                _dateOfDate = value;
				RaisePropertyChanged("DateOfDate");
			}
		}

		private int _dateScore;
		public int DateScore
		{
			get { return _dateScore; }
			set
			{
				_dateScore = value;
				RaisePropertyChanged("DateScore");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public override bool Equals(object obj)
		{
            return obj is CandidateDate && ((CandidateDate)obj).DateOfDate.Equals(DateOfDate) && ((CandidateDate)obj).CandidateName.Equals(CandidateName);
		}

		public override int GetHashCode()
		{
			return (CandidateName != null ? CandidateName.GetHashCode() : 0);
		}
    }
}

