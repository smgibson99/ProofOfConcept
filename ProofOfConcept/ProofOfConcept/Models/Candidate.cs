using System;
using System.ComponentModel;

namespace ProofOfConcept.Models
{
    public class Candidate : INotifyPropertyChanged
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                RaisePropertyChanged("UserId");
            }
        }

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

        private DateTime _lastDate;
        public DateTime LastDate
        {
            get { return _lastDate; }
            set
            {
                _lastDate = value;
                RaisePropertyChanged("LastDate");
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
            return obj is Candidate && ((Candidate)obj).UserId.Equals(UserId) && ((Candidate)obj).CandidateName.Equals(CandidateName);
        }

        public override int GetHashCode()
        {
            return (UserId != null ? UserId.GetHashCode() : 0) ^ (CandidateName != null ? CandidateName.GetHashCode() : 0);
        }
    }
}
