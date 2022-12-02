using System;

namespace Lab_12
{
    public class Account
    {
        Random random = new Random();
        static ulong lastNumber = 4364_2868_4768_0000;
        public ulong Number { get; private set; }
        public TypeAccount Type { get; set; }
        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Баланс не может быть отрицательным. Баланс: 0$");
                }
                else
                {
                    balance = value;
                }
            }
        }

        internal Account(TypeAccount type, decimal balance)
        {
            Type = type;
            Balance = balance;
            Number += lastNumber + (ulong)random.Next(1, 10);
            lastNumber = Number;
        }
        public override string ToString()
        {
            return $"Информация о счете\nТип счета-{Type}; Номер счета-{Number}; Баланс-{balance}$";
        }
        public static bool operator ==(Account account1, Account account2)
        {
            if (account1.ToString().Equals(account2.ToString()))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Account account1, Account account2)
        {
            if (account1.ToString().Equals(account2.ToString()))
            {
                return false;
            }
            return true;
        }
        public override bool Equals(object obj)
        {
            if (obj is Account account) // Read in the book
            {
                return account == this;
            }
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode(); // Read in the book
        }
    }
}