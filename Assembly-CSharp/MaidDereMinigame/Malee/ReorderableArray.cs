using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005BA RID: 1466
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060024E9 RID: 9449 RVA: 0x001FF25C File Offset: 0x001FD45C
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024EA RID: 9450 RVA: 0x001FF265 File Offset: 0x001FD465
		public ReorderableArray(int length)
		{
			this.array = new List<T>(length);
		}

		// Token: 0x1700052F RID: 1327
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

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x060024ED RID: 9453 RVA: 0x001FF2A1 File Offset: 0x001FD4A1
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x060024EE RID: 9454 RVA: 0x001FF2AE File Offset: 0x001FD4AE
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x060024EF RID: 9455 RVA: 0x001FF2B1 File Offset: 0x001FD4B1
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024F0 RID: 9456 RVA: 0x001FF2BE File Offset: 0x001FD4BE
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024F1 RID: 9457 RVA: 0x001FF2CB File Offset: 0x001FD4CB
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x001FF2E4 File Offset: 0x001FD4E4
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024F3 RID: 9459 RVA: 0x001FF2F2 File Offset: 0x001FD4F2
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024F4 RID: 9460 RVA: 0x001FF300 File Offset: 0x001FD500
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024F5 RID: 9461 RVA: 0x001FF30F File Offset: 0x001FD50F
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024F6 RID: 9462 RVA: 0x001FF31D File Offset: 0x001FD51D
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024F7 RID: 9463 RVA: 0x001FF32B File Offset: 0x001FD52B
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024F8 RID: 9464 RVA: 0x001FF338 File Offset: 0x001FD538
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024F9 RID: 9465 RVA: 0x001FF347 File Offset: 0x001FD547
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024FA RID: 9466 RVA: 0x001FF355 File Offset: 0x001FD555
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024FB RID: 9467 RVA: 0x001FF362 File Offset: 0x001FD562
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x001FF374 File Offset: 0x001FD574
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004D1C RID: 19740
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
