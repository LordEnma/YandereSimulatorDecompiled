using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B4 RID: 1460
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060024C2 RID: 9410 RVA: 0x001FBD3C File Offset: 0x001F9F3C
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x001FBD45 File Offset: 0x001F9F45
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
		// (get) Token: 0x060024C6 RID: 9414 RVA: 0x001FBD81 File Offset: 0x001F9F81
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x060024C7 RID: 9415 RVA: 0x001FBD8E File Offset: 0x001F9F8E
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x060024C8 RID: 9416 RVA: 0x001FBD91 File Offset: 0x001F9F91
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x001FBD9E File Offset: 0x001F9F9E
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024CA RID: 9418 RVA: 0x001FBDAB File Offset: 0x001F9FAB
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024CB RID: 9419 RVA: 0x001FBDC4 File Offset: 0x001F9FC4
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024CC RID: 9420 RVA: 0x001FBDD2 File Offset: 0x001F9FD2
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024CD RID: 9421 RVA: 0x001FBDE0 File Offset: 0x001F9FE0
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024CE RID: 9422 RVA: 0x001FBDEF File Offset: 0x001F9FEF
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x001FBDFD File Offset: 0x001F9FFD
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024D0 RID: 9424 RVA: 0x001FBE0B File Offset: 0x001FA00B
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024D1 RID: 9425 RVA: 0x001FBE18 File Offset: 0x001FA018
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024D2 RID: 9426 RVA: 0x001FBE27 File Offset: 0x001FA027
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024D3 RID: 9427 RVA: 0x001FBE35 File Offset: 0x001FA035
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024D4 RID: 9428 RVA: 0x001FBE42 File Offset: 0x001FA042
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024D5 RID: 9429 RVA: 0x001FBE54 File Offset: 0x001FA054
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004C90 RID: 19600
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
