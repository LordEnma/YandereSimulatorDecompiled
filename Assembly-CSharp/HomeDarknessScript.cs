// Decompiled with JetBrains decompiler
// Type: HomeDarknessScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeDarknessScript : MonoBehaviour
{
  public PrisonerManagerScript PrisonerManager;
  public HomeVideoGamesScript HomeVideoGames;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public HomeExitScript HomeExit;
  public InputDeviceScript InputDevice;
  public UILabel BasementLabel;
  public UISprite Sprite;
  public bool Cyberstalking;
  public bool FadeSlow;
  public bool FadeOut;

  private void Start()
  {
    if (GameGlobals.LoveSick)
      this.Sprite.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
  }

  private void Update()
  {
    if (this.FadeOut)
    {
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a + Time.deltaTime * (this.FadeSlow ? 0.2f : 1f));
      if ((double) this.Sprite.color.a < 1.0)
        return;
      this.HomeCamera.Profile.bloom.enabled = this.HomeCamera.RestoreBloom;
      this.HomeCamera.Profile.depthOfField.enabled = this.HomeCamera.RestoreDOF;
      if (this.HomeCamera.ID != 2)
      {
        if (this.HomeCamera.ID == 3)
        {
          if (this.Cyberstalking)
          {
            if (DateGlobals.PassDays < 1)
              DateGlobals.PassDays = 1;
            SceneManager.LoadScene("CalendarScene");
          }
          else
            SceneManager.LoadScene("YancordScene");
        }
        else if (this.HomeCamera.ID == 5)
        {
          if (this.HomeVideoGames.ID == 1)
            SceneManager.LoadScene("YanvaniaTitleScene");
          else
            SceneManager.LoadScene("MiyukiTitleScene");
        }
        else if (this.HomeCamera.ID == 9)
        {
          if (DateGlobals.PassDays < 1)
            DateGlobals.PassDays = 1;
          if (DateGlobals.Weekday != DayOfWeek.Friday)
            DateGlobals.ForceSkip = true;
          SceneManager.LoadScene("CalendarScene");
        }
        else if (this.HomeCamera.ID == 10)
        {
          StudentGlobals.SetStudentKidnapped(this.PrisonerManager.StudentID, false);
          StudentGlobals.StudentSlave = this.PrisonerManager.StudentID;
          StudentGlobals.PrisonerChosen = this.PrisonerManager.ChosenPrisoner;
          this.CheckForOsanaThursday();
        }
        else if (this.HomeCamera.ID == 11)
        {
          EventGlobals.KidnapConversation = true;
          SceneManager.LoadScene("PhoneScene");
        }
        else if (this.HomeCamera.ID == 12)
          SceneManager.LoadScene("LifeNoteScene");
        else if (this.HomeExit.ID == 1)
          this.CheckForOsanaThursday();
        else if (this.HomeExit.ID == 2)
          SceneManager.LoadScene("StreetScene");
        else if (this.HomeExit.ID == 3)
        {
          if ((double) this.HomeYandere.transform.position.y > -5.0)
          {
            this.HomeYandere.transform.position = new Vector3(-2f, -10f, -2.75f);
            this.HomeYandere.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
            this.HomeYandere.CanMove = true;
            this.FadeOut = false;
            this.HomeCamera.Destinations[0].position = new Vector3(2.425f, -8.5f, 0.0f);
            this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
            this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
            this.HomeCamera.Target = this.HomeCamera.Targets[0];
            this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
            this.BasementLabel.text = "Upstairs";
            this.HomeCamera.DayLight.SetActive(true);
            this.HomeCamera.DayLight.GetComponent<Light>().intensity = 0.66666f;
            Physics.SyncTransforms();
          }
          else
          {
            this.HomeYandere.transform.position = new Vector3(-1.6f, 0.0f, -1.6f);
            this.HomeYandere.transform.eulerAngles = new Vector3(0.0f, 45f, 0.0f);
            this.HomeYandere.CanMove = true;
            this.FadeOut = false;
            this.HomeCamera.Destinations[0].position = new Vector3(-2.0615f, 1.5f, 2.418f);
            this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
            this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
            this.HomeCamera.Target = this.HomeCamera.Targets[0];
            this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
            this.BasementLabel.text = "Basement";
            if (HomeGlobals.Night)
              this.HomeCamera.DayLight.SetActive(false);
            this.HomeCamera.DayLight.GetComponent<Light>().intensity = 2f;
            Physics.SyncTransforms();
          }
        }
        else
        {
          if (this.HomeExit.ID != 4)
            return;
          if (!GameGlobals.Eighties)
            SceneManager.LoadScene("StalkerHouseScene");
          else
            SceneManager.LoadScene("AsylumScene");
        }
      }
      else if (HomeGlobals.Night)
      {
        if (DateGlobals.Weekday == DayOfWeek.Sunday)
          DateGlobals.ForceSkip = true;
        else if (DateGlobals.PassDays < 1)
          DateGlobals.PassDays = 1;
        SceneManager.LoadScene("CalendarScene");
        if (StudentGlobals.UpdateRivalReputation)
        {
          StudentGlobals.SetStudentReputation(DateGlobals.Week + 10, StudentGlobals.GetStudentReputation(DateGlobals.Week + 10) - 50);
          if (StudentGlobals.GetStudentReputation(DateGlobals.Week + 10) <= -100)
          {
            GameGlobals.RivalEliminationID = 8;
            if (StudentGlobals.GetStudentReputation(DateGlobals.Week + 10) <= -150)
            {
              GameGlobals.SpecificEliminationID = 19;
              if (!GameGlobals.Debug)
                PlayerPrefs.SetInt("Suicide", 1);
              GameGlobals.NonlethalElimination = false;
            }
            else
            {
              Debug.Log((object) "Informing the Content Checklist that the player eliminated their rival by bullying.");
              GameGlobals.SpecificEliminationID = 4;
              if (!GameGlobals.Debug)
                PlayerPrefs.SetInt("Bully", 1);
              GameGlobals.NonlethalElimination = true;
            }
          }
          StudentGlobals.UpdateRivalReputation = false;
        }
        Debug.Log((object) "Went to sleep.");
      }
      else
      {
        if (DateGlobals.Weekday != DayOfWeek.Sunday)
          PlayerGlobals.Reputation -= 10f;
        HomeGlobals.Night = true;
        SceneManager.LoadScene("HomeScene");
      }
    }
    else
    {
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a - Time.deltaTime);
      if ((double) this.Sprite.color.a >= 0.0)
        return;
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0.0f);
    }
  }

  private void CheckForOsanaThursday()
  {
    PlayerGlobals.UsingGamepad = this.InputDevice.Type == InputDeviceType.Gamepad;
    int indexByScenePath = SceneUtility.GetBuildIndexByScenePath("WalkToSchoolScene");
    if (!GameGlobals.Eighties && GameGlobals.RivalEliminationID == 0 && !StudentGlobals.GetStudentKidnapped(11) && StudentGlobals.StudentSlave != 11 && DateGlobals.Weekday == DayOfWeek.Thursday && !HomeGlobals.LateForSchool && StudentGlobals.GetStudentReputation(11) > -100 && indexByScenePath > -1)
      SceneManager.LoadScene("WalkToSchoolScene");
    else if (DateGlobals.Weekday == DayOfWeek.Saturday)
    {
      DateGlobals.PassDays = 1;
      SceneManager.LoadScene("CalendarScene");
    }
    else if (GameGlobals.ShowAbduction)
    {
      SceneManager.LoadScene("AbductionScene");
      GameGlobals.ShowAbduction = false;
    }
    else
      SceneManager.LoadScene("LoadingScene");
  }
}
