using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000495 RID: 1173
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F44 RID: 8004 RVA: 0x001BCE78 File Offset: 0x001BB078
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F45 RID: 8005 RVA: 0x001BCE8C File Offset: 0x001BB08C
	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	// Token: 0x170004B0 RID: 1200
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

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001F48 RID: 8008 RVA: 0x001BCEB8 File Offset: 0x001BB0B8
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F49 RID: 8009 RVA: 0x001BCEC2 File Offset: 0x001BB0C2
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F4A RID: 8010 RVA: 0x001BCECA File Offset: 0x001BB0CA
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004201 RID: 16897
	[SerializeField]
	private T[] elements;
}
