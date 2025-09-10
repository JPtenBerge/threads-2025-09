// See https://aka.ms/new-console-template for more information

using DemoProject;

// Basics.Doe();
// Dirty.Doe();

ThreadPool.QueueUserWorkItem(state =>
{
	Console.WriteLine("hey dit werkt");
});

Thread.Sleep(2000);