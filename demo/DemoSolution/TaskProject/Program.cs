// See https://aka.ms/new-console-template for more information

using TaskProject;

// BasicTasks.Doe();
// Canceling.Doe();

// Plinq.Doe();

// Task.WaitAl

// try
// {
// 	Parallel.Invoke(
// 		() => { throw new NotImplementedException("Ga weg"); },
// 		() => { throw new NotSupportedException("Ga weg"); },
// 		() => { throw new ArgumentOutOfRangeException("Ga weg"); }
// 	);
// }
// catch (AggregateException ex)
// {
// 	
// }

Parallel.For(1, 100, (index, loopState) =>
{
	if (index == 4)
	{
		Console.WriteLine("breaking want 4!");
		loopState.Break();
	}
	
	Thread.Sleep(100 * Random.Shared.Next(1, 50));
	Console.WriteLine($"i: {index}");
});















