// Decompiled with JetBrains decompiler
// Type: SenpaiShrineCollectibleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SenpaiShrineCollectibleScript : MonoBehaviour
{
  public PromptScript Prompt;
  public int ID;

  private void Start()
  {
    if (!PlayerGlobals.GetShrineCollectible(this.ID))
      return;
    Object.Destroy((Object) this.gameObject);
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    Debug.Log((object) "Picked up shrine item.");
    ++this.Prompt.Yandere.StudentManager.Police.EndOfDay.ShrineItemsCollected;
    this.Prompt.Yandere.Inventory.ShrineCollectibles[this.ID] = true;
    this.Prompt.Hide();
    Object.Destroy((Object) this.gameObject);
  }
}
