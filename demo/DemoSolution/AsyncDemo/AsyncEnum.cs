namespace AsyncDemo;

public class AsyncEnum
{
	public static async Task Doe()
	{
		await foreach (int i in GeefWaarden())
		{
			Console.WriteLine("getal: " + i);
		}
	}

	public static async IAsyncEnumerable<int> GeefWaarden()
	{
		await Task.Delay(600); // de nieuwe verbeterde Thread.Sleep()
		yield return 4;
		await Task.Delay(1500); 
		yield return 8;
		await Task.Delay(4000); 
		yield return 15;
		await Task.Delay(200); 
		yield return 16;
		await Task.Delay(500); 
		yield return 23;
		await Task.Delay(600); 
		yield return 42;
	}
}