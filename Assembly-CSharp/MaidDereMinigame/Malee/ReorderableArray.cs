using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B0 RID: 1456
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060024A2 RID: 9378 RVA: 0x001F8E6C File Offset: 0x001F706C
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x001F8E75 File Offset: 0x001F7075
		public ReorderableArray(int length)
		{
			this.array = new List<T>(length);
		}

		// Token: 0x1700052B RID: 1323
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

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060024A6 RID: 9382 RVA: 0x001F8EB1 File Offset: 0x001F70B1
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024A7 RID: 9383 RVA: 0x001F8EBE File Offset: 0x001F70BE
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024A8 RID: 9384 RVA: 0x001F8EC1 File Offset: 0x001F70C1
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x001F8ECE File Offset: 0x001F70CE
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x001F8EDB File Offset: 0x001F70DB
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024AB RID: 9387 RVA: 0x001F8EF4 File Offset: 0x001F70F4
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024AC RID: 9388 RVA: 0x001F8F02 File Offset: 0x001F7102
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x001F8F10 File Offset: 0x001F7110
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x001F8F1F File Offset: 0x001F711F
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x001F8F2D File Offset: 0x001F712D
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x001F8F3B File Offset: 0x001F713B
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001F8F48 File Offset: 0x001F7148
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x001F8F57 File Offset: 0x001F7157
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x001F8F65 File Offset: 0x001F7165
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x001F8F72 File Offset: 0x001F7172
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x001F8F84 File Offset: 0x001F7184
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004C4F RID: 19535
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
