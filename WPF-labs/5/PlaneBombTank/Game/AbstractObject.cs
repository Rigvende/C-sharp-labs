using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Game
{
    //общий класс для самолета, бомбы и танка
    class AbstractObject : INotifyPropertyChanged
    {
        private Rect _gameObject;
        private string _info;
        private BitmapSource _image;
        private bool _isEnabled;

        public AbstractObject()
        {
            IsEnabled = true;
        }

        public bool IsActive { get; set; }

        public Rect GameObject
        {
            get { return _gameObject; }
            set
            {
                if (value.Equals(_gameObject))
                {
                    return;
                }
                _gameObject = value;
                OnPropertyChanged("GameObject");
            }
        }

        public string Info
        {
            get { return _info; }
            protected set
            {
                if (value == _info)
                {
                    return;
                }
                _info = value;
                OnPropertyChanged("Info");
            }
        }

        public BitmapSource Image
        {
            get { return _image; }
            set
            {
                if (Equals(value, _image))
                {
                    return;
                }
                _image = value;
                OnPropertyChanged("Image");
            }
        }
                
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (value == _isEnabled)
                {
                    return;
                }
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public virtual void Init() { }

        public virtual void Update() { }

        public virtual void Destroy()
        {
            Image = BitmapFrame.Create(new Uri("images/explosion.png", UriKind.RelativeOrAbsolute));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
