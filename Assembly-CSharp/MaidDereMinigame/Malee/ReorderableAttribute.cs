using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005C0 RID: 1472
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x0600250B RID: 9483 RVA: 0x00202F79 File Offset: 0x00201179
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x00202F82 File Offset: 0x00201182
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x0600250D RID: 9485 RVA: 0x00202F90 File Offset: 0x00201190
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x0600250E RID: 9486 RVA: 0x00202F9E File Offset: 0x0020119E
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x0600250F RID: 9487 RVA: 0x00202FAC File Offset: 0x002011AC
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x06002510 RID: 9488 RVA: 0x00202FBC File Offset: 0x002011BC
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

		// Token: 0x04004D78 RID: 19832
		public bool add;

		// Token: 0x04004D79 RID: 19833
		public bool remove;

		// Token: 0x04004D7A RID: 19834
		public bool draggable;

		// Token: 0x04004D7B RID: 19835
		public bool singleLine;

		// Token: 0x04004D7C RID: 19836
		public bool paginate;

		// Token: 0x04004D7D RID: 19837
		public bool sortable;

		// Token: 0x04004D7E RID: 19838
		public int pageSize;

		// Token: 0x04004D7F RID: 19839
		public string elementNameProperty;

		// Token: 0x04004D80 RID: 19840
		public string elementNameOverride;

		// Token: 0x04004D81 RID: 19841
		public string elementIconPath;
	}
}
