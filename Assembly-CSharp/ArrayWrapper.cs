using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F0E RID: 7950 RVA: 0x001B7FD8 File Offset: 0x001B61D8
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F0F RID: 7951 RVA: 0x001B7FEC File Offset: 0x001B61EC
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
	// (get) Token: 0x06001F12 RID: 7954 RVA: 0x001B8018 File Offset: 0x001B6218
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x001B8022 File Offset: 0x001B6222
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F14 RID: 7956 RVA: 0x001B802A File Offset: 0x001B622A
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004148 RID: 16712
	[SerializeField]
	private T[] elements;
}
