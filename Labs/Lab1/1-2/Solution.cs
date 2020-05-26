using System;

namespace Labs1_2_var4
{
    class Solution
    {
        static void Main (string [] args)
        {

            SquareEquation se1 = new SquareEquation();
            se1.A = 7;
            Console.WriteLine("A is changed: " + se1.A);
            se1.print();

            SquareEquation se2 = new SquareEquation(99);
            se2.A = 0;
            se2.print();

            SquareEquation se3 = new SquareEquation(0, 5);
            se3.A = -1;
            Console.WriteLine("C is changed: " + se3.C);
            se3.print();

            SquareEquation se4 = new SquareEquation(24, 7, -8);
            se4.A = 25;
            se4.B = 10;
            se4.C = 200;
            Console.WriteLine("A, B and C are changed: " + se4.A + ", " + se4.B + " and " + se4.C);
            se4.print();

            int ten = 10;
            SquareEquation se5 = se4 / ten;
            Console.Write("\n~ Overloaded /  :");
            se5.print();

            se5++;
            Console.Write("~ Overloaded ++  :");
            se5.print();

            se5 = se4 * 2;
            Console.Write("\n~ Overloaded *  :");
            se5.print();

            se5--;
            Console.Write("~ Overloaded --  :");
            se5.print();

            se5 = se3 + se4;
            Console.Write("\n~ Overloaded +  :");
            se5.print();

            se5 = se4 - se2;
            Console.Write("\n~ Overloaded - :");
            se5.print();

            Console.WriteLine("~ Overloaded ==  :");
            Console.WriteLine(se3 + " и " + se3 + " " + (se3 == se3 ? "are equal" : "are not equal"));
            Console.WriteLine();

            Console.WriteLine("~ Overloaded !=  :");
            Console.WriteLine(se5 + " и " + se4 + " " + (se5 != se4 ? "are not equal" : "are equal"));
            Console.WriteLine();

            string notZero = "is true because A is not equal to zero";
            string zero = "is false because A is equal to zero";
            Console.WriteLine("~ Overloaded true  :");
            Console.WriteLine(se1 + " " + (se1 ? notZero : zero));
            Console.WriteLine();

            Console.WriteLine("~ Overloaded false  :");
            Console.WriteLine(se1 + " / " + ten + " " + (se1 / 10 ? notZero : zero));
            Console.WriteLine();

            Console.WriteLine("~ Explicit type transformation  :");
            Console.WriteLine(se5 + " - object's A is changed to int type: " + (int)se5);
            Console.WriteLine("Number " + ten + " is changed from int type to SquareEquation type: " + (SquareEquation)ten);
        }
    }
}