using System;
using System.IO;

namespace Labs4_1
{
    class Menu
    {
        static int ShowMenu()
        {
            Console.WriteLine("Choose the option from menu:");
            Console.WriteLine("1 - set a current disc/directory");
            Console.WriteLine("2 - show list of all directories in the current directory");
            Console.WriteLine("3 - show list of all files in the current directory");
            Console.WriteLine("4 - show a chosen text file");
            Console.WriteLine("5 - create directory in the current directory");
            Console.WriteLine("6 - delete directory by index if it's empty");
            Console.WriteLine("7 - delete chosen files by indices");
            Console.WriteLine("8 - find list of files by date of creation");
            Console.WriteLine("9 - find list of text files with chosen text");
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

        public static void MakeChoice(ref DirectoryInfo dir)
        {
            int choice = ShowMenu();
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine("----------------------");
                    SetDirectory(ref dir);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("----------------------");
                    ShowListOfDirs(dir);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("----------------------");
                    ShowListOfFiles(dir);
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("----------------------");
                    ShowTextFileByIndex(dir);
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("----------------------");
                    CreateDirInCurrent(dir);
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("----------------------");
                    DeleteDirByIndex(dir);
                    Console.WriteLine();
                    break;
                case 7:
                    Console.WriteLine("----------------------");
                    DeleteFileByIndex(dir);
                    Console.WriteLine();
                    break;
                case 8:
                    Console.WriteLine("----------------------");
                    FindFilesByCreationDate(dir);
                    Console.WriteLine();
                    break;
                case 9:
                    Console.WriteLine("----------------------");
                    FindFilesByText(dir);
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Wrong number!");
                    MakeChoice(ref dir);
                    break;
            }
            MakeChoice(ref dir);
        }

        static void SetDirectory(ref DirectoryInfo dir)
        {
            Console.Write("Enter absolute path to directory: ");
            string path = Console.ReadLine();
            if (path[^1] != '\\')
            {
                path += '\\';
            }
            DirectoryInfo directory = new DirectoryInfo(@path);
            if (!directory.Exists)
            {
                Console.WriteLine("Wrong path!");
                return;
            }
            dir = directory;
        }

        static void ShowListOfDirs(DirectoryInfo dir)
        {
            int index = 0;
            DirectoryInfo[] directories = dir.GetDirectories("*");
            foreach (DirectoryInfo directory in directories)
            {
                Console.WriteLine(++index + " - " + directory.Name);
            }
        }

        static void ShowListOfFiles(DirectoryInfo dir)
        {
            int index = 0;
            FileInfo[] files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in files)
            {
                Console.WriteLine(++index + " - " + file.DirectoryName + "\\" + file.Name);
            }
        }

        static void ShowTextFileByIndex(DirectoryInfo dir)
        {
            ShowListOfFiles(dir);
            Console.Write("Enter the index of file: ");
            string index = Console.ReadLine();
            int choice = -1;
            try
            {
                choice = int.Parse(index) - 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong index!");
                ShowTextFileByIndex(dir);
            }
            FileInfo[] files = dir.GetFiles();
            if (choice >= 0 && choice < files.Length)
            {
                
                if (files[choice].Extension != ".txt")
                {
                    Console.WriteLine("Not a text file!");
                    return;
                }
                StreamReader sr = new StreamReader(files[choice].FullName);
                string text = sr.ReadToEnd();
                Console.WriteLine(text);
                sr.Close();
            } 
            else
            {
                Console.WriteLine("Wrong index!");
            }
        }

        static void CreateDirInCurrent(DirectoryInfo dir)
        {
            Console.Write("Enter a new dir's name: ");
            string name = Console.ReadLine();
            if (name.Length > 0)
            {
                dir.CreateSubdirectory(name);
                Console.WriteLine("Directory " + name + " is created successful");
            }
            else
            {
                Console.WriteLine("Empty name");
            }
        }

        static void DeleteDirByIndex(DirectoryInfo dir)
        {
            ShowListOfDirs(dir);
            Console.Write("Enter the name of the empty directory: ");
            string index = Console.ReadLine();
            int choice = 0;
            try
            {
                choice = int.Parse(index) - 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong index!");
                DeleteDirByIndex(dir);
            }
            DirectoryInfo[] directories = dir.GetDirectories("*");
            if (choice < 0 || choice >= directories.Length)
            {
                Console.WriteLine("Wrong index!");
                return;
            }
            else if (directories[choice].GetFiles().Length > 0 || directories[choice].GetDirectories().Length > 0)
            {
                Console.WriteLine("This directory is not empty!");
                return;
            }
            else
            {
                directories[choice].Delete();
                Console.WriteLine("Empty directory is deleted successful");
            }
        }

        static void DeleteFileByIndex(DirectoryInfo dir)
        {
            ShowListOfFiles(dir);
            Console.Write("Enter the index of the file: ");
            string index = Console.ReadLine();
            int choice = 0;
            try
            {
                choice = int.Parse(index) - 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong index!");
                DeleteFileByIndex(dir);
            }
            FileInfo[] files = dir.GetFiles();
            if (choice < 0 || choice >= files.Length)
            {
                Console.WriteLine("Wrong index!");
                return;
            }
            else
            {
                files[choice].Delete();
                Console.WriteLine("File with index {0} is deleted successful", choice);
            }
        }

        static void FindFilesByCreationDate(DirectoryInfo dir)
        {
            Console.Write("Enter the date of creation: ");
            DateTime chosenDate = DateTime.Now;
            try 
            {
                chosenDate = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong date!");
                FindFilesByCreationDate(dir);
            }
            if (chosenDate > DateTime.Now)
            {
                Console.WriteLine("Wrong date!");
                return;
            }
            FileInfo[] files = dir.GetFiles("*", SearchOption.AllDirectories);
            int index = 0;
            foreach (FileInfo file in files)
            {
                if (file.CreationTime.Date == chosenDate.Date)
                {
                    Console.WriteLine(++index + " - " + file.DirectoryName + "\\" + file.Name);
                }
            }
        }

        static void FindFilesByText(DirectoryInfo dir)
        {
            Console.Write("Enter text for search: ");
            string text = Console.ReadLine();
            FileInfo[] files = dir.GetFiles("*", SearchOption.AllDirectories);
            int index = 0;
            foreach (FileInfo file in files)
            {
                if (file.Extension != ".txt")
                {
                    continue;
                }
                StreamReader sr = new StreamReader(file.FullName);
                string fileText = sr.ReadToEnd();
                if (fileText.Contains(text))
                {
                    Console.WriteLine(++index + ")" + file.DirectoryName + "\\" + file.Name);
                }
            }
        }
    }
}
