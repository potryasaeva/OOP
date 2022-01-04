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
        private readonly string _balance;
        private readonly accountType _type;

        //свойства
        public long Number
        {
            get 
            { 
                return _number; 
            }
        }

        public string Balance 
        {
            get
            {
                return _balance;
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
     
        public BankAccountClass(BankAccountClass.accountType type) : this(string.Empty, type)
        {
            _balance = SetBalance();
            
        }

        public BankAccountClass( string balance, BankAccountClass.accountType type)
        {
            _number = ConfigureNumber();
            _balance = balance;
            _type = type;
        }

        public int ConfigureNumber() 
        {
            Random rnd = new Random();
            int uniqueNumber = rnd.Next(10000000, int.MaxValue);
            return uniqueNumber;
        }

        public string SetBalance()
        {
            Random rnd = new Random();
            int balance = rnd.Next(100000, int.MaxValue);
            return balance.ToString() + ".00"; 
        }

    }
}
