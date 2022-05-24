using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005C1 RID: 1473
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x06002517 RID: 9495 RVA: 0x00204C2D File Offset: 0x00202E2D
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x06002518 RID: 9496 RVA: 0x00204C36 File Offset: 0x00202E36
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x06002519 RID: 9497 RVA: 0x00204C44 File Offset: 0x00202E44
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x0600251A RID: 9498 RVA: 0x00204C52 File Offset: 0x00202E52
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x0600251B RID: 9499 RVA: 0x00204C60 File Offset: 0x00202E60
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x0600251C RID: 9500 RVA: 0x00204C70 File Offset: 0x00202E70
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

		// Token: 0x04004DA8 RID: 19880
		public bool add;

		// Token: 0x04004DA9 RID: 19881
		public bool remove;

		// Token: 0x04004DAA RID: 19882
		public bool draggable;

		// Token: 0x04004DAB RID: 19883
		public bool singleLine;

		// Token: 0x04004DAC RID: 19884
		public bool paginate;

		// Token: 0x04004DAD RID: 19885
		public bool sortable;

		// Token: 0x04004DAE RID: 19886
		public int pageSize;

		// Token: 0x04004DAF RID: 19887
		public string elementNameProperty;

		// Token: 0x04004DB0 RID: 19888
		public string elementNameOverride;

		// Token: 0x04004DB1 RID: 19889
		public string elementIconPath;
	}
}
