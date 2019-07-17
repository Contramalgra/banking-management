using System;
using System.Globalization;

namespace Banking_Renamer.Banks
{
    class GenericBank : Bank
    {
        //public GenericBank(string subfolder) : base(@"^[^-]*$", $@"{subfolder}\*.pdf")
        public GenericBank(string subfolder) : base("", $@"{subfolder}\*.pdf")
        {
        }

        public override DateTime Parse(string date)
        {
            return DateTime.Parse(date);
        }
    }
}
