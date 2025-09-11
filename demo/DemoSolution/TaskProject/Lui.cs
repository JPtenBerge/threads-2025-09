namespace TaskProject;

public class Lui<T> where T : new()
{
	private T _value;
	private static object s_lock = new();

	public T Value
	{
		get
		{
			if (_value == null)
			{
				lock (s_lock)
				{
					if (_value == null)
					{
						_value = new T();
					}
				}
			}

			return _value;
		}
	}
}