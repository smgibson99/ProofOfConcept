using System;
using System.ComponentModel;

namespace ProofOfConcept.Models
{
    public class Config : INotifyPropertyChanged
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

        private int _lowRatingBegin;
        public int LowRatingBegin
        {
            get { return _lowRatingBegin; }
            set
            {
                _lowRatingBegin = value;
                RaisePropertyChanged("LowRatingBegin");
            }
        }

        private int _lowRatingEnd;
        public int LowRatingEnd
        {
            get { return _lowRatingEnd; }
            set
            {
                _lowRatingEnd = value;
                RaisePropertyChanged("LowRatingEnd");
            }
        }

        private int _medRatingBegin;
        public int MedRatingBegin
        {
            get { return _medRatingBegin; }
            set
            {
                _medRatingBegin = value;
                RaisePropertyChanged("MedRatingBegin");
            }
        }

        private int _medRatingEnd;
        public int MedRatingEnd
        {
            get { return _medRatingEnd; }
            set
            {
                _medRatingEnd = value;
                RaisePropertyChanged("MedRatingEnd");
            }
        }

        private int _highRatingBegin;
        public int HighRatingBegin
        {
            get { return _highRatingBegin; }
            set
            {
                _highRatingBegin = value;
                RaisePropertyChanged("HighRatingBegin");
            }
        }

        private int _highRatingEnd;
        public int HighRatingEnd
        {
            get { return _highRatingEnd; }
            set
            {
                _highRatingEnd = value;
                RaisePropertyChanged("HighRatingEnd");
            }
        }

        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set
            {
                _welcomeMessage = value;
                RaisePropertyChanged("WelcomeMessage");
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
    }
}
