using System;

namespace Labs1_1_var1 
{
    class TankerGo
    {
        
        static void Main (string[] args)
        {
            int[] loading = new int[4];//массив танков для передачи в третий конструктор

            Console.Write("The weight of \"Teodor Nette\" tanks: ");
            Random random = new Random();
            for (int i = 0; i < loading.Length; i++)
            {
                loading[i] = random.Next(100);//заполняем массив рандомом
                Console.Write(loading[i] + " ");
            }
            Console.WriteLine();

            Tanker t1 = new Tanker();//создаём три экземпляра танкеров
            Tanker t2 = new Tanker("\"Admiral Nahimov\"");
            Tanker t3 = new Tanker("\"Teodor Nette\"", loading);

            t1.print();//вызываем печать для каждого
            t2.print();
            t3.print();

            Console.Write("\nSet name for your unknown tanker: ");
            t1.TankerName = Console.ReadLine();//используем сеттер (c проверкой длины имени) и геттер
            Console.WriteLine("Your unknown tanker has had a name: " + t1.TankerName);

            Console.WriteLine("\nIs it true that " + t3.TankerName + " is bigger than " + t1.TankerName + "? - " + t3.isBigger(t1));//сравнение на загруженность

            Tanker t4 = Tanker.returnBiggest(t1, t2, t3);//ищем самый загруженный из трёх танкеров через вызов статического метода
            Console.WriteLine("\nWe have just found the biggest tanker ever! It is " + t4.TankerName);            
        }
    }
}