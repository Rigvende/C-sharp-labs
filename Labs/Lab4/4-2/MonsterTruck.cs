using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Labs5

    //создала новый класс игрушечного монстр-трака, чтобы не потрошить полицейскую машинку
{
    [Serializable]
    public class MonsterTruck : Labs3.ToyCar, Labs3.ISound
    {

        public bool HasOpeningDoors { get; set; }
        public bool HasFireTurbines { get; set; }

        public MonsterTruck() : base(4, "unknown")
        {
        }

        public MonsterTruck(bool hasOpeningDoors, bool hasFireTurbines)
        {
            Wheels = 4;
            Name = "unknown";
            HasOpeningDoors = hasOpeningDoors;
            HasFireTurbines = hasFireTurbines;
        }

        public MonsterTruck(bool hasOpeningDoors, bool hasFireTurbines, string name, int wheels)
        {
            Wheels = wheels;
            Name = name;
            HasOpeningDoors = hasOpeningDoors;
            HasFireTurbines = hasFireTurbines;
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
            return HashCode.Combine(base.GetHashCode(), HasFireTurbines, HasOpeningDoors);
        }

        public override string ToString()
        {
            return "MonsterTruck{name=" + Name + ", wheels=" + wheels + ", hasOpeningDoors="
                   + HasOpeningDoors + ", hasFireTurbines=" + HasFireTurbines + '}';
        }

        public static void SaveClass(string filename)
        {
            Type type = typeof(MonsterTruck);
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine("Full class name:" + type.FullName);
            if (type.IsAbstract) writer.WriteLine("Abstract class");
            if (type.IsClass) writer.WriteLine("Class");
            if (type.IsInterface) writer.WriteLine("Interface");
            if (type.IsEnum) writer.WriteLine("Enumeration");
            if (type.IsSealed) writer.WriteLine("Sealed class");
            writer.WriteLine("Базовый класс - " + type.BaseType);
            FieldInfo[] fields = type.GetFields();
            if (fields.Length > 0)
            {
                writer.WriteLine("\nClass fields:");
            }
            foreach (var field in fields)
            {
                writer.WriteLine(field);
            }
            PropertyInfo[] properties = type.GetProperties();
            if (properties.Length > 0)
            {
                writer.WriteLine("\nClass properties:");
            }
            foreach (var property in properties)
            {
                writer.WriteLine(property);
            }
            MethodInfo[] methods = type.GetMethods();
            if (methods.Length > 0)
            {
                writer.WriteLine("\nClass methods:");
            }
            foreach (var method in methods)
            {
                writer.WriteLine(method);
            }
            writer.Close();
        }

        public void SaveObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(HasOpeningDoors);
            bw.Write(HasFireTurbines);
            bw.Write(Name);
            bw.Write(Wheels);
            fs.Close();
        }

        public static MonsterTruck LoadObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            bool openingDoors = br.ReadBoolean();
            bool fireTurbines = br.ReadBoolean();
            string carName = br.ReadString();
            int carWheels = br.ReadInt32();
            fs.Close();
            return new MonsterTruck(openingDoors, fireTurbines, carName, carWheels);
        }

        public void Serialize(string filename)
        {
            Stream fs = new FileStream(filename, FileMode.Create);
            BinaryFormatter fmt = new BinaryFormatter();
            fmt.Serialize(fs, this);
            fs.Close();
        }

        public static MonsterTruck Deserialize(string filename)
        {
            Stream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            MonsterTruck monsterTruck = (MonsterTruck)bf.Deserialize(fs);
            fs.Close();
            return monsterTruck;
        }
    }
}
