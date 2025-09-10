// See https://aka.ms/new-console-template for more information

using TaskProject;

// BasicTasks.Doe();
// Canceling.Doe();

try
{
	Parallel.Invoke(
		() => { throw new NotImplementedException("Ga weg"); },
		() => { throw new NotSupportedException("Ga weg"); },
		() => { throw new ArgumentOutOfRangeException("Ga weg"); }
	);
}
catch (AggregateException ex)
{
	
}
