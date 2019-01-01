using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Banking_Renamer
{
    class Program
    {
        //public const string RootBankingFolder = "Banking";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var rootDirectory = Directory.GetCurrentDirectory();
            var rootDirectory = args[0];

            // Scotia
            var files = Directory.GetFiles(rootDirectory, "*e-Statement*.pdf", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                string directoryName = Path.GetDirectoryName(file);

                StringBuilder newName = new StringBuilder();
                var currentNameNoExt = Path.GetFileNameWithoutExtension(file);
                var trimmedName = currentNameNoExt.Replace("e-Statement", string.Empty).Trim();
                var date = DateTime.Parse(trimmedName);

                newName.Append(date.ToString("yyyy-MM MMMM"));

                // Rebuild path
                newName.Append(Path.GetExtension(file));
                var newFile = Path.Combine(directoryName, newName.ToString());
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
