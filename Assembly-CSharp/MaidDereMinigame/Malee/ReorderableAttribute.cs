using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005BF RID: 1471
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x06002502 RID: 9474 RVA: 0x002019D9 File Offset: 0x001FFBD9
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x06002503 RID: 9475 RVA: 0x002019E2 File Offset: 0x001FFBE2
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x06002504 RID: 9476 RVA: 0x002019F0 File Offset: 0x001FFBF0
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x06002505 RID: 9477 RVA: 0x002019FE File Offset: 0x001FFBFE
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x06002506 RID: 9478 RVA: 0x00201A0C File Offset: 0x001FFC0C
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x06002507 RID: 9479 RVA: 0x00201A1C File Offset: 0x001FFC1C
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

		// Token: 0x04004D5A RID: 19802
		public bool add;

		// Token: 0x04004D5B RID: 19803
		public bool remove;

		// Token: 0x04004D5C RID: 19804
		public bool draggable;

		// Token: 0x04004D5D RID: 19805
		public bool singleLine;

		// Token: 0x04004D5E RID: 19806
		public bool paginate;

		// Token: 0x04004D5F RID: 19807
		public bool sortable;

		// Token: 0x04004D60 RID: 19808
		public int pageSize;

		// Token: 0x04004D61 RID: 19809
		public string elementNameProperty;

		// Token: 0x04004D62 RID: 19810
		public string elementNameOverride;

		// Token: 0x04004D63 RID: 19811
		public string elementIconPath;
	}
}
