using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005BF RID: 1471
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024FB RID: 9467 RVA: 0x00200F7D File Offset: 0x001FF17D
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x00200F86 File Offset: 0x001FF186
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024FD RID: 9469 RVA: 0x00200F94 File Offset: 0x001FF194
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024FE RID: 9470 RVA: 0x00200FA2 File Offset: 0x001FF1A2
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024FF RID: 9471 RVA: 0x00200FB0 File Offset: 0x001FF1B0
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x06002500 RID: 9472 RVA: 0x00200FC0 File Offset: 0x001FF1C0
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

		// Token: 0x04004D48 RID: 19784
		public bool add;

		// Token: 0x04004D49 RID: 19785
		public bool remove;

		// Token: 0x04004D4A RID: 19786
		public bool draggable;

		// Token: 0x04004D4B RID: 19787
		public bool singleLine;

		// Token: 0x04004D4C RID: 19788
		public bool paginate;

		// Token: 0x04004D4D RID: 19789
		public bool sortable;

		// Token: 0x04004D4E RID: 19790
		public int pageSize;

		// Token: 0x04004D4F RID: 19791
		public string elementNameProperty;

		// Token: 0x04004D50 RID: 19792
		public string elementNameOverride;

		// Token: 0x04004D51 RID: 19793
		public string elementIconPath;
	}
}
