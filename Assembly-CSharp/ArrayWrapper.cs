using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F4C RID: 8012 RVA: 0x001BD380 File Offset: 0x001BB580
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F4D RID: 8013 RVA: 0x001BD394 File Offset: 0x001BB594
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
	// (get) Token: 0x06001F50 RID: 8016 RVA: 0x001BD3C0 File Offset: 0x001BB5C0
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F51 RID: 8017 RVA: 0x001BD3CA File Offset: 0x001BB5CA
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F52 RID: 8018 RVA: 0x001BD3D2 File Offset: 0x001BB5D2
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004204 RID: 16900
	[SerializeField]
	private T[] elements;
}
