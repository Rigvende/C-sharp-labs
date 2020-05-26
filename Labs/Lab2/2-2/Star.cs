using System;

namespace Labs2_2_var4
{
    class Star : StarSystem
    {
        String name = "NoName";//имя звезды
        public double brightness;//светимость в 10^26Вт
        public int numberPlanets;//количество планет
        public String starType;//тип звезды
        private bool isCollapse;//возможность сколлапсировать
        
        //конструкторы (цепочкой):
        public Star() : this(0, 0, "Unknown")
        {
            name = "NoName";
        }
        public Star(double brightness, String starType) : this(brightness, 0, starType)
        {
        }
        public Star(double brightness, int numberPlanets, String starType)
        {
            this.brightness = brightness;
            this.numberPlanets = numberPlanets;
            this.starType = starType;
            objectMass = 300000;
        }

        //свойства для закрытого имени и булевого коллапса
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public bool IsCollapse
        {
            get
            {
                return isCollapse;
            }
            set
            {
                isCollapse = value;
            }
        }

        //переписываем абстрактный метод родителя:
        public override void countVolume()//посчитать объем
        {
            double volume = PI * objectRadius * 4 / 3;
            Console.WriteLine("Star volume: " + String.Format("{0:0.00}", volume) + " cube km");
        }

        //переписываем виртуальный метод родителя:
        public override void ShowObjectInfo()//показать инфу
        {
            Console.WriteLine("\nCharacteristics of cosmic object: star " + name);
            Console.WriteLine("Star type: " + starType);
            Console.WriteLine("Brightness: " + brightness + " * 10^26 Vatt");
            Console.WriteLine("Star mass: " + objectMass + " Earth's masses");
            Console.WriteLine("Star radius: " + objectRadius + " km");
            Console.WriteLine("Number of planets: " + numberPlanets);
        }       
        
        //собственныe методы (доступ к закрытому через открытый): 
        public void doCollapse(double throwingMass)//проверка на ближайший коллапс:
        {
            if(isBig(throwingMass) && objectMass > 1000000)
            {
                Console.WriteLine("Star " + name + " is throwing too much materia. It is going to collapse.");
                isCollapse = true;
            }
            else
            {
                Console.WriteLine("That's OK. The loosing weight is not match for collapsing.");
            }
        }
        bool isBig(double throwingMass) //метод расчёта сброшенной звездой массы
        {
            return throwingMass < objectMass / 3 && throwingMass > objectMass / 10; //если масса звезды по-прежнему велика - коллапс близко
        }
    }
}