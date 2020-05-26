using System;

namespace Labs2_1_var4
{
    class Logistics
    {
        static void Main(string [] args)
        {
            Tanker tanker1 = new Tanker("\"Yacht Beda\"", new int[] { 10, 20, 20, 30 }, 5);
            tanker1.CurrentVolume = new int[] { 10, 20, 90, 30, 80 };
            tanker1.Print();

            Tanker tanker2 = new Tanker("Admiral Nahimov");

            Tank tank1 = new Tank();
            Tank tank2 = new Tank(tanker1, 2, 200);
            Tank tank3 = new Tank(tanker2, 3, 250);
            Console.WriteLine("\n" + tank1.ToString());
            Console.WriteLine(tank2.ToString());
            Console.WriteLine(tank3.ToString());

            Tank[] tanks = new Tank [] { tank1, tank3 };

            tanker2.Tanks = tanks;
            tanker2.Print();


            Tanker[] tankers = new Tanker[4];
            tankers[0] = tanker1;
            tankers[1] = tanker2;

            Port port = new Port("Bristol", tankers);
            Console.WriteLine("\n" + port.ToString());

            port.tankers[1] = null;
            Console.WriteLine("\n" + port.ToString());
        }
    }
}