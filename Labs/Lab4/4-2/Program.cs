using System;

namespace Labs5
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем тестовый объект
            MonsterTruck monsterTruck = new MonsterTruck(false, true, "Jubilee", 4);
            Console.WriteLine("New object is created:"); 
            Console.WriteLine(monsterTruck);

            // сохраняем в файл информацию о классе
            MonsterTruck.SaveClass("MonsterTruck.txt");             
            Console.WriteLine("\nClass information is saved successfully");

            // сохраняем в файл информацию об объекте
            monsterTruck.SaveObject("MonsterTruckXXX.bin");           
            Console.WriteLine("Object information is saved successfully");

            //присваиваем переменной ссылку на новый объект
            monsterTruck = new MonsterTruck(true, true, "Galaxy", 6);  
            Console.WriteLine("\nObject is changed:");
            Console.WriteLine(monsterTruck);  

            //получаем из файла информацию об сохраненном ранее объекте
            monsterTruck = MonsterTruck.LoadObject("MonsterTruckXXX.bin");    
            Console.WriteLine("\nRestore information about object from the file:");
            Console.WriteLine(monsterTruck);

            // сериализуем объект
            monsterTruck.Serialize("MonsterTruckSeries.bin");            
            Console.WriteLine("\nObject is serialized successfully");

            //снова присваиваем переменной ссылку на новый объект
            monsterTruck = new MonsterTruck(true, false, "Cosmo-Jet", 3);        
            Console.WriteLine("\nObject is changed:");
            Console.WriteLine(monsterTruck);

            // десериализуем объект
            monsterTruck = MonsterTruck.Deserialize("MonsterTruckSeries.bin");   
            Console.WriteLine("\nRestore object through deserialization:");
            Console.WriteLine(monsterTruck);
        }
    }
}
