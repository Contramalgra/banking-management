using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking_Renamer
{
    public class Renamer
    {
        private readonly string rootDirectory;

        public Renamer(string directory)
        {
            rootDirectory = directory;
        }

        public void RenameBankFiles(string oldValue)
        {
            RenameBankFiles(oldValue, $"*{oldValue}*.pdf", DateTime.Parse);
        }
        public void RenameBankFiles(string regex, string searchPattern, Func<string, DateTime> dateParseFunc)
        {
            var files = Directory.GetFiles(rootDirectory, searchPattern, SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var trimmedName = Regex.Replace(Path.GetFileNameWithoutExtension(file), regex, string.Empty).Trim();
                var date = dateParseFunc(trimmedName);

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