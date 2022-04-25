namespace Shekelstein_Bank_App;

internal class BankAccount : IBankAccount
{
	private string _name { get; set; }
	private string _lastname { get; set; }
	private decimal _balance { get; set; }

	private BankAccount(string lastname, string name)
	{
		_lastname = lastname;
		_name = name;
		_balance = 0;
	}

	private BankAccount(string lastname, string name, decimal balance)
	{
		_lastname = lastname;
		_name = name;
		_balance = balance;
	}

	/// <summary>
	/// вообще такие вещи выносят в какие-нибудь фабрики, чтобы было проще порождать новые экземпляры
	/// </summary>
	/// <returns></returns>
	public static IBankAccount Create()
	{
		string? lastname, name;
		do
		{
			Console.Write("Фамилия: ");
			lastname = Console.ReadLine();
			Console.Write("Введите Ваше имя: ");
			name = Console.ReadLine();
		}
		while (InvalidFullName(lastname, name));

		return new BankAccount(lastname!, name!);
	}

	public void Display()
	{
		Console.WriteLine($"ФИО: {_lastname} {_name}");
		Console.WriteLine($"На счету на данный момент {_balance} тенге.");
	}

	public async Task AddMoneyAsync()
	{
		Console.Write("Введите сумму для вноса на счет: ");
		string? inputBalance = Console.ReadLine();

		if (String.IsNullOrEmpty(inputBalance))
			throw new NullReferenceException("Не может иметь значение null.");

		if (!decimal.TryParse(inputBalance, out decimal result))
			throw new InvalidCastException($"{inputBalance} не соответствует типу decimal");

		_balance += result;
		Console.WriteLine("Пополнение баланса, ожидайте...");
		await Task.Delay(5000);
		Console.WriteLine($"Баланс успешно пополнен. На вашем счету {_balance} тенге.");
	}

	public async Task TakeMoneyAsync()
	{
		Console.Write("Введите сумму для снятия со счета: ");
		string? inputBalance = Console.ReadLine();

		if (String.IsNullOrEmpty(inputBalance))
			throw new NullReferenceException("Не может иметь значение null.");

		if (!decimal.TryParse(inputBalance, out decimal result))
			throw new InvalidCastException($"{inputBalance} не соответствует типу decimal");

		if (_balance < result)
		{
			Console.WriteLine($"Недостаточно средств. На вашем счету {_balance} тенге.");
			return;
		}

		_balance -= result;
		Console.WriteLine("Снятие средств, ожидайте...");
		await Task.Delay(5000);
		Console.WriteLine($"Средства успешно сняты. На вашем счету {_balance} тенге.");
	}

	private static bool InvalidFullName(string? lastname, string? name)
	{
		return String.IsNullOrEmpty(name) || !name.All(char.IsLetter) ||
			   String.IsNullOrEmpty(lastname) || !lastname.All(char.IsLetter);
	}
}