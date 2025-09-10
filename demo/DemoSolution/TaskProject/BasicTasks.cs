namespace TaskProject;

public class BasicTasks
{
	public static void Doe()
	{
		var t1 = new Task<int>(() =>
		{
			for (int i = 0; i < 50000; i++)
			{
				Console.Write("x");
			}

			Console.WriteLine($"klaar 1 - ik heb gedraaid op #{Thread.CurrentThread.ManagedThreadId}");
			return 12;
		});
		
		var t2 = new Task<int>(() =>
		{
			for (int i = 0; i < 50000; i++)
			{
				Console.Write(".");
			}
			Console.WriteLine($"klaar 2 - ik heb gedraaid op #{Thread.CurrentThread.ManagedThreadId}");
			return 98;
		});
		t1.Start();
		t2.Start();
		// new TaskFactory().StartNew()

		var res1 = t1.GetAwaiter().GetResult();
		var res2 = t2.GetAwaiter().GetResult();

		Console.WriteLine($"klaar!!!! - ik heb gedraaid op #{Thread.CurrentThread.ManagedThreadId}");
		Console.WriteLine($"{res1} / {res2}");
		
	}
}