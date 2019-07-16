using System;
using System.Globalization;

namespace Banking_Renamer.Banks
{
    class Tangerine : Bank
    {
        public Tangerine() : base("Tangerine-Chequing_")
        {
        }

        public override DateTime Parse(string date)
        {
            return DateTime.ParseExact(date, "MMMyy", CultureInfo.CurrentCulture);
        }
    }
}
