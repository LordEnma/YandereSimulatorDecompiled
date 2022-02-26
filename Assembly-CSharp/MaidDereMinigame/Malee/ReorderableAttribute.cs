using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B4 RID: 1460
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024C5 RID: 9413 RVA: 0x001FC89D File Offset: 0x001FAA9D
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x001FC8A6 File Offset: 0x001FAAA6
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x001FC8B4 File Offset: 0x001FAAB4
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x001FC8C2 File Offset: 0x001FAAC2
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x001FC8D0 File Offset: 0x001FAAD0
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024CA RID: 9418 RVA: 0x001FC8E0 File Offset: 0x001FAAE0
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementNameOverride = null, string elementIconPath = null)
		{
			this.add = add;
			this.remove = remove;
			this.draggable = draggable;
			this.sortable = true;
			this.elementNameProperty = elementNameProperty;
			this.elementNameOverride = elementNameOverride;
			this.elementIconPath = elementIconPath;
		}

		// Token: 0x04004C96 RID: 19606
		public bool add;

		// Token: 0x04004C97 RID: 19607
		public bool remove;

		// Token: 0x04004C98 RID: 19608
		public bool draggable;

		// Token: 0x04004C99 RID: 19609
		public bool singleLine;

		// Token: 0x04004C9A RID: 19610
		public bool paginate;

		// Token: 0x04004C9B RID: 19611
		public bool sortable;

		// Token: 0x04004C9C RID: 19612
		public int pageSize;

		// Token: 0x04004C9D RID: 19613
		public string elementNameProperty;

		// Token: 0x04004C9E RID: 19614
		public string elementNameOverride;

		// Token: 0x04004C9F RID: 19615
		public string elementIconPath;
	}
}
