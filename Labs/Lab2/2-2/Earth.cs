using System;

namespace Labs2_2_var4
{
    sealed class Earth : Planet
    {
        readonly int numberOceans = 5;//количество океанов
        readonly int numberContinents = 6;//количество материков
        int humanPopulation = 7000000;//численность населения

        //конструкторы из родительского класса:
        public Earth(bool isSolid) : base(isSolid)
        {
        }
        public Earth() : base(1, 365, 1)
        { 
        }

        //свойства для населения:
        public int HumanPopulation
        {
            get
            {
                return humanPopulation;
            }
            set
            {
                if (value > 0) //проверка свойства 
                {
                    humanPopulation = value;
                }
                else
                {
                    humanPopulation = 0;
                    Console.WriteLine("Total annihilation: no more human beings stayed...");
                }
            }
        }
        
        //переписывается родительский метод:
        public override void ShowObjectInfo()
        {
            Console.WriteLine("\nCharacteristics of cosmic object: planet Earth.");
            Console.WriteLine("Earth is solid: " + isSolid);
            countDistance(2573232);
            Console.WriteLine("Rotate period: " + rotatePeriod + " days");
            Console.WriteLine("Earth mass: " + getMass());
            Console.WriteLine("Earth radius: " + objectRadius + " km");
            Console.WriteLine("Number of satellites: " + satellites);
            Console.WriteLine("Earth has " + numberOceans + " oceans and " + numberContinents + " continents.");
            Console.WriteLine("Human population nowadays: " + humanPopulation);
        }

        //собственный метод:
        String getMass()
        {
            if (humanPopulation == 0)
            {
                return "5,97 * 10^24 kg";
            }
            else
            {
                return "5,97 * 10^24 Earth kg + " + (humanPopulation * 50) + " human kg";
            }
        }
    }
}