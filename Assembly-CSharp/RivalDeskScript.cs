// Decompiled with JetBrains decompiler
// Type: RivalDeskScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class RivalDeskScript : MonoBehaviour
{
  public SchemesScript Schemes;
  public ClockScript Clock;
  public PromptScript Prompt;
  public bool Cheating;

  private void Start()
  {
    if (DateGlobals.Weekday == DayOfWeek.Friday)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (this.Prompt.Yandere.Inventory.AnswerSheet || !this.Prompt.Yandere.Inventory.DuplicateSheet)
      return;
    this.Prompt.enabled = true;
    if ((double) this.Clock.HourTime > 13.0)
    {
      this.Prompt.HideButton[0] = false;
      if ((double) this.Clock.HourTime > 13.5)
      {
        SchemeGlobals.SetSchemeStage(5, 100);
        this.Schemes.UpdateInstructions();
        this.Prompt.HideButton[0] = true;
      }
    }
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    if (DateGlobals.Weekday == DayOfWeek.Friday)
      SchemeGlobals.SetSchemeStage(5, 9);
    this.Schemes.UpdateInstructions();
    this.Prompt.Yandere.Inventory.DuplicateSheet = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.Cheating = true;
    this.enabled = false;
  }
}
