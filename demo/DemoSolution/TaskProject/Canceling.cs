namespace TaskProject;

public class Canceling
{
	public static void Doe()
	{
		var cts = new CancellationTokenSource();
		Task.Run(() =>
		{
			for (int i = 0; i < 5_000_000; i++)
			{
				cts.Token.ThrowIfCancellationRequested();
				Console.Write(".");
			}

			Console.WriteLine("klaar!");
		});

		Thread.Sleep(1000);
		Console.WriteLine("canceling!");
		cts.Cancel();
		Console.WriteLine("echt klaar nu");
	}
}