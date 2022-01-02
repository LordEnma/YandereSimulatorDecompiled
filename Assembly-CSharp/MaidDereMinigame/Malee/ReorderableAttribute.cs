using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005AF RID: 1455
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x0600249F RID: 9375 RVA: 0x001F93DD File Offset: 0x001F75DD
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x001F93E6 File Offset: 0x001F75E6
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001F93F4 File Offset: 0x001F75F4
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024A2 RID: 9378 RVA: 0x001F9402 File Offset: 0x001F7602
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x001F9410 File Offset: 0x001F7610
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024A4 RID: 9380 RVA: 0x001F9420 File Offset: 0x001F7620
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

		// Token: 0x04004C4E RID: 19534
		public bool add;

		// Token: 0x04004C4F RID: 19535
		public bool remove;

		// Token: 0x04004C50 RID: 19536
		public bool draggable;

		// Token: 0x04004C51 RID: 19537
		public bool singleLine;

		// Token: 0x04004C52 RID: 19538
		public bool paginate;

		// Token: 0x04004C53 RID: 19539
		public bool sortable;

		// Token: 0x04004C54 RID: 19540
		public int pageSize;

		// Token: 0x04004C55 RID: 19541
		public string elementNameProperty;

		// Token: 0x04004C56 RID: 19542
		public string elementNameOverride;

		// Token: 0x04004C57 RID: 19543
		public string elementIconPath;
	}
}
