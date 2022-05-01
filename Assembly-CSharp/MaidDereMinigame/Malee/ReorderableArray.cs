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
		// Token: 0x06002511 RID: 9489 RVA: 0x00202FF8 File Offset: 0x002011F8
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x06002512 RID: 9490 RVA: 0x00203001 File Offset: 0x00201201
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
		// (get) Token: 0x06002515 RID: 9493 RVA: 0x0020303D File Offset: 0x0020123D
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06002516 RID: 9494 RVA: 0x0020304A File Offset: 0x0020124A
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06002517 RID: 9495 RVA: 0x0020304D File Offset: 0x0020124D
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x06002518 RID: 9496 RVA: 0x0020305A File Offset: 0x0020125A
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x06002519 RID: 9497 RVA: 0x00203067 File Offset: 0x00201267
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x0600251A RID: 9498 RVA: 0x00203080 File Offset: 0x00201280
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x0600251B RID: 9499 RVA: 0x0020308E File Offset: 0x0020128E
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x0600251C RID: 9500 RVA: 0x0020309C File Offset: 0x0020129C
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x0600251D RID: 9501 RVA: 0x002030AB File Offset: 0x002012AB
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x0600251E RID: 9502 RVA: 0x002030B9 File Offset: 0x002012B9
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x0600251F RID: 9503 RVA: 0x002030C7 File Offset: 0x002012C7
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x06002520 RID: 9504 RVA: 0x002030D4 File Offset: 0x002012D4
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x06002521 RID: 9505 RVA: 0x002030E3 File Offset: 0x002012E3
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x06002522 RID: 9506 RVA: 0x002030F1 File Offset: 0x002012F1
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x06002523 RID: 9507 RVA: 0x002030FE File Offset: 0x002012FE
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x00203110 File Offset: 0x00201310
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004D82 RID: 19842
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
