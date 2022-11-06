// Decompiled with JetBrains decompiler
// Type: HintScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HintScript : MonoBehaviour
{
  public PauseScreenScript PauseScreen;
  public AudioSource MyAudio;
  public float Speed = 10f;
  public float Timer;
  public int QuickID;
  public bool DisplayTutorial;
  public bool Show;
  public UIPanel MyPanel;

  private void Start()
  {
    this.transform.localPosition = new Vector3(0.2043f, 0.0f, 1f);
    if (DateGlobals.Week > 1 || GameGlobals.Eighties)
      this.gameObject.SetActive(false);
    if (!OptionGlobals.HintsOff)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if ((double) this.MyPanel.alpha != 1.0)
      return;
    if (this.Show)
    {
      if ((double) this.Speed == 5.0)
      {
        this.MyAudio.Play();
        this.Speed = 0.0f;
      }
      this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(0.0f, 0.0f, 1f), Time.deltaTime * 10f);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 5.0)
        this.Show = false;
      if (!Input.GetButtonDown("Start") || this.PauseScreen.Yandere.Shutter.Snapping || this.PauseScreen.Yandere.TimeSkipping || this.PauseScreen.Yandere.Talking || this.PauseScreen.Yandere.Noticed || this.PauseScreen.Yandere.InClass || this.PauseScreen.Yandere.Struggling || this.PauseScreen.Yandere.Won || this.PauseScreen.Yandere.Dismembering || this.PauseScreen.Yandere.Attacked || !this.PauseScreen.Yandere.CanMove || this.PauseScreen.Yandere.Chased || this.PauseScreen.Yandere.Chasers != 0 || this.PauseScreen.Yandere.YandereVision || (double) Time.timeScale <= 9.9999997473787516E-05 || this.PauseScreen.Schedule.gameObject.activeInHierarchy)
        return;
      if (this.DisplayTutorial)
      {
        this.PauseScreen.Yandere.StudentManager.TutorialWindow.SummonWindow();
        this.DisplayTutorial = false;
      }
      else
      {
        this.PauseScreen.ShowScheduleScreen();
        this.PauseScreen.Sideways = true;
        this.PauseScreen.Schedule.JumpToEvent(this.QuickID);
      }
      this.transform.localPosition = new Vector3(0.2043f, 0.0f, 1f);
      this.Show = false;
      this.Speed = 5f;
      this.Timer = 0.0f;
    }
    else
    {
      if ((double) this.Speed >= 5.0)
        return;
      this.Timer = 0.0f;
      this.Speed = Mathf.MoveTowards(this.Speed, 5f, Time.deltaTime);
      this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(0.2043f, 0.0f, 1f), (float) ((double) this.Speed * (double) Time.deltaTime * 0.016666600480675697));
      if ((double) this.Speed == 5.0)
      {
        this.transform.localPosition = new Vector3(0.2043f, 0.0f, 1f);
        this.DisplayTutorial = false;
      }
      if (!Input.GetButtonDown("Start") || this.PauseScreen.Yandere.Shutter.Snapping || this.PauseScreen.Yandere.TimeSkipping || this.PauseScreen.Yandere.Talking || this.PauseScreen.Yandere.Noticed || this.PauseScreen.Yandere.InClass || this.PauseScreen.Yandere.Struggling || this.PauseScreen.Yandere.Won || this.PauseScreen.Yandere.Dismembering || this.PauseScreen.Yandere.Attacked || !this.PauseScreen.Yandere.CanMove || this.PauseScreen.Yandere.Chased || this.PauseScreen.Yandere.Chasers != 0 || this.PauseScreen.Yandere.YandereVision || (double) Time.timeScale <= 9.9999997473787516E-05 || this.PauseScreen.Schedule.gameObject.activeInHierarchy)
        return;
      if (this.DisplayTutorial)
      {
        this.PauseScreen.Yandere.StudentManager.TutorialWindow.SummonWindow();
        this.DisplayTutorial = false;
      }
      else
      {
        this.PauseScreen.ShowScheduleScreen();
        this.PauseScreen.Sideways = true;
        this.PauseScreen.Schedule.JumpToEvent(this.QuickID);
      }
      this.transform.localPosition = new Vector3(0.2043f, 0.0f, 1f);
      this.Speed = 5f;
    }
  }
}
