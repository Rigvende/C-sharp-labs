using System;
using System.Collections;
using System.Collections.Generic;

namespace Labs3
{
    class Program
    {
        static void Main(string[] args)
        {
            ISound doll = new Doll("Barbie", "blue");
            Console.WriteLine(doll.MakeSound("Ma-ma"));
            doll.Print();
            Doll barbie = (Doll)doll;
            barbie.DressColour = null;
            barbie.Print();

            IMove car = new PoliceCar(4, false, "Lada");
            car.Print();
            PoliceCar policeCar = (PoliceCar)car;
            policeCar.Print(); //используем метод интерфейса IMove
            ((ISound)policeCar).Print(); //используем метод интерфейса ISound через явное указание
            policeCar.PrintSoundingCar(); //используем обёртку
            policeCar.Wheels = 6;
            Console.WriteLine(policeCar.MakeSound("Weee-ouu"));
            policeCar.Move(2);
            Console.WriteLine();

            //создаем массив объектов интерфейса IMove, проходимся по ним циклом, если какие-то объекты
            //параллельно имплементируют интерфейс ISound, то вызываем метод этого интерфейса MakeSound())
            IMove[] cars = new IMove[4];
            cars[0] = car;
            cars[1] = new PoliceCar(4, true);
            cars[2] = new ToyCar(8, "Pegeot");
            cars[3] = policeCar;
            foreach (IMove toy in cars)
            {
                if (toy is ISound)
                {
                    ISound item = (ISound)toy;
                    Console.WriteLine(toy.GetHashCode() + " " + item.MakeSound("Bip"));
                }
            }
            Console.WriteLine();
            foreach (IMove toy in cars)
            {
                Console.WriteLine(toy.Name + " ");
            }
            Console.WriteLine();

            //сортируем массив интерфейсов, интерфейс IComparable, ключ - Name
            Array.Sort(cars);
            foreach (IMove toy in cars)
            {
                Console.WriteLine(toy.Name + " ");
            }
            Console.WriteLine();

            //сортируем массив интерфейсов, интерфейс IComparer, ключ - Name
            Array.Sort(cars, (o1, o2) => o1.Name.CompareTo(o2.Name));
            foreach (IMove toy in cars)
            {
                Console.WriteLine(toy.Name + " ");
            }
            Console.WriteLine();

            //создаем ArrayList и заполняем объектами из массива cars
            ArrayList list = new ArrayList();
            list.AddRange(cars);
            list.Add(new ToyCar(8, "BTR"));

            //вызываем меню
            Menu.MakeChoice(ref list);

            //создаем List, параметризованный типом IMove
            List<IMove> parametrizedList = new List<IMove>();
            parametrizedList.AddRange(cars);
            parametrizedList.Add(new ToyCar() { Name = "BTR", Wheels = 8 });

            MenuParametrized.MakeChoice(ref parametrizedList);
        }
    }
}