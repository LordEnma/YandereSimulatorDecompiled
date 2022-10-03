// Decompiled with JetBrains decompiler
// Type: TutorialWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TutorialWindowScript : MonoBehaviour
{
  public YandereScript Yandere;
  public bool ShowDistractionMessage;
  public bool ShowClothingMessage;
  public bool ShowCouncilMessage;
  public bool ShowTeacherMessage;
  public bool ShowPersonaMessage;
  public bool ShowLockerMessage;
  public bool ShowPoliceMessage;
  public bool ShowSanityMessage;
  public bool ShowSenpaiMessage;
  public bool ShowVisionMessage;
  public bool ShowWeaponMessage;
  public bool ShowBloodMessage;
  public bool ShowClassMessage;
  public bool ShowMoneyMessage;
  public bool ShowPhotoMessage;
  public bool ShowClubMessage;
  public bool ShowInfoMessage;
  public bool ShowPoolMessage;
  public bool ShowRepMessage;
  public bool IgnoreDistraction;
  public bool IgnoreClothing;
  public bool IgnoreCouncil;
  public bool IgnoreTeacher;
  public bool IgnorePersona;
  public bool IgnoreLocker;
  public bool IgnorePolice;
  public bool IgnoreSanity;
  public bool IgnoreSenpai;
  public bool IgnoreVision;
  public bool IgnoreWeapon;
  public bool IgnoreBlood;
  public bool IgnoreClass;
  public bool IgnoreMoney;
  public bool IgnorePhoto;
  public bool IgnoreClub;
  public bool IgnoreInfo;
  public bool IgnorePool;
  public bool IgnoreRep;
  public bool Hide;
  public bool Show;
  public UILabel TutorialLabel;
  public UILabel ShadowLabel;
  public UILabel TitleLabel;
  public UITexture TutorialImage;
  public string DisabledShortString;
  public string DisabledString;
  public Texture DisabledTexture;
  public string ClothingShortString;
  public string ClothingString;
  public Texture ClothingTexture;
  public string CouncilShortString;
  public string CouncilString;
  public Texture CouncilTexture;
  public string DistractionShortString;
  public string DistractionString;
  public Texture DistractionTexture;
  public string TeacherShortString;
  public string TeacherString;
  public Texture TeacherTexture;
  public string PersonaShortString;
  public string PersonaString;
  public Texture PersonaTexture;
  public string LockerShortString;
  public string LockerString;
  public Texture LockerTexture;
  public string PoliceShortString;
  public string PoliceString;
  public Texture PoliceTexture;
  public string SanityShortString;
  public string SanityString;
  public Texture SanityTexture;
  public string SenpaiShortString;
  public string SenpaiString;
  public Texture SenpaiTexture;
  public string VisionShortString;
  public string VisionString;
  public Texture VisionTexture;
  public string WeaponShortString;
  public string WeaponString;
  public Texture WeaponTexture;
  public string BloodShortString;
  public string BloodString;
  public Texture BloodTexture;
  public string ClassShortString;
  public string ClassString;
  public Texture ClassTexture;
  public string MoneyShortString;
  public string MoneyString;
  public Texture MoneyTexture;
  public string PhotoShortString;
  public string PhotoString;
  public Texture PhotoTexture;
  public string ClubShortString;
  public string ClubString;
  public Texture ClubTexture;
  public string InfoShortString;
  public string InfoString;
  public Texture InfoTexture;
  public string PoolShortString;
  public string PoolString;
  public Texture PoolTexture;
  public string RepShortString;
  public string RepString;
  public Texture RepTexture;
  public string PointsShortString;
  public string PointsString;
  public float HintTimer;
  public float Timer;
  public bool ForcingTutorial;
  public int ForceID;
  public GameObject DisableButton;
  public UILabel ContinueLabel;
  public UILabel ShortLabel;
  public UILabel ShortShadow;

  private void Start()
  {
    this.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    if (OptionGlobals.TutorialsOff)
    {
      this.enabled = false;
    }
    else
    {
      this.IgnoreDistraction = TutorialGlobals.IgnoreDistraction;
      this.IgnoreClothing = TutorialGlobals.IgnoreClothing;
      this.IgnoreCouncil = TutorialGlobals.IgnoreCouncil;
      this.IgnoreTeacher = TutorialGlobals.IgnoreTeacher;
      this.IgnorePersona = TutorialGlobals.IgnorePersona;
      this.IgnoreLocker = TutorialGlobals.IgnoreLocker;
      this.IgnorePolice = TutorialGlobals.IgnorePolice;
      this.IgnoreSanity = TutorialGlobals.IgnoreSanity;
      this.IgnoreSenpai = TutorialGlobals.IgnoreSenpai;
      this.IgnoreVision = TutorialGlobals.IgnoreVision;
      this.IgnoreWeapon = TutorialGlobals.IgnoreWeapon;
      this.IgnoreBlood = TutorialGlobals.IgnoreBlood;
      this.IgnoreClass = TutorialGlobals.IgnoreClass;
      this.IgnoreMoney = TutorialGlobals.IgnoreMoney;
      this.IgnorePhoto = TutorialGlobals.IgnorePhoto;
      this.IgnoreClub = TutorialGlobals.IgnoreClub;
      this.IgnoreInfo = TutorialGlobals.IgnoreInfo;
      this.IgnorePool = TutorialGlobals.IgnorePool;
      this.IgnoreRep = TutorialGlobals.IgnoreRep;
    }
  }

  private void Update()
  {
    if (this.Show)
    {
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1.2925f, 1.2925f, 1.2925f), Time.unscaledDeltaTime * 10f);
      if ((double) this.transform.localScale.x > 1.0)
      {
        if (Input.GetButtonDown("A"))
        {
          if (this.ForcingTutorial)
            this.ShowTutorial();
          this.Yandere.RPGCamera.enabled = true;
          this.Yandere.Blur.enabled = false;
          Time.timeScale = 1f;
          this.Show = false;
          this.Hide = true;
        }
        else if (Input.GetButtonDown("B"))
        {
          if (this.DisableButton.activeInHierarchy)
          {
            OptionGlobals.TutorialsOff = true;
            this.TutorialLabel.gameObject.SetActive(true);
            this.ShortLabel.gameObject.SetActive(false);
            this.DisableButton.SetActive(false);
            this.TitleLabel.text = "Tutorials Disabled";
            this.TutorialLabel.text = this.DisabledString;
            this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
            this.TutorialImage.mainTexture = this.DisabledTexture;
            this.ShadowLabel.text = this.TutorialLabel.text;
          }
        }
        else if (Input.GetButtonDown("X") && this.ShortLabel.gameObject.activeInHierarchy)
        {
          this.TutorialLabel.gameObject.SetActive(true);
          this.ShortLabel.gameObject.SetActive(false);
        }
      }
    }
    else if (this.Hide)
    {
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.unscaledDeltaTime * 10f);
      if ((double) this.transform.localScale.x < 0.10000000149011612)
      {
        this.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        this.Hide = false;
        if (OptionGlobals.TutorialsOff)
          this.enabled = false;
      }
    }
    if ((double) this.HintTimer > 0.0)
    {
      this.HintTimer = Mathf.MoveTowards(this.HintTimer, 0.0f, Time.deltaTime);
    }
    else
    {
      if (!this.ForcingTutorial && (!this.Yandere.CanMove || this.Yandere.Egg || this.Yandere.Aiming || this.Yandere.PauseScreen.Show || this.Yandere.CinematicCamera.activeInHierarchy))
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 5.0)
        return;
      if ((this.ForcingTutorial || !this.IgnoreClothing) && this.ShowClothingMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreClothing = true;
          this.IgnoreClothing = true;
        }
        this.TitleLabel.text = "No Spare Clothing";
        this.TutorialLabel.text = this.ClothingString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.ClothingTexture;
        this.ShortLabel.text = this.ClothingShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnoreCouncil) && this.ShowCouncilMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreCouncil = true;
          this.IgnoreCouncil = true;
        }
        this.TitleLabel.text = "Student Council";
        this.TutorialLabel.text = this.CouncilString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.CouncilTexture;
        this.ShortLabel.text = this.CouncilShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnoreTeacher) && this.ShowTeacherMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreTeacher = true;
          this.IgnoreTeacher = true;
        }
        this.TitleLabel.text = "Teachers";
        this.TutorialLabel.text = this.TeacherString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.TeacherTexture;
        this.ShortLabel.text = this.TeacherShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnorePersona) && this.ShowPersonaMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnorePersona = true;
          this.IgnorePersona = true;
        }
        this.TitleLabel.text = "Personas";
        this.TutorialLabel.text = this.PersonaString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.PersonaTexture;
        this.ShortLabel.text = this.PersonaShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnoreLocker) && this.ShowLockerMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreLocker = true;
          this.IgnoreLocker = true;
        }
        this.TitleLabel.text = "Notes In Lockers";
        this.TutorialLabel.text = this.LockerString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.LockerTexture;
        this.ShortLabel.text = this.LockerShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnorePolice) && this.ShowPoliceMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnorePolice = true;
          this.IgnorePolice = true;
        }
        this.TitleLabel.text = "Police";
        this.TutorialLabel.text = this.PoliceString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.PoliceTexture;
        this.ShortLabel.text = this.PoliceShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnoreSanity) && this.ShowSanityMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreSanity = true;
          this.IgnoreSanity = true;
        }
        this.TitleLabel.text = "Restoring Sanity";
        this.TutorialLabel.text = this.SanityString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.SanityTexture;
        this.ShortLabel.text = this.SanityShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnoreSenpai) && this.ShowSenpaiMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreSenpai = true;
          this.IgnoreSenpai = true;
        }
        this.TitleLabel.text = "Your Senpai";
        this.TutorialLabel.text = this.SenpaiString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.SenpaiTexture;
        this.ShortLabel.text = this.SenpaiShortString;
        this.DisplayHint();
      }
      if (this.ForcingTutorial || !this.IgnoreVision)
      {
        Bounds bounds = this.Yandere.StudentManager.WestBathroomArea.bounds;
        if (!bounds.Contains(this.Yandere.transform.position))
        {
          bounds = this.Yandere.StudentManager.EastBathroomArea.bounds;
          if (!bounds.Contains(this.Yandere.transform.position))
            goto label_55;
        }
        this.ShowVisionMessage = true;
label_55:
        if (this.ShowVisionMessage && !this.Show)
        {
          if (!this.ForcingTutorial)
          {
            TutorialGlobals.IgnoreVision = true;
            this.IgnoreVision = true;
          }
          this.TitleLabel.text = "Yandere Vision";
          this.TutorialLabel.text = this.VisionString;
          this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
          this.TutorialImage.mainTexture = this.VisionTexture;
          this.ShortLabel.text = this.VisionShortString;
          this.DisplayHint();
        }
      }
      if (this.ForcingTutorial || !this.IgnoreWeapon)
      {
        if (this.Yandere.Armed)
          this.ShowWeaponMessage = true;
        if (this.ShowWeaponMessage && !this.Show)
        {
          if (!this.ForcingTutorial)
          {
            TutorialGlobals.IgnoreWeapon = true;
            this.IgnoreWeapon = true;
          }
          this.TitleLabel.text = "Weapons";
          this.TutorialLabel.text = this.WeaponString;
          this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
          this.TutorialImage.mainTexture = this.WeaponTexture;
          this.ShortLabel.text = this.WeaponShortString;
          this.DisplayHint();
        }
      }
      if ((this.ForcingTutorial || !this.IgnoreBlood) && this.ShowBloodMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreBlood = true;
          this.IgnoreBlood = true;
        }
        this.TitleLabel.text = "Bloody Clothing";
        this.TutorialLabel.text = this.BloodString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.BloodTexture;
        this.ShortLabel.text = this.BloodShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnoreClass) && this.ShowClassMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreClass = true;
          this.IgnoreClass = true;
        }
        this.TitleLabel.text = "Attending Class";
        this.TutorialLabel.text = this.ClassString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.ClassTexture;
        this.ShortLabel.text = this.ClassShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnoreDistraction) && this.ShowDistractionMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreDistraction = true;
          this.IgnoreDistraction = true;
        }
        this.TitleLabel.text = "Causing Distractions";
        this.TutorialLabel.text = this.DistractionString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.DistractionTexture;
        this.ShortLabel.text = this.DistractionShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnoreMoney) && this.ShowMoneyMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreMoney = true;
          this.IgnoreMoney = true;
        }
        this.TitleLabel.text = "Getting Money";
        this.TutorialLabel.text = this.MoneyString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.MoneyTexture;
        this.ShortLabel.text = this.MoneyShortString;
        this.DisplayHint();
      }
      if (this.ForcingTutorial || !this.IgnorePhoto)
      {
        if (!this.ForcingTutorial && (double) this.Yandere.transform.position.z > -50.0)
          this.ShowPhotoMessage = true;
        if (this.ShowPhotoMessage && !this.Show)
        {
          if (!this.ForcingTutorial)
          {
            TutorialGlobals.IgnorePhoto = true;
            this.IgnorePhoto = true;
          }
          this.TitleLabel.text = "Taking Photographs";
          this.TutorialLabel.text = this.PhotoString;
          this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
          this.TutorialImage.mainTexture = this.PhotoTexture;
          this.ShortLabel.text = this.PhotoShortString;
          this.DisplayHint();
        }
      }
      if ((this.ForcingTutorial || !this.IgnoreClub) && this.ShowClubMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreClub = true;
          this.IgnoreClub = true;
        }
        this.TitleLabel.text = "Joining Clubs";
        this.TutorialLabel.text = this.ClubString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.ClubTexture;
        this.ShortLabel.text = this.ClubShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnoreInfo) && this.ShowInfoMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnoreInfo = true;
          this.IgnoreInfo = true;
        }
        this.TitleLabel.text = "Info-chan's Services";
        this.TutorialLabel.text = this.InfoString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.InfoTexture;
        this.ShortLabel.text = this.InfoShortString;
        this.DisplayHint();
      }
      if ((this.ForcingTutorial || !this.IgnorePool) && this.ShowPoolMessage && !this.Show)
      {
        if (!this.ForcingTutorial)
        {
          TutorialGlobals.IgnorePool = true;
          this.IgnorePool = true;
        }
        this.TitleLabel.text = "Cleaning Blood";
        this.TutorialLabel.text = this.PoolString;
        this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
        this.TutorialImage.mainTexture = this.PoolTexture;
        this.ShortLabel.text = this.PoolShortString;
        this.DisplayHint();
      }
      if (!this.ForcingTutorial && this.IgnoreRep || !this.ShowRepMessage || this.Show)
        return;
      if (!this.ForcingTutorial)
      {
        TutorialGlobals.IgnoreRep = true;
        this.IgnoreRep = true;
      }
      this.TitleLabel.text = "Reputation";
      this.TutorialLabel.text = this.RepString;
      this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
      this.TutorialImage.mainTexture = this.RepTexture;
      this.ShortLabel.text = this.RepShortString;
      this.DisplayHint();
    }
  }

  public void DisplayHint()
  {
    if (this.Yandere.PauseScreen.Show)
      return;
    this.Yandere.PauseScreen.Hint.Show = true;
    this.Yandere.PauseScreen.Hint.DisplayTutorial = true;
    this.HintTimer = 10f;
  }

  public void SummonWindow()
  {
    Debug.Log((object) "SummonWindow() has been called.");
    this.ShadowLabel.text = this.TutorialLabel.text;
    this.ShortShadow.text = this.ShortLabel.text;
    this.Yandere.RPGCamera.enabled = false;
    this.Yandere.Blur.enabled = true;
    Time.timeScale = 0.0f;
    this.HintTimer = 1f;
    this.Show = true;
    this.Timer = 0.0f;
    if (this.ForcingTutorial)
    {
      this.TutorialLabel.gameObject.SetActive(true);
      this.ShortLabel.gameObject.SetActive(false);
    }
    else
    {
      this.TutorialLabel.gameObject.SetActive(false);
      this.ShortLabel.gameObject.SetActive(true);
    }
  }

  public void ShowTutorial()
  {
    Debug.Log((object) ("ShowTutorial() has been called, and ForceID is: " + this.ForceID.ToString()));
    if (!this.ForcingTutorial)
    {
      Debug.Log((object) "ForcingTutorial is being set to true.");
      this.TutorialLabel.gameObject.SetActive(true);
      this.ShortLabel.gameObject.SetActive(false);
      this.DisableButton.SetActive(false);
      this.ContinueLabel.text = "RETURN";
      this.ForcingTutorial = true;
      this.HintTimer = 0.0f;
      this.Timer = 6f;
    }
    else
    {
      this.TutorialLabel.gameObject.SetActive(false);
      this.ShortLabel.gameObject.SetActive(true);
      this.DisableButton.SetActive(true);
      this.ContinueLabel.text = "EXIT";
      this.ForcingTutorial = false;
      this.Timer = 0.0f;
    }
    this.ShowDistractionMessage = false;
    this.ShowClothingMessage = false;
    this.ShowCouncilMessage = false;
    this.ShowTeacherMessage = false;
    this.ShowPersonaMessage = false;
    this.ShowLockerMessage = false;
    this.ShowPoliceMessage = false;
    this.ShowSanityMessage = false;
    this.ShowSenpaiMessage = false;
    this.ShowVisionMessage = false;
    this.ShowWeaponMessage = false;
    this.ShowBloodMessage = false;
    this.ShowClassMessage = false;
    this.ShowMoneyMessage = false;
    this.ShowPhotoMessage = false;
    this.ShowClubMessage = false;
    this.ShowInfoMessage = false;
    this.ShowPoolMessage = false;
    this.ShowRepMessage = false;
    switch (this.ForceID)
    {
      case 1:
        this.ShowClothingMessage = this.ForcingTutorial;
        this.IgnoreClothing = false;
        break;
      case 2:
        this.ShowCouncilMessage = this.ForcingTutorial;
        this.IgnoreCouncil = false;
        break;
      case 3:
        this.ShowTeacherMessage = this.ForcingTutorial;
        this.IgnoreTeacher = false;
        break;
      case 4:
        this.ShowLockerMessage = this.ForcingTutorial;
        this.IgnoreLocker = false;
        break;
      case 5:
        this.ShowPoliceMessage = this.ForcingTutorial;
        this.IgnorePolice = false;
        break;
      case 6:
        this.ShowSenpaiMessage = this.ForcingTutorial;
        this.IgnoreSenpai = false;
        break;
      case 7:
        this.ShowVisionMessage = this.ForcingTutorial;
        this.IgnoreVision = false;
        break;
      case 8:
        this.ShowWeaponMessage = this.ForcingTutorial;
        this.IgnoreWeapon = false;
        break;
      case 9:
        this.ShowSanityMessage = this.ForcingTutorial;
        this.IgnoreSanity = false;
        break;
      case 10:
        this.ShowBloodMessage = this.ForcingTutorial;
        this.IgnoreBlood = false;
        break;
      case 11:
        this.ShowClassMessage = this.ForcingTutorial;
        this.IgnoreClass = false;
        break;
      case 12:
        this.ShowPhotoMessage = this.ForcingTutorial;
        this.IgnorePhoto = false;
        break;
      case 13:
        this.ShowClubMessage = this.ForcingTutorial;
        this.IgnoreClub = false;
        break;
      case 14:
        this.ShowInfoMessage = this.ForcingTutorial;
        this.IgnoreInfo = false;
        break;
      case 15:
        this.ShowPoolMessage = this.ForcingTutorial;
        this.IgnorePool = false;
        break;
      case 16:
        this.ShowRepMessage = this.ForcingTutorial;
        this.IgnoreRep = false;
        break;
      case 17:
        this.ShowMoneyMessage = this.ForcingTutorial;
        this.IgnoreMoney = false;
        break;
      case 18:
        this.ShowDistractionMessage = this.ForcingTutorial;
        this.IgnoreDistraction = false;
        break;
      case 19:
        this.ShowPersonaMessage = this.ForcingTutorial;
        this.IgnorePersona = false;
        break;
    }
    this.Update();
    switch (this.ForceID)
    {
      case 1:
        this.ShowClothingMessage = this.ForcingTutorial;
        this.IgnoreClothing = true;
        break;
      case 2:
        this.ShowCouncilMessage = this.ForcingTutorial;
        this.IgnoreCouncil = true;
        break;
      case 3:
        this.ShowTeacherMessage = this.ForcingTutorial;
        this.IgnoreTeacher = true;
        break;
      case 4:
        this.ShowLockerMessage = this.ForcingTutorial;
        this.IgnoreLocker = true;
        break;
      case 5:
        this.ShowPoliceMessage = this.ForcingTutorial;
        this.IgnorePolice = true;
        break;
      case 6:
        this.ShowSenpaiMessage = this.ForcingTutorial;
        this.IgnoreSenpai = true;
        break;
      case 7:
        this.ShowVisionMessage = this.ForcingTutorial;
        this.IgnoreVision = true;
        break;
      case 8:
        this.ShowWeaponMessage = this.ForcingTutorial;
        this.IgnoreWeapon = true;
        break;
      case 9:
        this.ShowSanityMessage = this.ForcingTutorial;
        this.IgnoreSanity = true;
        break;
      case 10:
        this.ShowBloodMessage = this.ForcingTutorial;
        this.IgnoreBlood = true;
        break;
      case 11:
        this.ShowClassMessage = this.ForcingTutorial;
        this.IgnoreClass = true;
        break;
      case 12:
        this.ShowPhotoMessage = this.ForcingTutorial;
        this.IgnorePhoto = true;
        break;
      case 13:
        this.ShowClubMessage = this.ForcingTutorial;
        this.IgnoreClub = true;
        break;
      case 14:
        this.ShowInfoMessage = this.ForcingTutorial;
        this.IgnoreInfo = true;
        break;
      case 15:
        this.ShowPoolMessage = this.ForcingTutorial;
        this.IgnorePool = true;
        break;
      case 16:
        this.ShowRepMessage = this.ForcingTutorial;
        this.IgnoreRep = true;
        break;
      case 17:
        this.ShowMoneyMessage = this.ForcingTutorial;
        this.IgnoreMoney = true;
        break;
      case 18:
        this.ShowDistractionMessage = this.ForcingTutorial;
        this.IgnoreDistraction = true;
        break;
      case 19:
        this.ShowPersonaMessage = this.ForcingTutorial;
        this.IgnorePersona = true;
        break;
    }
  }
}
