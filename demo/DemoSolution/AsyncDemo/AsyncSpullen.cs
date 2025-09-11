using System.Text;

namespace AsyncDemo;

public class AsyncSpullen
{
	public static void Doe()
	{
		var file = File.Open("bla.txt", FileMode.OpenOrCreate);

		var buffer = Encoding.ASCII.GetBytes("Hello Class!");
		file.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(HandleEndWrite), file);
	}

	public static void HandleEndWrite(IAsyncResult state)
	{
		var file = (FileStream)state.AsyncState;
		file.EndWrite(state);
		file.Flush();
		file.Close();
	}
}