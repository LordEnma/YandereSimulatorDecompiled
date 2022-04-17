using System;
using UnityEngine;

// Token: 0x02000023 RID: 35
[AddComponentMenu("NGUI/Examples/UI Equipment Slot")]
public class UIEquipmentSlot : UIItemSlot
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600008C RID: 140 RVA: 0x00011350 File Offset: 0x0000F550
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

	// Token: 0x0600008D RID: 141 RVA: 0x00011373 File Offset: 0x0000F573
	protected override InvGameItem Replace(InvGameItem item)
	{
		if (!(this.equipment != null))
		{
			return item;
		}
		return this.equipment.Replace(this.slot, item);
	}

	// Token: 0x04000265 RID: 613
	public InvEquipment equipment;

	// Token: 0x04000266 RID: 614
	public InvBaseItem.Slot slot;
}
