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
		// Token: 0x060024B8 RID: 9400 RVA: 0x001FB684 File Offset: 0x001F9884
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x001FB68D File Offset: 0x001F988D
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
		// (get) Token: 0x060024BC RID: 9404 RVA: 0x001FB6C9 File Offset: 0x001F98C9
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024BD RID: 9405 RVA: 0x001FB6D6 File Offset: 0x001F98D6
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024BE RID: 9406 RVA: 0x001FB6D9 File Offset: 0x001F98D9
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x001FB6E6 File Offset: 0x001F98E6
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x001FB6F3 File Offset: 0x001F98F3
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x001FB70C File Offset: 0x001F990C
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x001FB71A File Offset: 0x001F991A
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x001FB728 File Offset: 0x001F9928
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x001FB737 File Offset: 0x001F9937
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x001FB745 File Offset: 0x001F9945
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x001FB753 File Offset: 0x001F9953
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x001FB760 File Offset: 0x001F9960
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x001FB76F File Offset: 0x001F996F
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x001FB77D File Offset: 0x001F997D
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024CA RID: 9418 RVA: 0x001FB78A File Offset: 0x001F998A
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024CB RID: 9419 RVA: 0x001FB79C File Offset: 0x001F999C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004C84 RID: 19588
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
