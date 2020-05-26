using System;
using System.Collections.Generic;
using System.Text;

namespace Labs3
{
    class MenuParametrized
    {
        static int ShowMenu()
        {
            Console.WriteLine("Choose the option from parametrized menu:");
            Console.WriteLine("1 - show list");
            Console.WriteLine("2 - add element");
            Console.WriteLine("3 - add element by index");
            Console.WriteLine("4 - find element from start");
            Console.WriteLine("5 - find element from end");
            Console.WriteLine("6 - delete by index");
            Console.WriteLine("7 - delete by name");
            Console.WriteLine("8 - reverse list");
            Console.WriteLine("9 - sort list");
            Console.WriteLine("10 - call methods of ISound objects");
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

        public static void MakeChoice(ref List<IMove> list)
        {
            int choice = ShowMenu();
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine("----------------------");
                    ShowList(list);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("----------------------");
                    AddElement(ref list);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("----------------------");
                    AddElementByIndex(ref list);
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("----------------------");
                    FindElementFromStart(list);
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("----------------------");
                    FindElementFromEnd(list);
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("----------------------");
                    DeleteElementByIndex(ref list);
                    Console.WriteLine();
                    break;
                case 7:
                    Console.WriteLine("----------------------");
                    DeleteElementByName(ref list);
                    Console.WriteLine();
                    break;
                case 8:
                    Console.WriteLine("----------------------");
                    ReverseList(ref list);
                    Console.WriteLine();
                    break;
                case 9:
                    Console.WriteLine("----------------------");
                    SortList(ref list);
                    Console.WriteLine();
                    break;
                case 10:
                    Console.WriteLine("----------------------");
                    CallMethods(list);
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Wrong number!");
                    MakeChoice(ref list);
                    break;
            }
            MakeChoice(ref list);
        }

        public static void ShowList(List<IMove> list)
        {
            foreach (IMove element in list)
            {
                Console.WriteLine(element.ToString());
            }
        }

        public static void AddElement(ref List<IMove> list)
        {
            Console.Write("Do you want to add [1] ToyCar or [2] PoliceCar? Enter number: ");
            switch (Console.ReadLine())
            {
                case "1":
                    list.Add(new ToyCar());
                    Console.WriteLine("New ToyCar added successfully");
                    break;
                case "2":
                    list.Add(new PoliceCar());
                    Console.WriteLine("New PoliceCar added successfully");
                    break;
                default:
                    Console.WriteLine("Wrong number!");
                    AddElement(ref list);
                    break;
            }
        }

        public static void AddElementByIndex(ref List<IMove> list)
        {
            Console.Write("Do you want to add [1] ToyCar or [2] PoliceCar? Enter number: ");
            switch (Console.ReadLine())
            {
                case "1":
                    AddIndex(ref list, new ToyCar());
                    Console.WriteLine("New ToyCar added successfully");
                    break;
                case "2":
                    AddIndex(ref list, new PoliceCar());
                    Console.WriteLine("New PoliceCar added successfully");
                    break;
                default:
                    Console.WriteLine("Wrong number!");
                    AddElement(ref list);
                    break;
            }
        }

        static void AddIndex(ref List<IMove> list, IMove item)
        {
            Console.Write("Enter index from 0 to {0}: ", list.Count - 1);
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice >= 0 && choice < list.Count)
                {
                    list.Insert(choice, item);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong number!");
                AddIndex(ref list, item);
            }
        }

        public static void FindElementFromStart(List<IMove> list)
        {
            Console.WriteLine("Enter the name of object: ");
            string name = Console.ReadLine();
            IMove item = new ToyCar
            {
                Name = name
            };
            if (list.Contains(item))
            {
                Console.WriteLine("Element is found. Its first index is " + list.IndexOf(item));
                return;
            }
            Console.WriteLine("No such elements are found");
        }

        public static void FindElementFromEnd(List<IMove> list)
        {
            Console.WriteLine("Enter the name of object: ");
            string name = Console.ReadLine();
            IMove item = new ToyCar
            {
                Name = name
            };
            if (list.Contains(item))
            {
                Console.WriteLine("Element is found. Its last index is " + list.LastIndexOf(item));
                return;
            }
            Console.WriteLine("No such elements are found");
        }
        public static void DeleteElementByIndex(ref List<IMove> list)
        {
            Console.Write("Enter index from 0 to {0}: ", list.Count - 1);
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice >= 0 && choice < list.Count)
                {
                    list.RemoveAt(choice);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong number!");
                DeleteElementByIndex(ref list);
            }
        }

        public static void DeleteElementByName(ref List<IMove> list)
        {
            Console.WriteLine("Enter the name of object: ");
            string name = Console.ReadLine();
            IMove item = new ToyCar
            {
                Name = name
            };
            if (!list.Contains(item))
            {
                Console.WriteLine("No such elements are found");
            }
            else
            {
                while (list.Contains(item))
                {
                    list.Remove(item);
                }
                Console.WriteLine("Element with name {0} is deleted", name);
            }
        }

        public static void ReverseList(ref List<IMove> list)
        {
            list.Reverse();
            Console.WriteLine("List is reversed");
        }

        public static void SortList(ref List<IMove> list)
        {
            list.Sort();
            Console.WriteLine("List is sorted.");
        }

        public static void CallMethods(List<IMove> list)
        {
            foreach (IMove element in list)
            {
                if (element is ISound)
                {
                    ((ISound)element).Print();
                    Console.WriteLine(((ISound)element).MakeSound("Bip"));
                }
            }
        }
    }
}
