using System;
using System.Globalization;

namespace Banking_Renamer.Banks
{
    class BRIM : Bank
    {
        public BRIM() : base(@"statement-\w{32}-", @"Brim\statement-*.pdf")
        {
        }

        public override DateTime Parse(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.CurrentCulture);
        }
    }
}
