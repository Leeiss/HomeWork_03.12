using System;

namespace Commerce
{
    public enum TypeAccount
    {
        Текущий = 1,
        Сберегательный
    }
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
        internal Account(TypeAccount type) : this(type, 0)
        {
        }
        internal Account() : this(TypeAccount.Сберегательный, 0)
        {
        }
        public void Display()
        {
            Console.WriteLine("Информация о счете:\n" + $"Тип счета: {Type}; Номер счета: {Number}; Баланс: {balance}$");
        }
        
    }
}