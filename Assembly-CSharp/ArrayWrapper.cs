using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F0C RID: 7948 RVA: 0x001B7308 File Offset: 0x001B5508
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x001B731C File Offset: 0x001B551C
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
	// (get) Token: 0x06001F10 RID: 7952 RVA: 0x001B7348 File Offset: 0x001B5548
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F11 RID: 7953 RVA: 0x001B7352 File Offset: 0x001B5552
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F12 RID: 7954 RVA: 0x001B735A File Offset: 0x001B555A
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004141 RID: 16705
	[SerializeField]
	private T[] elements;
}
