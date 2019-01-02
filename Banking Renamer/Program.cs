using System;
using System.Globalization;

namespace Banking_Renamer
{
    class Program
    {
        private const string SearchString_Scotia = "e-Statement";
        private const string SearchString_Tangerine = "Tangerine-Chequing_";
        //public const string RootBankingFolder = "Banking";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var rootDirectory = Directory.GetCurrentDirectory();
            var rootDirectory = args[0];
            var rf = new Renamer(rootDirectory);

            try
            {
                rf.RenameBankFilesRecursivelyExact(SearchString_Scotia);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                var anonymousFunction = new Func<string, DateTime>(s => DateTime.ParseExact(s, "MMMyy", CultureInfo.CurrentCulture));
                rf.RenameBankFilesRecursivelyExact(SearchString_Tangerine, $"*{SearchString_Tangerine}*.pdf", anonymousFunction);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        
    }
}
