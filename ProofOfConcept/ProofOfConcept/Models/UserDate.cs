using System;
using System.ComponentModel;

namespace ProofOfConcept.Models
{
    public class UserDate : INotifyPropertyChanged
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

        private string _qualityName;
        public string QualityName
        {
            get { return _qualityName; }
            set
            {
                _qualityName = value;
                RaisePropertyChanged("QualityName");
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

        private string _adviceGiven;
        public string AdviceGiven
        {
            get { return _adviceGiven; }
            set
            {
                _adviceGiven = value;
                RaisePropertyChanged("AdviceGiven");

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
            return obj is UserDate && ((UserDate)obj).UserId.Equals(UserId) && ((UserDate)obj).CandidateName.Equals(CandidateName) && ((UserDate)obj).DateOfDate.Equals(DateOfDate) && ((UserDate)obj).QualityName.Equals(QualityName);
        }

        public override int GetHashCode()
        {
            return (UserId != null ? UserId.GetHashCode() : 0) ^ (CandidateName != null ? CandidateName.GetHashCode() : 0) ^ (QualityName != null ? QualityName.GetHashCode() : 0);
        }
    }
}
