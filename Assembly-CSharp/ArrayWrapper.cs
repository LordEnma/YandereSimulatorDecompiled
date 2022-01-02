using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F01 RID: 7937 RVA: 0x001B6988 File Offset: 0x001B4B88
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F02 RID: 7938 RVA: 0x001B699C File Offset: 0x001B4B9C
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
	// (get) Token: 0x06001F05 RID: 7941 RVA: 0x001B69C8 File Offset: 0x001B4BC8
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F06 RID: 7942 RVA: 0x001B69D2 File Offset: 0x001B4BD2
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F07 RID: 7943 RVA: 0x001B69DA File Offset: 0x001B4BDA
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x0400412D RID: 16685
	[SerializeField]
	private T[] elements;
}
