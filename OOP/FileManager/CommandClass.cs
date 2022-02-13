using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Configuration;

namespace FileManager
{
    public class CommandClass
    {
        public CommandClass()
        {
            int lines = Convert.ToInt32(ConfigurationManager.AppSettings.Get("linesOnPage")); //получаем из конфига количество строк на странице с деревом каталогов.

            // отображаем дерево каталогов для диска С, при первом запуске
            string workDir = Directory.GetCurrentDirectory();
            string filename = "catalog.txt";
            WritePathTreeToTheFile(workDir, filename);

            var linesInFile = File.ReadAllLines(filename);
            var pages = linesInFile.Length / lines;
            List<string> commands = new();
            commands.Add(workDir);

            PrintSelectedPageOfTreeCatalog(1, pages, lines, linesInFile);
            PaginationOfCataloAndCommandHistory(pages, linesInFile, 1, lines);
            ExecuteCommandFromCommandLine(workDir, filename, lines, commands);
        }

        private static void ExecuteCommandFromCommandLine(string workDir, string filename, int lines, List<string> commands)
        {
            File.Delete(filename); //удаляем файл если он существует от предыдущих запросов
            do
            {
                Console.WriteLine("enter command");
                string command = Console.ReadLine();
                commands.Add(command);
                string[] commandLine = command.Split(' ');
                if (commandLine.Length == 1)
                {
                    Console.WriteLine("Please enter correct command and Path");
                }
                else
                {
                    string element = workDir + @"\" + commandLine[1];
                    switch (commandLine[0].ToLower())
                    {
                        case "cd":
                            try
                            {
                                WritePathTreeToTheFile(commandLine[1], filename);
                                var linesInFile1 = File.ReadAllLines(filename);
                                var pages = linesInFile1.Length / lines;
                                var page = 1;
                                PrintSelectedPageOfTreeCatalog(page, pages, lines, linesInFile1);
                                PaginationOfCataloAndCommandHistory(pages, linesInFile1, page, lines);
                                workDir = commandLine[1];
                                ExecuteCommandFromCommandLine(workDir, filename, lines, commands);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }break;

                        //Files
                        case "add":
                            FileCommands.Add(element);
                            break;

                        case "rm":
                            FileCommands.Remove(element);
                            break;

                        case "i":
                            FileCommands.GetInfo(element);
                            break;

                        case "copy":
                            FileCommands.Copy(element, commandLine[2]);
                            break;

                        case "move":
                            FileCommands.Copy(element, commandLine[2]);
                            break;

                        case "rename":
                            FileCommands.Rename(workDir + @"\", commandLine[1], commandLine[2]);
                            break;
                        
                        //Directories
                        case "mkdir":
                            DirCommands.Add(element);
                            break;

                        case "rmdir":
                            DirCommands.Remove(element);
                            break;

                        case "idir":
                            DirCommands.GetInfo(element);
                            break;

                        case "cpdir":
                            DirCommands.Copy(element, commandLine[2]);
                            break;

                        case "renamedir":
                            DirCommands.Rename(element, commandLine[2]);
                            break;

                        case "movepdir":
                            DirCommands.Move(element, commandLine[2]);
                            break;

                        default:
                            Console.WriteLine($"Couldn't fined command {commandLine[0]}. Please check that you use one of this: cd, add, rm, inf, mkdir, rmdir, infdir.");
                            break;
                    }
                }
            } while (!File.Exists(filename));
        }

        private static void WritePathTreeToTheFile(string directory, string filename)  //Данный метод создает при необходимости файл и записывает в него дерево подкаталогов и файлов.
        {
            try
            {
                var catalogElement = Directory.GetFileSystemEntries(directory);  //Получаем список подкатологов и файлов в директории
                File.WriteAllText(filename, directory);    // записываем в файл строку c введенной директорией и перенос строки
                File.AppendAllText(filename, Environment.NewLine);


                foreach (var i in catalogElement) //записываем в файл строки для каждого подкаталога и файла 
                {
                    try
                    {
                        var elementsInPath = Directory.GetFileSystemEntries(i);
                        File.AppendAllLines(filename, new[] { "  |  ", "  " + i.Replace("C:\\", "|--") });
                        foreach (var j in elementsInPath)
                        {
                            try
                            {
                                File.AppendAllLines(filename, new[] { "  " + j.Replace((i + "\\"), "|  |--") });
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintSelectedPageOfTreeCatalog(int page, int pages, int lines, string[] linesInFile)
        {
            Console.Clear();
            ConsoleRules();
            if (pages == 0)
            {
                foreach (var item in linesInFile)
                {
                    Console.WriteLine(item);
                }
            }
            else if (page < pages + 1)
            {
                for (int i = lines * (page - 1); i < lines * page; i++)
                {
                    Console.WriteLine(linesInFile[i]);
                }
            }
            else
            {
                Console.WriteLine($"Check your code. You use page number more that {pages}");
            }
            Console.WriteLine("-----------------------------------------------------");
        }

        private static void PaginationOfCataloAndCommandHistory(int pages, string[] linesInFile, int page, int lines)
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.RightArrow & page < pages)
                {
                    page++;
                    PrintSelectedPageOfTreeCatalog(page, pages, lines, linesInFile);
                }
                else if (key == ConsoleKey.LeftArrow & page != 1)
                {
                    page--;
                    PrintSelectedPageOfTreeCatalog(page, pages, lines, linesInFile);
                }
                else if (key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    PrintSelectedPageOfTreeCatalog(page, pages, lines, linesInFile);
                }
            } while (key != ConsoleKey.Escape);
            if (key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

        private static void ConsoleRules()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("|  KEY              |  ACTION                                              |");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("|LEFT/RIGHT ARROW   | listing catalog to the left.                         |");
            Console.WriteLine("|UP/DOWN ARROW      | command history.Works only on active command line    |");
            Console.WriteLine("|ENTER              | enter in command line.                               |");
            Console.WriteLine("|ESC                | exit.                                                |");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("|Commands for files: add, rm, copy, i, rename, move.                       |");
            Console.WriteLine("|Commands for directories: mkdir, rmdir, cpdir, idir, renamedir, movepdir. |");
            Console.WriteLine("|Use command cd PATH for listing catalog.                                  |");
            Console.WriteLine("----------------------------------------------------------------------------");
        }
    }
}
