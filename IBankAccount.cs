namespace Shekelstein_Bank_App;

internal interface IBankAccount
{
	void Display();
	Task AddMoneyAsync();
	Task TakeMoneyAsync();
}