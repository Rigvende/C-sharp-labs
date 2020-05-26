using System;

namespace Labs3
{
    class Doll : ISound
    {
        string dressColour;
        string name;

        public string DressColour
        {
            get
            {
                return dressColour;
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    dressColour = "no";
                }
                else
                {
                    dressColour = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    name = "unknown";
                }
                else
                {
                    name = value;
                }
            }
        }

        public Doll() : this("unknown", "no") {
        }
        public Doll (string name, string dressColour)
        {
            DressColour = dressColour;
            Name = name;
        }

        public string MakeSound(string sound)
        {
            return "The doll makes sound: " + sound;
        }

        public void Print()
        {
            Console.WriteLine("The doll name is {0} and it has a {1} dress", name, dressColour);
        }
    }
}