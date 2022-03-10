using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B6 RID: 1462
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060024D1 RID: 9425 RVA: 0x001FD2F4 File Offset: 0x001FB4F4
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024D2 RID: 9426 RVA: 0x001FD2FD File Offset: 0x001FB4FD
		public ReorderableArray(int length)
		{
			this.array = new List<T>(length);
		}

		// Token: 0x1700052E RID: 1326
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

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024D5 RID: 9429 RVA: 0x001FD339 File Offset: 0x001FB539
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x060024D6 RID: 9430 RVA: 0x001FD346 File Offset: 0x001FB546
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x060024D7 RID: 9431 RVA: 0x001FD349 File Offset: 0x001FB549
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x001FD356 File Offset: 0x001FB556
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024D9 RID: 9433 RVA: 0x001FD363 File Offset: 0x001FB563
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024DA RID: 9434 RVA: 0x001FD37C File Offset: 0x001FB57C
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024DB RID: 9435 RVA: 0x001FD38A File Offset: 0x001FB58A
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024DC RID: 9436 RVA: 0x001FD398 File Offset: 0x001FB598
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024DD RID: 9437 RVA: 0x001FD3A7 File Offset: 0x001FB5A7
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024DE RID: 9438 RVA: 0x001FD3B5 File Offset: 0x001FB5B5
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024DF RID: 9439 RVA: 0x001FD3C3 File Offset: 0x001FB5C3
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024E0 RID: 9440 RVA: 0x001FD3D0 File Offset: 0x001FB5D0
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024E1 RID: 9441 RVA: 0x001FD3DF File Offset: 0x001FB5DF
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x001FD3ED File Offset: 0x001FB5ED
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x001FD3FA File Offset: 0x001FB5FA
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x001FD40C File Offset: 0x001FB60C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004CBD RID: 19645
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
