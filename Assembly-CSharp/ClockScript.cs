// Decompiled with JetBrains decompiler
// Type: ClockScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ClockScript : MonoBehaviour
{
  private string MinuteNumber = string.Empty;
  private string HourNumber = string.Empty;
  public Collider MeetingRoomTrespassZone;
  public Collider[] TrespassZones;
  public PostProcessingProfile Profile;
  public StudentManagerScript StudentManager;
  public CameraEffectsScript CameraEffects;
  public LoveManagerScript LoveManager;
  public YandereScript Yandere;
  public PoliceScript Police;
  public ClockScript Clock;
  public MotionBlur Blur;
  public Vector3 OriginalPosition;
  public Transform PromptParent;
  public Transform MinuteHand;
  public Transform HourHand;
  public Transform Sun;
  public GameObject SunFlare;
  public UILabel PeriodLabel;
  public UILabel TimeLabel;
  public UILabel DayLabel;
  public Light MainLight;
  public float HalfwayTime;
  public float PresentTime;
  public float TargetTime;
  public float StartTime;
  public float HourTime;
  public float AmbientLightDim;
  public float BloomFadeSpeed = 10f;
  public float TimeSkipSpeed = 1f;
  public float BathroomDim;
  public float CameraTimer;
  public float DayProgress;
  public float LastMinute;
  public float BloomWait;
  public float StartHour;
  public float TimeSpeed;
  public float Minute;
  public float Timer;
  public float Hour;
  public PhaseOfDay Phase;
  public int Weekday;
  public int Period;
  public int Day = 1;
  public int ID;
  public string TimeText = string.Empty;
  public bool IgnorePhotographyClub;
  public bool BloomDisabled;
  public bool LateStudent;
  public bool UpdateBloom;
  public bool MissionMode;
  public bool ReduceKnee;
  public bool StopTime;
  public bool TimeSkip;
  public bool FadeIn;
  public bool Horror;
  public bool Lerp;
  public AudioSource SchoolBell;
  public Color SkyboxColor;
  public float BloomIntensity = 11f;
  public float BloomRadius = 7f;
  public float BloomKnee = 1f;
  public UISprite BathroomDimSprite;
  public Light[] BathroomLight;
  public Collider[] Bathroom;

  private void Start()
  {
    if (!this.MissionMode)
    {
      this.Profile.bloom.enabled = true;
      this.BloomDisabled = OptionGlobals.DisableBloom;
      OptionGlobals.DisableBloom = false;
    }
    RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f);
    this.PeriodLabel.text = "BEFORE CLASS";
    this.PresentTime = this.StartHour * 60f;
    if (PlayerPrefs.GetInt("LoadingSave") == 1)
    {
      int profile = GameGlobals.Profile;
      int num = PlayerPrefs.GetInt("SaveSlot");
      this.Weekday = PlayerPrefs.GetInt("Profile_" + profile.ToString() + "_Slot_" + num.ToString() + "_Weekday");
      if (this.Weekday == 1)
        DateGlobals.Weekday = DayOfWeek.Monday;
      else if (this.Weekday == 2)
        DateGlobals.Weekday = DayOfWeek.Tuesday;
      else if (this.Weekday == 3)
        DateGlobals.Weekday = DayOfWeek.Wednesday;
      else if (this.Weekday == 4)
        DateGlobals.Weekday = DayOfWeek.Thursday;
      else if (this.Weekday == 5)
        DateGlobals.Weekday = DayOfWeek.Friday;
    }
    else
    {
      switch (DateGlobals.Weekday)
      {
        case DayOfWeek.Monday:
          this.Weekday = 1;
          break;
        case DayOfWeek.Tuesday:
          this.Weekday = 2;
          break;
        case DayOfWeek.Wednesday:
          this.Weekday = 3;
          break;
        case DayOfWeek.Thursday:
          this.Weekday = 4;
          break;
        case DayOfWeek.Friday:
          this.Weekday = 5;
          break;
      }
    }
    this.Day = this.Weekday + (DateGlobals.Week - 1) * 5;
    if (DateGlobals.Weekday == DayOfWeek.Sunday)
      DateGlobals.Weekday = DayOfWeek.Monday;
    if (!SchoolGlobals.SchoolAtmosphereSet)
    {
      SchoolGlobals.SchoolAtmosphereSet = true;
      SchoolGlobals.PreviousSchoolAtmosphere = 1f;
      SchoolGlobals.SchoolAtmosphere = 1f;
    }
    if ((double) SchoolGlobals.SchoolAtmosphere < 0.5)
    {
      this.CameraEffects.UpdateBloom(1f);
      this.CameraEffects.UpdateBloomKnee(0.5f);
      this.CameraEffects.UpdateBloomRadius(4f);
      this.Police.Darkness.enabled = true;
      this.Police.Darkness.color = new Color(this.Police.Darkness.color.r, this.Police.Darkness.color.g, this.Police.Darkness.color.b, 1f);
      this.FadeIn = true;
    }
    else
    {
      this.CameraEffects.UpdateBloom(11f);
      this.CameraEffects.UpdateBloomKnee(1f);
      this.CameraEffects.UpdateBloomRadius(7f);
      this.BloomKnee = 1f;
      this.BloomRadius = 7f;
      this.BloomIntensity = 11f;
      this.UpdateBloom = true;
    }
    this.DayLabel.text = this.GetWeekdayText(DateGlobals.Weekday);
    this.MainLight.color = new Color(1f, 1f, 1f, 1f);
    RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
    RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
    if (ClubGlobals.GetClubClosed(ClubType.Photography) || StudentGlobals.GetStudentGrudge(56) || StudentGlobals.GetStudentGrudge(57) || StudentGlobals.GetStudentGrudge(58) || StudentGlobals.GetStudentGrudge(59) || StudentGlobals.GetStudentGrudge(60))
      this.IgnorePhotographyClub = true;
    this.MissionMode = MissionModeGlobals.MissionMode;
    this.HourTime = this.PresentTime / 60f;
    this.Hour = Mathf.Floor(this.PresentTime / 60f);
    this.Minute = Mathf.Floor((float) (((double) this.PresentTime / 60.0 - (double) this.Hour) * 60.0));
    this.UpdateClock();
    if (GameGlobals.Eighties)
      this.BecomeEighties();
    if (!this.StudentManager.RecordingVideo)
      return;
    this.CameraEffects.UpdateBloom(1f);
    this.CameraEffects.UpdateBloomRadius(4f);
    this.CameraEffects.UpdateBloomKnee(0.75f);
  }

  public void Update()
  {
    if (this.FadeIn && (double) Time.deltaTime < 1.0)
    {
      this.Police.Darkness.color = new Color(this.Police.Darkness.color.r, this.Police.Darkness.color.g, this.Police.Darkness.color.b, Mathf.MoveTowards(this.Police.Darkness.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Police.Darkness.color.a == 0.0)
      {
        this.Police.Darkness.enabled = false;
        this.FadeIn = false;
      }
    }
    if (!this.MissionMode && (double) this.CameraTimer < 1.0)
    {
      this.CameraTimer += Time.deltaTime;
      if ((double) this.CameraTimer > 1.0 && !this.StudentManager.MemorialScene.enabled)
      {
        if (this.BloomDisabled)
        {
          OptionGlobals.DisableBloom = true;
          this.Profile.bloom.enabled = false;
        }
        this.Yandere.RPGCamera.mouseX = 0.0f;
        this.Yandere.RPGCamera.enabled = true;
        this.Yandere.CanMove = true;
        this.GivePlayerBroughtWeapon();
      }
    }
    if ((double) this.PresentTime < 1080.0)
    {
      if (this.UpdateBloom)
      {
        if ((double) this.BloomWait == 0.0)
        {
          if (!this.ReduceKnee)
          {
            if (this.Lerp)
            {
              this.BloomIntensity = Mathf.Lerp(this.BloomIntensity, 1f, Time.deltaTime);
              this.BloomRadius = Mathf.Lerp(this.BloomRadius, 4f, Time.deltaTime);
              if ((double) this.BloomIntensity < 1.10000002384186)
              {
                this.BloomIntensity = 1f;
                this.BloomRadius = 4f;
              }
            }
            else
            {
              this.BloomIntensity = Mathf.MoveTowards(this.BloomIntensity, 1f, Time.deltaTime * this.BloomFadeSpeed);
              this.BloomRadius = Mathf.MoveTowards(this.BloomRadius, 4f, Time.deltaTime * this.BloomFadeSpeed);
            }
            this.CameraEffects.UpdateBloom(this.BloomIntensity);
            this.CameraEffects.UpdateBloomRadius(this.BloomRadius);
            if ((double) this.BloomIntensity == 1.0 && (double) this.BloomRadius == 4.0)
              this.ReduceKnee = true;
          }
          else
          {
            this.BloomKnee = Mathf.MoveTowards(this.BloomKnee, 0.75f, Time.deltaTime * (this.BloomFadeSpeed * 0.1f));
            this.CameraEffects.UpdateBloomKnee(this.BloomKnee);
            if ((double) this.BloomKnee == 0.75)
              this.UpdateBloom = false;
          }
        }
        else
          this.BloomWait = Mathf.MoveTowards(this.BloomWait, 0.0f, Time.deltaTime);
      }
    }
    else if (this.LoveManager.WaitingToConfess)
    {
      if (!this.StopTime)
        this.LoveManager.BeginConfession();
    }
    else if (!this.Police.FadeOut && !this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.DelinquentFighting && !this.Yandere.Pickpocketing && !this.Yandere.Noticed)
    {
      Debug.Log((object) "Ending the day because it's 6:00 PM.");
      if (!this.StudentManager.Portal.GetComponent<PortalScript>().EndedFinalEvents)
        this.StudentManager.Portal.GetComponent<PortalScript>().EndFinalEvents();
      this.StudentManager.Reputation.UpdateRep();
      this.Police.DayOver = true;
      this.Yandere.StudentManager.StopMoving();
      this.Police.Darkness.enabled = true;
      this.Police.FadeOut = true;
      this.StopTime = true;
    }
    if (!this.StopTime)
    {
      if (this.Period == 3)
        this.PresentTime += (float) ((double) Time.deltaTime * 0.0166666675359011 * (double) this.TimeSpeed * 0.5);
      else
        this.PresentTime += Time.deltaTime * 0.01666667f * this.TimeSpeed;
    }
    this.HourTime = this.PresentTime / 60f;
    this.Hour = Mathf.Floor(this.PresentTime / 60f);
    this.Minute = Mathf.Floor((float) (((double) this.PresentTime / 60.0 - (double) this.Hour) * 60.0));
    if ((double) this.Minute != (double) this.LastMinute)
      this.UpdateClock();
    this.MinuteHand.localEulerAngles = new Vector3(this.MinuteHand.localEulerAngles.x, this.MinuteHand.localEulerAngles.y, this.Minute * 6f);
    this.HourHand.localEulerAngles = new Vector3(this.HourHand.localEulerAngles.x, this.HourHand.localEulerAngles.y, this.Hour * 30f);
    if (this.LateStudent && (double) this.HourTime > 7.90000009536743)
      this.ActivateLateStudent();
    if ((double) this.HourTime < 8.5)
    {
      if (this.Period < 1)
      {
        this.PeriodLabel.text = "BEFORE CLASS";
        this.DeactivateTrespassZones();
        ++this.Period;
      }
    }
    else if ((double) this.HourTime < 13.0)
    {
      if (this.Period < 2)
      {
        this.PeriodLabel.text = "CLASS TIME";
        this.ActivateTrespassZones();
        ++this.Period;
      }
    }
    else if ((double) this.HourTime < 13.5)
    {
      if (this.Period < 3)
      {
        this.PeriodLabel.text = "LUNCH TIME";
        this.StudentManager.DramaPhase = 0;
        this.StudentManager.UpdateDrama();
        this.DeactivateTrespassZones();
        ++this.Period;
        this.StudentManager.WednesdayGiftBox.SetActive(false);
        this.StudentManager.FridayTestNotes.SetActive(false);
        this.StudentManager.MondayBento.SetActive(false);
        this.StudentManager.RivalBookBag.NoBento = true;
        this.StudentManager.Unstop();
        if (!GameGlobals.Eighties && DateGlobals.Week == 1 && !this.StudentManager.MissionMode)
        {
          Debug.Log((object) ("Apparently, GameGlobals.Eighties is: " + GameGlobals.Eighties.ToString()));
          this.StudentManager.UpdateLunchtimeStudents();
        }
        this.UpdateClock();
      }
    }
    else if ((double) this.HourTime < 15.5)
    {
      if (this.Period < 4)
      {
        this.PeriodLabel.text = "CLASS TIME";
        this.ActivateTrespassZones();
        ++this.Period;
      }
    }
    else if ((double) this.HourTime < 16.0)
    {
      if (this.Period < 5)
      {
        if (this.StudentManager.Bully && this.StudentManager.Bullies > 0)
          this.StudentManager.UpdateGraffiti();
        this.PeriodLabel.text = "CLEANING TIME";
        this.DeactivateTrespassZones();
        if (this.Weekday == 5)
          this.MeetingRoomTrespassZone.enabled = true;
        this.StudentManager.Unstop();
        ++this.Period;
        this.UpdateClock();
      }
    }
    else if (this.Period < 6)
    {
      this.PeriodLabel.text = "AFTER SCHOOL";
      this.StudentManager.DramaPhase = 0;
      this.StudentManager.UpdateDrama();
      ++this.Period;
    }
    if (!this.IgnorePhotographyClub && (double) this.HourTime > 16.75 && this.StudentManager.SleuthPhase < 4)
    {
      this.StudentManager.SleuthPhase = 3;
      this.StudentManager.UpdateSleuths();
    }
    this.Sun.eulerAngles = new Vector3(this.Sun.eulerAngles.x, this.Sun.eulerAngles.y, (float) (90.0 * ((double) this.PresentTime - 420.0) / 660.0 - 45.0));
    if (!this.Horror)
    {
      Bounds bounds = this.StudentManager.WestBathroomArea.bounds;
      if (!bounds.Contains(this.Yandere.transform.position))
      {
        bounds = this.StudentManager.EastBathroomArea.bounds;
        if (!bounds.Contains(this.Yandere.transform.position))
        {
          this.BathroomDim = 0.0f;
          goto label_71;
        }
      }
      for (int index = 1; index < this.Bathroom.Length; ++index)
      {
        bounds = this.Bathroom[index].bounds;
        if (bounds.Contains(this.Yandere.transform.position))
          this.BathroomDim = this.BathroomLight[index].enabled ? 0.0f : 0.5f;
      }
label_71:
      if ((double) this.BathroomDimSprite.alpha != (double) this.BathroomDim)
        this.BathroomDimSprite.alpha = Mathf.MoveTowards(this.BathroomDimSprite.alpha, this.BathroomDim, Time.deltaTime * 10f);
      this.AmbientLightDim = 0.75f;
      if ((double) this.PresentTime > 930.0)
      {
        this.DayProgress = (float) (((double) this.PresentTime - 930.0) / 150.0);
        this.MainLight.color = new Color((float) (1.0 - 0.149019598960876 * (double) this.DayProgress), (float) (1.0 - 0.403921544551849 * (double) this.DayProgress), (float) (1.0 - 0.709803938865662 * (double) this.DayProgress));
        RenderSettings.ambientLight = new Color((float) (1.0 - 0.149019598960876 * (double) this.DayProgress - (1.0 - (double) this.AmbientLightDim) * (1.0 - (double) this.DayProgress)), (float) (1.0 - 0.403921544551849 * (double) this.DayProgress - (1.0 - (double) this.AmbientLightDim) * (1.0 - (double) this.DayProgress)), (float) (1.0 - 0.709803938865662 * (double) this.DayProgress - (1.0 - (double) this.AmbientLightDim) * (1.0 - (double) this.DayProgress)));
        this.SkyboxColor = new Color((float) (1.0 - 0.149019598960876 * (double) this.DayProgress - 0.5 * (1.0 - (double) this.DayProgress)), (float) (1.0 - 0.403921544551849 * (double) this.DayProgress - 0.5 * (1.0 - (double) this.DayProgress)), (float) (1.0 - 0.709803938865662 * (double) this.DayProgress - 0.5 * (1.0 - (double) this.DayProgress)));
        RenderSettings.skybox.SetColor("_Tint", new Color(this.SkyboxColor.r, this.SkyboxColor.g, this.SkyboxColor.b));
      }
      else
        RenderSettings.ambientLight = new Color(this.AmbientLightDim, this.AmbientLightDim, this.AmbientLightDim);
    }
    if (!this.TimeSkip)
      return;
    if ((double) this.HalfwayTime == 0.0)
    {
      this.HalfwayTime = this.PresentTime + (float) (((double) this.TargetTime - (double) this.PresentTime) * 0.5);
      this.OriginalPosition = this.Yandere.transform.position;
      if (!this.StudentManager.Eighties)
      {
        this.Yandere.Phone.transform.localPosition = new Vector3(0.02f, -0.005f, 0.03f);
        this.Yandere.Phone.transform.localEulerAngles = new Vector3(0.0f, -165f, -165f);
      }
      else
      {
        this.Yandere.Phone.transform.localPosition = new Vector3(0.02f, -0.0066666f, 0.03f);
        this.Yandere.Phone.transform.localEulerAngles = new Vector3(-75f, 120f, 75f);
      }
      this.Yandere.TimeSkipping = true;
      this.Yandere.CanMove = false;
      if (this.Yandere.Armed)
        this.Yandere.Unequip();
    }
    this.TimeSkipSpeed += Time.deltaTime;
    if ((double) Time.timeScale < 10.0)
      Time.timeScale = Mathf.MoveTowards(Time.timeScale, 10f, this.TimeSkipSpeed * Time.unscaledDeltaTime);
    this.Yandere.CharacterAnimation["f02_timeSkip_00"].speed = 1f / Time.timeScale;
    if ((double) this.PresentTime > (double) this.TargetTime)
      this.EndTimeSkip();
    if ((double) this.Yandere.CameraEffects.Streaks.color.a <= 0.0 && (double) this.Yandere.CameraEffects.MurderStreaks.color.a <= 0.0 && !this.Yandere.NearSenpai && !Input.GetButtonDown("B"))
      return;
    this.EndTimeSkip();
  }

  public void EndTimeSkip()
  {
    if (GameGlobals.AlphabetMode)
      this.StopTime = true;
    this.Yandere.PauseScreen.PromptBar.ClearButtons();
    this.Yandere.PauseScreen.PromptBar.Show = false;
    this.PromptParent.localScale = new Vector3(1f, 1f, 1f);
    this.Yandere.transform.position = this.OriginalPosition;
    this.Yandere.Phone.SetActive(false);
    this.Yandere.TimeSkipping = false;
    Time.timeScale = 1f;
    this.TimeSkip = false;
    this.HalfwayTime = 0.0f;
    this.TimeSkipSpeed = 1f;
    if (this.Yandere.Noticed || this.Police.FadeOut)
      return;
    this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
    this.Yandere.CanMoveTimer = 0.5f;
  }

  public string GetWeekdayText(DayOfWeek weekday)
  {
    switch (weekday)
    {
      case DayOfWeek.Sunday:
        this.Weekday = 0;
        return "SUNDAY";
      case DayOfWeek.Monday:
        this.Weekday = 1;
        return "MONDAY";
      case DayOfWeek.Tuesday:
        this.Weekday = 2;
        return "TUESDAY";
      case DayOfWeek.Wednesday:
        this.Weekday = 3;
        return "WEDNESDAY";
      case DayOfWeek.Thursday:
        this.Weekday = 4;
        return "THURSDAY";
      case DayOfWeek.Friday:
        this.Weekday = 5;
        return "FRIDAY";
      default:
        this.Weekday = 6;
        return "SATURDAY";
    }
  }

  private void ActivateTrespassZones()
  {
    if (!this.SchoolBell.isPlaying || (double) this.SchoolBell.time > 1.0)
      this.SchoolBell.Play();
    foreach (Collider trespassZone in this.TrespassZones)
      trespassZone.enabled = true;
  }

  public void DeactivateTrespassZones()
  {
    this.Yandere.Trespassing = false;
    if ((!this.SchoolBell.isPlaying || (double) this.SchoolBell.time > 1.0) && !this.StudentManager.SpawnNobody)
      this.SchoolBell.Play();
    foreach (Collider trespassZone in this.TrespassZones)
    {
      if (!trespassZone.GetComponent<TrespassScript>().OffLimits)
        trespassZone.enabled = false;
    }
  }

  public void ActivateLateStudent()
  {
    if (!this.StudentManager.MissionMode && (UnityEngine.Object) this.StudentManager.Students[7] != (UnityEngine.Object) null)
    {
      this.StudentManager.Students[7].gameObject.SetActive(true);
      this.StudentManager.Students[7].Pathfinding.speed = 4f;
      this.StudentManager.Students[7].Spawned = true;
      this.StudentManager.Students[7].Hurry = true;
    }
    this.LateStudent = false;
  }

  public void NightLighting()
  {
    this.MainLight.color = new Color(0.25f, 0.25f, 0.5f);
    RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.5f);
    this.SkyboxColor = new Color(0.1f, 0.1f, 0.2f);
    RenderSettings.skybox.SetColor("_Tint", new Color(0.1f, 0.1f, 0.2f));
  }

  public void UpdateClock()
  {
    this.LastMinute = this.Minute;
    this.HourNumber = (double) this.Hour == 0.0 || (double) this.Hour == 12.0 ? "12" : ((double) this.Hour >= 12.0 ? (this.Hour - 12f).ToString("f0") : this.Hour.ToString("f0"));
    this.MinuteNumber = (double) this.Minute >= 10.0 ? this.Minute.ToString("f0") : "0" + this.Minute.ToString("f0");
    this.TimeText = this.HourNumber + ":" + this.MinuteNumber + ((double) this.Hour < 12.0 ? " AM" : " PM");
    this.TimeLabel.text = this.TimeText;
  }

  public void BecomeEighties()
  {
    this.StudentManager.EightiesifyLabel(this.TimeLabel);
    this.StudentManager.EightiesifyLabel(this.PeriodLabel);
    this.StudentManager.EightiesifyLabel(this.DayLabel);
    this.StudentManager.EightiesifyLabel(this.Yandere.Inventory.MoneyLabel);
    this.LateStudent = false;
  }

  public void GivePlayerBroughtWeapon()
  {
    int bringingItem = PlayerGlobals.BringingItem;
    if (bringingItem <= 0 || bringingItem >= this.Police.EndOfDay.WeaponManager.BroughtWeapons.Length)
      return;
    this.Police.EndOfDay.WeaponManager.BroughtWeapons[bringingItem].Prompt.Circle[3].fillAmount = 0.0f;
    this.Police.EndOfDay.WeaponManager.BroughtWeapons[bringingItem].UnequipImmediately = true;
  }
}
