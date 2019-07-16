using System;
using System.Globalization;

namespace Banking_Renamer.Banks
{
    class BMO : Bank
    {
        public BMO() : base("eStatement_")
        {
        }

        public override DateTime Parse(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.CurrentCulture);
        }
    }
}
