namespace TaskProject;

public class Barriertje
{
	private static Barrier s_barrier = new(5);

	public static void Doe()
	{
		List<Task> tasks = [];

		for (int i = 1; i <= 5; i++)
		{
			var task = new Task(() =>
			{
				Console.WriteLine("Even het obstakel overwinnen");
				Thread.Sleep(Random.Shared.Next(700, 400 * i));
				Console.WriteLine("Overwonnen en wachten");
				s_barrier.SignalAndWait();
				Console.WriteLine("Iedereen compleet, en door naar het volgende obstakel");
				Thread.Sleep(Random.Shared.Next(700, 400 * i));
				Console.WriteLine("Wederom overwonnen en wachten");
				s_barrier.SignalAndWait();
				Console.WriteLine("En weer door");
			});
			task.Start();
			tasks.Add(task);
		}

		Task.WaitAll(tasks);
	}
}