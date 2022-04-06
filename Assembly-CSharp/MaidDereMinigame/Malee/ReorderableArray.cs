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
		// Token: 0x06002501 RID: 9473 RVA: 0x00200FFC File Offset: 0x001FF1FC
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x00201005 File Offset: 0x001FF205
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
		// (get) Token: 0x06002505 RID: 9477 RVA: 0x00201041 File Offset: 0x001FF241
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06002506 RID: 9478 RVA: 0x0020104E File Offset: 0x001FF24E
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06002507 RID: 9479 RVA: 0x00201051 File Offset: 0x001FF251
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x06002508 RID: 9480 RVA: 0x0020105E File Offset: 0x001FF25E
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x06002509 RID: 9481 RVA: 0x0020106B File Offset: 0x001FF26B
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x0600250A RID: 9482 RVA: 0x00201084 File Offset: 0x001FF284
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x0600250B RID: 9483 RVA: 0x00201092 File Offset: 0x001FF292
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x002010A0 File Offset: 0x001FF2A0
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x0600250D RID: 9485 RVA: 0x002010AF File Offset: 0x001FF2AF
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x0600250E RID: 9486 RVA: 0x002010BD File Offset: 0x001FF2BD
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x0600250F RID: 9487 RVA: 0x002010CB File Offset: 0x001FF2CB
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x06002510 RID: 9488 RVA: 0x002010D8 File Offset: 0x001FF2D8
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x06002511 RID: 9489 RVA: 0x002010E7 File Offset: 0x001FF2E7
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x06002512 RID: 9490 RVA: 0x002010F5 File Offset: 0x001FF2F5
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x06002513 RID: 9491 RVA: 0x00201102 File Offset: 0x001FF302
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x06002514 RID: 9492 RVA: 0x00201114 File Offset: 0x001FF314
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004D52 RID: 19794
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
