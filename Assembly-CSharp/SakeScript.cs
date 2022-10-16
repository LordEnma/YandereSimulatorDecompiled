// Decompiled with JetBrains decompiler
// Type: SakeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
