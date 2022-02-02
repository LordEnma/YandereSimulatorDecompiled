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
		// Token: 0x060024B6 RID: 9398 RVA: 0x001FB36C File Offset: 0x001F956C
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001FB375 File Offset: 0x001F9575
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
		// (get) Token: 0x060024BA RID: 9402 RVA: 0x001FB3B1 File Offset: 0x001F95B1
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024BB RID: 9403 RVA: 0x001FB3BE File Offset: 0x001F95BE
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024BC RID: 9404 RVA: 0x001FB3C1 File Offset: 0x001F95C1
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x001FB3CE File Offset: 0x001F95CE
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x001FB3DB File Offset: 0x001F95DB
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x001FB3F4 File Offset: 0x001F95F4
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x001FB402 File Offset: 0x001F9602
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x001FB410 File Offset: 0x001F9610
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x001FB41F File Offset: 0x001F961F
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x001FB42D File Offset: 0x001F962D
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x001FB43B File Offset: 0x001F963B
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x001FB448 File Offset: 0x001F9648
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x001FB457 File Offset: 0x001F9657
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x001FB465 File Offset: 0x001F9665
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x001FB472 File Offset: 0x001F9672
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x001FB484 File Offset: 0x001F9684
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004C7E RID: 19582
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
