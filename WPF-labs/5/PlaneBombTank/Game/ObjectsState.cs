using System.ComponentModel;
using System.Threading;

namespace Game
{
    //класс отслеживает состояние объектов
    internal class ObjectsState : INotifyPropertyChanged
    {
        private Timer _t;

        public Tank Tank { get; set; }
        public Plane Plane { get; set; }
        public Missile Missile { get; set; }
        public bool IsStarted { get; set; }

        public void Init()
        {
            Tank.Init();
            Plane.Init();
        }

        public void Start()
        {
            if (IsStarted)
            {
                return;
            }
            Movement move = new Movement();
            _t = new Timer
                (
                state =>
                {
                    Plane.Update();
                    if (!Missile.IsEnabled)
                    {
                        return;
                    }
                    Missile.Update();
                    if (Missile.GameObject.IntersectsWith(Tank.GameObject))
                    {
                        if (Missile.IsActive)
                        {
                            Missile.IsActive = false;
                            Missile.Destroy();
                            Tank.Destroy();
                        }
                        if (move.Location >= 50)
                        {
                            Missile.IsEnabled = false;
                            Tank.IsEnabled = false;
                        }
                    }
                    else if (Missile.GameObject.Y < 40)
                    {
                        if (Missile.IsActive)
                        {
                            Missile.IsActive = false;
                            Missile.Destroy();
                        }
                        if (move.Location >= 50)
                        {
                            Missile.IsEnabled = false;
                            move.Location = 0;
                        }
                    }
                },
                null, 0, 10);
            IsStarted = true;
        }

        public void Pause()
        {
            if (IsStarted)
            {
                _t.Dispose();
                IsStarted = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
