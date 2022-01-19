using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B2 RID: 1458
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024AC RID: 9388 RVA: 0x001FAA4D File Offset: 0x001F8C4D
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x001FAA56 File Offset: 0x001F8C56
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x001FAA64 File Offset: 0x001F8C64
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x001FAA72 File Offset: 0x001F8C72
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x001FAA80 File Offset: 0x001F8C80
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001FAA90 File Offset: 0x001F8C90
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

		// Token: 0x04004C69 RID: 19561
		public bool add;

		// Token: 0x04004C6A RID: 19562
		public bool remove;

		// Token: 0x04004C6B RID: 19563
		public bool draggable;

		// Token: 0x04004C6C RID: 19564
		public bool singleLine;

		// Token: 0x04004C6D RID: 19565
		public bool paginate;

		// Token: 0x04004C6E RID: 19566
		public bool sortable;

		// Token: 0x04004C6F RID: 19567
		public int pageSize;

		// Token: 0x04004C70 RID: 19568
		public string elementNameProperty;

		// Token: 0x04004C71 RID: 19569
		public string elementNameOverride;

		// Token: 0x04004C72 RID: 19570
		public string elementIconPath;
	}
}
