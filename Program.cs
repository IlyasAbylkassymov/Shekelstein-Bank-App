using System;

namespace Shekelstein_Bank_App
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Добро пожаловать в приложение банка Шекельштейн.");
            MenuLogic("", "");
        }
        private static void MenuLogic(string surname, string name)
        {
            string? choice = null;
            Console.WriteLine("Введите ваши данные.");
            Console.WriteLine("Фамилия: ");
            surname = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(surname) && surname.All(char.IsLetter))
            {
                Console.WriteLine("Имя:");
                name = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(name) && name.All(char.IsLetter))
                {
                    BankAccount bankAccount = new BankAccount(surname, name);
                    
                    do {
                        Console.WriteLine("Меню.");
                        Console.WriteLine("1. Информация о счёте.");
                        Console.WriteLine("2. Внести средства на счёт.");
                        Console.WriteLine("3. Снять средства со счёта");
                        Console.WriteLine("4. Выйти");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine($"ФИО: {bankAccount.surname} {bankAccount.name}");
                                Console.WriteLine($"На счету на данный момент {bankAccount.balance} тенге.");
                                break;
                            case "2":
                                bankAccount.Deposit();
                                break;
                            case "3":
                                bankAccount.Withdraw();
                                break;
                            case "4":
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор пункта.");
                                break;
                        }
                    }
                    while (choice != "4");
                    Console.WriteLine("Хорошего дня.");
                    Console.WriteLine("Выход...");
                }
                else
                {
                    Console.WriteLine("Некорректный формат имени.");
                    MenuLogic("", "");
                }
            }
            else
            {
                Console.WriteLine("Некорректный формат фамилии.");
                MenuLogic("", "");
            }
        }

    }
    
}