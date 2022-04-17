using System;
using System.Threading;

namespace Shekelstein_Bank_App
{
    public class BankAccount
    {
        public string name = "";
        public string surname = "";
        public int balance = 0;
        public BankAccount(string surname, string name)
        {
            this.surname = surname;
            this.name = name;
        }
        public void Deposit()
        {
            Console.WriteLine("Введите сумму для вноса на счет:");
            string? stringBalance = Console.ReadLine();
            if (int.TryParse(stringBalance, out int result) && Convert.ToInt32(stringBalance) > 0)
            {
                balance += Convert.ToInt32(stringBalance);
                Console.WriteLine("Пополнение баланса, ожидайте...");
                Thread.Sleep(5000);
                Console.WriteLine($"Баланс успешно пополнен. На вашем счету {balance} тенге");
            }
            else
            {
                Console.WriteLine("Некорректный ввод суммы");
            }
        }
        public void Withdraw()
        {
            Console.WriteLine("Введите сумму для снятия со счета:");
            string? stringBalance = Console.ReadLine();
            if (int.TryParse(stringBalance, out int result) && Convert.ToInt32(stringBalance) > 0)
            {
                if (balance >= Convert.ToInt32(stringBalance))
                {
                    balance -= Convert.ToInt32(stringBalance);
                    Console.WriteLine("Снятие средств, ожидайте...");
                    Thread.Sleep(5000);
                    Console.WriteLine($"Средства успешно сняты. На вашем счету {balance} тенге.");
                }
                else
                {
                    Console.WriteLine($"Недостаточно средств. На вашем счету {balance} тенге.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод суммы");
            }
        }
    }
}