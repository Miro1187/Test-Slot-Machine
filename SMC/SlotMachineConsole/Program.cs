using System;
using System.Linq;
using Common;
using Engine;

namespace SlotMachineConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = EngineFacrtory.GetEngine();

            Console.WriteLine("Wellcome!");

            bool validAmount = false;
            decimal balance;
            decimal stake;

            do
            {
                Console.WriteLine("Please deposit money you will like to play with:");
                string amountStr = Console.ReadLine();

                validAmount = decimal.TryParse(amountStr, out balance);
            }
            while (validAmount == false);

            do
            {
                validAmount = false;
                do
                {
                    Console.WriteLine("Enter stake amount:");
                    string amountStr = Console.ReadLine();

                    validAmount = decimal.TryParse(amountStr, out stake);
                    if (stake > balance)
                    {
                        validAmount = false;
                        Console.WriteLine("Insufficient balance!");
                    }
                }
                while (validAmount == false);

                Console.WriteLine("");

                var rows = engine.GetRows(4);

                rows.ForEach(x =>
                {
                    Console.WriteLine(x.RowString);
                });

                decimal wonAmount = rows.Sum(x => x.Coefficient) * stake;
                balance = balance - stake + wonAmount;
                Console.WriteLine(string.Format("You have won: {0}", wonAmount));
                Console.WriteLine(string.Format("Current balance is: {0}", balance));
                Console.WriteLine("");
            }
            while (balance > 0);
        }
    }

    public static class EngineFacrtory
    {
        public static IEngine GetEngine()
        {
            return new SMEngine();
        }
    }
}
