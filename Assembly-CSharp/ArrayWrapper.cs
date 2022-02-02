using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F10 RID: 7952 RVA: 0x001B8500 File Offset: 0x001B6700
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F11 RID: 7953 RVA: 0x001B8514 File Offset: 0x001B6714
	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	// Token: 0x170004AD RID: 1197
	public T this[int i]
	{
		get
		{
			return this.elements[i];
		}
		set
		{
			this.elements[i] = value;
		}
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06001F14 RID: 7956 RVA: 0x001B8540 File Offset: 0x001B6740
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x001B854A File Offset: 0x001B674A
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x001B8552 File Offset: 0x001B6752
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004150 RID: 16720
	[SerializeField]
	private T[] elements;
}
