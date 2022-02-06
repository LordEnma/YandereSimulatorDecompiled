using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B2 RID: 1458
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024B5 RID: 9397 RVA: 0x001FB809 File Offset: 0x001F9A09
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x001FB812 File Offset: 0x001F9A12
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001FB820 File Offset: 0x001F9A20
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x001FB82E File Offset: 0x001F9A2E
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x001FB83C File Offset: 0x001F9A3C
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x001FB84C File Offset: 0x001F9A4C
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

		// Token: 0x04004C7D RID: 19581
		public bool add;

		// Token: 0x04004C7E RID: 19582
		public bool remove;

		// Token: 0x04004C7F RID: 19583
		public bool draggable;

		// Token: 0x04004C80 RID: 19584
		public bool singleLine;

		// Token: 0x04004C81 RID: 19585
		public bool paginate;

		// Token: 0x04004C82 RID: 19586
		public bool sortable;

		// Token: 0x04004C83 RID: 19587
		public int pageSize;

		// Token: 0x04004C84 RID: 19588
		public string elementNameProperty;

		// Token: 0x04004C85 RID: 19589
		public string elementNameOverride;

		// Token: 0x04004C86 RID: 19590
		public string elementIconPath;
	}
}
