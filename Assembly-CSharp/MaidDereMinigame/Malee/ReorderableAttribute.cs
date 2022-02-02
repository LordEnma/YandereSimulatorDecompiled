using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B2 RID: 1458
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024B0 RID: 9392 RVA: 0x001FB2ED File Offset: 0x001F94ED
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001FB2F6 File Offset: 0x001F94F6
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x001FB304 File Offset: 0x001F9504
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x001FB312 File Offset: 0x001F9512
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x001FB320 File Offset: 0x001F9520
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x001FB330 File Offset: 0x001F9530
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

		// Token: 0x04004C74 RID: 19572
		public bool add;

		// Token: 0x04004C75 RID: 19573
		public bool remove;

		// Token: 0x04004C76 RID: 19574
		public bool draggable;

		// Token: 0x04004C77 RID: 19575
		public bool singleLine;

		// Token: 0x04004C78 RID: 19576
		public bool paginate;

		// Token: 0x04004C79 RID: 19577
		public bool sortable;

		// Token: 0x04004C7A RID: 19578
		public int pageSize;

		// Token: 0x04004C7B RID: 19579
		public string elementNameProperty;

		// Token: 0x04004C7C RID: 19580
		public string elementNameOverride;

		// Token: 0x04004C7D RID: 19581
		public string elementIconPath;
	}
}
