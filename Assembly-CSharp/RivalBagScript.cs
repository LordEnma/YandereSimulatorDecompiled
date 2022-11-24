// Decompiled with JetBrains decompiler
// Type: RivalBagScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class RivalBagScript : MonoBehaviour
{
  public SchemesScript Schemes;
  public ClockScript Clock;
  public PromptScript Prompt;

  private void Start()
  {
    if (!((UnityEngine.Object) this.Schemes.StudentManager.Students[this.Schemes.StudentManager.RivalID] == (UnityEngine.Object) null) && StudentGlobals.StudentSlave != this.Schemes.StudentManager.RivalID)
      return;
    this.gameObject.SetActive(false);
    this.Prompt.enabled = false;
    this.Prompt.Hide();
  }

  private void Update()
  {
    if (this.Clock.Period == 2 || this.Clock.Period > 3)
    {
      this.Prompt.HideButton[0] = true;
      this.Prompt.HideButton[1] = true;
    }
    else
    {
      this.Prompt.HideButton[0] = !this.Prompt.Yandere.Inventory.Cigs;
      this.Prompt.HideButton[1] = !this.Prompt.Yandere.Inventory.Ring;
    }
    if (this.Prompt.Yandere.Inventory.Cigs)
    {
      this.Prompt.enabled = true;
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        if (DateGlobals.Weekday == DayOfWeek.Wednesday)
          SchemeGlobals.SetSchemeStage(3, 4);
        this.Schemes.UpdateInstructions();
        this.Prompt.Yandere.Inventory.Cigs = false;
        this.Prompt.enabled = false;
        this.Prompt.Hide();
        this.enabled = false;
      }
    }
    if (!this.Prompt.Yandere.Inventory.Ring)
      return;
    this.Prompt.enabled = true;
    if ((double) this.Prompt.Circle[1].fillAmount != 0.0)
      return;
    if (DateGlobals.Weekday == DayOfWeek.Tuesday)
      SchemeGlobals.SetSchemeStage(2, 6);
    this.Schemes.UpdateInstructions();
    this.Prompt.Yandere.Inventory.Ring = false;
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    this.enabled = false;
  }
}
