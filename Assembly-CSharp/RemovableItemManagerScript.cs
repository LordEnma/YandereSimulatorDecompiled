using System;
using UnityEngine;

public class RemovableItemManagerScript : MonoBehaviour
{
	public RemovableItemScript[] RemovableItems;

	private void Start()
	{
		RemovableItems = UnityEngine.Object.FindObjectsOfType(typeof(RemovableItemScript)) as RemovableItemScript[];
		bool flag = false;
		if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			flag = true;
		}
		for (int i = 0; i < RemovableItems.Length; i++)
		{
			if (GameGlobals.GetItemRemoved(i) == 1)
			{
				if (RemovableItems[i].ClubItem && flag)
				{
					Debug.Log("Item #" + i + " (" + RemovableItems[i].gameObject.name + ") was used up by the player, but it has been replaced.");
					GameGlobals.SetItemRemoved(i, 0);
				}
				else
				{
					Debug.Log("Item #" + i + " (" + RemovableItems[i].gameObject.name + ") was used up by the player. It is now being removed.");
					RemovableItems[i].gameObject.SetActive(value: false);
				}
			}
		}
	}

	public void RemoveItems()
	{
		for (int i = 0; i < RemovableItems.Length; i++)
		{
			if (RemovableItems[i] == null || !RemovableItems[i].gameObject.activeInHierarchy)
			{
				if (RemovableItems[i] == null)
				{
					Debug.Log("Item #" + i + " was used up by the player. It won't reappear at school unless it is replenishes.");
				}
				else
				{
					Debug.Log("Item #" + i + " (" + RemovableItems[i].gameObject.name + ") was used up by the player. It won't reappear at school unless it is replenishes.");
				}
				GameGlobals.SetItemRemoved(i, 1);
			}
		}
	}
}
