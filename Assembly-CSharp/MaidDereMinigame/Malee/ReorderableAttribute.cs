using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B2 RID: 1458
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024B2 RID: 9394 RVA: 0x001FB605 File Offset: 0x001F9805
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x001FB60E File Offset: 0x001F980E
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x001FB61C File Offset: 0x001F981C
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x001FB62A File Offset: 0x001F982A
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x001FB638 File Offset: 0x001F9838
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001FB648 File Offset: 0x001F9848
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

		// Token: 0x04004C7A RID: 19578
		public bool add;

		// Token: 0x04004C7B RID: 19579
		public bool remove;

		// Token: 0x04004C7C RID: 19580
		public bool draggable;

		// Token: 0x04004C7D RID: 19581
		public bool singleLine;

		// Token: 0x04004C7E RID: 19582
		public bool paginate;

		// Token: 0x04004C7F RID: 19583
		public bool sortable;

		// Token: 0x04004C80 RID: 19584
		public int pageSize;

		// Token: 0x04004C81 RID: 19585
		public string elementNameProperty;

		// Token: 0x04004C82 RID: 19586
		public string elementNameOverride;

		// Token: 0x04004C83 RID: 19587
		public string elementIconPath;
	}
}
