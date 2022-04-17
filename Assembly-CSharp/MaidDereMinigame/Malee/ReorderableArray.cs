using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005C0 RID: 1472
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x06002508 RID: 9480 RVA: 0x00201A58 File Offset: 0x001FFC58
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x06002509 RID: 9481 RVA: 0x00201A61 File Offset: 0x001FFC61
		public ReorderableArray(int length)
		{
			this.array = new List<T>(length);
		}

		// Token: 0x17000530 RID: 1328
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

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x0600250C RID: 9484 RVA: 0x00201A9D File Offset: 0x001FFC9D
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x0600250D RID: 9485 RVA: 0x00201AAA File Offset: 0x001FFCAA
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x0600250E RID: 9486 RVA: 0x00201AAD File Offset: 0x001FFCAD
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x0600250F RID: 9487 RVA: 0x00201ABA File Offset: 0x001FFCBA
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x06002510 RID: 9488 RVA: 0x00201AC7 File Offset: 0x001FFCC7
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x06002511 RID: 9489 RVA: 0x00201AE0 File Offset: 0x001FFCE0
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x06002512 RID: 9490 RVA: 0x00201AEE File Offset: 0x001FFCEE
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x06002513 RID: 9491 RVA: 0x00201AFC File Offset: 0x001FFCFC
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x06002514 RID: 9492 RVA: 0x00201B0B File Offset: 0x001FFD0B
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x06002515 RID: 9493 RVA: 0x00201B19 File Offset: 0x001FFD19
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x06002516 RID: 9494 RVA: 0x00201B27 File Offset: 0x001FFD27
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x06002517 RID: 9495 RVA: 0x00201B34 File Offset: 0x001FFD34
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x06002518 RID: 9496 RVA: 0x00201B43 File Offset: 0x001FFD43
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x06002519 RID: 9497 RVA: 0x00201B51 File Offset: 0x001FFD51
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x0600251A RID: 9498 RVA: 0x00201B5E File Offset: 0x001FFD5E
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x0600251B RID: 9499 RVA: 0x00201B70 File Offset: 0x001FFD70
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004D64 RID: 19812
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
