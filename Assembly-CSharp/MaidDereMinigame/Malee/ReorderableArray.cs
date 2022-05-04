using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005C1 RID: 1473
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x06002512 RID: 9490 RVA: 0x002030F4 File Offset: 0x002012F4
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x06002513 RID: 9491 RVA: 0x002030FD File Offset: 0x002012FD
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
		// (get) Token: 0x06002516 RID: 9494 RVA: 0x00203139 File Offset: 0x00201339
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06002517 RID: 9495 RVA: 0x00203146 File Offset: 0x00201346
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06002518 RID: 9496 RVA: 0x00203149 File Offset: 0x00201349
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x06002519 RID: 9497 RVA: 0x00203156 File Offset: 0x00201356
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x0600251A RID: 9498 RVA: 0x00203163 File Offset: 0x00201363
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x0600251B RID: 9499 RVA: 0x0020317C File Offset: 0x0020137C
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x0600251C RID: 9500 RVA: 0x0020318A File Offset: 0x0020138A
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x0600251D RID: 9501 RVA: 0x00203198 File Offset: 0x00201398
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x0600251E RID: 9502 RVA: 0x002031A7 File Offset: 0x002013A7
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x0600251F RID: 9503 RVA: 0x002031B5 File Offset: 0x002013B5
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x06002520 RID: 9504 RVA: 0x002031C3 File Offset: 0x002013C3
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x06002521 RID: 9505 RVA: 0x002031D0 File Offset: 0x002013D0
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x06002522 RID: 9506 RVA: 0x002031DF File Offset: 0x002013DF
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x06002523 RID: 9507 RVA: 0x002031ED File Offset: 0x002013ED
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x002031FA File Offset: 0x002013FA
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x06002525 RID: 9509 RVA: 0x0020320C File Offset: 0x0020140C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004D82 RID: 19842
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
