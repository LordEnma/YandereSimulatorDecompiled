using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B2 RID: 1458
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060024B0 RID: 9392 RVA: 0x001F9DFC File Offset: 0x001F7FFC
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001F9E05 File Offset: 0x001F8005
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
		// (get) Token: 0x060024B4 RID: 9396 RVA: 0x001F9E41 File Offset: 0x001F8041
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024B5 RID: 9397 RVA: 0x001F9E4E File Offset: 0x001F804E
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024B6 RID: 9398 RVA: 0x001F9E51 File Offset: 0x001F8051
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001F9E5E File Offset: 0x001F805E
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x001F9E6B File Offset: 0x001F806B
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x001F9E84 File Offset: 0x001F8084
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x001F9E92 File Offset: 0x001F8092
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x001F9EA0 File Offset: 0x001F80A0
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x001F9EAF File Offset: 0x001F80AF
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x001F9EBD File Offset: 0x001F80BD
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x001F9ECB File Offset: 0x001F80CB
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x001F9ED8 File Offset: 0x001F80D8
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x001F9EE7 File Offset: 0x001F80E7
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x001F9EF5 File Offset: 0x001F80F5
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x001F9F02 File Offset: 0x001F8102
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x001F9F14 File Offset: 0x001F8114
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004C6C RID: 19564
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
