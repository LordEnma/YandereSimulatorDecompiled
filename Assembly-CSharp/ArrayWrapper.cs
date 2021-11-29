using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001EF4 RID: 7924 RVA: 0x001B56F4 File Offset: 0x001B38F4
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001EF5 RID: 7925 RVA: 0x001B5708 File Offset: 0x001B3908
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
	// (get) Token: 0x06001EF8 RID: 7928 RVA: 0x001B5734 File Offset: 0x001B3934
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001EF9 RID: 7929 RVA: 0x001B573E File Offset: 0x001B393E
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001EFA RID: 7930 RVA: 0x001B5746 File Offset: 0x001B3946
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x040040F6 RID: 16630
	[SerializeField]
	private T[] elements;
}
