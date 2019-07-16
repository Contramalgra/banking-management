using System;

namespace Banking_Renamer.Banks
{
    class RBC : Bank
    {
        public RBC() : base(@"[\dX]+-\w{8,9}-", @"RBC\*.pdf")
        {
        }

        public override DateTime Parse(string date)
        {
            return DateTime.Parse(date);
        }
    }
}
