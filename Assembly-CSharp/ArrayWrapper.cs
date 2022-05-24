using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000498 RID: 1176
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F66 RID: 8038 RVA: 0x001C0828 File Offset: 0x001BEA28
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F67 RID: 8039 RVA: 0x001C083C File Offset: 0x001BEA3C
	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	// Token: 0x170004B2 RID: 1202
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

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06001F6A RID: 8042 RVA: 0x001C0868 File Offset: 0x001BEA68
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F6B RID: 8043 RVA: 0x001C0872 File Offset: 0x001BEA72
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F6C RID: 8044 RVA: 0x001C087A File Offset: 0x001BEA7A
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004251 RID: 16977
	[SerializeField]
	private T[] elements;
}
