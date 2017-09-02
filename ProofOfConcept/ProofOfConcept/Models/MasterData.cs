using System;
using System.ComponentModel;

namespace ProofOfConcept.Models
{
    public class MasterData : INotifyPropertyChanged
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

        private int _sequenceNo;
        public int SequenceNo
        {
            get { return _sequenceNo; }
            set
            {
                _sequenceNo = value;
                RaisePropertyChanged("SequenceNo");
            }
        }

        private string _adviceLow;
        public string AdviceLow
        {
            get { return _adviceLow; }
            set
            {
                _adviceLow = value;
                RaisePropertyChanged("AdviceLow");
            }
        }

        private string _adviceMed;
        public string AdviceMed
        {
            get { return _adviceMed; }
            set
            {
                _adviceMed = value;
                RaisePropertyChanged("AdviceMed");
            }
        }

        private string _adviceHigh;
        public string AdviceHigh
        {
            get { return _adviceHigh; }
            set
            {
                _adviceHigh = value;
                RaisePropertyChanged("AdviceHigh");
            }
        }

        private int _accessLevel;
        public int AccessLevel
        {
            get { return _accessLevel; }
            set
            {
                _accessLevel = value;
                RaisePropertyChanged("AccessLevel");
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
            return obj is MasterData && ((MasterData)obj).QualityName.Equals(QualityName) && ((MasterData)obj).SequenceNo == SequenceNo;
        }

        public override int GetHashCode()
        {
            return (QualityName != null ? QualityName.GetHashCode() : 0);
        }
    }
}
