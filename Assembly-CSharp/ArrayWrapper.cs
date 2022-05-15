using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000498 RID: 1176
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F65 RID: 8037 RVA: 0x001C03AC File Offset: 0x001BE5AC
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F66 RID: 8038 RVA: 0x001C03C0 File Offset: 0x001BE5C0
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
	// (get) Token: 0x06001F69 RID: 8041 RVA: 0x001C03EC File Offset: 0x001BE5EC
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F6A RID: 8042 RVA: 0x001C03F6 File Offset: 0x001BE5F6
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F6B RID: 8043 RVA: 0x001C03FE File Offset: 0x001BE5FE
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004248 RID: 16968
	[SerializeField]
	private T[] elements;
}
