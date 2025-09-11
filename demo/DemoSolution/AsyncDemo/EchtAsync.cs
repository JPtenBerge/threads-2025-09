namespace AsyncDemo;

public class EchtAsync
{
	private static object _lock = new object();

	public static async Task Doe()
	{
		Console.WriteLine("eerste");

		// Monitor.Enter(_lock);
		await File.AppendAllTextAsync("bla2.txt", "heuj");
		// Monitor.Exit(_lock);

		Console.WriteLine("tweede");
		await File.AppendAllTextAsync("bla2.txt", "heuj");
		await File.AppendAllTextAsync("bla2.txt", "heuj");
		Console.WriteLine("derde");
	}
}