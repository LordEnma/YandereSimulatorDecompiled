using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B5 RID: 1461
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024CB RID: 9419 RVA: 0x001FD275 File Offset: 0x001FB475
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024CC RID: 9420 RVA: 0x001FD27E File Offset: 0x001FB47E
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024CD RID: 9421 RVA: 0x001FD28C File Offset: 0x001FB48C
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024CE RID: 9422 RVA: 0x001FD29A File Offset: 0x001FB49A
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x001FD2A8 File Offset: 0x001FB4A8
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024D0 RID: 9424 RVA: 0x001FD2B8 File Offset: 0x001FB4B8
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

		// Token: 0x04004CB3 RID: 19635
		public bool add;

		// Token: 0x04004CB4 RID: 19636
		public bool remove;

		// Token: 0x04004CB5 RID: 19637
		public bool draggable;

		// Token: 0x04004CB6 RID: 19638
		public bool singleLine;

		// Token: 0x04004CB7 RID: 19639
		public bool paginate;

		// Token: 0x04004CB8 RID: 19640
		public bool sortable;

		// Token: 0x04004CB9 RID: 19641
		public int pageSize;

		// Token: 0x04004CBA RID: 19642
		public string elementNameProperty;

		// Token: 0x04004CBB RID: 19643
		public string elementNameOverride;

		// Token: 0x04004CBC RID: 19644
		public string elementIconPath;
	}
}
