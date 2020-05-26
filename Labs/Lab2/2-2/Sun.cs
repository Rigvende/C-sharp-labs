using System;

namespace Labs2_2_var4
{
    class Sun : Star
    {
        int spots;//количество пятен
        
        //испоьлзуется конструктор от родительского класса:
        public Sun() : base(3820, 8, "yellow dwarf")
        {
            objectMass = 332940;
        }

        //свойства для пятен:
        public int Spots
        {
            get
            {
                return spots;
            }
            set
            {
                if (value >= 0) //проверка свойства 
                {
                    spots = value;
                }
                else
                {
                    Console.WriteLine("Negative number of sun spots. Probably, we see parallel universe!");
                }
            }
        }
        
        //переписываем родительский метод:
        public override void ShowObjectInfo()//показываем инфу
        {
            Console.WriteLine("\nCharacteristics of cosmic object: star Sun.");
            Console.WriteLine("Star type: " + starType);
            Console.WriteLine("Brightness: " + brightness + " * 10^26 Vatt");
            Console.WriteLine("Star mass: " + objectMass + " Earth's masses");
            Console.WriteLine("Star radius: " + objectRadius + " km");
            Console.WriteLine("Number of planets: " + numberPlanets);
            Console.WriteLine("Now Sun has " + spots + " spots.");
        }

        //собственный метод:
        public void checkActive()//проверяем активность
        {
            if (spots > 100)
            {
                Console.WriteLine("Sun is in an active phase. Geomagnetical storms is possible.");
            }
            else if (spots > 300)
            {
                Console.WriteLine("I think we must get out of here. Probably, the Sun is gonna be a dark hole.");
            }
            else
            {
                Console.WriteLine("That's OK. Sun is calm.");
            }
        }
    }           
}