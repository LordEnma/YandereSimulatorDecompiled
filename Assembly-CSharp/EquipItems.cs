// Decompiled with JetBrains decompiler
// Type: EquipItems
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Equip Items")]
public class EquipItems : MonoBehaviour
{
  public int[] itemIDs;

  private void Start()
  {
    if (this.itemIDs != null && this.itemIDs.Length != 0)
    {
      InvEquipment invEquipment = this.GetComponent<InvEquipment>();
      if ((Object) invEquipment == (Object) null)
        invEquipment = this.gameObject.AddComponent<InvEquipment>();
      int maxExclusive = 12;
      int index = 0;
      for (int length = this.itemIDs.Length; index < length; ++index)
      {
        int itemId = this.itemIDs[index];
        InvBaseItem byId = InvDatabase.FindByID(itemId);
        if (byId != null)
          invEquipment.Equip(new InvGameItem(itemId, byId)
          {
            quality = (InvGameItem.Quality) Random.Range(0, maxExclusive),
            itemLevel = NGUITools.RandomRange(byId.minItemLevel, byId.maxItemLevel)
          });
        else
          Debug.LogWarning((object) ("Can't resolve the item ID of " + itemId.ToString()));
      }
    }
    Object.Destroy((Object) this);
  }
}
