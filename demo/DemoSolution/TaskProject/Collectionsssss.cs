using System.Collections.Concurrent;

namespace TaskProject;

public class Collectionsssss
{
	private static ConcurrentDictionary<int, string> s_dict = new();

	public static void Doe()
	{
		var t1 = new Task(() =>
		{
			for (int i = 0; i < 10; i++)
			{
				s_dict.TryAdd(i, "Task 1");
				Thread.Sleep(i * 10);
			}
		});
		var t2 = new Task(() =>
		{
			for (int i = 0; i < 10; i++)
			{
				s_dict.TryAdd(i, "Task 2");
				Thread.Sleep(i * 11);
			}
		});
		t1.Start();
		t2.Start();

		Task.WaitAll(t1, t2);

		foreach (var entry in s_dict)
		{
			Console.WriteLine($"{entry.Key} heeft value {entry.Value}");
		}
	}
}