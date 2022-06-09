// Decompiled with JetBrains decompiler
// Type: HomeSleepScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class HomeSleepScript : MonoBehaviour
{
  public HomeDarknessScript HomeDarkness;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public HomeWindowScript HomeWindow;
  public GameObject SkipSchoolWindow;
  public UILabel EightiesLabel;
  public UILabel DescLabel;
  public UILabel Label;
  public bool Anime;

  public void Start()
  {
    if (this.Anime)
      return;
    this.SkipSchoolWindow.SetActive(false);
    if (GameGlobals.Eighties)
      this.Label = this.EightiesLabel;
    if (HomeGlobals.Night)
      return;
    if (DateGlobals.Weekday == DayOfWeek.Sunday)
    {
      this.DescLabel.text = "Advance to nighttime?";
      this.Label.text = "Nap";
    }
    else
    {
      this.DescLabel.text = "Advance to nighttime?";
      this.Label.text = "Skip School";
      this.SkipSchoolWindow.SetActive(true);
    }
  }

  private void Update()
  {
    if (this.HomeYandere.CanMove || this.HomeDarkness.FadeOut)
      return;
    if (Input.GetButtonDown("A"))
    {
      this.HomeDarkness.Sprite.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.HomeDarkness.Cyberstalking = true;
      this.HomeDarkness.FadeOut = true;
      this.HomeWindow.Show = false;
      this.enabled = false;
    }
    if (!Input.GetButtonDown("B"))
      return;
    this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
    this.HomeCamera.Target = this.HomeCamera.Targets[0];
    this.HomeYandere.CanMove = true;
    this.HomeWindow.Show = false;
    this.enabled = false;
  }
}
