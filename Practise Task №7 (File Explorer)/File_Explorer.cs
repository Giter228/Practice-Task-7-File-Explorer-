using System.IO;

namespace Practise_Task__7__File_Explorer_
{
    public class File_Explorer
    {
        public static DriveInfo[] AllDiscs = DriveInfo.GetDrives();
        public static int minPos = 3;
        public static int maxPos;
        public static int currentPos = minPos;
        public static string way;
        public static void Menu_Of_Discs()
        {
            int number = 0;

            Console.SetCursorPosition(50, 0);
            Console.WriteLine("~ Этот компьютер");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Выбор диска:");


            foreach (DriveInfo disc in AllDiscs)
            {
                Console.Write("  {0}", disc.Name);
                Console.WriteLine(" Свободно {0} ГБ из {1} ГБ", (disc.AvailableFreeSpace / 1073741824), (disc.TotalSize / 1073741824));
            }

            string[] ladno = Directory.GetFiles("C:\\"); // просто чтобы было
            string[] ladno2 = Directory.GetFiles("C:\\"); // просто чтобы было

            maxPos = AllDiscs.Count() + minPos;
            Arrows.Position(minPos, maxPos, currentPos, number, way, ref ladno, ladno2);
        }
        public static void Root_Folder(int current, int number)
        {
            number = 1;
            int i = 3;
            foreach (DriveInfo disc in AllDiscs)
            {
                if (i == current)
                {
                    way = "";

                    Console.Clear();
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine($"~ Папка {way}"); ;
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t" + "Название" + "\t\t\t" + "Дата создания" + "\t\t" + "Тип");

                    string[] AllDirectories = Directory.GetDirectories(disc.Name);
                    int x = 0;
                    foreach (string directory in AllDirectories)
                    {
                        string[] directories = directory.Split("\\");
                        Console.Write("  " + directories[1]);
                        Console.SetCursorPosition(38, x + 3);
                        Console.Write(Directory.GetCreationTime(AllDirectories[x]));

                        string[] format_of_directories = directory.Split(".");
                        Console.SetCursorPosition(63, x + 3);
                        string format = "." + format_of_directories[format_of_directories.Count() - 1];
                        if (directories[directories.Count() - 1].Contains("."))
                        {
                            Console.WriteLine(format);
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                        x++;

                    }

                    string[] AllFiles = Directory.GetFiles(disc.Name);
                    x = 0;
                    foreach (string file in AllFiles)
                    {
                        string[] files = file.Split("\\");
                        Console.SetCursorPosition(0, 3 + AllDirectories.Count() + x);
                        Console.Write("  " + files[1]);
                        Console.SetCursorPosition(38, 3 + AllDirectories.Count() + x);
                        Console.WriteLine(Directory.GetCreationTime(AllFiles[x]));

                        string[] format_of_files = file.Split(".");
                        Console.SetCursorPosition(63, 3 + AllDirectories.Count() + x);
                        string format = "." + format_of_files[format_of_files.Count() - 1];
                        if (files[files.Count() - 1].Contains("."))
                        {
                            Console.WriteLine(format);
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                        x++;
                    }

                    Functions(AllDirectories, AllFiles);
                    maxPos = 3 + AllDirectories.Count() + AllFiles.Count();
                    Arrows.Position(minPos, maxPos, currentPos, number, way, ref AllDirectories, AllFiles);
                }
                i++;
            }
        }
        public static void ShowMeFOLDERS(string way, int number)
        {
            number++;

            Console.Clear();
            Console.SetCursorPosition(50, 0);
            string[] WhatIS_theFolder = way.Split("\\");

            Console.WriteLine($"~ Папка {WhatIS_theFolder[WhatIS_theFolder.Count() - 1]}"); ;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t" + "Название" + "\t\t\t" + "Дата создания" + "\t\t" + "Тип");

            string[] AllDirectories = Directory.GetDirectories(way);
            int x = 0;
            foreach (string directory in AllDirectories)
            {
                string[] directories = directory.Split("\\");
                Console.Write("  " + directories[directories.Count() - 1]);

                Console.SetCursorPosition(38, x + 3);
                Console.Write(Directory.GetCreationTime(AllDirectories[x]));

                string[] format_of_directories = directory.Split(".");
                Console.SetCursorPosition(63, x + 3);
                string format = "." + format_of_directories[format_of_directories.Count() - 1];
                if (directories[directories.Count() - 1].Contains("."))
                {
                    Console.WriteLine(format);
                }
                else
                {
                    Console.WriteLine("");
                }
                x++;
            }

            string[] AllFiles = Directory.GetFiles(way);
            x = 0;
            foreach (string file in AllFiles)
            {
                string[] files = file.Split("\\");
                Console.SetCursorPosition(0, 3 + AllDirectories.Count() + x);
                Console.Write("  " + files[files.Count() - 1]);

                Console.SetCursorPosition(38, 3 + AllDirectories.Count() + x);
                Console.WriteLine(Directory.GetCreationTime(AllFiles[x]));

                string[] format_of_files = file.Split(".");
                Console.SetCursorPosition(63, 3 + AllDirectories.Count() + x);
                string format = "." + format_of_files[format_of_files.Count() - 1];
                if (files[files.Count() - 1].Contains("."))
                {
                    Console.WriteLine(format);
                }
                else
                {
                    Console.WriteLine("");
                }
                x++;
            }

            Functions(AllDirectories, AllFiles);
            maxPos = 3 + AllDirectories.Count() + AllFiles.Count();
            Arrows.Position(minPos, maxPos, currentPos, number, way, ref AllDirectories, AllFiles);

        }
        public static int Functions(string[] AllDirectories, string[] AllFiles)
        {
            for (int p = 3; p < 3 + AllDirectories.Count() + AllFiles.Count(); p++)
            {
                Console.SetCursorPosition(82, p);
                Console.WriteLine("|");
                if (p == 3)
                {
                    Console.SetCursorPosition(84, p);
                    Console.WriteLine("F1 - Создать папку");
                }
                else if (p == 4)
                {
                    Console.SetCursorPosition(84, p);
                    Console.WriteLine("F2 - Создать файл");
                }
                else if (p == 5)
                {
                    Console.SetCursorPosition(84, p);
                    Console.WriteLine("F3 - Удалить");
                    Console.SetCursorPosition(83, p + 1);
                    Console.WriteLine("--------------------------------");
                }
            }
            return 0;
        }
    }
}
