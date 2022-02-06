using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B3 RID: 1459
	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060024BB RID: 9403 RVA: 0x001FB888 File Offset: 0x001F9A88
		public ReorderableArray() : this(0)
		{
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x001FB891 File Offset: 0x001F9A91
		public ReorderableArray(int length)
		{
			this.array = new List<T>(length);
		}

		// Token: 0x1700052D RID: 1325
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

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024BF RID: 9407 RVA: 0x001FB8CD File Offset: 0x001F9ACD
		public int Length
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060024C0 RID: 9408 RVA: 0x001FB8DA File Offset: 0x001F9ADA
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x060024C1 RID: 9409 RVA: 0x001FB8DD File Offset: 0x001F9ADD
		public int Count
		{
			get
			{
				return this.array.Count;
			}
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x001FB8EA File Offset: 0x001F9AEA
		public object Clone()
		{
			return new List<T>(this.array);
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x001FB8F7 File Offset: 0x001F9AF7
		public void CopyFrom(IEnumerable<T> value)
		{
			this.array.Clear();
			this.array.AddRange(value);
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x001FB910 File Offset: 0x001F9B10
		public bool Contains(T value)
		{
			return this.array.Contains(value);
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x001FB91E File Offset: 0x001F9B1E
		public int IndexOf(T value)
		{
			return this.array.IndexOf(value);
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x001FB92C File Offset: 0x001F9B2C
		public void Insert(int index, T item)
		{
			this.array.Insert(index, item);
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x001FB93B File Offset: 0x001F9B3B
		public void RemoveAt(int index)
		{
			this.array.RemoveAt(index);
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x001FB949 File Offset: 0x001F9B49
		public void Add(T item)
		{
			this.array.Add(item);
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x001FB957 File Offset: 0x001F9B57
		public void Clear()
		{
			this.array.Clear();
		}

		// Token: 0x060024CA RID: 9418 RVA: 0x001FB964 File Offset: 0x001F9B64
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.array.CopyTo(array, arrayIndex);
		}

		// Token: 0x060024CB RID: 9419 RVA: 0x001FB973 File Offset: 0x001F9B73
		public bool Remove(T item)
		{
			return this.array.Remove(item);
		}

		// Token: 0x060024CC RID: 9420 RVA: 0x001FB981 File Offset: 0x001F9B81
		public T[] ToArray()
		{
			return this.array.ToArray();
		}

		// Token: 0x060024CD RID: 9421 RVA: 0x001FB98E File Offset: 0x001F9B8E
		public IEnumerator<T> GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x060024CE RID: 9422 RVA: 0x001FB9A0 File Offset: 0x001F9BA0
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.array.GetEnumerator();
		}

		// Token: 0x04004C87 RID: 19591
		[SerializeField]
		private List<T> array = new List<T>();
	}
}
