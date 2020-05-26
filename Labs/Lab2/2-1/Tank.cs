using System;

namespace Labs2_1_var4
{
    class Tank
    {
        int tankIndex;//индекс танка
        Tanker tanker; //ссылка на вмещающий объект - танкер (для композиции)
        int loadVolume;//загруженность танка одного танка в тоннах
        readonly int maxVolume = 500;//максимальная загруженность одного танка в тоннах
                
        //конструкторы танка:
        public Tank() : this(null, 0, 0)
        {
        }
        public Tank(Tanker tanker, int tankIndex) : this (tanker, tankIndex, 0)
        {
        }
        public Tank (Tanker tanker, int tankIndex, int loadVolume)
        {
            this.tanker = tanker;
            this.tankIndex = tankIndex;
            this.loadVolume = loadVolume;
        }

        //свойства закрытых полей:
        public Tanker Tanker
        {
            get
            {
                return tanker;
            }
            set
            {
                if (value != null)
                {
                    tanker = value;
                }
            }
        }
        public int TankIndex
        {
            get
            {
                return tankIndex;
            }
            set
            {
                if (value > 0)
                {
                    tankIndex = value;
                }
            }
        }
        public int LoadVolume
        {
            get
            {
                return loadVolume;
            }
            set
            {
                if (value > 0 && value <= maxVolume)
                {
                    loadVolume = value;
                }
            }
        }

        // метод, определяющий доступный для загрузки вес
        public int CheckLoad()
        {
            return loadVolume == 0 ? maxVolume : maxVolume - loadVolume;
        }

        //перегрузка метода toString
        public override string ToString()
        {
            if (tanker != null)
            {
                return "Tankers's " + tanker.TankerName + " tank  # " + tankIndex + " has " + CheckLoad() + " tons free for loading";
            }
            else
            {
                return "Unknown tanker's tank # " + tankIndex + " has " + CheckLoad() + " tons free for loading";
            }
        }
    }
}