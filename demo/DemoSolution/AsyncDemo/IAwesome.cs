namespace AsyncDemo;

public interface IAwesomeService
{
	Task Doe();
}

public class AwesomeService : IAwesomeService
{
	public async Task Doe()
	{
		await File.AppendAllTextAsync();
	}
}

// testing
public class FakeAwesomeService : IAwesomeService
{
	public Task Doe()
	{
		return Task.FromResult("qwerty");
	}
}