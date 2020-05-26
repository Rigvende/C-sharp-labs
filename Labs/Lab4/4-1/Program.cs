using System;
using System.IO;

namespace Labs4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\"); // текущий каталог
            try
            {
                Menu.MakeChoice(ref dir);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error! Wrong file name");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error! Wrong directory name");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }
        }
    }
}
