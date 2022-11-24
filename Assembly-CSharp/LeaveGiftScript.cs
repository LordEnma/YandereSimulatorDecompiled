// Decompiled with JetBrains decompiler
// Type: LeaveGiftScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LeaveGiftScript : MonoBehaviour
{
  public EndOfDayScript EndOfDay;
  public PromptScript Prompt;
  public GameObject Note;
  public GameObject Box;

  private void Start()
  {
    this.Note.SetActive(false);
    this.Box.SetActive(false);
    this.EndOfDay.SenpaiGifts = CollectibleGlobals.SenpaiGifts;
    if (this.EndOfDay.SenpaiGifts != 0)
      return;
    this.Prompt.HideButton[1] = true;
  }

  private void Update()
  {
    if (!this.Prompt.InView)
      return;
    if ((double) Vector3.Distance(this.Prompt.Yandere.transform.position, this.Prompt.Yandere.Senpai.position) > 10.0)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.HideButton[0] = true;
        this.Note.SetActive(true);
        this.CheckForDisable();
      }
      else
      {
        if ((double) this.Prompt.Circle[1].fillAmount != 0.0)
          return;
        this.Prompt.HideButton[1] = true;
        --this.EndOfDay.SenpaiGifts;
        this.Box.SetActive(true);
        this.CheckForDisable();
      }
    }
    else
      this.Prompt.Hide();
  }

  private void CheckForDisable()
  {
    if (!this.Prompt.HideButton[0] || !this.Prompt.HideButton[1])
      return;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.enabled = false;
  }
}
