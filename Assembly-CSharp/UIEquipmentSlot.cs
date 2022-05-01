using System;
using UnityEngine;

// Token: 0x02000023 RID: 35
[AddComponentMenu("NGUI/Examples/UI Equipment Slot")]
public class UIEquipmentSlot : UIItemSlot
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600008C RID: 140 RVA: 0x00011490 File Offset: 0x0000F690
	protected override InvGameItem observedItem
	{
		get
		{
			if (!(this.equipment != null))
			{
				return null;
			}
			return this.equipment.GetItem(this.slot);
		}
	}

	// Token: 0x0600008D RID: 141 RVA: 0x000114B3 File Offset: 0x0000F6B3
	protected override InvGameItem Replace(InvGameItem item)
	{
		if (!(this.equipment != null))
		{
			return item;
		}
		return this.equipment.Replace(this.slot, item);
	}

	// Token: 0x04000267 RID: 615
	public InvEquipment equipment;

	// Token: 0x04000268 RID: 616
	public InvBaseItem.Slot slot;
}
