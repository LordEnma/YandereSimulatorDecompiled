// Decompiled with JetBrains decompiler
// Type: SakeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SakeScript : MonoBehaviour
{
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.Inventory.Sake = true;
    this.UpdatePrompt();
  }

  public void UpdatePrompt()
  {
    if (this.Prompt.Yandere.Inventory.Sake)
    {
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      Object.Destroy((Object) this.gameObject);
    }
    else
    {
      this.Prompt.enabled = true;
      this.Prompt.Hide();
    }
  }
}
