using System;
using System.ComponentModel;

namespace ProofOfConcept.Models
{
    public class IdealMate : INotifyPropertyChanged
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

        private int _scoreValue;
        public int ScoreValue
        {
            get { return _scoreValue; }
            set
            {
                _scoreValue = value;
                RaisePropertyChanged("ScoreValue");
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
            return obj is IdealMate && ((IdealMate)obj).UserId.Equals(UserId) && ((IdealMate)obj).QualityName.Equals(QualityName);
        }

        public override int GetHashCode()
        {
            return (UserId != null ? UserId.GetHashCode() : 0) ^ (QualityName != null ? QualityName.GetHashCode() : 0);
        }
    }
}
