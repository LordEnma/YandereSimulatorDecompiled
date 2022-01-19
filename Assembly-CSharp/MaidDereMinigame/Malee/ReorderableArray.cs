using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B3 RID: 1459
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060024B2 RID: 9394 RVA: 0x001FAACC File Offset: 0x001F8CCC
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x001FAAD5 File Offset: 0x001F8CD5
		public ReorderableArray(int length)
		{
			this.array = new List<T>(length);
		}

		// Token: 0x1700052C RID: 1324
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

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024B6 RID: 9398 RVA: 0x001FAB11 File Offset: 0x001F8D11
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024B7 RID: 9399 RVA: 0x001FAB1E File Offset: 0x001F8D1E
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024B8 RID: 9400 RVA: 0x001FAB21 File Offset: 0x001F8D21
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x001FAB2E File Offset: 0x001F8D2E
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x001FAB3B File Offset: 0x001F8D3B
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x001FAB54 File Offset: 0x001F8D54
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x001FAB62 File Offset: 0x001F8D62
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x001FAB70 File Offset: 0x001F8D70
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x001FAB7F File Offset: 0x001F8D7F
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x001FAB8D File Offset: 0x001F8D8D
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x001FAB9B File Offset: 0x001F8D9B
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x001FABA8 File Offset: 0x001F8DA8
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x001FABB7 File Offset: 0x001F8DB7
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x001FABC5 File Offset: 0x001F8DC5
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x001FABD2 File Offset: 0x001F8DD2
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x001FABE4 File Offset: 0x001F8DE4
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004C73 RID: 19571
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
