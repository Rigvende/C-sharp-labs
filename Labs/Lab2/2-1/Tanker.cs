using System;

namespace Labs2_1_var4
{
    class Tanker
    {
        string tankerName;//имя танкера
        int numberTanks;//количество танков в танкере
        int[] currentVolume;//массив, содержащий значения наполненности всех танков
        Tank[] tanks;//массив танков (композиция)
        Port port;//ссылка на вмещающий объект (агрегация)

        //конструкторы (цепочкой):
        public Tanker() : this("unknown", new int[4] { 0, 0, 0, 0 }, 4) 
        {
        }
        public Tanker(string tankerName) : this(tankerName, new int[4] { 350, 200, 250, 300 }, 4) 
        {
            this.tankerName = tankerName;
        }
        public Tanker(string tankerName, int[] currentVolume, int numberTanks) 
        {
            this.tankerName = tankerName;
            this.currentVolume = currentVolume;
            this.numberTanks = numberTanks % 2 == 0 && numberTanks == currentVolume.Length ? numberTanks : currentVolume.Length;
            this.tanks = new Tank[] { };
        }

        //свойства инкапсулированных полей:
        public int NumberTanks 
        {
            get
            {
                return numberTanks;
            }
            set
            {
                if (numberTanks <= 1 || numberTanks >= 11) 
                {
                    numberTanks = value;
                }
                else
                {
                    Console.WriteLine("Error! Number of tanks should be even. Your tanker can't change its base tank's number.");
                    numberTanks = 4;
                }
            }
        }
        public int[] CurrentVolume 
        {
            get
            {
                return currentVolume;
            }
            set
            {
                this.currentVolume = value.Length % 2 == 0 ? value : new int [] { 0, 0, 0, 0};
            }
        }
        public string TankerName 
        {
            get
            {
                return tankerName;
            }
            set
            {
                if (value.Length <= 20) 
                {
                    tankerName = value;
                }
                else
                {
                    Console.WriteLine("Error! Your name is too big. Your tanker can't change its name.");
                }
            }
        }
        public Port Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }
        public Tank [] Tanks
        {
            get
            {
                return tanks;
            }
            set
            {
                tanks = value;
            }
        }

        //метод для вывода информации
        public void Print()
        {
            Console.WriteLine("\nYou see the " + tankerName + " tanker");
            Console.WriteLine(tankerName + " tanker  weights " + (FindLeftWeight(currentVolume) + FindRightWeight(currentVolume)) + " tons.");
            Console.WriteLine(isFalling(currentVolume));
        }

        //найти вес левой половины:
        private int FindLeftWeight(int[] current)
        {
            int weight = 0;
            for (int i = 0; i < current.Length / 2; i++)
            {
                weight = weight + current[i];
            }
            return weight;
        }

        //найти вес правой половины:
        private int FindRightWeight(int[] current)
        {
            int weight = 0;
            for (int i = current.Length - 1; i >= current.Length / 2; i--)
            {
                weight = weight + current[i];
            }
            return weight;
        }
        //определить угрозу опрокидывания:
        public string isFalling(int[] current)
        {
            bool one = FindLeftWeight(current) - FindRightWeight(current) > FindLeftWeight(current) / 2;
            bool two = FindRightWeight(current) - FindLeftWeight(current) > FindRightWeight(current) / 2;
            if (one || two)
            {
                return "Probably, it is almost falling at the back because it is overweighting. It needs quickly throwing out ballast.";
            }
            else
            {
                return "The tanker is seating good on the water. It is not overweighting.";
            }
        }
    }
}