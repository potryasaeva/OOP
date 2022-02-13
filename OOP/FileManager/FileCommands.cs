using System;
using System.IO;

namespace FileManager
{
    public abstract class FileCommands : Commands
    {
        public FileCommands()
        {
        }

        public static void Add(string path) {
            try
            {
                FileStream fileStream = File.Create(path);
                Console.WriteLine($"File {path} is created");
                fileStream.Close();
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }

        public static void Remove(string path)
        {
            try
            {
                File.Delete(path);
                Console.WriteLine($"File {path} is deleted");
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
                Console.WriteLine($"File attribute - {File.GetAttributes(path)}; Creation time - {File.GetCreationTime(path)}; Last access time - {File.GetLastAccessTime(path)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public static void Rename(string path, string oldName, string newName)
        {
            try
            {
                File.Move(path+oldName, path + newName);
                Console.WriteLine($"File {oldName} is renamed to {newName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Copy(string path, string toDir)
        {
            try
            {
                File.Copy(path, toDir);
                Console.WriteLine($"File {path} is copied to {toDir}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Move(string path, string toDir)
        {
            try
            {
                File.Move(path, toDir);
                Console.WriteLine($"File {path} is moved to {toDir}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
