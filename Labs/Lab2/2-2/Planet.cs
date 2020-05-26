using System;

namespace Labs2_2_var4
{
    class Planet : StarSystem
    {
        String name = "NoName";//имя планеты
        public bool isSolid = true;//твёрдая или газообразная
        public double starDistance = 147;//растояние до звезды в миллионах км
        public int rotatePeriod;//период обращения вокруг звезды в земных днях
        public int satellites;//кол-во спутников

        //конструкторы (без цепочки):
        public Planet()
        {
            satellites = 0;
        }
        public Planet(bool isSolid)
        {
            this.isSolid = isSolid;
            if (isSolid == true)
            {
                satellites = 1;
            }
            objectMass = 1;
            rotatePeriod = 365;
            objectRadius = 6371;
        }
        public Planet(double objectMass, int rotatePeriod, int satellites)
        {
            this.objectMass = objectMass;
            this.rotatePeriod = rotatePeriod;
            this.satellites = satellites;
        }

        //свойства для закрытого имени:
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

        //переписываем абстрактный метод родителя:
        public override void countVolume()//посчитать объем
        {
            double volume = PI * objectRadius * 4 / 3;
            Console.WriteLine("Planet volume: " + String.Format("{0:0.00}", volume) + " cube km");
        }

        public void countDistance(int speed)
        {
            double distance = ((rotatePeriod * speed) / (2 * PI)) / 1000000;
            Console.WriteLine("Distance from star: " + String.Format("{0:0.00}", distance) + " millions km");
        }
        
        //переписываем виртуальный метод родителя:
        public override void ShowObjectInfo()//показать инфу
        {
            Console.WriteLine("\nCharacteristics of cosmic object: planet " + name);
            Console.WriteLine("The planet is solid: " + isSolid);
            Console.WriteLine("Star distance: " + starDistance + " millions km");
            Console.WriteLine("Rotate period: " + rotatePeriod + " Earth's days");
            Console.WriteLine("Planet mass: " + objectMass + " Earth's masses");
            Console.WriteLine("Planet radius: " + objectRadius + " km");
            Console.WriteLine("Number of satellites: " + satellites);
        }

        //создаём собственный виртуальный метод
        virtual public bool lifeable(double starDistance)//проверить на жизнепригодность
        {
            return starDistance > 100 && starDistance < 200;
        }
    }
}