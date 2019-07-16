using System;

namespace Banking_Renamer.DateParsers
{
    public class ScotiaParser : IDateParser
    {
        public DateTime Parse(string date)
        {
            return DateTime.Parse(date);
        }
    }
}
