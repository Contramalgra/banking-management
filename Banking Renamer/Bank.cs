using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Renamer
{
    public abstract class Bank : IFileFinder
    {
        public string SearchPattern { get; set; }
        public string SearchRegex { get; set; }
        //protected IDateParser dateParser;
        public abstract IDateParser GetDateParser();
        //public Renamer FolderRenamer { get; set; }

        public Bank(string searchRegex)
        {
            SearchRegex = searchRegex;
            SearchPattern = $"*{SearchRegex}*.pdf";
        }

        public Bank(string searchRegex, string searchString)
        {
            SearchRegex = searchRegex;
            SearchPattern = searchString;
        }
    }
}
