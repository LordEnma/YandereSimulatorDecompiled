using System;

[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
	public StringArrayWrapper(int size)
		: base(size)
	{
	}

	public StringArrayWrapper(string[] elements)
		: base(elements)
	{
	}
}
