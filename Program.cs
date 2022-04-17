using System;

namespace Shekelstein_Bank_App
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложения банка Шекельштейн.");
            BankAccount bankAccount = new BankAccount();
            bankAccount.StartingUp();
        }
    }
    
}