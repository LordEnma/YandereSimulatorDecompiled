using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005BF RID: 1471
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060024F9 RID: 9465 RVA: 0x00200ACC File Offset: 0x001FECCC
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024FA RID: 9466 RVA: 0x00200AD5 File Offset: 0x001FECD5
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
		// (get) Token: 0x060024FD RID: 9469 RVA: 0x00200B11 File Offset: 0x001FED11
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x060024FE RID: 9470 RVA: 0x00200B1E File Offset: 0x001FED1E
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x060024FF RID: 9471 RVA: 0x00200B21 File Offset: 0x001FED21
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x06002500 RID: 9472 RVA: 0x00200B2E File Offset: 0x001FED2E
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x06002501 RID: 9473 RVA: 0x00200B3B File Offset: 0x001FED3B
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x00200B54 File Offset: 0x001FED54
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x06002503 RID: 9475 RVA: 0x00200B62 File Offset: 0x001FED62
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x06002504 RID: 9476 RVA: 0x00200B70 File Offset: 0x001FED70
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x06002505 RID: 9477 RVA: 0x00200B7F File Offset: 0x001FED7F
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x06002506 RID: 9478 RVA: 0x00200B8D File Offset: 0x001FED8D
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x06002507 RID: 9479 RVA: 0x00200B9B File Offset: 0x001FED9B
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x06002508 RID: 9480 RVA: 0x00200BA8 File Offset: 0x001FEDA8
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x06002509 RID: 9481 RVA: 0x00200BB7 File Offset: 0x001FEDB7
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x0600250A RID: 9482 RVA: 0x00200BC5 File Offset: 0x001FEDC5
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x0600250B RID: 9483 RVA: 0x00200BD2 File Offset: 0x001FEDD2
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x00200BE4 File Offset: 0x001FEDE4
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004D4E RID: 19790
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
