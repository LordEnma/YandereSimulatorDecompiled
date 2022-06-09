// Decompiled with JetBrains decompiler
// Type: CraftableItemScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CraftableItemScript : MonoBehaviour
{
  public PromptScript Prompt;
  public bool Chemistry;
  public int ID;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    switch (this.ID)
    {
      case 1:
        this.Prompt.Yandere.Inventory.Ammonium = true;
        break;
      case 2:
        this.Prompt.Yandere.Inventory.Balloons = true;
        break;
      case 3:
        this.Prompt.Yandere.Inventory.Bandages = true;
        break;
      case 4:
        this.Prompt.Yandere.Inventory.Glass = true;
        break;
      case 5:
        this.Prompt.Yandere.Inventory.Hairpins = true;
        break;
      case 6:
        this.Prompt.Yandere.Inventory.Nails = true;
        break;
      case 7:
        this.Prompt.Yandere.Inventory.Paper = true;
        break;
      case 8:
        this.Prompt.Yandere.Inventory.PaperClips = true;
        break;
      case 9:
        this.Prompt.Yandere.Inventory.SilverFulminate = true;
        break;
      case 10:
        this.Prompt.Yandere.Inventory.WoodenSticks = true;
        break;
    }
    this.Prompt.Hide();
    Object.Destroy((Object) this.gameObject);
  }
}
