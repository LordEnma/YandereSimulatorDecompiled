using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000497 RID: 1175
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F5B RID: 8027 RVA: 0x001BF118 File Offset: 0x001BD318
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F5C RID: 8028 RVA: 0x001BF12C File Offset: 0x001BD32C
	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	// Token: 0x170004B1 RID: 1201
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

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06001F5F RID: 8031 RVA: 0x001BF158 File Offset: 0x001BD358
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F60 RID: 8032 RVA: 0x001BF162 File Offset: 0x001BD362
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F61 RID: 8033 RVA: 0x001BF16A File Offset: 0x001BD36A
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x0400422A RID: 16938
	[SerializeField]
	private T[] elements;
}
