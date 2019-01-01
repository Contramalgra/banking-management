using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Banking_Renamer
{
    class Program
    {
        public const string RootBankingFolder = "Banking";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var rootDirectory = Directory.GetCurrentDirectory();

            // Scotia
            var files = Directory.GetFiles(rootDirectory, "*e-Statement*.pdf", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                string directoryName = Path.GetDirectoryName(file);
                var arrDirectories = directoryName.Split('\\').ToList();

                StringBuilder newName = new StringBuilder();
                var currentNameNoExt = Path.GetFileNameWithoutExtension(file);
                var trimmedName = currentNameNoExt.Replace("e-Statement", string.Empty).Trim();
                var date = DateTime.Parse(trimmedName);

                newName.Append(date.ToString("yyyy-MM MMMM"));

                var bankingIndex = arrDirectories.FindLastIndex(s => s.Equals(RootBankingFolder, StringComparison.CurrentCultureIgnoreCase));
                // /**/Banking/Scotia/Chequing/
                if (bankingIndex == arrDirectories.Count - 3)
                {
                    newName.Append($" {arrDirectories[arrDirectories.Count - 2]} {arrDirectories[arrDirectories.Count - 1]}");
                }

                // Rebuild path
                newName.Append(Path.GetExtension(file));
                var newFile = Path.Combine(directoryName, newName.ToString());
                try
                {
                    File.Move(file, newFile);
                }
                catch (PathTooLongException)
                {
                    //
                }
                catch (DirectoryNotFoundException)
                {
                }
                catch (IOException)
                {

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
