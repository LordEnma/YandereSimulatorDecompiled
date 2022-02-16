using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B3 RID: 1459
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024BC RID: 9404 RVA: 0x001FBCBD File Offset: 0x001F9EBD
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x001FBCC6 File Offset: 0x001F9EC6
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x001FBCD4 File Offset: 0x001F9ED4
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x001FBCE2 File Offset: 0x001F9EE2
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x001FBCF0 File Offset: 0x001F9EF0
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x001FBD00 File Offset: 0x001F9F00
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

		// Token: 0x04004C86 RID: 19590
		public bool add;

		// Token: 0x04004C87 RID: 19591
		public bool remove;

		// Token: 0x04004C88 RID: 19592
		public bool draggable;

		// Token: 0x04004C89 RID: 19593
		public bool singleLine;

		// Token: 0x04004C8A RID: 19594
		public bool paginate;

		// Token: 0x04004C8B RID: 19595
		public bool sortable;

		// Token: 0x04004C8C RID: 19596
		public int pageSize;

		// Token: 0x04004C8D RID: 19597
		public string elementNameProperty;

		// Token: 0x04004C8E RID: 19598
		public string elementNameOverride;

		// Token: 0x04004C8F RID: 19599
		public string elementIconPath;
	}
}
