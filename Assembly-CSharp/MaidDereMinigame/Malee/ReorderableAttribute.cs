using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005C1 RID: 1473
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x06002516 RID: 9494 RVA: 0x002046C5 File Offset: 0x002028C5
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x06002517 RID: 9495 RVA: 0x002046CE File Offset: 0x002028CE
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x06002518 RID: 9496 RVA: 0x002046DC File Offset: 0x002028DC
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x06002519 RID: 9497 RVA: 0x002046EA File Offset: 0x002028EA
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x0600251A RID: 9498 RVA: 0x002046F8 File Offset: 0x002028F8
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x0600251B RID: 9499 RVA: 0x00204708 File Offset: 0x00202908
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

		// Token: 0x04004D9F RID: 19871
		public bool add;

		// Token: 0x04004DA0 RID: 19872
		public bool remove;

		// Token: 0x04004DA1 RID: 19873
		public bool draggable;

		// Token: 0x04004DA2 RID: 19874
		public bool singleLine;

		// Token: 0x04004DA3 RID: 19875
		public bool paginate;

		// Token: 0x04004DA4 RID: 19876
		public bool sortable;

		// Token: 0x04004DA5 RID: 19877
		public int pageSize;

		// Token: 0x04004DA6 RID: 19878
		public string elementNameProperty;

		// Token: 0x04004DA7 RID: 19879
		public string elementNameOverride;

		// Token: 0x04004DA8 RID: 19880
		public string elementIconPath;
	}
}
