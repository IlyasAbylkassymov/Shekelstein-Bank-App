namespace Shekelstein_Bank_App;

internal class Menu : IMenu
{
	public bool SessionInAction { get; private set; }

	private readonly Dictionary<string, string> _menuItems;

	private Menu()
	{
		SessionInAction = true;
		_menuItems = new Dictionary<string, string>
		{
			{ "1", "Информация о счёте." },
			{ "2", "Внести средства на счёт." },
			{ "3", "Снять средства со счёта." },
			{ "4", "Выйти." },
		};
	}

	/// <summary>
	/// вообще такие вещи выносят в какие-нибудь фабрики, чтобы было проще порождать новые экземпляры
	/// </summary>
	/// <returns></returns>
	public static IMenu Create()
	{
		return new Menu();
	}

	public void Display()
	{
		foreach (var item in _menuItems)
		{
			Console.WriteLine(item.Key + " - " + item.Value);
		}
	}

	public string MakeChoice()
	{
		var choice = Console.ReadLine();
		if (String.IsNullOrEmpty(choice))
			throw new NullReferenceException("Введеные данные не могут иметь значение null. или \"\"");
		return choice;
	}

	public void EndSession()
	{
		SessionInAction = false;
	}

	public void PrintWrong()
	{
		Console.WriteLine("Некорректный выбор пункта.");
	}
}