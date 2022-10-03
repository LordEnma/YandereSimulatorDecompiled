// Decompiled with JetBrains decompiler
// Type: SanityPillsScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SanityPillsScript : MonoBehaviour
{
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    ++this.Prompt.Yandere.Alphabet.Cheats;
    this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
    this.Prompt.Yandere.SanityPills = true;
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    this.gameObject.SetActive(false);
  }
}
