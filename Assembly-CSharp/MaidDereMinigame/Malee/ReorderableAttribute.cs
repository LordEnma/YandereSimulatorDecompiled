using System;
using UnityEngine;

namespace MaidDereMinigame.Malee
{
	// Token: 0x020005B1 RID: 1457
	public class ReorderableAttribute : PropertyAttribute
	{
		// Token: 0x060024AA RID: 9386 RVA: 0x001F9D7D File Offset: 0x001F7F7D
		public ReorderableAttribute() : this(null)
		{
		}

		// Token: 0x060024AB RID: 9387 RVA: 0x001F9D86 File Offset: 0x001F7F86
		public ReorderableAttribute(string elementNameProperty) : this(true, true, true, elementNameProperty, null, null)
		{
		}

		// Token: 0x060024AC RID: 9388 RVA: 0x001F9D94 File Offset: 0x001F7F94
		public ReorderableAttribute(string elementNameProperty, string elementIconPath) : this(true, true, true, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x001F9DA2 File Offset: 0x001F7FA2
		public ReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath) : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
		{
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x001F9DB0 File Offset: 0x001F7FB0
		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
		{
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x001F9DC0 File Offset: 0x001F7FC0
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

		// Token: 0x04004C62 RID: 19554
		public bool add;

		// Token: 0x04004C63 RID: 19555
		public bool remove;

		// Token: 0x04004C64 RID: 19556
		public bool draggable;

		// Token: 0x04004C65 RID: 19557
		public bool singleLine;

		// Token: 0x04004C66 RID: 19558
		public bool paginate;

		// Token: 0x04004C67 RID: 19559
		public bool sortable;

		// Token: 0x04004C68 RID: 19560
		public int pageSize;

		// Token: 0x04004C69 RID: 19561
		public string elementNameProperty;

		// Token: 0x04004C6A RID: 19562
		public string elementNameOverride;

		// Token: 0x04004C6B RID: 19563
		public string elementIconPath;
	}
}
