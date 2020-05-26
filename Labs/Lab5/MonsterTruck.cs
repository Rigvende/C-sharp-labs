using System;

namespace Labs5

//создала новый класс игрушечного монстр-трака, чтобы не потрошить полицейскую машинку
{
    public class MonsterTruck : Labs3.ToyCar, Labs3.ISound
    {
        int fireTurbines;

        // делегаты для обработки событий (меняется имя или количество турбин)
        public delegate void NameChangedHandler();
        public delegate void FireTurbinesChangedHandler(int newValue);

        // обработчики событий
        public event NameChangedHandler OnNameChanged;
        public event FireTurbinesChangedHandler OnFireTurbinesChanged;

        // добавляем в свойства обработчики событий
        public int FireTurbines 
        {
            get
            {
                return fireTurbines;
            }
            set
            {
                if (value >= 0)
                {
                    fireTurbines = value;
                    OnFireTurbinesChanged?.Invoke(fireTurbines);
                }
                else
                {
                    Console.WriteLine("Wrong number of turbines.");
                }
            }
        }

        public new string Name
        {
            get 
            { 
                return base.Name; 
            }
            set
            {
                base.Name = value;
                OnNameChanged?.Invoke();
            }
        }

        public MonsterTruck() : base(4, "unknown")
        {
        }

        public MonsterTruck(string name)
        {
            Wheels = 4;
            Name = name;
        }

        public MonsterTruck(int fireTurbines, string name, int wheels)
        {
            Wheels = wheels;
            Name = name;
            FireTurbines = fireTurbines;
        }

        // метод для оповещения в случае изменения имени
        public static void NameChangeHandler()
        {
            Console.WriteLine("Warning! Name of the Monster-Truck is changed!");
        }

        // метод для оповещения в случае изменения числа турбин
        public void FireTurbinesChangeHandler(int value)
        {
            Console.WriteLine("Warning! Number of fire turbines is changed to " + value);
        }

        //реализумем метод интерфейса IMove
        public new void Move(int speed)
        {
            Console.WriteLine("On it's giant wheels Monster-Truck has speed equals {0} metres per second", speed);
        }

        //реализуем метод интерфейса ISound
        public string MakeSound(string sound)
        {
            return "Monster-Truck makes sound: " + sound;
        }

        public override bool Equals(object obj)
        {
            Labs3.IMove item = (Labs3.IMove)obj;
            return obj != null && obj is MonsterTruck && Name.Equals(item.Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), fireTurbines);
        }

        public override string ToString()
        {
            return "MonsterTruck{name=" + Name + ", wheels=" + wheels + ", fireTurbines=" + fireTurbines + '}';
        }
    }
}