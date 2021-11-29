using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005AD RID: 1453
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x0600248B RID: 9355 RVA: 0x001F76B9 File Offset: 0x001F58B9
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x0600248C RID: 9356 RVA: 0x001F76C2 File Offset: 0x001F58C2
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x001F76D0 File Offset: 0x001F58D0
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x0600248E RID: 9358 RVA: 0x001F76DE File Offset: 0x001F58DE
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x001F76EC File Offset: 0x001F58EC
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x06002490 RID: 9360 RVA: 0x001F76FC File Offset: 0x001F58FC
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

		// Token: 0x04004C06 RID: 19462
		public bool add;

		// Token: 0x04004C07 RID: 19463
		public bool remove;

		// Token: 0x04004C08 RID: 19464
		public bool draggable;

		// Token: 0x04004C09 RID: 19465
		public bool singleLine;

		// Token: 0x04004C0A RID: 19466
		public bool paginate;

		// Token: 0x04004C0B RID: 19467
		public bool sortable;

		// Token: 0x04004C0C RID: 19468
		public int pageSize;

		// Token: 0x04004C0D RID: 19469
		public string elementNameProperty;

		// Token: 0x04004C0E RID: 19470
		public string elementNameOverride;

		// Token: 0x04004C0F RID: 19471
		public string elementIconPath;
	}
}
