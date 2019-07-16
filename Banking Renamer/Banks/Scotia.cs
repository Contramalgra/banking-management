using System;

namespace Banking_Renamer.Banks
{
    public class Scotia : Bank
    {
        public Scotia() : base("e-Statement")
        {
        }

        public override DateTime Parse(string date)
        {
            return DateTime.Parse(date);
        }
    }
}
