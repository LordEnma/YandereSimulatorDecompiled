public class SerializablePair<T, U>
{
	public T first;

	public U second;

	public SerializablePair(T first, U second)
	{
		this.first = first;
		this.second = second;
	}

	public SerializablePair()
		: this(default(T), default(U))
	{
	}
}
