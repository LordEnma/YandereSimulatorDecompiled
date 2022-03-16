using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B9 RID: 1465
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024E3 RID: 9443 RVA: 0x001FF1DD File Offset: 0x001FD3DD
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024E4 RID: 9444 RVA: 0x001FF1E6 File Offset: 0x001FD3E6
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024E5 RID: 9445 RVA: 0x001FF1F4 File Offset: 0x001FD3F4
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024E6 RID: 9446 RVA: 0x001FF202 File Offset: 0x001FD402
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x001FF210 File Offset: 0x001FD410
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x001FF220 File Offset: 0x001FD420
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

		// Token: 0x04004D12 RID: 19730
		public bool add;

		// Token: 0x04004D13 RID: 19731
		public bool remove;

		// Token: 0x04004D14 RID: 19732
		public bool draggable;

		// Token: 0x04004D15 RID: 19733
		public bool singleLine;

		// Token: 0x04004D16 RID: 19734
		public bool paginate;

		// Token: 0x04004D17 RID: 19735
		public bool sortable;

		// Token: 0x04004D18 RID: 19736
		public int pageSize;

		// Token: 0x04004D19 RID: 19737
		public string elementNameProperty;

		// Token: 0x04004D1A RID: 19738
		public string elementNameOverride;

		// Token: 0x04004D1B RID: 19739
		public string elementIconPath;
	}
}
