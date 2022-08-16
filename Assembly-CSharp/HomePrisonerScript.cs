// Decompiled with JetBrains decompiler
// Type: HomePrisonerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePrisonerScript : MonoBehaviour
{
  public HomePrisonerChanScript EightiesPrisoner;
  public PrisonerManagerScript PrisonerManager;
  public InputManagerScript InputManager;
  public HomePrisonerChanScript Prisoner;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public HomeWindowScript HomeWindow;
  public HomeDarknessScript Darkness;
  public UILabel[] OptionLabels;
  public string[] Descriptions;
  public string[] Notes;
  public string[] Hours;
  public int[] SanityNumbers;
  public Transform TortureDestination;
  public Transform TortureTarget;
  public GameObject NowLoading;
  public Transform Highlight;
  public AudioSource Jukebox;
  public UILabel SanityLabel;
  public UILabel DescLabel;
  public UILabel Subtitle;
  public bool PlayedAudio;
  public bool ZoomIn;
  public float Timer;
  public int Sanity = 100;
  public int ID = 1;
  public AudioClip FirstTorture;
  public AudioClip Under50Torture;
  public AudioClip Over50Torture;
  public AudioClip TortureHit;
  public string[] FullSanityBanterText;
  public string[] HighSanityBanterText;
  public string[] LowSanityBanterText;
  public string[] NoSanityBanterText;
  public string[] BanterText;
  public AudioClip[] FullSanityBanter;
  public AudioClip[] HighSanityBanter;
  public AudioClip[] LowSanityBanter;
  public AudioClip[] NoSanityBanter;
  public AudioClip[] Banter;
  public float BanterTimer;
  public bool Initialized;
  public bool Bantering;
  public int BanterID;
  public string[] AnimName;
  public int AnimID;

  public void Start()
  {
    if (this.PrisonerManager.StudentID > 0)
      this.Sanity = StudentGlobals.GetStudentSanity(this.PrisonerManager.StudentID);
    this.SanityLabel.text = "Sanity: " + this.Sanity.ToString() + "%";
    this.Prisoner.Sanity = (float) this.Sanity;
    this.Subtitle.text = string.Empty;
    for (int index = 1; index < this.Descriptions.Length - 1; ++index)
      this.Descriptions[index] = "If you torture your prisoner for " + this.Hours[index] + ", you will reduce her sanity by " + (this.SanityNumbers[index] + ClassGlobals.PsychologyGrade * 10).ToString() + "%, and " + this.Notes[index];
    if ((double) this.Sanity == 100.0)
    {
      this.BanterText = this.FullSanityBanterText;
      this.Banter = this.FullSanityBanter;
    }
    else if ((double) this.Sanity >= 50.0)
    {
      this.BanterText = this.HighSanityBanterText;
      this.Banter = this.HighSanityBanter;
    }
    else if ((double) this.Sanity == 0.0)
    {
      this.BanterText = this.NoSanityBanterText;
      this.Banter = this.NoSanityBanter;
    }
    else
    {
      this.BanterText = this.LowSanityBanterText;
      this.Banter = this.LowSanityBanter;
    }
    if ((double) this.Sanity < 100.0)
      this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapIdle_02");
    this.OptionLabels[1].alpha = 1f;
    this.OptionLabels[2].alpha = 1f;
    this.OptionLabels[3].alpha = 1f;
    this.OptionLabels[4].alpha = 1f;
    this.OptionLabels[5].alpha = 1f;
    if (!HomeGlobals.Night)
    {
      UILabel optionLabel1 = this.OptionLabels[2];
      optionLabel1.color = new Color(optionLabel1.color.r, optionLabel1.color.g, optionLabel1.color.b, 0.5f);
      if (HomeGlobals.LateForSchool)
      {
        UILabel optionLabel2 = this.OptionLabels[1];
        optionLabel2.color = new Color(optionLabel2.color.r, optionLabel2.color.g, optionLabel2.color.b, 0.5f);
      }
      if (DateGlobals.Weekday == DayOfWeek.Friday)
      {
        UILabel optionLabel3 = this.OptionLabels[3];
        optionLabel3.color = new Color(optionLabel3.color.r, optionLabel3.color.g, optionLabel3.color.b, 0.5f);
        UILabel optionLabel4 = this.OptionLabels[4];
        optionLabel4.color = new Color(optionLabel4.color.r, optionLabel4.color.g, optionLabel4.color.b, 0.5f);
      }
    }
    else
    {
      UILabel optionLabel5 = this.OptionLabels[1];
      optionLabel5.color = new Color(optionLabel5.color.r, optionLabel5.color.g, optionLabel5.color.b, 0.5f);
      UILabel optionLabel6 = this.OptionLabels[3];
      optionLabel6.color = new Color(optionLabel6.color.r, optionLabel6.color.g, optionLabel6.color.b, 0.5f);
      UILabel optionLabel7 = this.OptionLabels[4];
      optionLabel7.color = new Color(optionLabel7.color.r, optionLabel7.color.g, optionLabel7.color.b, 0.5f);
    }
    if (this.Sanity > 0)
    {
      this.OptionLabels[5].text = "?????";
      UILabel optionLabel = this.OptionLabels[5];
      optionLabel.color = new Color(optionLabel.color.r, optionLabel.color.g, optionLabel.color.b, 0.5f);
    }
    else
    {
      this.OptionLabels[5].text = "Bring to School";
      UILabel optionLabel8 = this.OptionLabels[1];
      optionLabel8.color = new Color(optionLabel8.color.r, optionLabel8.color.g, optionLabel8.color.b, 0.5f);
      UILabel optionLabel9 = this.OptionLabels[2];
      optionLabel9.color = new Color(optionLabel9.color.r, optionLabel9.color.g, optionLabel9.color.b, 0.5f);
      UILabel optionLabel10 = this.OptionLabels[3];
      optionLabel10.color = new Color(optionLabel10.color.r, optionLabel10.color.g, optionLabel10.color.b, 0.5f);
      UILabel optionLabel11 = this.OptionLabels[4];
      optionLabel11.color = new Color(optionLabel11.color.r, optionLabel11.color.g, optionLabel11.color.b, 0.5f);
      UILabel optionLabel12 = this.OptionLabels[5];
      optionLabel12.color = new Color(optionLabel12.color.r, optionLabel12.color.g, optionLabel12.color.b, 1f);
      if (DateGlobals.Weekday == DayOfWeek.Sunday)
        this.OptionLabels[5].alpha = 0.5f;
      if (HomeGlobals.Night)
        optionLabel12.color = new Color(optionLabel12.color.r, optionLabel12.color.g, optionLabel12.color.b, 0.5f);
    }
    if (DateGlobals.Weekday == DayOfWeek.Sunday)
    {
      UILabel optionLabel = this.OptionLabels[1];
      optionLabel.color = new Color(optionLabel.color.r, optionLabel.color.g, optionLabel.color.b, 0.5f);
    }
    if (!this.Initialized)
    {
      this.Initialized = true;
      this.UpdateDesc();
    }
    if (StudentGlobals.Prisoners == 0)
      this.enabled = false;
    this.Prisoner = this.EightiesPrisoner;
  }

  private void Update()
  {
    AudioSource component = this.GetComponent<AudioSource>();
    if ((double) Vector3.Distance(this.HomeYandere.transform.position, this.Prisoner.transform.position) < 2.0 && this.HomeYandere.CanMove)
    {
      this.BanterTimer += Time.deltaTime;
      if ((double) this.BanterTimer > 5.0 && !this.Bantering)
      {
        this.Bantering = true;
        if (this.BanterID < this.Banter.Length - 1)
        {
          ++this.BanterID;
          this.Subtitle.text = this.BanterText[this.BanterID];
          component.clip = this.Banter[this.BanterID];
          component.Play();
        }
      }
    }
    if (this.Bantering && !component.isPlaying)
    {
      this.Subtitle.text = string.Empty;
      this.Bantering = false;
      this.BanterTimer = 0.0f;
    }
    if (this.HomeYandere.CanMove || !((UnityEngine.Object) this.HomeCamera.Destination == (UnityEngine.Object) this.HomeCamera.Destinations[10]) && !((UnityEngine.Object) this.HomeCamera.Destination == (UnityEngine.Object) this.TortureDestination))
      return;
    if (this.InputManager.TappedDown)
    {
      ++this.ID;
      if (this.ID > 5)
        this.ID = 1;
      this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (465.0 - (double) this.ID * 40.0), this.Highlight.localPosition.z);
      this.UpdateDesc();
    }
    if (this.InputManager.TappedUp)
    {
      --this.ID;
      if (this.ID < 1)
        this.ID = 5;
      this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (465.0 - (double) this.ID * 40.0), this.Highlight.localPosition.z);
      this.UpdateDesc();
    }
    if (Input.GetKeyDown(KeyCode.Z))
    {
      this.Sanity = 0;
      StudentGlobals.SetStudentSanity(this.PrisonerManager.StudentID, this.Sanity);
      this.SanityLabel.text = "Sanity: " + this.Sanity.ToString("f0") + "%";
      this.Prisoner.UpdateSanity();
    }
    if (!this.ZoomIn)
    {
      if (Input.GetButtonDown("A") && (double) this.OptionLabels[this.ID].color.a == 1.0)
      {
        if ((double) this.Sanity > 0.0)
        {
          if ((double) this.Sanity == 100.0)
            this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapTorture_01");
          else if ((double) this.Sanity >= 50.0)
          {
            this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapTorture_02");
          }
          else
          {
            this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapSurrender_00");
            this.TortureDestination.localPosition = new Vector3(this.TortureDestination.localPosition.x, 0.0f, 1f);
            this.TortureTarget.localPosition = new Vector3(this.TortureTarget.localPosition.x, 1.1f, this.TortureTarget.localPosition.z);
          }
          this.HomeCamera.Destination = this.TortureDestination;
          this.HomeCamera.Target = this.TortureTarget;
          this.HomeCamera.Torturing = true;
          this.Prisoner.Tortured = true;
          this.Prisoner.RightEyeRotOrigin.x = -6f;
          this.Prisoner.LeftEyeRotOrigin.x = 6f;
          this.ZoomIn = true;
          if (this.PrisonerManager.ChosenPrisoner > 1)
            this.Darkness.Sprite.alpha = 1f;
          this.HomeCamera.UpdateDOF(0.6f);
        }
        else
          this.Darkness.FadeOut = true;
        this.HomeWindow.Show = false;
        this.HomeCamera.PromptBar.ClearButtons();
        this.HomeCamera.PromptBar.Show = false;
        this.Jukebox.volume -= 0.5f;
      }
      if (!Input.GetButtonDown("B"))
        return;
      this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
      this.HomeCamera.Target = this.HomeCamera.Targets[0];
      this.HomeCamera.PromptBar.ClearButtons();
      this.HomeCamera.PromptBar.Show = false;
      this.HomeYandere.CanMove = true;
      this.HomeYandere.gameObject.SetActive(true);
      this.HomeWindow.Show = false;
    }
    else
    {
      this.TortureDestination.Translate(Vector3.forward * (Time.deltaTime * 0.02f));
      this.Jukebox.volume -= Time.deltaTime * 0.05f;
      this.Timer += Time.deltaTime;
      if ((double) this.Sanity >= 50.0)
      {
        this.TortureDestination.localPosition = new Vector3(this.TortureDestination.localPosition.x, this.TortureDestination.localPosition.y + Time.deltaTime * 0.05f, this.TortureDestination.localPosition.z);
        if ((double) this.Sanity == 100.0)
        {
          if ((double) this.Timer > 2.0 && !this.PlayedAudio)
          {
            component.clip = this.FirstTorture;
            this.PlayedAudio = true;
            component.Play();
          }
        }
        else if ((double) this.Timer > 1.5 && !this.PlayedAudio)
        {
          component.clip = this.Over50Torture;
          this.PlayedAudio = true;
          component.Play();
        }
      }
      else if ((double) this.Timer > 5.0 && !this.PlayedAudio)
      {
        component.clip = this.Under50Torture;
        this.PlayedAudio = true;
        component.Play();
      }
      if ((double) this.Timer > 10.0)
      {
        if ((double) this.Darkness.Sprite.color.a != 1.0)
        {
          this.Darkness.enabled = false;
          this.Darkness.Sprite.color = new Color(this.Darkness.Sprite.color.r, this.Darkness.Sprite.color.g, this.Darkness.Sprite.color.b, 1f);
          component.clip = this.TortureHit;
          component.Play();
        }
      }
      else if (this.PrisonerManager.ChosenPrisoner > 1)
        this.Darkness.Sprite.alpha = 0.99999f;
      if ((double) this.Timer <= 15.0)
        return;
      Debug.Log((object) ("StudentGlobals.GetStudentSanity was: " + StudentGlobals.GetStudentSanity(this.PrisonerManager.StudentID).ToString()));
      if (this.ID == 1)
      {
        Time.timeScale = 1f;
        this.NowLoading.SetActive(true);
        HomeGlobals.LateForSchool = true;
        if (DateGlobals.Weekday == DayOfWeek.Saturday)
        {
          DateGlobals.PassDays = 1;
          SceneManager.LoadScene("CalendarScene");
        }
        else
          SceneManager.LoadScene("LoadingScene");
        StudentGlobals.SetStudentSanity(this.PrisonerManager.StudentID, this.Sanity - 2 - ClassGlobals.PsychologyGrade * 10);
      }
      else if (this.ID == 2)
      {
        if (DateGlobals.PassDays < 1)
          DateGlobals.PassDays = 1;
        if (DateGlobals.Weekday == DayOfWeek.Sunday)
          DateGlobals.ForceSkip = true;
        SceneManager.LoadScene("CalendarScene");
        StudentGlobals.SetStudentSanity(this.PrisonerManager.StudentID, this.Sanity - 8 - ClassGlobals.PsychologyGrade * 10);
      }
      else if (this.ID == 3)
      {
        HomeGlobals.Night = true;
        SceneManager.LoadScene("HomeScene");
        StudentGlobals.SetStudentSanity(this.PrisonerManager.StudentID, this.Sanity - 24 - ClassGlobals.PsychologyGrade * 10);
        PlayerGlobals.Reputation -= 20f;
      }
      else if (this.ID == 4)
      {
        if (DateGlobals.PassDays < 1)
          DateGlobals.PassDays = 1;
        if (DateGlobals.Weekday == DayOfWeek.Sunday)
          DateGlobals.ForceSkip = true;
        else
          PlayerGlobals.Reputation -= 20f;
        SceneManager.LoadScene("CalendarScene");
        StudentGlobals.SetStudentSanity(this.PrisonerManager.StudentID, this.Sanity - 36 - ClassGlobals.PsychologyGrade * 10);
      }
      if ((double) StudentGlobals.GetStudentSanity(this.PrisonerManager.StudentID) < 0.0)
        StudentGlobals.SetStudentSanity(this.PrisonerManager.StudentID, 0);
      Debug.Log((object) ("And now, StudentGlobals.GetStudentSanity is: " + StudentGlobals.GetStudentSanity(this.PrisonerManager.StudentID).ToString()));
    }
  }

  public void UpdateDesc()
  {
    this.Start();
    this.HomeCamera.PromptBar.Label[0].text = "Accept";
    this.DescLabel.text = this.Descriptions[this.ID];
    if (!HomeGlobals.Night)
    {
      if (HomeGlobals.LateForSchool && this.ID == 1)
      {
        this.DescLabel.text = "This option is unavailable if you are late for school.";
        this.HomeCamera.PromptBar.Label[0].text = string.Empty;
      }
      if (this.ID == 2)
      {
        this.DescLabel.text = "This option is unavailable in the daytime.";
        this.HomeCamera.PromptBar.Label[0].text = string.Empty;
      }
      if (DateGlobals.Weekday == DayOfWeek.Friday && (this.ID == 3 || this.ID == 4))
      {
        this.DescLabel.text = "This option is unavailable on Friday.";
        this.HomeCamera.PromptBar.Label[0].text = string.Empty;
      }
    }
    else if (this.ID != 2)
    {
      this.DescLabel.text = "This option is unavailable at nighttime.";
      this.HomeCamera.PromptBar.Label[0].text = string.Empty;
    }
    if (this.ID == 5)
    {
      if ((double) this.Sanity > 0.0)
        this.DescLabel.text = "This option is unavailable until your prisoner's Sanity has reached zero.";
      if (HomeGlobals.Night)
      {
        this.DescLabel.text = "This option is unavailable at nighttime.";
        this.HomeCamera.PromptBar.Label[0].text = string.Empty;
      }
    }
    this.HomeCamera.PromptBar.UpdateButtons();
  }
}
