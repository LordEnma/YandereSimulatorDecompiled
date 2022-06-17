// Decompiled with JetBrains decompiler
// Type: HomeExitScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class HomeExitScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public HomeDarknessScript HomeDarkness;
  public HomeYandereScript HomeYandere;
  public BringItemScript HomeBringItem;
  public HomeCameraScript HomeCamera;
  public HomeWindowScript HomeWindow;
  public GameObject BringItemPrompt;
  public Transform Highlight;
  public UILabel[] Labels;
  public int ID = 1;

  private void Start()
  {
    UILabel label1 = this.Labels[1];
    if (HomeGlobals.Night)
    {
      label1.color = new Color(label1.color.r, label1.color.g, label1.color.b, 0.5f);
      if (SchemeGlobals.GetSchemeStage(6) == 9 && !StudentGlobals.GetStudentDead(10 + DateGlobals.Week) && !StudentGlobals.GetStudentKidnapped(10 + DateGlobals.Week) && GameGlobals.RivalEliminationID == 0)
      {
        UILabel label2 = this.Labels[4];
        label2.color = new Color(label2.color.r, label2.color.g, label2.color.b, 1f);
        label2.text = "Stalker's House";
        if (GameGlobals.Eighties)
          this.Labels[4].text = "Insane Asylum";
      }
      this.BringItemPrompt.SetActive(false);
    }
    else
    {
      if (DateGlobals.Weekday != DayOfWeek.Sunday)
        return;
      label1.color = new Color(label1.color.r, label1.color.g, label1.color.b, 0.5f);
    }
  }

  private void Update()
  {
    if (this.HomeYandere.CanMove || this.HomeDarkness.FadeOut || (double) this.HomeWindow.Sprite.color.a <= 0.899999976158142)
      return;
    if (this.InputManager.TappedDown)
    {
      ++this.ID;
      if (this.ID > 4)
        this.ID = 1;
      this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (50.0 - (double) this.ID * 50.0), this.Highlight.localPosition.z);
    }
    if (this.InputManager.TappedUp)
    {
      --this.ID;
      if (this.ID < 1)
        this.ID = 4;
      this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (50.0 - (double) this.ID * 50.0), this.Highlight.localPosition.z);
    }
    if (Input.GetButtonDown("A") && (double) this.Labels[this.ID].color.a == 1.0)
    {
      if (this.ID == 1)
      {
        this.HomeBringItem.HomeWindow.Show = true;
        this.HomeWindow.Show = false;
      }
      else
      {
        if (this.ID == 2)
          this.HomeDarkness.Sprite.color = new Color(1f, 1f, 1f, 0.0f);
        else if (this.ID == 3)
          this.HomeDarkness.Sprite.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        else if (this.ID == 4)
          this.HomeDarkness.Sprite.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        this.HomeDarkness.FadeOut = true;
        this.HomeWindow.Show = false;
        this.enabled = false;
      }
    }
    if (!Input.GetButtonDown("B"))
      return;
    this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
    this.HomeCamera.Target = this.HomeCamera.Targets[0];
    this.HomeYandere.CanMove = true;
    this.HomeWindow.Show = false;
    this.enabled = false;
  }

  public void GoToSchool()
  {
    if ((double) SchoolGlobals.SchoolAtmosphere < 0.5 || GameGlobals.LoveSick)
      this.HomeDarkness.Sprite.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    else
      this.HomeDarkness.Sprite.color = new Color(1f, 1f, 1f, 0.0f);
    this.HomeDarkness.FadeOut = true;
    this.HomeWindow.Show = false;
    this.enabled = false;
  }
}
