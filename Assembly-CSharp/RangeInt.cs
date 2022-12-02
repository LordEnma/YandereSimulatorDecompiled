using System;
using UnityEngine;

[Serializable]
public class RangeInt
{
	[SerializeField]
	private int value;

	[SerializeField]
	private int min;

	[SerializeField]
	private int max;

	public int Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	public int Min
	{
		get
		{
			return min;
		}
	}

	public int Max
	{
		get
		{
			return max;
		}
	}

	public int Next
	{
		get
		{
			if (value != max)
			{
				return value + 1;
			}
			return min;
		}
	}

	public int Previous
	{
		get
		{
			if (value != min)
			{
				return value - 1;
			}
			return max;
		}
	}

	public RangeInt(int value, int min, int max)
	{
		this.value = value;
		this.min = min;
		this.max = max;
	}

	public RangeInt(int min, int max)
		: this(min, min, max)
	{
	}
}
