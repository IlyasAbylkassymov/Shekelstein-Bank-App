﻿using System;
using System.Threading;

namespace Shekelstein_Bank_App
{
    public class BankAccount
    {
        public string name = "";
        public string surname = "";
        public bool isNameAndSurnameInCorrectFormat = true;
        public int balance = 0;
        public string Name
        {
            get { return name; }
            set {
                isNameAndSurnameInCorrectFormat = true;
                if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter) && !value.Any(char.IsSeparator) && !value.Any(char.IsWhiteSpace))
                {
                    name = value;   
                }
                else
                {
                    Console.WriteLine("Некорректный формат имени.");
                    isNameAndSurnameInCorrectFormat = false;
                }
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                isNameAndSurnameInCorrectFormat = true;
                if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter) && !value.Any(char.IsSeparator) && !value.Any(char.IsWhiteSpace))
                {
                    surname = value;
                }
                else
                {
                    Console.WriteLine("Некорректный формат фамилии.");
                    isNameAndSurnameInCorrectFormat = false;
                }
            }
        }

        public BankAccount()
        {

        }
        public void MenuShowUp()
        {
            Console.WriteLine("Меню.");
            Console.WriteLine("1. Информация о счёте.");
            Console.WriteLine("2. Внести средства на счёт.");
            Console.WriteLine("3. Снять средства со счёта");
            Console.WriteLine("4. Выйти");
            string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"ФИО: {surname} {name}");
                        Console.WriteLine($"На счету на данный момент {balance} тенге.");
                        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
                        Console.ReadKey();
                        MenuShowUp();
                        break;
                    case "2":
                        Console.WriteLine("Введите сумму для вноса на счет:");
                        string? stringBalance = Console.ReadLine();
                        if(int.TryParse(stringBalance, out int result) && Convert.ToInt32(stringBalance) > 0)
                        {
                                balance += Convert.ToInt32(stringBalance);
                                Console.WriteLine("Пополнение баланса, ожидайте...");
                                Thread.Sleep(5000);
                                Console.WriteLine($"Баланс успешно пополнен. На вашем счету {balance} тенге");
                                MenuShowUp();
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод суммы");
                            MenuShowUp();
                        }
                        
                        break;
                    case "3":
                        Console.WriteLine("Введите сумму для снятия со счета:");
                        stringBalance = Console.ReadLine();
                        if (int.TryParse(stringBalance, out result) && Convert.ToInt32(stringBalance)>0)
                        {
                                if (balance >= Convert.ToInt32(stringBalance))
                                {
                                    balance -= Convert.ToInt32(stringBalance);
                                }
                                else
                                {
                                    Console.WriteLine($"Недостаточно средств. На вашем счету {balance} тенге.");
                                    MenuShowUp();
                                    break;
                                }
                                Console.WriteLine("Снятие средств, ожидайте...");
                                Thread.Sleep(5000);
                                Console.WriteLine($"Средства успешно сняты. На вашем счету {balance} тенге.");
                                MenuShowUp();
                            
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод суммы");
                            MenuShowUp();
                        }
                        break;
                    case "4":
                        Console.WriteLine("Хорошего дня.");
                        Console.WriteLine("Выход...");
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор пункта.");
                        MenuShowUp();
                        break;
                }
        }
        public void StartingUp()
        {

            Console.WriteLine("Введите ваши данные.");
            Console.WriteLine("Фамилия: ");
            Surname = Console.ReadLine();
            if(isNameAndSurnameInCorrectFormat)
            {
                Console.WriteLine("Имя: ");
                Name = Console.ReadLine();
                if(isNameAndSurnameInCorrectFormat)
                {
                    Console.WriteLine($"Здравствуйте, {surname} {name}");
                    MenuShowUp();
                }
                else
                {
                    Console.WriteLine("Попробуйте ещё раз");
                    StartingUp();
                }
            }
            else
            {
                Console.WriteLine("Попробуйте ещё раз");
                StartingUp();
            }
        }
    }
}
