// Decompiled with JetBrains decompiler
// Type: RestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RestScript : MonoBehaviour
{
  public PortalScript Portal;
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Portal.CanAttendClass = true;
    this.Portal.CheckForProblems();
    if (!this.Portal.CanAttendClass)
      this.Prompt.Circle[0].fillAmount = 1f;
    else if (this.Portal.Clock.Period < 5)
    {
      this.Portal.Reputation.PendingRep -= 10f;
      this.Portal.Reputation.UpdateRep();
      this.Prompt.Yandere.Resting = true;
      if (this.Portal.Police.PoisonScene || this.Portal.Police.SuicideScene && this.Portal.Police.Corpses - this.Portal.Police.HiddenCorpses > 0 || this.Portal.Police.Corpses - this.Portal.Police.HiddenCorpses > 0 || (double) this.Portal.Reputation.Reputation <= -100.0)
      {
        this.Portal.EndDay();
      }
      else
      {
        this.Portal.ClassDarkness.enabled = true;
        this.Portal.Clock.StopTime = true;
        this.Portal.Transition = true;
        this.Portal.FadeOut = true;
        this.Prompt.Yandere.Character.GetComponent<Animation>().CrossFade(this.Prompt.Yandere.IdleAnim);
        this.Prompt.Yandere.YandereVision = false;
        this.Prompt.Yandere.CanMove = false;
        this.Portal.EndEvents();
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else
    {
      this.Prompt.Yandere.Character.GetComponent<Animation>().CrossFade(this.Prompt.Yandere.IdleAnim);
      this.Prompt.Yandere.YandereVision = false;
      this.Prompt.Yandere.CanMove = false;
      this.Prompt.Yandere.Resting = true;
      this.Portal.EndDay();
    }
  }
}
