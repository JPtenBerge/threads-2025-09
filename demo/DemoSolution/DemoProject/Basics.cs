namespace DemoProject;

public class Basics
{
	public static void Doe()
	{
		var t1 = new Thread(() =>
		{
			for (int i = 0; i < 50000; i++)
			{
				Console.Write("x");
			}

			Console.WriteLine("klaar 1");
		});
		
		var t2 = new Thread(() =>
		{
			for (int i = 0; i < 50000; i++)
			{
				Console.Write(".");
			}
			Console.WriteLine("klaar 2");
		});
		t2.Priority = ThreadPriority.Highest;
		t1.Start();
		t1.Join();
		
		t2.Start();
		
	}
}
