using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Renamer
{
    public interface IFileFinder
    {
        string SearchPattern { get; set; }
        string SearchRegex { get; set; }
        IDateParser GetDateParser();
    }
}
