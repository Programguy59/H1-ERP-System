namespace H1_ERP_System.ui;

public class ErrorScreen
{
	public ErrorScreen(string message)
	{
		Console.Clear();
		
		Console.WriteLine("An error has occurred!");
		Console.WriteLine();
		Console.WriteLine(message);
		Console.WriteLine();
		
		Console.WriteLine("Press any key to continue...");
		Console.ReadKey();
		
		Console.Clear();
	}
}
