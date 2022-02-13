using System;
using System.IO;

namespace FileManager
{
    public abstract class DirCommands : Commands
    {
        public DirCommands()
        {
        }

        public static void Add(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"Directory {path} is created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public static void Remove(string path)
        {
            try
            {
                Directory.Delete(path);
                Console.WriteLine($"Directory {path} is deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void GetInfo(string path)
        {
            try
            {
                Console.WriteLine($"Directory root - {Directory.GetDirectoryRoot(path)}; Creation time - {Directory.GetCreationTime(path)}; Last access time - {Directory.GetLastAccessTime(path)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Rename(string oldName, string newName)
        {
            Move(oldName, newName);
            Remove(oldName);
        }

        public static void Copy(string sourceDir, string toDir, bool recursive = true)
        {
            try
            {
                var dir = new DirectoryInfo(sourceDir);

                if (!dir.Exists)
                    throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

                DirectoryInfo[] dirs = dir.GetDirectories();

                Directory.CreateDirectory(toDir);

                foreach (FileInfo file in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine(toDir, file.Name);
                    file.CopyTo(targetFilePath);
                }

                if (recursive)
                {
                    foreach (DirectoryInfo subDir in dirs)
                    {
                        string newDestinationDir = Path.Combine(toDir, subDir.Name);
                        Copy(subDir.FullName, newDestinationDir, true);
                    }
                }
                Console.WriteLine($"Directory {sourceDir} is copied to {toDir}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Move(string sourceDir, string toDir)
        {
            try
            {
                Copy(sourceDir, toDir);
                Remove(sourceDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
