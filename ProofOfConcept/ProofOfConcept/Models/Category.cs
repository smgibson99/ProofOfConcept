using System;
using System.ComponentModel;

namespace ProofOfConcept.Models
{
    public class Category : INotifyPropertyChanged
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

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                RaisePropertyChanged("CategoryName");
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
            return obj is Category && ((Category)obj).CategoryName.Equals(CategoryName);
        }

        public override int GetHashCode()
        {
            return (CategoryName != null ? CategoryName.GetHashCode() : 0);
        }
    }
}
