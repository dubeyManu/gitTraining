using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork_Day_4
{
    class BankAccount
    {
        public int balance { get; private set; }
        public BankAccount()
        {
            this.balance = 500;
        }
        public BankAccount(int bal)
        {
            this.balance = bal;
        }
        
    }
    class BankClient
    {
        public static void Main()
        {
            BankAccount b1 = new BankAccount();
            Console.WriteLine($"The balance of default bank account balance is { b1.balance}.");
            BankAccount b2 = new BankAccount(0);
            Console.WriteLine($"The balance of custom bank account balance is { b2.balance}.");

        }
    }
}
