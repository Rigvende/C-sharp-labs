using System.Text;

namespace Labs4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаём тестовый экземпляр
            StringBuilder sb = new StringBuilder("Hello, World!");
            Menu.MakeChoice(sb);
        }
    }
}
