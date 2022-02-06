using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F15 RID: 7957 RVA: 0x001B8A2C File Offset: 0x001B6C2C
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x001B8A40 File Offset: 0x001B6C40
	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	// Token: 0x170004AE RID: 1198
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

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001F19 RID: 7961 RVA: 0x001B8A6C File Offset: 0x001B6C6C
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B8A76 File Offset: 0x001B6C76
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F1B RID: 7963 RVA: 0x001B8A7E File Offset: 0x001B6C7E
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004159 RID: 16729
	[SerializeField]
	private T[] elements;
}
