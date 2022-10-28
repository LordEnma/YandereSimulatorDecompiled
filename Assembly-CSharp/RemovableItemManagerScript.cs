// Decompiled with JetBrains decompiler
// Type: RemovableItemManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class RemovableItemManagerScript : MonoBehaviour
{
  public RemovableItemScript[] RemovableItems;

  private void Start()
  {
    this.RemovableItems = UnityEngine.Object.FindObjectsOfType(typeof (RemovableItemScript)) as RemovableItemScript[];
    bool flag = false;
    if (DateGlobals.Weekday == DayOfWeek.Monday)
      flag = true;
    for (int itemID = 0; itemID < this.RemovableItems.Length; ++itemID)
    {
      if (GameGlobals.GetItemRemoved(itemID) == 1)
      {
        if (this.RemovableItems[itemID].ClubItem & flag)
        {
          Debug.Log((object) ("Item #" + itemID.ToString() + " (" + this.RemovableItems[itemID].gameObject.name + ") was used up by the player, but it has been replaced."));
          GameGlobals.SetItemRemoved(itemID, 0);
        }
        else
        {
          Debug.Log((object) ("Item #" + itemID.ToString() + " (" + this.RemovableItems[itemID].gameObject.name + ") was used up by the player. It is now being removed."));
          this.RemovableItems[itemID].gameObject.SetActive(false);
        }
      }
    }
  }

  public void RemoveItems()
  {
    for (int itemID = 0; itemID < this.RemovableItems.Length; ++itemID)
    {
      if ((UnityEngine.Object) this.RemovableItems[itemID] == (UnityEngine.Object) null || !this.RemovableItems[itemID].gameObject.activeInHierarchy)
      {
        if ((UnityEngine.Object) this.RemovableItems[itemID] == (UnityEngine.Object) null)
          Debug.Log((object) ("Item #" + itemID.ToString() + " was used up by the player. It won't reappear at school unless it is replenishes."));
        else
          Debug.Log((object) ("Item #" + itemID.ToString() + " (" + this.RemovableItems[itemID].gameObject.name + ") was used up by the player. It won't reappear at school unless it is replenishes."));
        GameGlobals.SetItemRemoved(itemID, 1);
      }
    }
  }
}
