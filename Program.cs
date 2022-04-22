namespace Shekelstein_Bank_App;

class Program
{
	public static async Task Main(string[] args)
	{
		Console.WriteLine("Добро пожаловать в приложение банка Шекельштейн.\nВведите Ваши данные.");
		var menu = Menu.Create();
		var account = BankAccount.Create();
		while (menu.SessionInAction)
		{
			menu.Display();
			try
			{
				switch (menu.MakeChoice())
				{
					case "1":
						account.Display();
						break;
					case "2":
						await account.AddMoneyAsync();
						break;
					case "3":
						await account.TakeMoneyAsync();
						break;
					case "4":
						menu.EndSession();
						break;
					default:
						menu.PrintWrong();
						break;
				}
			}
			catch (NullReferenceException ex)
			{
				// вообще тут должна быть индивидуальная обработка исключения, конкретно для этого типа ошибки, но было лень делать
				Console.WriteLine(ex);
			}
			catch (InvalidCastException ex)
			{
				// вообще тут должна быть индивидуальная обработка исключения, конкретно для этого типа ошибки, но было лень делать
				Console.WriteLine(ex);
			}
		}

		Console.WriteLine("Хорошего дня.");
		Console.WriteLine("Выход...");
		await Task.Delay(3000);
	}
}