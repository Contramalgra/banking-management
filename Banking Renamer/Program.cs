using System;
using System.Globalization;
using Banking_Renamer.Banks;

namespace Banking_Renamer
{
    class Program
    {
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

            rf.RenameBankFiles(new Scotia());
            rf.RenameBankFiles(new Tangerine());
            rf.RenameBankFiles(new CoastCapitalSavings());            
            rf.RenameBankFiles(new BMO(), true);
            rf.RenameBankFiles(new RBC(), true);
            rf.RenameBankFiles(new BRIM(), true);
            rf.RenameBankFiles(new GenericBank("CIBC"));
        }
    }
}
