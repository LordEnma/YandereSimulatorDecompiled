using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005C2 RID: 1474
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x0600251D RID: 9501 RVA: 0x00204CAC File Offset: 0x00202EAC
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x0600251E RID: 9502 RVA: 0x00204CB5 File Offset: 0x00202EB5
		public ReorderableArray(int length)
		{
			this.array = new List<T>(length);
		}

		// Token: 0x17000531 RID: 1329
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

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06002521 RID: 9505 RVA: 0x00204CF1 File Offset: 0x00202EF1
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06002522 RID: 9506 RVA: 0x00204CFE File Offset: 0x00202EFE
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06002523 RID: 9507 RVA: 0x00204D01 File Offset: 0x00202F01
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x00204D0E File Offset: 0x00202F0E
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x06002525 RID: 9509 RVA: 0x00204D1B File Offset: 0x00202F1B
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x06002526 RID: 9510 RVA: 0x00204D34 File Offset: 0x00202F34
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x06002527 RID: 9511 RVA: 0x00204D42 File Offset: 0x00202F42
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x06002528 RID: 9512 RVA: 0x00204D50 File Offset: 0x00202F50
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x06002529 RID: 9513 RVA: 0x00204D5F File Offset: 0x00202F5F
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x0600252A RID: 9514 RVA: 0x00204D6D File Offset: 0x00202F6D
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x0600252B RID: 9515 RVA: 0x00204D7B File Offset: 0x00202F7B
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x0600252C RID: 9516 RVA: 0x00204D88 File Offset: 0x00202F88
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x0600252D RID: 9517 RVA: 0x00204D97 File Offset: 0x00202F97
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x0600252E RID: 9518 RVA: 0x00204DA5 File Offset: 0x00202FA5
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x0600252F RID: 9519 RVA: 0x00204DB2 File Offset: 0x00202FB2
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x06002530 RID: 9520 RVA: 0x00204DC4 File Offset: 0x00202FC4
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004DB2 RID: 19890
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
