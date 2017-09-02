using System;
using System.ComponentModel;

namespace ProofOfConcept.Models
{
    public class User : INotifyPropertyChanged
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
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        private string _userEmail;
        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
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
            return obj is User && ((User)obj).UserId.Equals(UserId);
        }

        public override int GetHashCode()
        {
            return (UserId != null ? UserId.GetHashCode() : 0);
        }
    }
  
}
