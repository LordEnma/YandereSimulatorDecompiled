using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200048F RID: 1167
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F28 RID: 7976 RVA: 0x001BA16C File Offset: 0x001B836C
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F29 RID: 7977 RVA: 0x001BA180 File Offset: 0x001B8380
	public ArrayWrapper(T[] elements)
	{
		this.elements = elements;
	}

	// Token: 0x170004AF RID: 1199
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

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001F2C RID: 7980 RVA: 0x001BA1AC File Offset: 0x001B83AC
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F2D RID: 7981 RVA: 0x001BA1B6 File Offset: 0x001B83B6
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F2E RID: 7982 RVA: 0x001BA1BE File Offset: 0x001B83BE
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004189 RID: 16777
	[SerializeField]
	private T[] elements;
}
