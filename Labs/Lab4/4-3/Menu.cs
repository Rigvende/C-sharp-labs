using System;
using System.Text;

namespace Labs4_3
{
    class Menu
    {
        static int ShowMenu()
        {
            Console.WriteLine("Choose the option from menu:");
            Console.WriteLine("1 - enter new text");
            Console.WriteLine("2 - show text");
            Console.WriteLine("3 - insert * after each chosen character");
            Console.WriteLine("4 - replace character");
            Console.WriteLine("5 - delete chosen substring");
            Console.WriteLine("0 - exit");
            Console.Write("Your choice: ");
            string answer = Console.ReadLine();
            int choice;
            try
            {
                choice = int.Parse(answer);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong number!");
                return ShowMenu();
            }
            return choice;
        }

        public static void MakeChoice(StringBuilder sb)
        {
            int choice = ShowMenu();
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine("----------------------");
                    EnterText(sb);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("----------------------");
                    ShowText(sb);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("----------------------");
                    InsertAsterisk(sb);
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("----------------------");
                    ReplaceCharacter(sb);
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("----------------------");
                    DeleteSubstring(sb);
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Wrong number!");
                    MakeChoice(sb);
                    break;
            }
            MakeChoice(sb);
        }

        static void EnterText(StringBuilder sb)
        {
            Console.Write ("Enter your text: ");
            sb.Clear();
            sb.Append(Console.ReadLine());
        }

        static void ShowText(StringBuilder sb)
        {
            Console.WriteLine(sb);
        }

        static void InsertAsterisk(StringBuilder sb)
        {
            Console.WriteLine("Choose character: ");
            string choice = Console.ReadKey().KeyChar.ToString();
            sb.Replace(choice, choice + "*");
        }

        static void ReplaceCharacter(StringBuilder sb)
        {
            Console.Write("Enter replaced character: ");
            char oldChar = Console.ReadKey().KeyChar;
            Console.Write("\nEnter new character: ");
            char newChar = Console.ReadKey().KeyChar;
            sb.Replace(oldChar, newChar);
        }

        static void DeleteSubstring(StringBuilder sb)
        {
            Console.Write("Enter substring: ");
            string substring = Console.ReadLine();
            sb.Replace(substring, "");
        }
    }
}
