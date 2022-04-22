namespace Shekelstein_Bank_App;

internal interface IMenu
{
	bool SessionInAction { get; }
	void Display();
	string MakeChoice();
	void EndSession();
	void PrintWrong();
}