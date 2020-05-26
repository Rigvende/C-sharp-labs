using System;

namespace Labs2_2_var4
{
    class Mars : Planet
    {
        int workStations;//количество научных аппаратов
        bool isDustStorm = true;//проверка на пылевую бурю

        //конструктор по умолчанию, прописываем свойства для закрытых полей:
        public int WorkStations
        {
            get
            {
                return workStations;
            }
            set
            {
                if (value >= 0) //проверка свойства 
                {
                    workStations = value;
                }
                else
                {
                    Console.WriteLine("Work station's log is under attack. You have lost all information.");
                }
            }
        }
        public bool IsDustStorm
        {
            get
            {
                return isDustStorm;
            }
            set
            {
                isDustStorm = value;
            }
        }
       
        //переписываем родительский метод:
        public override void ShowObjectInfo()
        {
            Console.WriteLine("\nCharacteristics of cosmic object: planet Mars.");
            Console.WriteLine("The planet is solid: " + isSolid);
            Console.WriteLine("Distance from Sun: " + starDistance + " millions km");
            Console.WriteLine("Rotate period: " + rotatePeriod + " Earth's days");
            Console.WriteLine("Planet mass: " + objectMass + " Earth's masses");
            Console.WriteLine("Planet radius: " + objectRadius + " km");
            Console.WriteLine("Number of satellites: " + satellites);
            Console.WriteLine("There are " + workStations + " work stations on Mars now.");
            Console.WriteLine("Now Mars has strong dust storm: " + isDustStorm);
        }

        //переписываем родительский виртуальный метод:
        public override bool lifeable(double starDistance)//проверяем на жизнеспособность
        {
            this.starDistance = starDistance;
            if (isDustStorm == false)
            {
                return base.lifeable(starDistance);
            }
            else
            {
                return false;
            }
        }

        //собственный метод:
        public void helloCuriosity()
        {
            if (workStations == 1)
            {
                Console.WriteLine("\"Hello! Get me out of here!\" - \"Curiosity\" said.");
            }
        }
    }
}