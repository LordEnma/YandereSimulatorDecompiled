// Decompiled with JetBrains decompiler
// Type: CleanUpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CleanUpScript : MonoBehaviour
{
  public Projector BloodProjector;
  public UISprite CleanUpDarkness;
  public PromptScript Prompt;
  public bool FadeOut;
  public bool FadeIn;

  private void Update()
  {
    if ((Object) this.Prompt.Yandere.PickUp != (Object) null && (Object) this.Prompt.Yandere.PickUp.Mop != (Object) null && this.Prompt.Yandere.PickUp.Mop.Bleached)
    {
      this.Prompt.HideButton[0] = false;
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Yandere.CanMove = false;
        this.FadeOut = true;
      }
      if (this.FadeOut)
      {
        this.CleanUpDarkness.alpha = Mathf.MoveTowards(this.CleanUpDarkness.alpha, 1f, Time.deltaTime);
        if ((double) this.CleanUpDarkness.alpha == 1.0)
        {
          this.BloodProjector.enabled = false;
          this.FadeOut = false;
          this.FadeIn = true;
        }
      }
      if (!this.FadeIn)
        return;
      this.CleanUpDarkness.alpha = Mathf.MoveTowards(this.CleanUpDarkness.alpha, 0.0f, Time.deltaTime);
      if ((double) this.CleanUpDarkness.alpha != 0.0)
        return;
      this.Prompt.Hide();
      this.BloodProjector.gameObject.SetActive(false);
      this.Prompt.Yandere.CanMove = true;
    }
    else
      this.Prompt.HideButton[0] = true;
  }
}
