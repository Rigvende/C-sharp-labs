using System;

namespace Labs2_2_var4
{
    abstract class StarSystem
    {
        public double objectMass; //масса объекта (в единицах массы Земли)
        public int objectRadius; //радиус объекта в км
        public const double PI = 3.14;
       
        abstract public void countVolume();//абстрактный метод нахождения объема
        virtual public void ShowObjectInfo()//вывод информации
        {
        }
        public static void ShowStarSystemInfo()//вывод информации 
        {
            Console.WriteLine("\nUnknown cosmic abstraction.");
        }
    }
}