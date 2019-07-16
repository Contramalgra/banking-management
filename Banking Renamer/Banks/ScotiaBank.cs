using System;
using Banking_Renamer.DateParsers;

namespace Banking_Renamer.Banks
{
    public class ScotiaBank : Bank, IDateParser
    {
        public ScotiaBank(string searchString) : base(searchString)
        {
        }

        public ScotiaBank(string searchRegex, string searchString) : base(searchRegex, searchString)
        {
        }

        public override IDateParser GetDateParser()
        {
            return new ScotiaParser();
        }

        public DateTime Parse(string date)
        {
            return DateTime.Parse(date);
        }
    }
}
