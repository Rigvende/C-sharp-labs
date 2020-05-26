using System;

namespace Labs5
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем первый тестовый объект
            MonsterTruck monsterTruck1 = new MonsterTruck(2, "Jubilee", 4);
            Console.WriteLine("Object 1: " + monsterTruck1);

            // добавляем обработчики событий для первого объекта
            monsterTruck1.OnNameChanged += MonsterTruck.NameChangeHandler;
            monsterTruck1.OnFireTurbinesChanged += monsterTruck1.FireTurbinesChangeHandler;

            // обработка события с помощью статического метода
            Console.WriteLine("\nEvent handler (static method):");
            monsterTruck1.Name = "Dirty Jack";
            Console.WriteLine("Object 1: " + monsterTruck1);

            // обработка события с помощью обычного метода класса
            Console.WriteLine("\nEvent handler (non-static method):");
            monsterTruck1.FireTurbines = 1;
            Console.WriteLine("Object 1: " + monsterTruck1);

            // создаем второй тестовый объект
            MonsterTruck monsterTruck2 = new MonsterTruck(4, "Cosmo-Jet", 3);
            Console.WriteLine("\n================================================================");
            Console.WriteLine("Object 2: " + monsterTruck2);

            // добавляем обработчики событий для второго объекта
            monsterTruck2.OnNameChanged += delegate ()
            {
                Console.WriteLine("\nEvent handler (anonimous delegate):\nWarning! Name of the Monster-Truck is changed!");
            };
            monsterTruck2.OnFireTurbinesChanged += (value) =>
            {
                Console.WriteLine("\nEvent handler (lambda-expression):\nWarning! Number of fire turbines is changed to " + value);
            };

            // обработка события с помощью анонимного делегата
            monsterTruck2.Name = "Elephant-13";
            Console.WriteLine("Object 2: " + monsterTruck2);

            // обработка события с помощью лямбда-выражения
            monsterTruck2.FireTurbines = 13;
            Console.WriteLine("Object 2: " + monsterTruck2);
        }
    }
}
