using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Banking_Renamer
{
    public class Renamer
    {
        private readonly string rootDirectory;

        public Renamer(string directory)
        {
            rootDirectory = directory;
        }

        public void RenameBankFilesRecursivelyExact(string oldValue)
        {
            RenameBankFilesRecursivelyExact(oldValue, $"*{oldValue}*.pdf", DateTime.Parse);
        }
        public void RenameBankFilesRecursivelyExact(string oldValue, string searchPattern, Func<string, DateTime> parseFunc)
        {
            var files = Directory.GetFiles(rootDirectory, searchPattern, SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var trimmedName = Path.GetFileNameWithoutExtension(file).Replace(oldValue, string.Empty).Trim();
                var date = parseFunc(trimmedName);

                StringBuilder newName = new StringBuilder();
                newName.Append(date.ToString("yyyy-MM MMMM"));

                // Rebuild path
                newName.Append(Path.GetExtension(file));
                var newFile = Path.Combine(Path.GetDirectoryName(file), newName.ToString());
                try
                {
                    File.Move(file, newFile);
                }
                catch (PathTooLongException e)
                {
                    Console.WriteLine(e);
                }
                catch (DirectoryNotFoundException)
                {
                    try
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(newFile));
                        File.Move(file, newFile);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void RenameBankFilesRecursivelyRegex(string oldValue, string searchPattern, Func<string, DateTime> parseFunc)
        {
            var files = Directory.GetFiles(rootDirectory, searchPattern, SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var trimmedName = Path.GetFileNameWithoutExtension(file).Replace(oldValue, string.Empty).Trim();
                var date = parseFunc(trimmedName);

                StringBuilder newName = new StringBuilder();
                newName.Append(date.ToString("yyyy-MM MMMM"));

                // Rebuild path
                newName.Append(Path.GetExtension(file));
                var newFile = Path.Combine(Path.GetDirectoryName(file), newName.ToString());
                try
                {
                    File.Move(file, newFile);
                }
                catch (PathTooLongException e)
                {
                    Console.WriteLine(e);
                }
                catch (DirectoryNotFoundException)
                {
                    try
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(newFile));
                        File.Move(file, newFile);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}