using System;
using UnityEngine;

// Token: 0x02000026 RID: 38
[AddComponentMenu("NGUI/Examples/UI Storage Slot")]
public class UIStorageSlot : UIItemSlot
{
	// Token: 0x17000004 RID: 4
	// (get) Token: 0x0600009D RID: 157 RVA: 0x00011989 File Offset: 0x0000FB89
	protected override InvGameItem observedItem
	{
		get
		{
			if (!(this.storage != null))
			{
				return null;
			}
			return this.storage.GetItem(this.slot);
		}
	}

	// Token: 0x0600009E RID: 158 RVA: 0x000119AC File Offset: 0x0000FBAC
	protected override InvGameItem Replace(InvGameItem item)
	{
		if (!(this.storage != null))
		{
			return item;
		}
		return this.storage.Replace(this.slot, item);
	}

	// Token: 0x04000278 RID: 632
	public UIItemStorage storage;

	// Token: 0x04000279 RID: 633
	public int slot;
}
