using System;

namespace Banking_Renamer
{
    public abstract class Bank : IFileFinder, IDateParser
    {
        public string SearchPattern { get; set; }
        public string SearchRegex { get; set; }
        public abstract DateTime Parse(string date);

        public static string DefaultPdfFormat(string s) => $"*{s}*.pdf";

        public Bank(string searchRegex)
        {
            SearchRegex = searchRegex;
            SearchPattern = DefaultPdfFormat(searchRegex);
        }

        public Bank(string searchRegex, string searchString)
        {
            SearchRegex = searchRegex;
            SearchPattern = searchString;
        }
    }
}
