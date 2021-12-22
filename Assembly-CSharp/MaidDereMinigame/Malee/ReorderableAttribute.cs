using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005AF RID: 1455
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x0600249C RID: 9372 RVA: 0x001F8DED File Offset: 0x001F6FED
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x001F8DF6 File Offset: 0x001F6FF6
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x001F8E04 File Offset: 0x001F7004
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x0600249F RID: 9375 RVA: 0x001F8E12 File Offset: 0x001F7012
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x001F8E20 File Offset: 0x001F7020
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001F8E30 File Offset: 0x001F7030
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

		// Token: 0x04004C45 RID: 19525
		public bool add;

		// Token: 0x04004C46 RID: 19526
		public bool remove;

		// Token: 0x04004C47 RID: 19527
		public bool draggable;

		// Token: 0x04004C48 RID: 19528
		public bool singleLine;

		// Token: 0x04004C49 RID: 19529
		public bool paginate;

		// Token: 0x04004C4A RID: 19530
		public bool sortable;

		// Token: 0x04004C4B RID: 19531
		public int pageSize;

		// Token: 0x04004C4C RID: 19532
		public string elementNameProperty;

		// Token: 0x04004C4D RID: 19533
		public string elementNameOverride;

		// Token: 0x04004C4E RID: 19534
		public string elementIconPath;
	}
}
