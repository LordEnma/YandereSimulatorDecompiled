// Decompiled with JetBrains decompiler
// Type: CloakingDeviceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CloakingDeviceScript : MonoBehaviour
{
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    ++this.Prompt.Yandere.Alphabet.Cheats;
    this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
    this.Prompt.Yandere.CanCloak = true;
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    Object.Destroy((Object) this.gameObject);
  }
}
