using System;

namespace Labs2_1_var4
{
    class Port
    {
        string city;//населённый пункт, где находится порт
        public Tanker [] tankers;//массив танкеров в порту (для агрегации)

        //конструкторы:
        public Port()
        {
            city = "Unknown city";
        }
        public Port (string city, Tanker[] tankers)
        {
            this.tankers = tankers;
            this.city = city;
        }

        //свойства для закрытых полей:
        public string City 
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        
        //метод, определяющий количество танкеров в порту:
        public int GetTankersCount()
        {
            int count = 0;
            foreach (Tanker t in tankers)
            {
                if (t != null)
                {
                    count++;
                }
            }
            return count;
        }

        //переписываем toString:
        public override string ToString()
        {
            return "Port in " + city + " has " + GetTankersCount() + " tanker(s) now";
        }
    }
}