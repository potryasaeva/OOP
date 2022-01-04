using System;

namespace BankProject
{
    public class BankAccountClass
    {
        public enum accountType
        {
            current,
            credit,
            budget,
            correspondent,
            special,
            deposit,
            investment
        }


        //поля
        private readonly int _number;
        private decimal _balance;
        private readonly accountType _type;


        //свойства
        public long Number
        {
            get
            {
                return _number;
            }
        }

        public decimal Balance
        {
            get
            {
                return _balance;
            }

            set
            {
                _balance = value;
            }

        }

        public BankAccountClass.accountType Type

        {
            get
            {
                return _type;
            }
        }


        //конструкторы
        public BankAccountClass() : this(0)
        {

        }

        public BankAccountClass(BankAccountClass.accountType type) : this(0, type)
        {
            _balance = SetBalance();

        }

        public BankAccountClass(decimal balance, BankAccountClass.accountType type)
        {
            _number = ConfigureNumber();
            _balance = balance;
            _type = type;
        }


        //методы
        public int ConfigureNumber()
        {
            Random rnd = new Random();
            int uniqueNumber = rnd.Next(10000000, int.MaxValue);
            return uniqueNumber;
        }

        public decimal SetBalance()
        {
            Random rnd = new Random();
            decimal balance = new Decimal(rnd.Next(100000, int.MaxValue) + 0.02);
            return balance;
        }

        public void Moneytransfer(BankAccountClass BankAccount, int amount)
        {
            BankAccount.Balance -= amount;
            Balance += amount;
        }

    }
}
