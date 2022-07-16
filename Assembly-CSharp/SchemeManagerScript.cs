// Decompiled with JetBrains decompiler
// Type: SchemeManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SchemeManagerScript : MonoBehaviour
{
  public SchemesScript Schemes;
  public ClockScript Clock;
  public bool ClockCheck;
  public float Timer;
  public int CurrentScheme;

  private void Update()
  {
    if (this.CurrentScheme < 6)
    {
      if ((double) this.Clock.HourTime > 15.5)
      {
        SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, 100);
        this.Clock.Yandere.NotificationManager.CustomText = "Scheme failed! You were too slow.";
        this.Clock.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        this.Schemes.UpdateInstructions();
        this.enabled = false;
      }
    }
    else if (this.CurrentScheme > 6 && Input.GetButton("A"))
    {
      if (Input.GetButtonDown("LB"))
      {
        SchemeGlobals.SetSchemeStage(this.CurrentScheme, SchemeGlobals.GetSchemeStage(this.CurrentScheme) - 1);
        this.Schemes.UpdateInstructions();
      }
      else if (Input.GetButtonDown("RB"))
      {
        SchemeGlobals.SetSchemeStage(this.CurrentScheme, SchemeGlobals.GetSchemeStage(this.CurrentScheme) + 1);
        this.Schemes.UpdateInstructions();
      }
    }
    if (!this.ClockCheck || (double) this.Clock.HourTime <= 8.25)
      return;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 1.0)
      return;
    this.Timer = 0.0f;
    if (SchemeGlobals.GetSchemeStage(5) != 1)
      return;
    Debug.Log((object) "It's past 8:15 AM, so we're advancing to Stage 2 of Scheme 5.");
    SchemeGlobals.SetSchemeStage(5, 2);
    this.Schemes.UpdateInstructions();
    this.ClockCheck = false;
  }
}
