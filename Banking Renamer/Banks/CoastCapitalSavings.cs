using System;
using System.Globalization;

namespace Banking_Renamer.Banks
{
    class CoastCapitalSavings : Bank
    {
        public CoastCapitalSavings() : base(@"statement-\d+-", "*.pdf")
        {
        }

        public override DateTime Parse(string date)
        {
            return DateTime.ParseExact(date, "yyMMMdd", CultureInfo.CurrentCulture);
        }
    }
}
