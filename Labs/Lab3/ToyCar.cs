using System;

namespace Labs3
{
    [Serializable]
    public class ToyCar : IMove, IComparable
    {
        protected int wheels;
        protected string name;

        public ToyCar() {
            name = "unknown";
        }

        public ToyCar(int wheels, string name)
        {
            Wheels = wheels;
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    name = "unknown";
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Wheels
        {
            get
            {
                return wheels;
            }
            set
            {
                if (value < 0 || value > 10)
                {
                    Console.WriteLine("Error! Number of wheels is unacceptable. Wheels are set to 0.");
                    wheels = 0;
                }
                else
                {
                    wheels = value;
                }
            }
        }

        public int CompareTo(object car)
        {
            ToyCar item = car as ToyCar;
            if (item != null)
                return Name.CompareTo(item.Name);
            else
                throw new Exception("Error! Impossible to compare objects.");
        }

        public void Move(int speed)
        {
            if (speed <= 0)
            {
                Console.WriteLine("Toy car has unlimited speed.");
            }
            else
            {
                Console.WriteLine("Toy car has speed {0} meters per second", speed);
            }
        }

        public void Print()
        {
            Console.WriteLine("This is a toy car. It has {0} wheels", wheels);
        }

        public override bool Equals(object obj)
        {
            IMove item = (IMove)obj;
            return Name.Equals(item.Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Wheels);
        }

        public override string ToString()
        {
            return "ToyCar{name=" + Name + ",wheels=" + wheels + '}';
        }      
    }
}
