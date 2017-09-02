using System;
using System.ComponentModel;

namespace ProofOfConcept.Models
{
    public class Quality : INotifyPropertyChanged
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
            }
        }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
            }
        }

        private int _accessLevel;
        public int AccessLevel
        {
            get { return _accessLevel; }
            set
            {
                _accessLevel = value;
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
            return obj is Quality && ((Quality)obj).QualityName.Equals(QualityName) && ((Quality)obj).CategoryName.Equals(CategoryName);
        }

        public override int GetHashCode()
        {
            return (QualityName != null ? QualityName.GetHashCode() : 0) ^ (CategoryName != null ? CategoryName.GetHashCode() : 0);
        }
    }
}
