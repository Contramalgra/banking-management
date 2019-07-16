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
        private const string SearchString_Brim = @"statement-\w{32}-";
        //private const string SearchString_CIBC = @"CIBC\";

        //public const string RootBankingFolder = "Banking";

        private static void PrintHeader()
        {
            Console.WriteLine(@" _____ _ _        ____                                      ");
            Console.WriteLine(@"|  ___(_) | ___  |  _ \ ___ _ __   __ _ _ __ ___   ___ _ __ ");
            Console.WriteLine(@"| |_  | | |/ _ \ | |_) / _ \ '_ \ / _` | '_ ` _ \ / _ \ '__|");
            Console.WriteLine(@"|  _| | | |  __/ |  _ <  __/ | | | (_| | | | | | |  __/ |   ");
            Console.WriteLine(@"|_|   |_|_|\___| |_| \_\___|_| |_|\__,_|_| |_| |_|\___|_|   ");
            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            PrintHeader();
            var rootDirectory = args.Length > 0 && System.IO.Directory.Exists(args[0]) ? args[0] : System.IO.Directory.GetCurrentDirectory();

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

            // rf.RenameBankFiles(SearchString_RBC, @"RBC\*.pdf", DateTime.Parse, true);

            rf.RenameBankFiles(
                SearchString_Brim,
                @"Brim\statement-*.pdf",
                s => DateTime.ParseExact(s, "yyyyMMdd", CultureInfo.CurrentCulture),
                true
            );

            rf.RenameBankFiles(
                "", //@"^[^-]*$",
                @"CIBC\*.pdf",
                s => DateTime.Parse(s)
            );
        }
    }
}
