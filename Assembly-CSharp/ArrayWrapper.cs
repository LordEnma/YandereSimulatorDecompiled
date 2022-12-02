using System.Collections;
using UnityEngine;

public class ArrayWrapper<T> : IEnumerable
{
	[SerializeField]
	private T[] elements;

	public T this[int i]
	{
		get
		{
			return elements[i];
		}
		set
		{
			elements[i] = value;
		}
	}

	public int Length
	{
		get
		{
			return elements.Length;
		}
	}

	public ArrayWrapper(int size)
	{
		elements = new T[size];
	}

	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	public T[] Get()
	{
		return elements;
	}

	public IEnumerator GetEnumerator()
	{
		return elements.GetEnumerator();
	}
}
