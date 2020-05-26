using System;

namespace Labs1_2_var4
{
    class SquareEquation
    {
        private int a;
        private int b;
        private int c;

        public static int count = 0;

        public int A //сеттер и геттер для переменной а
        {
            get
            {
                return a;
            }
            set
            {
                if (value <= 100 && value >= -100 && value != 0) //проверка свойства 
                {
                    a = value;
                }
                else
                {
                    Console.WriteLine("\nWarning! Your number " + value + " for A has incorrect meaning. Your A stayed previous: " + A + ".\n~ ~ ~ ~ ~ ~ ~ ~");
                }
            }
        }
        public int B //сеттер и геттер для переменной b
        {
            get
            {
                return b;
            }
            set
            {
                if (value <= 100 && value >= -100) //проверка свойства 
                {
                    b = value;
                }
                else
                {
                    Console.WriteLine("\nWarning! Your number " + value + " for B has incorrect meaning. Your B stayed previous: " + B + ".\n~ ~ ~ ~ ~ ~ ~ ~");
                }
            }
        }
        public int C //сеттер и геттер для переменной с
        {
            get
            {
                return c;
            }
            set
            {
                if (value <= 100 && value >= -100) //проверка свойства 
                {
                    c = value;
                }
                else
                {
                    Console.WriteLine("\nWarning! Your number " + value + " for C has incorrect meaning. Your C stayed previous: " + C + ".\n~ ~ ~ ~ ~ ~ ~ ~");
                }
            }
        }

        public SquareEquation() : this(1, 0, 0) //конструктор 1 с цепочкой
        {
        }
        public SquareEquation(int a) : this(a, 0, 0) //конструктор 2 с цепочкой
        {
        }
        public SquareEquation(int a, int b) : this(a, b, 0) //конструктор 3 с цепочкой
        {
        }
        public SquareEquation(int a, int b, int c) //конструктор 4
        {
            if (a != 0)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                Console.WriteLine("New square equation is created!\nf(x) = " + ToString());
            }
            else
            {
                Console.WriteLine("Warning! A = 0, your equation is not square.\n~ ~ ~ ~ ~ ~ ~ ~ ~");
            }
        }

        public static SquareEquation operator ++ (SquareEquation se)//перегруженный оператор инкремента
        {
            se.a++;
            se.b++;
            se.c++;
            return se;
        }

        public static SquareEquation operator -- (SquareEquation se)//перегруженный оператор декремента
        {
            se.a--;
            se.b--;
            se.c--;
            return se;
        }

        public static SquareEquation operator - (SquareEquation se1, SquareEquation se2)//перегруженный оператор минус
        {
            SquareEquation se = new SquareEquation();
            se.a = se1.a - se2.a;
            se.b = se1.b - se2.b;
            se.c = se1.c - se2.c;
            return se;
        }

        public static SquareEquation operator + (SquareEquation se1, SquareEquation se2)//перегруженный оператор плюс
        {
            SquareEquation se = new SquareEquation();
            se.a = se1.a + se2.a;
            se.b = se1.b + se2.b;
            se.c = se1.c + se2.c;
            return se;
        }

        public static SquareEquation operator * (SquareEquation se1, int i)//перегруженный оператор умножить на число
        {
            SquareEquation se = new SquareEquation();
            se.a = se1.a * i;
            se.b = se1.b * i;
            se.c = se1.c * i;
            return se;
        }

        public static SquareEquation operator / (SquareEquation se1, int i)//перегруженный оператор делить на число
        {
            SquareEquation se = new SquareEquation();
            if (i != 0)
            {
                se.a = se1.a / i;
                se.b = se1.b / i;
                se.c = se1.c / i;
                return se;
            }
            else
            {
                Console.WriteLine("Division by zero!");
                return null;
            }
        }
        
        public static bool operator == (SquareEquation se1, SquareEquation se2)//перегруженный оператор равно
        {
            return se1.A == se2.A && se1.B == se2.B && se1.C == se2.C;
        }

        
        public static bool operator != (SquareEquation se1, SquareEquation se2)//перегруженный оператор не равно
        {
            return se1.A != se2.A || se1.B != se2.B || se1.C != se2.C;
        }

        
        public static bool operator true (SquareEquation se1)//перегруженный оператор true
        {
            return se1.A != 0;
        }

        
        public static bool operator false (SquareEquation se1)//перегруженный оператор false
        {
            return se1.A == 0;
        }

        
        public static explicit operator int (SquareEquation se1)//явное преобразование типа класса к int
        {
            return se1.A;
        }

        
        public static explicit operator SquareEquation(int i)//явное преобразование int к типу класса
        {
            return new SquareEquation(i, i, i);
        }
                
        public override string ToString()//перегрузка метода toString
        {
            return this.A + "x^2 + " + this.B + "x + " + this.C;
        }

        public void print()//вывод информации
        {
            ++count;
            Console.WriteLine("\n-------------\nEquation # " + count + "\n-------------");
            Console.WriteLine("f(x) = " + ToString());
            findDiscriminant();
            Console.WriteLine();
        }
                   
        private double findRoots(int a, int b, int c)//нахождение корней уравнения
        {
            double discriminant;
            discriminant = (b * b) - (4 * a * c); 
            return discriminant;
        }

        private void findDiscriminant()
        {
            double x1;
            double x2;
            double discriminant = findRoots(A, B, C);
            Console.WriteLine("Discriminant = " + discriminant);
            if (discriminant == 0)
            {
                x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("x = " + x1);
            }
            else if (discriminant > 0)
            {
                x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("x1 = " + x1);
                Console.WriteLine("x2 = " + x2);
            }
            else
            {
                Console.WriteLine("Equation has no roots.");
            }
        }
    }
}