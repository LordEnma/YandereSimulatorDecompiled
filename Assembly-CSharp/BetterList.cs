using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02000070 RID: 112
public class BetterList<T>
{
	// Token: 0x06000319 RID: 793 RVA: 0x00020664 File Offset: 0x0001E864
	public IEnumerator<T> GetEnumerator()
	{
		if (this.buffer != null)
		{
			int num;
			for (int i = 0; i < this.size; i = num)
			{
				yield return this.buffer[i];
				num = i + 1;
			}
		}
		yield break;
	}

	// Token: 0x17000057 RID: 87
	[DebuggerHidden]
	[Obsolete("Access the list.buffer[index] instead -- direct array access avoids a copy, so it can be much faster")]
	public T this[int i]
	{
		get
		{
			return this.buffer[i];
		}
		set
		{
			this.buffer[i] = value;
		}
	}

	// Token: 0x0600031C RID: 796 RVA: 0x00020690 File Offset: 0x0001E890
	private void AllocateMore()
	{
		T[] array = (this.buffer != null) ? new T[Mathf.Max(this.buffer.Length << 1, 32)] : new T[32];
		if (this.buffer != null && this.size > 0)
		{
			this.buffer.CopyTo(array, 0);
		}
		this.buffer = array;
	}

	// Token: 0x0600031D RID: 797 RVA: 0x000206EC File Offset: 0x0001E8EC
	private void Trim()
	{
		if (this.size > 0)
		{
			if (this.size < this.buffer.Length)
			{
				T[] array = new T[this.size];
				for (int i = 0; i < this.size; i++)
				{
					array[i] = this.buffer[i];
				}
				this.buffer = array;
				return;
			}
		}
		else
		{
			this.buffer = null;
		}
	}

	// Token: 0x0600031E RID: 798 RVA: 0x00020751 File Offset: 0x0001E951
	public void Clear()
	{
		this.size = 0;
	}

	// Token: 0x0600031F RID: 799 RVA: 0x0002075A File Offset: 0x0001E95A
	public void Release()
	{
		this.size = 0;
		this.buffer = null;
	}

	// Token: 0x06000320 RID: 800 RVA: 0x0002076C File Offset: 0x0001E96C
	public void Add(T item)
	{
		if (this.buffer == null || this.size == this.buffer.Length)
		{
			this.AllocateMore();
		}
		T[] array = this.buffer;
		int num = this.size;
		this.size = num + 1;
		array[num] = item;
	}

	// Token: 0x06000321 RID: 801 RVA: 0x000207B4 File Offset: 0x0001E9B4
	public void Insert(int index, T item)
	{
		if (this.buffer == null || this.size == this.buffer.Length)
		{
			this.AllocateMore();
		}
		if (index > -1 && index < this.size)
		{
			for (int i = this.size; i > index; i--)
			{
				this.buffer[i] = this.buffer[i - 1];
			}
			this.buffer[index] = item;
			this.size++;
			return;
		}
		this.Add(item);
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0002083C File Offset: 0x0001EA3C
	public bool Contains(T item)
	{
		if (this.buffer == null)
		{
			return false;
		}
		for (int i = 0; i < this.size; i++)
		{
			if (this.buffer[i].Equals(item))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000323 RID: 803 RVA: 0x00020888 File Offset: 0x0001EA88
	public int IndexOf(T item)
	{
		if (this.buffer == null)
		{
			return -1;
		}
		for (int i = 0; i < this.size; i++)
		{
			if (this.buffer[i].Equals(item))
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06000324 RID: 804 RVA: 0x000208D4 File Offset: 0x0001EAD4
	public bool Remove(T item)
	{
		if (this.buffer != null)
		{
			EqualityComparer<T> @default = EqualityComparer<T>.Default;
			for (int i = 0; i < this.size; i++)
			{
				if (@default.Equals(this.buffer[i], item))
				{
					this.size--;
					this.buffer[i] = default(T);
					for (int j = i; j < this.size; j++)
					{
						this.buffer[j] = this.buffer[j + 1];
					}
					this.buffer[this.size] = default(T);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0002098C File Offset: 0x0001EB8C
	public void RemoveAt(int index)
	{
		if (this.buffer != null && index > -1 && index < this.size)
		{
			this.size--;
			this.buffer[index] = default(T);
			for (int i = index; i < this.size; i++)
			{
				this.buffer[i] = this.buffer[i + 1];
			}
			this.buffer[this.size] = default(T);
		}
	}

	// Token: 0x06000326 RID: 806 RVA: 0x00020A18 File Offset: 0x0001EC18
	public T Pop()
	{
		if (this.buffer != null && this.size != 0)
		{
			T[] array = this.buffer;
			int num = this.size - 1;
			this.size = num;
			T result = array[num];
			this.buffer[this.size] = default(T);
			return result;
		}
		return default(T);
	}

	// Token: 0x06000327 RID: 807 RVA: 0x00020A75 File Offset: 0x0001EC75
	public T[] ToArray()
	{
		this.Trim();
		return this.buffer;
	}

	// Token: 0x06000328 RID: 808 RVA: 0x00020A84 File Offset: 0x0001EC84
	[DebuggerHidden]
	[DebuggerStepThrough]
	public void Sort(BetterList<T>.CompareFunc comparer)
	{
		int num = 0;
		int num2 = this.size - 1;
		bool flag = true;
		while (flag)
		{
			flag = false;
			for (int i = num; i < num2; i++)
			{
				if (comparer(this.buffer[i], this.buffer[i + 1]) > 0)
				{
					T t = this.buffer[i];
					this.buffer[i] = this.buffer[i + 1];
					this.buffer[i + 1] = t;
					flag = true;
				}
				else if (!flag)
				{
					num = ((i == 0) ? 0 : (i - 1));
				}
			}
		}
	}

	// Token: 0x040004A6 RID: 1190
	public T[] buffer;

	// Token: 0x040004A7 RID: 1191
	public int size;

	// Token: 0x020005F0 RID: 1520
	// (Invoke) Token: 0x06002586 RID: 9606
	public delegate int CompareFunc(T left, T right);
}
