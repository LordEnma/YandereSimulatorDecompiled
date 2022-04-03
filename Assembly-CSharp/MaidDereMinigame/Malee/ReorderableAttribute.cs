using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005BE RID: 1470
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024F3 RID: 9459 RVA: 0x00200A4D File Offset: 0x001FEC4D
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024F4 RID: 9460 RVA: 0x00200A56 File Offset: 0x001FEC56
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024F5 RID: 9461 RVA: 0x00200A64 File Offset: 0x001FEC64
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024F6 RID: 9462 RVA: 0x00200A72 File Offset: 0x001FEC72
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024F7 RID: 9463 RVA: 0x00200A80 File Offset: 0x001FEC80
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024F8 RID: 9464 RVA: 0x00200A90 File Offset: 0x001FEC90
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

		// Token: 0x04004D44 RID: 19780
		public bool add;

		// Token: 0x04004D45 RID: 19781
		public bool remove;

		// Token: 0x04004D46 RID: 19782
		public bool draggable;

		// Token: 0x04004D47 RID: 19783
		public bool singleLine;

		// Token: 0x04004D48 RID: 19784
		public bool paginate;

		// Token: 0x04004D49 RID: 19785
		public bool sortable;

		// Token: 0x04004D4A RID: 19786
		public int pageSize;

		// Token: 0x04004D4B RID: 19787
		public string elementNameProperty;

		// Token: 0x04004D4C RID: 19788
		public string elementNameOverride;

		// Token: 0x04004D4D RID: 19789
		public string elementIconPath;
	}
}
