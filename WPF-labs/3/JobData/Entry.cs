using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JobData
{
    [Serializable]
    class Entry : INotifyPropertyChanged
    {
        private string _surname;
        private double _salary;
        private string _profession;
        private string _street;
        private string _house;
        private string _city;
        private int _index;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged("surname");
            }
        }
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                bool result = double.TryParse(value.ToString(), out double convertedValue);
                if (result)
                {
                    _salary = convertedValue;
                    OnPropertyChanged("salary");
                }
            }
        }
        public string Profession
        {
            get
            {
                return _profession;
            }
            set
            {
                _profession = value;
                OnPropertyChanged("profession");
            }
        }
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
                OnPropertyChanged("street");
            }
        }
        public string House
        {
            get
            {
                return _house;
            }
            set
            {
                _house = value;
                OnPropertyChanged("house");
            }
        }
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged("city");
            }
        }

        public void Clear()
        {
            City = "";
            Profession = "";
            Salary = 0;
            Surname = "";
            Street = "";
            House = "";
        }

        public bool IsFilled()
        {
            return !string.IsNullOrEmpty(Surname)
                && (Salary > 0)
                && !string.IsNullOrEmpty(Street)
                && !string.IsNullOrEmpty(Profession)
                && !string.IsNullOrEmpty(City)
                && !string.IsNullOrEmpty(House);
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
