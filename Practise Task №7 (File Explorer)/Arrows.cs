using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practise_Task__7__File_Explorer_
{
    public class Arrows
    {
        int min, max, current, number;
        string way;
        string[] AllDirectories, AllFiles;
        public Arrows(int minPos, int maxPos)
        {
            min = minPos;
            max = maxPos;
            current = minPos;
            number = number;
            way = way;
            AllDirectories = AllDirectories;
            AllFiles = AllFiles;
        }
        public static void Position(int min, int max, int current, int number, string way, ref string[] AllDirectories, string[] AllFiles)
        {
            ConsoleKeyInfo Keypressed;
            do
            {
                Console.CursorVisible = false;
                Keypressed = Console.ReadKey();

                if (Keypressed.Key == ConsoleKey.DownArrow)
                {
                    current++;

                    current = current == max ? current = min : current = current;
                }
                else if (Keypressed.Key == ConsoleKey.UpArrow)
                {
                    current--;

                    current = current == min - 1 ? current = max - 1 : current = current;
                }
                else if (Keypressed.Key == ConsoleKey.Escape)
                {
                    if (number == 0)
                    {
                        Environment.Exit(0);
                    }
                    else if (number == 1)
                    {
                        Console.Clear();
                        File_Explorer.Menu_Of_Discs();
                    }
                    else if (number == 2)
                    {
                        Console.Clear();
                        File_Explorer.Root_Folder(current, number);
                    }
                    else
                    {
                        Console.Clear();
                        number -= 2;
                        File_Explorer.ShowMeFOLDERS(way, number);
                    }
                }
                else if (Keypressed.Key == ConsoleKey.F1)
                {
                    Console.SetCursorPosition(84, 8);
                    Console.WriteLine("Введите имя папки:");

                    Console.CursorVisible = true;
                    Console.SetCursorPosition(84, 9);
                    string name = Console.ReadLine();

                    string way2 = way + "\\" + name;
                    Directory.CreateDirectory(way2);
                    File_Explorer.ShowMeFOLDERS(way, number);
                }
                else if (Keypressed.Key == ConsoleKey.F2)
                {
                    Console.SetCursorPosition(84, 8);
                    Console.WriteLine("Введите имя файла:");

                    Console.CursorVisible = true;
                    Console.SetCursorPosition(84, 9);
                    string name = Console.ReadLine();

                    string way2 = way + "\\" + name;
                    File.WriteAllText(way2, "");
                    File_Explorer.ShowMeFOLDERS(way, number);
                }
                else if (Keypressed.Key == ConsoleKey.F3)
                {
                    if (current >= AllDirectories.Count() + 3)
                    {
                        File.Delete(AllFiles[3 + AllDirectories.Count() - current]);
                    }
                    else
                    {
                        Directory.Delete(AllDirectories[current - 3]);
                    }
                    File_Explorer.ShowMeFOLDERS(way, number);
                }
                Console.SetCursorPosition(0, current);
                for (int i = 3; i < max + 1; i++)
                {
                    Console.SetCursorPosition(0, i);
                    if (i == current)
                    {
                        Console.WriteLine(":)");
                    }
                    else
                    {
                        Console.WriteLine("  ");
                    }
                }
                Console.SetCursorPosition(0, current + 1);
            } while (Keypressed.Key != ConsoleKey.Enter);

            if (number == 0)
            {
                File_Explorer.Root_Folder(current, number);
            }
            else
            {
                way = "";
                if (current >= AllDirectories.Count() + 3)
                {
                    way += AllFiles[current - AllDirectories.Count() - 3];
                    Process.Start(new ProcessStartInfo { FileName = way, UseShellExecute = true });
                    Arrows.Position(min, max, current, number, way, ref AllDirectories, AllFiles);
                }
                else
                {
                    way += AllDirectories[current - 3];
                    File_Explorer.ShowMeFOLDERS(way, number);
                }
            }
        }
    }
}
