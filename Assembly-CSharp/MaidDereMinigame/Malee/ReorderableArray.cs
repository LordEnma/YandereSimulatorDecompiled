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
		// Token: 0x060024A5 RID: 9381 RVA: 0x001F945C File Offset: 0x001F765C
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x001F9465 File Offset: 0x001F7665
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
		// (get) Token: 0x060024A9 RID: 9385 RVA: 0x001F94A1 File Offset: 0x001F76A1
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024AA RID: 9386 RVA: 0x001F94AE File Offset: 0x001F76AE
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024AB RID: 9387 RVA: 0x001F94B1 File Offset: 0x001F76B1
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024AC RID: 9388 RVA: 0x001F94BE File Offset: 0x001F76BE
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x001F94CB File Offset: 0x001F76CB
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x001F94E4 File Offset: 0x001F76E4
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x001F94F2 File Offset: 0x001F76F2
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x001F9500 File Offset: 0x001F7700
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001F950F File Offset: 0x001F770F
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x001F951D File Offset: 0x001F771D
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x001F952B File Offset: 0x001F772B
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x001F9538 File Offset: 0x001F7738
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x001F9547 File Offset: 0x001F7747
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x001F9555 File Offset: 0x001F7755
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001F9562 File Offset: 0x001F7762
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x001F9574 File Offset: 0x001F7774
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004C58 RID: 19544
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
