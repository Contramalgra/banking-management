using System;
using System.Globalization;

namespace Banking_Renamer
{
    class Program
    {
        private const string SearchString_Scotia = "e-Statement";
        private const string SearchString_Tangerine = "Tangerine-Chequing_";
        private const string SearchString_CoastCapital = @"statement-\d+-";
        private const string SearchString_BMO = "eStatement_";
        private const string SearchString_RBC = @"[\dX]+-\w{8,9}-";

        //public const string RootBankingFolder = "Banking";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var rootDirectory = Directory.GetCurrentDirectory();
            var rootDirectory = args[0];
            var rf = new Renamer(rootDirectory);
            
            rf.RenameBankFiles(SearchString_Scotia);
            
            var anonymousFunction = new Func<string, DateTime>(s => DateTime.ParseExact(s, "MMMyy", CultureInfo.CurrentCulture));
            rf.RenameBankFiles(SearchString_Tangerine, anonymousFunction);

            rf.RenameBankFiles(
                SearchString_CoastCapital,
                "*.pdf",
                s => DateTime.ParseExact(s, "yyMMMdd", CultureInfo.CurrentCulture)
            );

            rf.RenameBankFiles(SearchString_BMO, s => DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.CurrentCulture), true);

            rf.RenameBankFiles(SearchString_RBC, "*.pdf", DateTime.Parse, true);
            
        }
    }
}
