using System.Diagnostics;

namespace TaskProject;

public class Plinq
{
	public static void Doe()
	{
		List<int> lijstje = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30];

		var watch = new Stopwatch();
		watch.Start();
		var filtered = lijstje.AsParallel().Where(x => HeleZwareFilterOperatie(x)).ToArray();
		watch.Stop();
		foreach (var item in filtered)
		{
			Console.WriteLine($"item: {item}");
		}

		Console.WriteLine($"Elapsed milliseconds: {watch.ElapsedMilliseconds}");
	}

	public static bool HeleZwareFilterOperatie(int item)
	{
		Console.WriteLine($"berekenen voor item {item} / {Thread.CurrentThread.ManagedThreadId}");
		Thread.SpinWait(50_000_000);
		return true;
	}
}