using UnityEngine;

[AddComponentMenu("NGUI/Examples/UI Storage Slot")]
public class UIStorageSlot : UIItemSlot
{
	public UIItemStorage storage;

	public int slot;

	protected override InvGameItem observedItem
	{
		get
		{
			if (!(storage != null))
			{
				return null;
			}
			return storage.GetItem(slot);
		}
	}

	protected override InvGameItem Replace(InvGameItem item)
	{
		if (!(storage != null))
		{
			return item;
		}
		return storage.Replace(slot, item);
	}
}
