using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005AE RID: 1454
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<!0>, ICollection<!0>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x06002491 RID: 9361 RVA: 0x001F7738 File Offset: 0x001F5938
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x001F7741 File Offset: 0x001F5941
		public ReorderableArray(int length)
		{
			this.array = new List<!0>(length);
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
		// (get) Token: 0x06002495 RID: 9365 RVA: 0x001F777D File Offset: 0x001F597D
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06002496 RID: 9366 RVA: 0x001F778A File Offset: 0x001F598A
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06002497 RID: 9367 RVA: 0x001F778D File Offset: 0x001F598D
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x001F779A File Offset: 0x001F599A
		public object Clone()
		{
			return new List<!0>(this.array);
		}

		// Token: 0x06002499 RID: 9369 RVA: 0x001F77A7 File Offset: 0x001F59A7
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x0600249A RID: 9370 RVA: 0x001F77C0 File Offset: 0x001F59C0
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x0600249B RID: 9371 RVA: 0x001F77CE File Offset: 0x001F59CE
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x0600249C RID: 9372 RVA: 0x001F77DC File Offset: 0x001F59DC
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x001F77EB File Offset: 0x001F59EB
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x001F77F9 File Offset: 0x001F59F9
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x0600249F RID: 9375 RVA: 0x001F7807 File Offset: 0x001F5A07
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x001F7814 File Offset: 0x001F5A14
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001F7823 File Offset: 0x001F5A23
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024A2 RID: 9378 RVA: 0x001F7831 File Offset: 0x001F5A31
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x001F783E File Offset: 0x001F5A3E
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024A4 RID: 9380 RVA: 0x001F7850 File Offset: 0x001F5A50
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004C10 RID: 19472
		[SerializeField]
		private List<T> array = new List<!0>();
	}
}
