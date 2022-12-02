using System;

[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
	public IntAndIntPair(int first, int second)
		: base(first, second)
	{
	}

	public IntAndIntPair()
		: base(0, 0)
	{
	}
}
