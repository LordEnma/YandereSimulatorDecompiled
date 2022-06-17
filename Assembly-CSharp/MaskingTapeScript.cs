// Decompiled with JetBrains decompiler
// Type: MaskingTapeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MaskingTapeScript : MonoBehaviour
{
  public CarryableCardboardBoxScript Box;
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.Inventory.MaskingTape = true;
    this.Box.Prompt.enabled = true;
    this.Box.enabled = true;
    this.gameObject.SetActive(false);
  }
}
