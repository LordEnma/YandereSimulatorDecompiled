// Decompiled with JetBrains decompiler
// Type: HidingSpotScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HidingSpotScript : MonoBehaviour
{
  public PromptBarScript PromptBar;
  public PromptScript Prompt;
  public Transform Exit;
  public Transform Spot;
  public string AnimName;
  public bool Bench;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    if (this.Prompt.Yandere.Chased || this.Prompt.Yandere.Chasers != 0 || !((Object) this.Prompt.Yandere.Pursuer == (Object) null))
      return;
    if (this.Bench)
    {
      this.Prompt.Yandere.MyController.radius = 0.1f;
    }
    else
    {
      this.Prompt.Yandere.MyController.center = new Vector3(this.Prompt.Yandere.MyController.center.x, 0.3f, this.Prompt.Yandere.MyController.center.z);
      this.Prompt.Yandere.MyController.radius = 0.0f;
      this.Prompt.Yandere.MyController.height = 0.5f;
    }
    this.Prompt.Yandere.HideAnim = this.AnimName;
    this.Prompt.Yandere.HidingSpot = this.Spot;
    this.Prompt.Yandere.ExitSpot = this.Exit;
    this.Prompt.Yandere.CanMove = false;
    this.Prompt.Yandere.Hiding = true;
    this.Prompt.Yandere.EmptyHands();
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[1].text = "Stop";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
  }
}
