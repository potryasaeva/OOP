using System;

namespace BankProject
{
    class Program
    {
        static void Main()
        {
            BankAccountClass accountFrom = new BankAccountClass(BankAccountClass.accountType.current);
            BankAccountClass accountTo = new BankAccountClass(BankAccountClass.accountType.credit);

            Console.WriteLine(accountFrom);
            Console.WriteLine("\n________________________________\n");
            Console.WriteLine(accountTo);

            Console.WriteLine(accountFrom == accountTo);
            Console.WriteLine(accountFrom == accountFrom);
            Console.WriteLine(accountFrom != accountTo);
            Console.WriteLine(accountFrom != accountFrom);
            Console.WriteLine(accountFrom.Equals(accountTo));
            Console.WriteLine(accountFrom.Equals(accountFrom));
            Console.WriteLine(accountFrom.GetHashCode());
            Console.WriteLine(accountTo.GetHashCode());


            /*Console.WriteLine($"{accountFrom.Type} account: \n  number: {accountFrom.Number} \n  balance: {accountFrom.Balance}");
            Console.WriteLine("\n________________________________\n");
            Console.WriteLine($"{accountTo.Type} account: \n  number: {accountTo.Number} \n  balance: {accountTo.Balance}");

            Console.WriteLine("\n________________________________\n");

            Console.WriteLine("Please, enter integer amount for transaction:");
            string enteredValue = Console.ReadLine();

            if (Int32.TryParse(enteredValue, out int amount))
            {
                accountTo.Moneytransfer(accountFrom, amount);
                Console.WriteLine($"{accountFrom.Type} account: \n  number: {accountFrom.Number} \n  balance: {accountFrom.Balance}");
                Console.WriteLine("\n________________________________\n");
                Console.WriteLine($"{accountTo.Type} account: \n  number: {accountTo.Number} \n  balance: {accountTo.Balance}");


            }
            else
            {
                Console.WriteLine($"You entered not integer amount. plz try again");
                Main();
            }

            */

        }
    }
}
