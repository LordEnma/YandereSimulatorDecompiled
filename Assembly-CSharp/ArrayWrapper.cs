using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F12 RID: 7954 RVA: 0x001B880C File Offset: 0x001B6A0C
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x001B8820 File Offset: 0x001B6A20
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
	// (get) Token: 0x06001F16 RID: 7958 RVA: 0x001B884C File Offset: 0x001B6A4C
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F17 RID: 7959 RVA: 0x001B8856 File Offset: 0x001B6A56
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x001B885E File Offset: 0x001B6A5E
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004156 RID: 16726
	[SerializeField]
	private T[] elements;
}
