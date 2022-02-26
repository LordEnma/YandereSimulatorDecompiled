using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048F RID: 1167
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F25 RID: 7973 RVA: 0x001B99CC File Offset: 0x001B7BCC
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F26 RID: 7974 RVA: 0x001B99E0 File Offset: 0x001B7BE0
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
	// (get) Token: 0x06001F29 RID: 7977 RVA: 0x001B9A0C File Offset: 0x001B7C0C
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F2A RID: 7978 RVA: 0x001B9A16 File Offset: 0x001B7C16
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F2B RID: 7979 RVA: 0x001B9A1E File Offset: 0x001B7C1E
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004172 RID: 16754
	[SerializeField]
	private T[] elements;
}
