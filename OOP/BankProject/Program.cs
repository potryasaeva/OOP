using System;

namespace BankProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccountClass account = new BankAccountClass("526.00", BankAccountClass.accountType.credit);
            Console.WriteLine($"Account number: {account.Number} \nAccount balance: {account.Balance} \nAccount type: {account.Type}");
            
            BankAccountClass account1 = new BankAccountClass(BankAccountClass.accountType.budget);
            Console.WriteLine($"Account number: {account1.Number} \nAccount balance: {account1.Balance} \nAccount type: {account1.Type}");

        }
    }
}
