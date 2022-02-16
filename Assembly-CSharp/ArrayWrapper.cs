using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048E RID: 1166
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F1C RID: 7964 RVA: 0x001B8E80 File Offset: 0x001B7080
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F1D RID: 7965 RVA: 0x001B8E94 File Offset: 0x001B7094
	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	// Token: 0x170004AF RID: 1199
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

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001F20 RID: 7968 RVA: 0x001B8EC0 File Offset: 0x001B70C0
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F21 RID: 7969 RVA: 0x001B8ECA File Offset: 0x001B70CA
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F22 RID: 7970 RVA: 0x001B8ED2 File Offset: 0x001B70D2
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004162 RID: 16738
	[SerializeField]
	private T[] elements;
}
