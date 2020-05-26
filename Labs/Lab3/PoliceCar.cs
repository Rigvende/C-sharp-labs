using System;

namespace Labs3
{
    class PoliceCar : ToyCar, ISound
    {
        public bool HasOpeningDoors { get; set; }

        public PoliceCar() : base (4, "unknown")
        {
        }

        public PoliceCar(int wheels, bool hasOpeningDoors)
        {
            Wheels = wheels;
            HasOpeningDoors = hasOpeningDoors;
            Name = "unknown";
        }

        public PoliceCar(int wheels, bool hasOpeningDoors, string name)
        {
            Wheels = wheels;
            Name = name;
            HasOpeningDoors = hasOpeningDoors;
        }

        //реализумем метод интерфейса IMove
        public new void Move(int speed)
        {
            Console.WriteLine("On it's {0} wheels toy police car has speed equals {1} metres per second", wheels, speed);
        }

        //реализуем метод интерфейса ISound
        public string MakeSound(string sound)
        {
            return "Police car makes sound: " + sound;
        }

        //реализуем метод интерфейса IMove, унаследованный от класса ToyCar
        public new void Print() 
        {
            Console.WriteLine("This is a toy police car. It mark is {2}. It has {0} wheels and it doors can be opened: {1}", 
                              wheels, HasOpeningDoors, name);
        }

        //реализуем метод интерфейса ISound (явно)
        void ISound.Print()
        {
            Console.WriteLine("This toy makes a loud sound.");
        }

        //метод-обертка для вызова метода интерфейса ISound
        public void PrintSoundingCar ()
        {
            ((ISound)this).Print();
        }

        //реализуем интерфейс IComparable
        public new int CompareTo(object car)
        {
            if (car is PoliceCar item)
            {
                return Name.CompareTo(item.Name);
            }
            else
            {
                throw new Exception("Error! Impossible to compare objects.");
            }
        }

        public override bool Equals(object obj)
        {
            IMove item = (IMove)obj;
            return Name.Equals(item.Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), HasOpeningDoors);
        }

        public override string ToString()
        {
            return "PoliceCar{name=" + Name + ", wheels=" + wheels + ", hasOpeningDoors=" + HasOpeningDoors + '}';
        }      
    }
}