using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001EFE RID: 7934 RVA: 0x001B64B0 File Offset: 0x001B46B0
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001EFF RID: 7935 RVA: 0x001B64C4 File Offset: 0x001B46C4
	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	// Token: 0x170004AC RID: 1196
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

	// Token: 0x170004AD RID: 1197
	// (get) Token: 0x06001F02 RID: 7938 RVA: 0x001B64F0 File Offset: 0x001B46F0
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F03 RID: 7939 RVA: 0x001B64FA File Offset: 0x001B46FA
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F04 RID: 7940 RVA: 0x001B6502 File Offset: 0x001B4702
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004126 RID: 16678
	[SerializeField]
	private T[] elements;
}
