using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public class ArrayWrapper<T> : IEnumerable
{
	// Token: 0x06001F52 RID: 8018 RVA: 0x001BDD5C File Offset: 0x001BBF5C
	public ArrayWrapper(int size)
	{
		this.elements = new T[size];
	}

	// Token: 0x06001F53 RID: 8019 RVA: 0x001BDD70 File Offset: 0x001BBF70
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
	// (get) Token: 0x06001F56 RID: 8022 RVA: 0x001BDD9C File Offset: 0x001BBF9C
	public int Length
	{
		get
		{
			return this.elements.Length;
		}
	}

	// Token: 0x06001F57 RID: 8023 RVA: 0x001BDDA6 File Offset: 0x001BBFA6
	public T[] Get()
	{
		return this.elements;
	}

	// Token: 0x06001F58 RID: 8024 RVA: 0x001BDDAE File Offset: 0x001BBFAE
	public IEnumerator GetEnumerator()
	{
		return this.elements.GetEnumerator();
	}

	// Token: 0x04004214 RID: 16916
	[SerializeField]
	private T[] elements;
}
