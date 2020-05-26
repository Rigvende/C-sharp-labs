using System;

namespace Labs1_1_var1
{
    class Tanker
{
        string tankerName;//имя танкера
        public int [] currentVolume;//массив, содержащий значения наполненности танков
        const int tankVolume = 100;//объём одного танка
        const int loadSpeed = 10;//скорость наполнения танка

        public Tanker(): this("unknown", new int[4] { 0, 0, 0, 0}) //конструктор 1 с цепочкой
        {
        }
        public Tanker(string name): this (name, new int[4] { 70, 40, 50, 60}) //конструктор 2 с цепочкой
        {
        }
        public Tanker(string name, int[] volume) //конструктор 3
        {
            this.tankerName = name;
            this.currentVolume = volume;
        }

        public string TankerName //сеттер и геттер для инкапсулированного имени
        {
            get
            {
                return tankerName;
            }
            set
            {
                if (value.Length <= 20) //проверка свойства на длину имени
                {
                    tankerName = value;
                }
                else
                {
                    Console.WriteLine("Error! Your name is too big. Your tanker can't change its name.");
                }
            }
        }
               
        public void print()//вывод сообщения
        {
            Console.WriteLine("\nYou see the " + tankerName + " tanker");
            Console.WriteLine("The max volume of each its tank is " + tankVolume + " tons. Tank's loading speed is " + loadSpeed + " tons per minute.");
            Console.WriteLine(tankerName + " tanker  weights " + (findLeftWeight(currentVolume) + findRightWeight(currentVolume)) + " tons.");
            Console.WriteLine(isFalling(currentVolume));
        }

        private int findLeftWeight(int [] current)//найти вес левой половины
        {
            int weight = 0;
            for (int i = 0; i < current.Length / 2; i++)
            {
                weight = weight + current[i];
            }
            return weight;
        }

        private int findRightWeight(int [] current)//найти вес правой половины
        {
            int weight = 0;
            for (int i = current.Length - 1; i >= current.Length / 2; i--)
            {
                weight = weight + current[i];
            }
            return weight;
        }

        public double fullLoad(int maxVolume, int [] current)//найти время полного заполнения
        {
            int sumFree = 0;
            for (int i = 0; i < current.Length; i++) {
                int freeVolume = tankVolume - current[i];
                sumFree = sumFree + freeVolume;
            }
            double loadTime = sumFree / loadSpeed;
            return loadTime;
        }

        public string isFalling(int [] current)//определить угрозу опрокидывания
        {
            bool one = findLeftWeight(current) - findRightWeight(current) > findLeftWeight(current) / 2;
            bool two = findRightWeight(current) - findLeftWeight(current) > findRightWeight(current) / 2;
            if (one || two)
            {
                return "Probably, it is almost falling at the back because it is overweighting. It needs quickly throwing out ballast.";
            }
            else
            {
                return "The tanker is seating good on the water. It is not overweighting.";
            }
                      
        }

        public bool isBigger(Tanker a) //является ли текущий танкер более загруженным, чем другой
        {
            int weight1 = findRightWeight(currentVolume) + findLeftWeight(currentVolume);
            int weight2 = findLeftWeight(a.currentVolume) + findRightWeight(a.currentVolume);
            if (weight1 > weight2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Tanker returnBiggest(Tanker a, Tanker b, Tanker c)//вернуть танкер с наибольшей загрузкой
        {
            int weight1 = a.findLeftWeight(a.currentVolume) + a.findRightWeight(a.currentVolume);
            int weight2 = b.findLeftWeight(b.currentVolume) + b.findRightWeight(b.currentVolume);
            int weight3 = c.findLeftWeight(c.currentVolume) + c.findRightWeight(c.currentVolume);
            if (weight1 > weight2 && weight1 > weight3) {
                return a;
            }
            else if (weight2 > weight1 && weight2 > weight3) {
                return b;
            }
            else {
                return c;
            }
        }
    }
}