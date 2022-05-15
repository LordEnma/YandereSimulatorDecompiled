using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005C2 RID: 1474
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x0600251C RID: 9500 RVA: 0x00204744 File Offset: 0x00202944
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x0600251D RID: 9501 RVA: 0x0020474D File Offset: 0x0020294D
		public ReorderableArray(int length)
		{
			this.array = new List<T>(length);
		}

		// Token: 0x17000531 RID: 1329
		public T this[int index]
		{
			get
			{
				return this.array[index];
			}
			set
			{
				this.array[index] = value;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06002520 RID: 9504 RVA: 0x00204789 File Offset: 0x00202989
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06002521 RID: 9505 RVA: 0x00204796 File Offset: 0x00202996
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06002522 RID: 9506 RVA: 0x00204799 File Offset: 0x00202999
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x06002523 RID: 9507 RVA: 0x002047A6 File Offset: 0x002029A6
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x002047B3 File Offset: 0x002029B3
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x06002525 RID: 9509 RVA: 0x002047CC File Offset: 0x002029CC
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x06002526 RID: 9510 RVA: 0x002047DA File Offset: 0x002029DA
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x06002527 RID: 9511 RVA: 0x002047E8 File Offset: 0x002029E8
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x06002528 RID: 9512 RVA: 0x002047F7 File Offset: 0x002029F7
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x06002529 RID: 9513 RVA: 0x00204805 File Offset: 0x00202A05
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x0600252A RID: 9514 RVA: 0x00204813 File Offset: 0x00202A13
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x0600252B RID: 9515 RVA: 0x00204820 File Offset: 0x00202A20
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x0600252C RID: 9516 RVA: 0x0020482F File Offset: 0x00202A2F
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x0600252D RID: 9517 RVA: 0x0020483D File Offset: 0x00202A3D
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x0600252E RID: 9518 RVA: 0x0020484A File Offset: 0x00202A4A
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x0600252F RID: 9519 RVA: 0x0020485C File Offset: 0x00202A5C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004DA9 RID: 19881
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
