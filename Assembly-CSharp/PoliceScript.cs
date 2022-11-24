// Decompiled with JetBrains decompiler
// Type: PoliceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoliceScript : MonoBehaviour
{
  public LowRepGameOverScript LowRepGameOver;
  public StudentManagerScript StudentManager;
  public ClubManagerScript ClubManager;
  public HeartbrokenScript Heartbroken;
  public LoveManagerScript LoveManager;
  public PauseScreenScript PauseScreen;
  public ReputationScript Reputation;
  public TranqCaseScript TranqCase;
  public EndOfDayScript EndOfDay;
  public JukeboxScript Jukebox;
  public YandereScript Yandere;
  public ClockScript Clock;
  public JsonScript JSON;
  public UIPanel Panel;
  public GameObject HeartbeatCamera;
  public GameObject DetectionCamera;
  public GameObject SuicideStudent;
  public GameObject UICamera;
  public GameObject Icons;
  public GameObject FPS;
  public Transform GarbageParent;
  public Transform BloodParent;
  public Transform LimbParent;
  public RagdollScript[] CorpseList;
  public UILabel[] ResultsLabels;
  public UILabel ContinueLabel;
  public UILabel TimeLabel;
  public UISprite ContinueButton;
  public UISprite Darkness;
  public UISprite BloodIcon;
  public UISprite UniformIcon;
  public UISprite WeaponIcon;
  public UISprite CorpseIcon;
  public UISprite PartsIcon;
  public UISprite SanityIcon;
  public string ElectrocutedStudentName = string.Empty;
  public string DrownedStudentName = string.Empty;
  public bool BloodDisposed;
  public bool UniformDisposed;
  public bool WeaponDisposed;
  public bool CorpseDisposed;
  public bool PartsDisposed;
  public bool SanityRestored;
  public bool MurderSuicideScene;
  public bool ElectroScene;
  public bool SuicideScene;
  public bool PoisonScene;
  public bool MurderScene;
  public bool WasHoldingBloodyWeapon;
  public bool SkippingPastPoison;
  public bool StudentFoundCorpse;
  public bool BeginConfession;
  public bool GenocideEnding;
  public bool TeacherReport;
  public bool ClubActivity;
  public bool CouncilDeath;
  public bool MaskReported;
  public bool SelfReported;
  public bool FadeResults;
  public bool ShowResults;
  public bool SuicideNote;
  public bool TextUpdated;
  public bool GameOver;
  public bool DayOver;
  public bool Delayed;
  public bool FadeOut;
  public bool Invalid;
  public bool Suicide;
  public bool Called;
  public bool LowRep;
  public bool Show;
  public int IncineratedWeapons;
  public int RedPaintClothing;
  public int SuicideVictims;
  public int BloodyClothing;
  public int BloodyWeapons;
  public int HiddenCorpses;
  public int MurderWeapons;
  public int PhotoEvidence;
  public int DrownVictims;
  public int BodyParts;
  public int SuicideID;
  public int Witnesses;
  public int Corpses;
  public int Deaths;
  public int Frame;
  public float ResultsTimer;
  public float Timer;
  public float TargetX;
  public float TargetY;
  public int Minutes;
  public int Seconds;
  public string Protagonist = "Ayano";
  public string[] VtuberNames;
  public int[] IDsToIgnore;
  public int IDsCounted;
  public int SuspensionLength;
  public int RemainingDays;
  public bool Suspended;

  private void Start()
  {
    if ((double) SchoolGlobals.SchoolAtmosphere > 0.5)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0.0f);
      this.Darkness.enabled = false;
    }
    this.transform.localPosition = new Vector3(-260f, this.transform.localPosition.y, this.transform.localPosition.z);
    foreach (UILabel resultsLabel in this.ResultsLabels)
      resultsLabel.color = new Color(resultsLabel.color.r, resultsLabel.color.g, resultsLabel.color.b, 0.0f);
    this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, 0.0f);
    this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, 0.0f);
    this.Icons.SetActive(false);
    if (!GameGlobals.Eighties)
      return;
    this.Protagonist = "Ryoba";
    this.TargetX = 25f;
    this.TargetY = -25f;
  }

  private void Update()
  {
    if (this.Show)
    {
      if (this.StudentManager.Eighties && !this.TextUpdated)
      {
        ++this.Frame;
        if (this.Frame > 1)
        {
          foreach (UILabel componentsInChild in this.gameObject.GetComponentsInChildren<UILabel>())
            this.StudentManager.EightiesifyLabel(componentsInChild);
          this.TextUpdated = true;
          this.Yandere.CinematicCamera.SetActive(false);
        }
      }
      this.StudentManager.TutorialWindow.ShowPoliceMessage = true;
      int num1 = this.PoisonScene ? 1 : 0;
      if (!this.Icons.activeInHierarchy)
        this.Icons.SetActive(true);
      this.transform.localPosition = new Vector3(Mathf.Lerp(this.transform.localPosition.x, this.TargetX, Time.deltaTime * 10f), Mathf.Lerp(this.transform.localPosition.y, this.TargetY, Time.deltaTime * 10f), this.transform.localPosition.z);
      if (this.BloodParent.childCount == 0)
      {
        if (!this.BloodDisposed)
        {
          this.BloodIcon.spriteName = "Yes";
          this.BloodDisposed = true;
        }
      }
      else if (this.BloodDisposed)
      {
        this.BloodIcon.spriteName = "No";
        this.BloodDisposed = false;
      }
      if (this.BloodyClothing == 0)
      {
        if (!this.UniformDisposed)
        {
          this.UniformIcon.spriteName = "Yes";
          this.UniformDisposed = true;
        }
      }
      else if (this.UniformDisposed)
      {
        this.UniformIcon.spriteName = "No";
        this.UniformDisposed = false;
      }
      if (this.MurderWeapons == 0 || this.IncineratedWeapons == this.MurderWeapons)
      {
        if (!this.WeaponDisposed)
        {
          this.WeaponIcon.spriteName = "Yes";
          this.WeaponDisposed = true;
        }
      }
      else if (this.WeaponDisposed)
      {
        this.WeaponIcon.spriteName = "No";
        this.WeaponDisposed = false;
      }
      if (this.Corpses == 0)
      {
        if (!this.CorpseDisposed)
        {
          this.CorpseIcon.spriteName = "Yes";
          this.CorpseDisposed = true;
        }
      }
      else if (this.CorpseDisposed)
      {
        this.CorpseIcon.spriteName = "No";
        this.CorpseDisposed = false;
      }
      if (this.BodyParts == 0)
      {
        if (!this.PartsDisposed)
        {
          this.PartsIcon.spriteName = "Yes";
          this.PartsDisposed = true;
        }
      }
      else if (this.PartsDisposed)
      {
        this.PartsIcon.spriteName = "No";
        this.PartsDisposed = false;
      }
      if ((double) this.Yandere.Sanity == 100.0)
      {
        if (!this.SanityRestored)
        {
          this.SanityIcon.spriteName = "Yes";
          this.SanityRestored = true;
        }
      }
      else if (this.SanityRestored)
      {
        this.SanityIcon.spriteName = "No";
        this.SanityRestored = false;
      }
      if (!this.Clock.StopTime)
        this.Timer = Mathf.MoveTowards(this.Timer, 0.0f, Time.deltaTime);
      if ((double) this.Timer <= 0.0)
      {
        this.Timer = 0.0f;
        if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.Egg && !this.Yandere.Lifting && !this.FadeOut)
        {
          this.Reputation.UpdateRep();
          if ((double) this.Reputation.Reputation <= -100.0)
            this.Show = false;
          this.BeginFadingOut();
        }
      }
      int num2 = Mathf.CeilToInt(this.Timer);
      this.Minutes = num2 / 60;
      this.Seconds = num2 % 60;
      this.TimeLabel.text = string.Format("{0:00}:{1:00}", (object) this.Minutes, (object) this.Seconds);
      if ((double) this.Yandere.NotificationManager.NotificationParent.localPosition.x == 0.0)
        this.Yandere.NotificationManager.NotificationParent.localPosition = new Vector3(0.15f, this.Yandere.NotificationManager.NotificationParent.localPosition.y, this.Yandere.NotificationManager.NotificationParent.localPosition.z);
    }
    else if (this.Deaths > 86 && !this.Invalid && !this.Yandere.Egg && this.Clock.Weekday == 1 && this.StudentManager.Students[1].gameObject.activeInHierarchy && !this.StudentManager.Students[1].Fleeing)
    {
      this.GenocideEnding = true;
      this.BeginFadingOut();
    }
    if (this.FadeOut)
    {
      if (this.Yandere.Laughing)
        this.Yandere.StopLaughing();
      if (this.Clock.TimeSkip || this.Yandere.CanMove)
      {
        if (this.Clock.TimeSkip)
          this.Clock.EndTimeSkip();
        this.Yandere.StopAiming();
        this.Yandere.CanMove = false;
        this.Yandere.YandereVision = false;
        this.Yandere.PauseScreen.enabled = false;
        this.Yandere.CinematicCamera.SetActive(false);
        this.Yandere.CharacterAnimation.CrossFade("f02_idleShort_00");
        if ((UnityEngine.Object) this.Yandere.Mask != (UnityEngine.Object) null)
          this.Yandere.Mask.Drop();
        if ((UnityEngine.Object) this.Yandere.PickUp != (UnityEngine.Object) null)
          this.Yandere.EmptyHands();
        if (this.Yandere.Dragging || this.Yandere.Carrying)
          this.Yandere.EmptyHands();
      }
      this.PauseScreen.Panel.alpha = Mathf.MoveTowards(this.PauseScreen.Panel.alpha, 0.0f, Time.deltaTime);
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a > 0.99900001287460327)
      {
        this.Darkness.alpha = 1f;
        if (!this.ShowResults)
        {
          this.HeartbeatCamera.SetActive(false);
          this.DetectionCamera.SetActive(false);
          if (this.ClubActivity)
          {
            this.ClubManager.Club = this.Yandere.Club;
            this.ClubManager.ClubActivity();
            this.FadeOut = false;
          }
          else
          {
            this.Yandere.MyController.enabled = false;
            this.Yandere.enabled = false;
            this.DetermineResults();
            this.ShowResults = true;
            Time.timeScale = 2f;
            this.Jukebox.Volume = 0.0f;
          }
          if (this.GenocideEnding)
          {
            SceneManager.LoadScene("GenocideScene");
            if (!GameGlobals.Debug)
            {
              PlayerPrefs.SetInt("Genocide", 1);
              PlayerPrefs.SetInt("a", 1);
            }
          }
        }
      }
    }
    if (this.ShowResults)
    {
      this.ResultsTimer += Time.deltaTime;
      if ((double) this.ResultsTimer > 1.0)
      {
        UILabel resultsLabel = this.ResultsLabels[0];
        resultsLabel.color = new Color(resultsLabel.color.r, resultsLabel.color.g, resultsLabel.color.b, resultsLabel.color.a + Time.deltaTime);
      }
      if ((double) this.ResultsTimer > 2.0)
      {
        UILabel resultsLabel = this.ResultsLabels[1];
        resultsLabel.color = new Color(resultsLabel.color.r, resultsLabel.color.g, resultsLabel.color.b, resultsLabel.color.a + Time.deltaTime);
      }
      if ((double) this.ResultsTimer > 3.0)
      {
        UILabel resultsLabel = this.ResultsLabels[2];
        resultsLabel.color = new Color(resultsLabel.color.r, resultsLabel.color.g, resultsLabel.color.b, resultsLabel.color.a + Time.deltaTime);
      }
      if ((double) this.ResultsTimer > 4.0)
      {
        UILabel resultsLabel = this.ResultsLabels[3];
        resultsLabel.color = new Color(resultsLabel.color.r, resultsLabel.color.g, resultsLabel.color.b, resultsLabel.color.a + Time.deltaTime);
      }
      if ((double) this.ResultsTimer > 5.0)
      {
        UILabel resultsLabel = this.ResultsLabels[4];
        resultsLabel.color = new Color(resultsLabel.color.r, resultsLabel.color.g, resultsLabel.color.b, resultsLabel.color.a + Time.deltaTime);
      }
      if ((double) this.ResultsTimer > 6.0)
      {
        this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, this.ContinueButton.color.a + Time.deltaTime);
        this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, this.ContinueLabel.color.a + Time.deltaTime);
        if ((double) this.ContinueButton.color.a > 1.0)
          this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, 1f);
        if ((double) this.ContinueLabel.color.a > 1.0)
          this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, 1f);
      }
      if (Input.GetKeyDown("space"))
      {
        this.ShowResults = false;
        this.FadeResults = true;
        this.FadeOut = false;
        this.ResultsTimer = 0.0f;
      }
      if ((double) this.ResultsTimer > 7.0 && Input.GetButtonDown("A"))
      {
        this.ShowResults = false;
        this.FadeResults = true;
        this.FadeOut = false;
        this.ResultsTimer = 0.0f;
      }
    }
    foreach (UILabel resultsLabel in this.ResultsLabels)
    {
      if ((double) resultsLabel.color.a > 1.0)
        resultsLabel.color = new Color(resultsLabel.color.r, resultsLabel.color.g, resultsLabel.color.b, 1f);
    }
    if (!this.FadeResults)
      return;
    foreach (UILabel resultsLabel in this.ResultsLabels)
      resultsLabel.color = new Color(resultsLabel.color.r, resultsLabel.color.g, resultsLabel.color.b, resultsLabel.color.a - Time.deltaTime);
    this.ContinueButton.color = new Color(this.ContinueButton.color.r, this.ContinueButton.color.g, this.ContinueButton.color.b, this.ContinueButton.color.a - Time.deltaTime);
    this.ContinueLabel.color = new Color(this.ContinueLabel.color.r, this.ContinueLabel.color.g, this.ContinueLabel.color.b, this.ContinueLabel.color.a - Time.deltaTime);
    if ((double) this.ResultsLabels[0].color.a > 0.0)
      return;
    if (this.BeginConfession)
    {
      this.LoveManager.Suitor = this.StudentManager.Students[1];
      this.LoveManager.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
      this.LoveManager.Suitor.CharacterAnimation.enabled = true;
      this.LoveManager.Rival.CharacterAnimation.enabled = true;
      this.LoveManager.BeginConfession();
      Time.timeScale = 1f;
      this.enabled = false;
    }
    else if (this.GameOver)
    {
      this.Heartbroken.transform.parent.transform.parent = (Transform) null;
      this.Heartbroken.transform.parent.gameObject.SetActive(true);
      this.Heartbroken.Noticed = false;
      this.transform.parent.transform.parent.gameObject.SetActive(false);
      if (this.EndOfDay.gameObject.activeInHierarchy)
        return;
      Time.timeScale = 1f;
    }
    else if (this.LowRep)
    {
      this.Yandere.ShoulderCamera.enabled = false;
      this.Yandere.RPGCamera.enabled = false;
      this.Yandere.RPGCamera.transform.parent = this.LowRepGameOver.MyCamera;
      this.Yandere.RPGCamera.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.Yandere.RPGCamera.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.LowRepGameOver.gameObject.SetActive(true);
      this.UICamera.SetActive(false);
      this.FPS.SetActive(false);
      Time.timeScale = 1f;
      this.enabled = false;
    }
    else if (!this.TeacherReport)
    {
      if (this.EndOfDay.Phase != 1)
        return;
      this.Yandere.MyListener.enabled = false;
      this.EndOfDay.gameObject.SetActive(true);
      this.EndOfDay.enabled = true;
      this.EndOfDay.Phase = 14;
      if (this.EndOfDay.PreviouslyActivated)
        this.EndOfDay.Start();
      for (int index = 0; index < 5; ++index)
        this.ResultsLabels[index].text = string.Empty;
      this.enabled = false;
    }
    else
    {
      this.DetermineResults();
      this.TeacherReport = false;
      this.FadeResults = false;
      this.ShowResults = true;
    }
  }

  private void DetermineResults()
  {
    Debug.Log((object) "DetermineResults() has been called.");
    if (this.Yandere.VtuberID > 0)
      this.Protagonist = this.VtuberNames[this.Yandere.VtuberID];
    this.ResultsLabels[0].transform.parent.gameObject.SetActive(true);
    if (this.Show)
    {
      this.Yandere.MyListener.enabled = false;
      this.EndOfDay.PoliceArrived = true;
      this.EndOfDay.gameObject.SetActive(true);
      this.EndOfDay.enabled = true;
      this.enabled = false;
      if (this.EndOfDay.PreviouslyActivated)
        this.EndOfDay.Start();
      for (int index = 0; index < 5; ++index)
        this.ResultsLabels[index].text = string.Empty;
    }
    else if (this.Yandere.ShoulderCamera.GoingToCounselor && !this.EndOfDay.Counselor.Expelled)
    {
      if (this.Yandere.Police.Corpses - this.Yandere.Police.HiddenCorpses > 0)
      {
        this.ResultsLabels[0].text = "While " + this.Protagonist + " was in the counselor's office,";
        this.ResultsLabels[1].text = "a corpse was discovered on school grounds.";
        this.ResultsLabels[2].text = "The school faculty was informed of the corpse,";
        this.ResultsLabels[3].text = "and the police were called to the school.";
        this.ResultsLabels[4].text = "No one is allowed to leave school until a police investigation has taken place.";
      }
      else if (this.WasHoldingBloodyWeapon)
      {
        this.ResultsLabels[0].text = "When " + this.Protagonist + " was caught,";
        this.ResultsLabels[1].text = "a blood-stained weapon was found in her possession.";
        this.ResultsLabels[2].text = "The school faculty was informed of the weapon,";
        this.ResultsLabels[3].text = "and the police were called to the school.";
        this.ResultsLabels[4].text = "No one is allowed to leave school until a police investigation has taken place.";
      }
      else if (this.Yandere.Police.BloodyWeapons > 0)
      {
        this.ResultsLabels[0].text = "While " + this.Protagonist + " was in the counselor's office,";
        this.ResultsLabels[1].text = "a faculty member discovered a mysterious bloody weapon.";
        this.ResultsLabels[2].text = "The school faculty was informed of the weapon,";
        this.ResultsLabels[3].text = "and the police were called to the school.";
        this.ResultsLabels[4].text = "No one is allowed to leave school until a police investigation has taken place.";
      }
      this.TeacherReport = true;
      this.Show = true;
    }
    else if ((double) this.Reputation.Reputation <= -100.0)
    {
      this.ResultsLabels[0].text = this.Protagonist + "'s bizarre conduct has been observed and discussed by many people.";
      this.ResultsLabels[1].text = "Word of " + this.Protagonist + "'s strange behavior has reached Senpai.";
      this.ResultsLabels[2].text = "Senpai is now aware that " + this.Protagonist + " is a deranged person.";
      this.ResultsLabels[3].text = "From this day forward, Senpai will fear and avoid " + this.Protagonist + ".";
      this.ResultsLabels[4].text = this.Protagonist + " will never have her Senpai's love.";
      this.LowRep = true;
    }
    else if (!this.Suicide && !this.PoisonScene)
    {
      this.ResultsLabels[0].text = (double) this.Clock.HourTime >= 18.0 ? "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave." : (!this.Yandere.InClass ? (!this.Yandere.Resting || this.Corpses <= 0 ? (!this.Yandere.Resting ? (!GameGlobals.SenpaiMourning ? this.Protagonist + " is ready to leave school." : this.Protagonist + " is ready to leave school.") : (!GameGlobals.SenpaiMourning ? this.Protagonist + " recovers from her injuries, and is ready to leave school." : this.Protagonist + " recovers from her injuries, and is ready to leave school.")) : this.Protagonist + " rests without disposing of a corpse.") : (!this.SkippingPastPoison ? this.Protagonist + " attempts to attend class without disposing of a corpse." : "A student has died from eating poisoned food."));
      if (this.Suspended)
      {
        this.Yandere.Class.Portal.EndFinalEvents();
        if (this.Clock.Weekday == 1)
          this.RemainingDays = 5;
        else if (this.Clock.Weekday == 2)
          this.RemainingDays = 4;
        else if (this.Clock.Weekday == 3)
          this.RemainingDays = 3;
        else if (this.Clock.Weekday == 4)
          this.RemainingDays = 2;
        else if (this.Clock.Weekday == 5)
          this.RemainingDays = 1;
        if (this.EndOfDay.Counselor.CounselorPunishments > 5 || this.EndOfDay.Counselor.Expelled)
        {
          this.ResultsLabels[0].text = this.Protagonist + " is no longer allowed";
          this.ResultsLabels[1].text = "to attend Akademi.";
          this.ResultsLabels[2].text = "This means that she will";
          this.ResultsLabels[3].text = "never be able to confess";
          this.ResultsLabels[4].text = "her love to her Senpai.";
          this.GameOver = true;
        }
        else if (this.RemainingDays - this.SuspensionLength <= 0 && !this.StudentManager.RivalEliminated)
        {
          this.ResultsLabels[0].text = "Due to her suspension,";
          this.ResultsLabels[1].text = this.Protagonist + " will be unable";
          this.ResultsLabels[2].text = "to prevent her rival";
          this.ResultsLabels[3].text = "from confessing to Senpai.";
          this.ResultsLabels[4].text = this.Protagonist + " will never have Senpai.";
          this.GameOver = true;
        }
        else if (this.SuspensionLength == 1)
        {
          this.ResultsLabels[0].text = this.Protagonist + " has been sent home early.";
          this.ResultsLabels[1].text = "";
          this.ResultsLabels[2].text = "She won't be able to see Senpai again until tomorrow.";
          this.ResultsLabels[3].text = "";
          this.ResultsLabels[4].text = this.Protagonist + "'s heart aches as she thinks of Senpai.";
        }
        else
        {
          this.ResultsLabels[0].text = this.Protagonist + " has been sent home early.";
          this.ResultsLabels[1].text = "";
          this.ResultsLabels[2].text = "She will have to wait " + this.SuspensionLength.ToString() + " days before returning to school.";
          this.ResultsLabels[3].text = "";
          this.ResultsLabels[4].text = this.Protagonist + "'s heart aches as she thinks of Senpai.";
        }
      }
      else
      {
        this.BloodyClothing -= this.RedPaintClothing;
        if (this.Corpses == 0 && this.LimbParent.childCount == 0 && this.BloodParent.childCount == 0 && this.BloodyWeapons == 0 && this.BloodyClothing == 0 && !this.SuicideScene)
        {
          if ((double) this.Yandere.Sanity < 66.666656494140625 || (double) this.Yandere.Bloodiness > 0.0 && !this.Yandere.RedPaint)
          {
            this.ResultsLabels[1].text = this.Protagonist + " is approached by a faculty member.";
            if ((double) this.Yandere.Bloodiness > 0.0)
            {
              this.ResultsLabels[2].text = "The faculty member immediately notices the blood staining her clothing.";
              this.ResultsLabels[3].text = this.Protagonist + " is not able to convince the faculty member that nothing is wrong.";
              this.ResultsLabels[4].text = "The faculty member calls the police.";
              this.TeacherReport = true;
              this.Show = true;
            }
            else
            {
              this.ResultsLabels[2].text = this.Protagonist + " exhibited extremely erratic behavior, frightening the faculty member.";
              this.ResultsLabels[3].text = "The faculty member becomes angry with " + this.Protagonist + ", but " + this.Protagonist + " leaves before the situation gets worse.";
              this.ResultsLabels[4].text = this.Protagonist + " returns home.";
            }
          }
          else if (!this.StudentManager.Eighties && (UnityEngine.Object) this.StudentManager.Students[2] != (UnityEngine.Object) null && this.StudentManager.Students[2].Alive && this.Yandere.Inventory.Ring || this.StudentManager.Eighties && (UnityEngine.Object) this.StudentManager.Students[30] != (UnityEngine.Object) null && this.StudentManager.Students[30].Alive && this.Yandere.Inventory.Ring || this.Yandere.Inventory.RivalPhone && this.StudentManager.CommunalLocker.RivalPhone.StudentID == this.StudentManager.RivalID && !this.StudentManager.RivalEliminated || this.Yandere.Inventory.RivalPhone && this.StudentManager.CommunalLocker.RivalPhone.StudentID != this.StudentManager.RivalID && this.StudentManager.Students[this.StudentManager.CommunalLocker.RivalPhone.StudentID].Alive)
          {
            if (this.Yandere.Inventory.Ring)
            {
              this.ResultsLabels[1].text = "A student tells the faculty that her ring is missing.";
              this.ResultsLabels[2].text = "Suspecting theft, the faculty check all students' belongings before they are allowed to leave school.";
              this.ResultsLabels[3].text = "The stolen ring is found on " + this.Protagonist + "'s person.";
              this.ResultsLabels[4].text = this.Protagonist + " is expelled from school for stealing from another student.";
            }
            else if (this.StudentManager.CommunalLocker.RivalPhone.StudentID == this.StudentManager.RivalID)
            {
              this.ResultsLabels[1].text = "Osana tells the faculty that her phone is missing.";
              this.ResultsLabels[2].text = "Suspecting theft, the faculty check all students' belongings before they are allowed to leave school.";
              this.ResultsLabels[3].text = "Osana's stolen phone is found on " + this.Protagonist + "'s person.";
              this.ResultsLabels[4].text = this.Protagonist + " is expelled from school for stealing from another student.";
            }
            else
            {
              this.ResultsLabels[1].text = "A student tells the faculty that her phone is missing.";
              this.ResultsLabels[2].text = "Suspecting theft, the faculty check all students' belongings before they are allowed to leave school.";
              this.ResultsLabels[3].text = "The student's stolen phone is found on " + this.Protagonist + "'s person.";
              this.ResultsLabels[4].text = this.Protagonist + " is expelled from school for stealing from another student.";
            }
            this.GameOver = true;
            this.Heartbroken.Counselor.Expelled = true;
          }
          else if (DateGlobals.Weekday == DayOfWeek.Friday)
          {
            if (this.StudentManager.RivalEliminated || this.StudentManager.SabotageProgress == 5 || this.StudentManager.LoveManager.ConfessToSuitor)
            {
              if (!this.StudentManager.RivalEliminated)
              {
                if (this.StudentManager.LoveManager.ConfessToSuitor)
                {
                  this.StudentManager.RivalEliminated = true;
                  this.EndOfDay.RivalEliminationMethod = RivalEliminationType.Matchmade;
                }
                else if (this.StudentManager.SabotageProgress == 5)
                {
                  this.StudentManager.RivalEliminated = true;
                  this.EndOfDay.RivalEliminationMethod = RivalEliminationType.Rejected;
                }
              }
              this.ResultsLabels[0].text = this.Protagonist + "'s rival is no longer a threat.";
              this.ResultsLabels[1].text = this.Protagonist + " considers confessing her love to Senpai...";
              this.ResultsLabels[2].text = "...but she cannot build up the courage to speak to him.";
              this.ResultsLabels[3].text = this.Protagonist + " follows Senpai out of school and watches him from a distance until he has returned to his home.";
              this.ResultsLabels[4].text = "Then, " + this.Protagonist + " returns to her own home, and considers what she should do next...";
            }
            else
            {
              this.ResultsLabels[0].text = "It is 6:00 PM on Friday.";
              this.ResultsLabels[1].text = this.Protagonist + "'s rival asks Senpai to meet her under the cherry tree behind the school.";
              this.ResultsLabels[2].text = "As cherry blossoms fall around them...";
              this.ResultsLabels[3].text = "...she confesses her feelings for Senpai.";
              this.ResultsLabels[4].text = this.Protagonist + " watches from a short distance away...";
              this.BeginConfession = true;
            }
          }
          else
          {
            if ((double) this.Clock.HourTime < 18.0)
            {
              if ((double) this.Yandere.Senpai.position.z > -75.0)
              {
                this.ResultsLabels[1].text = "However, she can't bring herself to leave before Senpai does.";
                this.ResultsLabels[2].text = this.Protagonist + " waits at the school's entrance until Senpai eventually appears.";
                this.ResultsLabels[3].text = "She follows him and watches him from a distance until he has returned to his home.";
                this.ResultsLabels[4].text = "Then, " + this.Protagonist + " returns to her house.";
              }
              else
              {
                this.ResultsLabels[1].text = this.Protagonist + " quickly runs out of school, determined to catch a glimpse of Senpai as he walks home.";
                this.ResultsLabels[2].text = "Eventually, she catches up to him.";
                this.ResultsLabels[3].text = this.Protagonist + " follows Senpai and watches him from a distance until he has returned to his home.";
                this.ResultsLabels[4].text = "Then, " + this.Protagonist + " returns to her house.";
              }
            }
            else
            {
              this.ResultsLabels[1].text = "Like all other students, " + this.Protagonist + " is instructed to leave school.";
              this.ResultsLabels[2].text = "After exiting school, " + this.Protagonist + " locates Senpai.";
              this.ResultsLabels[3].text = this.Protagonist + " follows Senpai and watches him from a distance until he has returned to his home.";
              this.ResultsLabels[4].text = "Then, " + this.Protagonist + " returns to her house.";
            }
            if (!GameGlobals.SenpaiMourning)
              return;
            this.ResultsLabels[1].text = "Like all other students, " + this.Protagonist + " is instructed to leave school.";
            this.ResultsLabels[2].text = this.Protagonist + " leaves school.";
            this.ResultsLabels[3].text = this.Protagonist + " returns to her home.";
            this.ResultsLabels[4].text = "Her heart aches as she thinks of Senpai.";
          }
        }
        else
        {
          if (this.Corpses > 0)
          {
            this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
            this.ResultsLabels[2].text = "The faculty member immediately calls the police.";
            this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
            this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
            this.TeacherReport = true;
            this.Show = true;
          }
          else if (this.LimbParent.childCount > 0)
          {
            this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a dismembered body part.";
            this.ResultsLabels[2].text = "The faculty member decides to call the police.";
            this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
            this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
            this.TeacherReport = true;
            this.Show = true;
          }
          else if (this.BloodParent.childCount > 0 || this.BloodyClothing > 0)
          {
            this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious blood stain.";
            this.ResultsLabels[2].text = "The faculty member decides to call the police.";
            this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
            this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
            this.TeacherReport = true;
            this.Show = true;
          }
          else if (this.BloodyWeapons > 0)
          {
            this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a mysterious bloody weapon.";
            this.ResultsLabels[2].text = "The faculty member decides to call the police.";
            this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
            this.ResultsLabels[4].text = "The faculty do not allow any students to leave the school until a police investigation has taken place.";
            this.TeacherReport = true;
            this.Show = true;
          }
          else if (this.SuicideScene)
          {
            this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a pair of shoes on the rooftop.";
            this.ResultsLabels[2].text = "The faculty member fears that there has been a suicide, but cannot find a corpse anywhere. The faculty member does not take any action.";
            this.ResultsLabels[3].text = this.Protagonist + " leaves school and follows Senpai, watching him as he walks home.";
            this.ResultsLabels[4].text = "Once he is safely home, " + this.Protagonist + " returns to her own home.";
            if (GameGlobals.SenpaiMourning)
            {
              this.ResultsLabels[3].text = this.Protagonist + " leaves school.";
              this.ResultsLabels[4].text = this.Protagonist + " returns home.";
            }
          }
          if (!this.SelfReported)
            return;
          this.ResultsLabels[0].text = this.Protagonist + " informs a faculty member that something alarming is present at school.";
          this.ResultsLabels[1].text = "The faculty member confirms that " + this.Protagonist + " is telling the truth.";
        }
      }
    }
    else if (this.Suicide)
    {
      this.ResultsLabels[0].text = this.Yandere.InClass ? (this.Corpses <= 0 ? this.Protagonist + " attempts to attend class without cleaning up some blood." : this.Protagonist + " attempts to attend class without disposing of a corpse.") : "The school day has ended. Faculty members must walk through the school and tell any lingering students to leave.";
      this.ResultsLabels[1].text = "While walking around the school, a faculty member discovers a corpse.";
      this.ResultsLabels[2].text = !this.SuicideNote ? "It appears as though a student has fallen from the school rooftop." : "It appears as though a student has committed suicide.";
      this.ResultsLabels[3].text = "The faculty member informs the rest of the faculty about her discovery.";
      this.ResultsLabels[4].text = "The faculty members agree to call the police and report the student's death.";
      this.TeacherReport = true;
      this.Show = true;
      if (!this.SelfReported)
        return;
      this.ResultsLabels[0].text = this.Protagonist + " informs a faculty member that something alarming is present at school.";
      this.ResultsLabels[1].text = "The faculty member confirms that " + this.Protagonist + " is telling the truth.";
    }
    else
    {
      if (!this.PoisonScene)
        return;
      this.ResultsLabels[0].text = "A faculty member discovers the student who " + this.Protagonist + " poisoned.";
      this.ResultsLabels[1].text = "The faculty member calls for an ambulance immediately.";
      this.ResultsLabels[2].text = "The faculty member suspects that the student's death was a murder.";
      this.ResultsLabels[3].text = "The faculty member also calls for the police.";
      this.ResultsLabels[4].text = "The school's students are not allowed to leave until a police investigation has taken place.";
      this.TeacherReport = true;
      this.Show = true;
    }
  }

  public void KillStudents()
  {
    for (int studentID = 1; studentID < 101; ++studentID)
    {
      if (!StudentGlobals.GetStudentDead(studentID) && (double) this.StudentManager.StudentReps[studentID] < -150.0)
      {
        ++this.Deaths;
        StudentGlobals.SetStudentDead(studentID, true);
        Debug.Log((object) ("Student #" + studentID.ToString() + " committed suicide due to low reputation. They will have a memorial at school tomorrow."));
        if (StudentGlobals.MemorialStudents < 9)
        {
          ++StudentGlobals.MemorialStudents;
          switch (StudentGlobals.MemorialStudents)
          {
            case 1:
              StudentGlobals.MemorialStudent1 = studentID;
              continue;
            case 2:
              StudentGlobals.MemorialStudent2 = studentID;
              continue;
            case 3:
              StudentGlobals.MemorialStudent3 = studentID;
              continue;
            case 4:
              StudentGlobals.MemorialStudent4 = studentID;
              continue;
            case 5:
              StudentGlobals.MemorialStudent5 = studentID;
              continue;
            case 6:
              StudentGlobals.MemorialStudent6 = studentID;
              continue;
            case 7:
              StudentGlobals.MemorialStudent7 = studentID;
              continue;
            case 8:
              StudentGlobals.MemorialStudent8 = studentID;
              continue;
            case 9:
              StudentGlobals.MemorialStudent9 = studentID;
              continue;
            default:
              continue;
          }
        }
      }
    }
    if (this.Deaths > 0)
    {
      PlayerGlobals.Kills += this.Deaths;
      Debug.Log((object) ("There were " + this.Deaths.ToString() + " deaths at school today. As a result, PlayerGlobals.Kills is being incremented."));
      for (int studentID = 2; studentID < this.StudentManager.NPCsTotal + 1; ++studentID)
      {
        if (StudentGlobals.GetStudentDying(studentID) && !StudentGlobals.GetStudentDead(studentID) || (UnityEngine.Object) this.StudentManager.Students[studentID] != (UnityEngine.Object) null && !this.StudentManager.Students[studentID].Alive)
        {
          Debug.Log((object) "Subtracting 10% school atmosphere because someone died. Atmosphere will go down further if everyone *knows* they are dead.");
          SchoolGlobals.SchoolAtmosphere -= 0.1f;
          if (this.JSON.Students[studentID].Club == ClubType.Council)
          {
            --SchoolGlobals.SchoolAtmosphere;
            SchoolGlobals.HighSecurity = true;
          }
          StudentGlobals.SetStudentDead(studentID, true);
          if (studentID > 10 && studentID < DateGlobals.Week + 10 && (UnityEngine.Object) this.StudentManager.Students[studentID] != (UnityEngine.Object) null && this.StudentManager.Students[studentID].Ragdoll.Disposed)
          {
            Debug.Log((object) "The player killed a previous rival and disposed of her corpse.");
            this.EndOfDay.SetFormerRivalDeath(studentID - 10, this.StudentManager.Students[studentID]);
            GameGlobals.SetRivalEliminations(studentID - 10, 11);
          }
          StudentGlobals.SetStudentGrudge(studentID, false);
        }
      }
      if (this.Corpses > 0)
      {
        Debug.Log((object) ("Subtracting " + (this.Corpses * 10).ToString() + "% school atmosphere because " + this.Corpses.ToString() + " murders are confirmed."));
        SchoolGlobals.SchoolAtmosphere -= (float) this.Corpses * 0.1f;
      }
      if (this.DrownVictims + this.Corpses > 0)
      {
        Debug.Log((object) "Today, there were corpses on school grounds.");
        foreach (RagdollScript corpse in this.CorpseList)
        {
          if ((UnityEngine.Object) corpse != (UnityEngine.Object) null && !corpse.Disposed)
          {
            if (this.IDsCounted < 99)
            {
              this.IDsToIgnore[this.IDsCounted] = corpse.StudentID;
              ++this.IDsCounted;
            }
            if (StudentGlobals.MemorialStudents < 9)
            {
              Debug.Log((object) "''MemorialStudents'' is being incremented upwards.");
              ++StudentGlobals.MemorialStudents;
              switch (StudentGlobals.MemorialStudents)
              {
                case 1:
                  StudentGlobals.MemorialStudent1 = corpse.Student.StudentID;
                  continue;
                case 2:
                  StudentGlobals.MemorialStudent2 = corpse.Student.StudentID;
                  continue;
                case 3:
                  StudentGlobals.MemorialStudent3 = corpse.Student.StudentID;
                  continue;
                case 4:
                  StudentGlobals.MemorialStudent4 = corpse.Student.StudentID;
                  continue;
                case 5:
                  StudentGlobals.MemorialStudent5 = corpse.Student.StudentID;
                  continue;
                case 6:
                  StudentGlobals.MemorialStudent6 = corpse.Student.StudentID;
                  continue;
                case 7:
                  StudentGlobals.MemorialStudent7 = corpse.Student.StudentID;
                  continue;
                case 8:
                  StudentGlobals.MemorialStudent8 = corpse.Student.StudentID;
                  continue;
                case 9:
                  StudentGlobals.MemorialStudent9 = corpse.Student.StudentID;
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
      if (this.LimbParent.childCount > 0)
      {
        Debug.Log((object) ("Today, there were " + this.LimbParent.childCount.ToString() + " body parts on school grounds."));
        foreach (Transform transform in this.LimbParent)
        {
          if ((UnityEngine.Object) transform.gameObject != (UnityEngine.Object) null && (UnityEngine.Object) transform.GetComponent<BodyPartScript>() != (UnityEngine.Object) null)
          {
            Debug.Log((object) ("This limb's name is " + transform.name + "."));
            int studentId = transform.GetComponent<BodyPartScript>().StudentID;
            Debug.Log((object) ("Limb belonged to Student # " + studentId.ToString() + "."));
            if (!((IEnumerable<int>) this.IDsToIgnore).Contains<int>(studentId))
            {
              ++PlayerGlobals.CorpsesDiscovered;
              SchoolGlobals.SchoolAtmosphere -= 0.1f;
              if (StudentGlobals.MemorialStudents < 9)
              {
                Debug.Log((object) "''MemorialStudents'' is being incremented upwards.");
                ++StudentGlobals.MemorialStudents;
                switch (StudentGlobals.MemorialStudents)
                {
                  case 1:
                    StudentGlobals.MemorialStudent1 = studentId;
                    break;
                  case 2:
                    StudentGlobals.MemorialStudent2 = studentId;
                    break;
                  case 3:
                    StudentGlobals.MemorialStudent3 = studentId;
                    break;
                  case 4:
                    StudentGlobals.MemorialStudent4 = studentId;
                    break;
                  case 5:
                    StudentGlobals.MemorialStudent5 = studentId;
                    break;
                  case 6:
                    StudentGlobals.MemorialStudent6 = studentId;
                    break;
                  case 7:
                    StudentGlobals.MemorialStudent7 = studentId;
                    break;
                  case 8:
                    StudentGlobals.MemorialStudent8 = studentId;
                    break;
                  case 9:
                    StudentGlobals.MemorialStudent9 = studentId;
                    break;
                }
              }
            }
            else
              Debug.Log((object) "Wait, we already acknowledged that student's corpse or counted a limb from that student! Ignore it.");
            if (this.IDsCounted < 99)
            {
              this.IDsToIgnore[this.IDsCounted] = studentId;
              ++this.IDsCounted;
            }
          }
        }
      }
    }
    SchoolGlobals.SchoolAtmosphere = Mathf.Clamp01(SchoolGlobals.SchoolAtmosphere);
    for (int studentID = 1; studentID < this.StudentManager.StudentsTotal; ++studentID)
    {
      StudentScript student = this.StudentManager.Students[studentID];
      if ((UnityEngine.Object) student != (UnityEngine.Object) null && student.Grudge && student.Persona != PersonaType.Evil)
      {
        StudentGlobals.SetStudentGrudge(studentID, true);
        if (student.OriginalPersona == PersonaType.Sleuth && !StudentGlobals.GetStudentDying(studentID))
        {
          StudentGlobals.SetStudentGrudge(56, true);
          StudentGlobals.SetStudentGrudge(57, true);
          StudentGlobals.SetStudentGrudge(58, true);
          StudentGlobals.SetStudentGrudge(59, true);
          StudentGlobals.SetStudentGrudge(60, true);
        }
        if (!this.StudentManager.Eighties && (student.StudentID == 2 || student.StudentID == 3))
        {
          StudentGlobals.SetStudentGrudge(2, true);
          StudentGlobals.SetStudentGrudge(3, true);
        }
      }
    }
  }

  public void BeginFadingOut()
  {
    Debug.Log((object) "PoliceScript's BeginFadingOut() has been called.");
    this.DayOver = true;
    this.StudentManager.StopMoving();
    this.Darkness.enabled = true;
    if (this.Yandere.Laughing)
      this.Yandere.StopLaughing();
    this.Clock.StopTime = true;
    this.FadeOut = true;
    if (this.EndOfDay.gameObject.activeInHierarchy)
      return;
    Time.timeScale = 1f;
  }

  public void UpdateCorpses()
  {
    foreach (RagdollScript corpse in this.CorpseList)
    {
      if ((UnityEngine.Object) corpse != (UnityEngine.Object) null)
      {
        corpse.Prompt.HideButton[3] = true;
        if (this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus > 0 && !corpse.Tranquil)
          corpse.Prompt.HideButton[3] = false;
      }
    }
  }
}
