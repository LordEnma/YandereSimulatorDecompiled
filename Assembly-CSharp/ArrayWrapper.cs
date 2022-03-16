using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000492 RID: 1170
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F3A RID: 7994 RVA: 0x001BB8EC File Offset: 0x001B9AEC
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F3B RID: 7995 RVA: 0x001BB900 File Offset: 0x001B9B00
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
	// (get) Token: 0x06001F3E RID: 7998 RVA: 0x001BB92C File Offset: 0x001B9B2C
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F3F RID: 7999 RVA: 0x001BB936 File Offset: 0x001B9B36
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F40 RID: 8000 RVA: 0x001BB93E File Offset: 0x001B9B3E
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x040041D4 RID: 16852
	[SerializeField]
	private T[] elements;
}
