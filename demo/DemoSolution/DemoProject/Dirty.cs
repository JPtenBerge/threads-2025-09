namespace DemoProject;

public class Dirty
{
	public static int s_counter; // <== shared resource
	private static object s_lock = new object();

	public static void Doe()
	{
		var t1 = new Thread(() =>
		{
			for (var i = 0; i < 1_000_000; i++)
			{
				try
				{
					Monitor.Enter(s_lock);
					s_counter++;
				}
				finally
				{
					Monitor.Exit(s_lock);
				}
			}
		});
		var t2 = new Thread(() =>
		{
			for (var i = 0; i < 1_000_000; i++)
			{
				Monitor.Enter(s_lock);
				s_counter++;
				Monitor.Exit(s_lock);

				// lock (this)
				// {
				// }
			}
		});
		t1.Start();
		t2.Start();
		t1.Join();
		t2.Join();
		Console.WriteLine($"counter is nu {s_counter}");
	}
}