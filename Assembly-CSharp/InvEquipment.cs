using System;
using UnityEngine;

// Token: 0x0200002A RID: 42
[AddComponentMenu("NGUI/Examples/Equipment")]
public class InvEquipment : MonoBehaviour
{
	// Token: 0x17000006 RID: 6
	// (get) Token: 0x060000AD RID: 173 RVA: 0x00011AB0 File Offset: 0x0000FCB0
	public InvGameItem[] equippedItems
	{
		get
		{
			return this.mItems;
		}
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00011AB8 File Offset: 0x0000FCB8
	public InvGameItem Replace(InvBaseItem.Slot slot, InvGameItem item)
	{
		InvBaseItem invBaseItem = (item != null) ? item.baseItem : null;
		if (slot == InvBaseItem.Slot.None)
		{
			if (item != null)
			{
				Debug.LogWarning("Can't equip \"" + item.name + "\" because it doesn't specify an item slot");
			}
			return item;
		}
		if (invBaseItem != null && invBaseItem.slot != slot)
		{
			return item;
		}
		if (this.mItems == null)
		{
			int num = 8;
			this.mItems = new InvGameItem[num];
		}
		InvGameItem result = this.mItems[slot - InvBaseItem.Slot.Weapon];
		this.mItems[slot - InvBaseItem.Slot.Weapon] = item;
		if (this.mAttachments == null)
		{
			this.mAttachments = base.GetComponentsInChildren<InvAttachmentPoint>();
		}
		int i = 0;
		int num2 = this.mAttachments.Length;
		while (i < num2)
		{
			InvAttachmentPoint invAttachmentPoint = this.mAttachments[i];
			if (invAttachmentPoint.slot == slot)
			{
				GameObject gameObject = invAttachmentPoint.Attach((invBaseItem != null) ? invBaseItem.attachment : null);
				if (invBaseItem != null && gameObject != null)
				{
					Renderer component = gameObject.GetComponent<Renderer>();
					if (component != null)
					{
						component.material.color = invBaseItem.color;
					}
				}
			}
			i++;
		}
		return result;
	}

	// Token: 0x060000AF RID: 175 RVA: 0x00011BB8 File Offset: 0x0000FDB8
	public InvGameItem Equip(InvGameItem item)
	{
		if (item != null)
		{
			InvBaseItem baseItem = item.baseItem;
			if (baseItem != null)
			{
				return this.Replace(baseItem.slot, item);
			}
			Debug.LogWarning("Can't resolve the item ID of " + item.baseItemID.ToString());
		}
		return item;
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00011C00 File Offset: 0x0000FE00
	public InvGameItem Unequip(InvGameItem item)
	{
		if (item != null)
		{
			InvBaseItem baseItem = item.baseItem;
			if (baseItem != null)
			{
				return this.Replace(baseItem.slot, null);
			}
		}
		return item;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00011C29 File Offset: 0x0000FE29
	public InvGameItem Unequip(InvBaseItem.Slot slot)
	{
		return this.Replace(slot, null);
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00011C34 File Offset: 0x0000FE34
	public bool HasEquipped(InvGameItem item)
	{
		if (this.mItems != null)
		{
			int i = 0;
			int num = this.mItems.Length;
			while (i < num)
			{
				if (this.mItems[i] == item)
				{
					return true;
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00011C6C File Offset: 0x0000FE6C
	public bool HasEquipped(InvBaseItem.Slot slot)
	{
		if (this.mItems != null)
		{
			int i = 0;
			int num = this.mItems.Length;
			while (i < num)
			{
				InvBaseItem baseItem = this.mItems[i].baseItem;
				if (baseItem != null && baseItem.slot == slot)
				{
					return true;
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00011CB4 File Offset: 0x0000FEB4
	public InvGameItem GetItem(InvBaseItem.Slot slot)
	{
		if (slot != InvBaseItem.Slot.None)
		{
			int num = slot - InvBaseItem.Slot.Weapon;
			if (this.mItems != null && num < this.mItems.Length)
			{
				return this.mItems[num];
			}
		}
		return null;
	}

	// Token: 0x04000283 RID: 643
	private InvGameItem[] mItems;

	// Token: 0x04000284 RID: 644
	private InvAttachmentPoint[] mAttachments;
}
