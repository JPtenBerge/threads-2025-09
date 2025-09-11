using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AsyncDemo;

public static class ProcessExtensions
{
	public static TaskAwaiter<int> GetAwaiter(this Process process)
	{
		var tcs = new TaskCompletionSource<int>();
		process.EnableRaisingEvents = true;
		process.Exited += (sender, args) =>
		{
			Console.WriteLine("exit event");
			tcs.TrySetResult(process.ExitCode);
		};
		if (process.HasExited)
		{
			Console.WriteLine("is al geexit");
			tcs.TrySetResult(process.ExitCode);
		}

		return tcs.Task.GetAwaiter();
	}
}