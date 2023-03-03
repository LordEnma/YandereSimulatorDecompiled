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
		base.transform.localScale = new Vector3(0f, 0f, 0f);
		if (OptionGlobals.TutorialsOff)
		{
			base.enabled = false;
			return;
		}
		IgnoreDistraction = TutorialGlobals.IgnoreDistraction;
		IgnoreClothing = TutorialGlobals.IgnoreClothing;
		IgnoreCouncil = TutorialGlobals.IgnoreCouncil;
		IgnoreTeacher = TutorialGlobals.IgnoreTeacher;
		IgnorePersona = TutorialGlobals.IgnorePersona;
		IgnoreLocker = TutorialGlobals.IgnoreLocker;
		IgnorePolice = TutorialGlobals.IgnorePolice;
		IgnoreSanity = TutorialGlobals.IgnoreSanity;
		IgnoreSenpai = TutorialGlobals.IgnoreSenpai;
		IgnoreVision = TutorialGlobals.IgnoreVision;
		IgnoreWeapon = TutorialGlobals.IgnoreWeapon;
		IgnoreBlood = TutorialGlobals.IgnoreBlood;
		IgnoreClass = TutorialGlobals.IgnoreClass;
		IgnoreMoney = TutorialGlobals.IgnoreMoney;
		IgnorePhoto = TutorialGlobals.IgnorePhoto;
		IgnoreClub = TutorialGlobals.IgnoreClub;
		IgnoreInfo = TutorialGlobals.IgnoreInfo;
		IgnorePool = TutorialGlobals.IgnorePool;
		IgnoreRep = TutorialGlobals.IgnoreRep;
	}

	private void Update()
	{
		if (Show)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1.2925f, 1.2925f, 1.2925f), Time.unscaledDeltaTime * 10f);
			if (base.transform.localScale.x > 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					if (ForcingTutorial)
					{
						ShowTutorial();
					}
					Yandere.RPGCamera.enabled = true;
					Yandere.Blur.enabled = false;
					Time.timeScale = 1f;
					Show = false;
					Hide = true;
					if (Yandere.PauseScreen.Show)
					{
						Debug.Log("Returning to Favors screen?");
						Yandere.PromptBar.ClearButtons();
						Yandere.PromptBar.Label[0].text = "Confirm";
						Yandere.PromptBar.Label[1].text = "Back";
						if (Yandere.PauseScreen.FavorMenu.isActiveAndEnabled)
						{
							Yandere.PromptBar.Label[5].text = "Change";
						}
						else
						{
							Yandere.PromptBar.Label[4].text = "Change";
						}
						Yandere.PromptBar.UpdateButtons();
						Yandere.PauseScreen.PromptBar.Show = true;
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					if (DisableButton.activeInHierarchy)
					{
						OptionGlobals.TutorialsOff = true;
						TutorialLabel.gameObject.SetActive(value: true);
						ShortLabel.gameObject.SetActive(value: false);
						DisableButton.SetActive(value: false);
						TitleLabel.text = "Tutorials Disabled";
						TutorialLabel.text = DisabledString;
						TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
						TutorialImage.mainTexture = DisabledTexture;
						ShadowLabel.text = TutorialLabel.text;
					}
				}
				else if (Input.GetButtonDown("X") && ShortLabel.gameObject.activeInHierarchy)
				{
					TutorialLabel.gameObject.SetActive(value: true);
					ShortLabel.gameObject.SetActive(value: false);
				}
			}
		}
		else if (Hide)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
			if (base.transform.localScale.x < 0.1f)
			{
				base.transform.localScale = new Vector3(0f, 0f, 0f);
				Hide = false;
				if (OptionGlobals.TutorialsOff)
				{
					base.enabled = false;
				}
			}
		}
		if (HintTimer > 0f)
		{
			HintTimer = Mathf.MoveTowards(HintTimer, 0f, Time.deltaTime);
		}
		else
		{
			if (!ForcingTutorial && (!Yandere.CanMove || Yandere.Egg || Yandere.Aiming || Yandere.PauseScreen.Show || Yandere.CinematicCamera.activeInHierarchy))
			{
				return;
			}
			Timer += Time.deltaTime;
			if (!(Timer > 5f))
			{
				return;
			}
			if ((ForcingTutorial || !IgnoreClothing) && ShowClothingMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreClothing = true;
					IgnoreClothing = true;
				}
				TitleLabel.text = "No Spare Clothing";
				TutorialLabel.text = ClothingString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = ClothingTexture;
				ShortLabel.text = ClothingShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreCouncil) && ShowCouncilMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreCouncil = true;
					IgnoreCouncil = true;
				}
				TitleLabel.text = "Student Council";
				TutorialLabel.text = CouncilString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = CouncilTexture;
				ShortLabel.text = CouncilShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreTeacher) && ShowTeacherMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreTeacher = true;
					IgnoreTeacher = true;
				}
				TitleLabel.text = "Teachers";
				TutorialLabel.text = TeacherString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = TeacherTexture;
				ShortLabel.text = TeacherShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnorePersona) && ShowPersonaMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnorePersona = true;
					IgnorePersona = true;
				}
				TitleLabel.text = "Personas";
				TutorialLabel.text = PersonaString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = PersonaTexture;
				ShortLabel.text = PersonaShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreLocker) && ShowLockerMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreLocker = true;
					IgnoreLocker = true;
				}
				TitleLabel.text = "Notes In Lockers";
				TutorialLabel.text = LockerString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = LockerTexture;
				ShortLabel.text = LockerShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnorePolice) && ShowPoliceMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnorePolice = true;
					IgnorePolice = true;
				}
				TitleLabel.text = "Police";
				TutorialLabel.text = PoliceString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = PoliceTexture;
				ShortLabel.text = PoliceShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreSanity) && ShowSanityMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreSanity = true;
					IgnoreSanity = true;
				}
				TitleLabel.text = "Restoring Sanity";
				TutorialLabel.text = SanityString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = SanityTexture;
				ShortLabel.text = SanityShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreSenpai) && ShowSenpaiMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreSenpai = true;
					IgnoreSenpai = true;
				}
				TitleLabel.text = "Your Senpai";
				TutorialLabel.text = SenpaiString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = SenpaiTexture;
				ShortLabel.text = SenpaiShortString;
				DisplayHint();
			}
			if (ForcingTutorial || !IgnoreVision)
			{
				if (Yandere.StudentManager.WestBathroomArea.bounds.Contains(Yandere.transform.position) || Yandere.StudentManager.EastBathroomArea.bounds.Contains(Yandere.transform.position))
				{
					ShowVisionMessage = true;
				}
				if (ShowVisionMessage && !Show)
				{
					if (!ForcingTutorial)
					{
						TutorialGlobals.IgnoreVision = true;
						IgnoreVision = true;
					}
					TitleLabel.text = "Yandere Vision";
					TutorialLabel.text = VisionString;
					TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
					TutorialImage.mainTexture = VisionTexture;
					ShortLabel.text = VisionShortString;
					DisplayHint();
				}
			}
			if (ForcingTutorial || !IgnoreWeapon)
			{
				if (Yandere.Armed)
				{
					ShowWeaponMessage = true;
				}
				if (ShowWeaponMessage && !Show)
				{
					if (!ForcingTutorial)
					{
						TutorialGlobals.IgnoreWeapon = true;
						IgnoreWeapon = true;
					}
					TitleLabel.text = "Weapons";
					TutorialLabel.text = WeaponString;
					TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
					TutorialImage.mainTexture = WeaponTexture;
					ShortLabel.text = WeaponShortString;
					DisplayHint();
				}
			}
			if ((ForcingTutorial || !IgnoreBlood) && ShowBloodMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreBlood = true;
					IgnoreBlood = true;
				}
				TitleLabel.text = "Bloody Clothing";
				TutorialLabel.text = BloodString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = BloodTexture;
				ShortLabel.text = BloodShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreClass) && ShowClassMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreClass = true;
					IgnoreClass = true;
				}
				TitleLabel.text = "Attending Class";
				TutorialLabel.text = ClassString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = ClassTexture;
				ShortLabel.text = ClassShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreDistraction) && ShowDistractionMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreDistraction = true;
					IgnoreDistraction = true;
				}
				TitleLabel.text = "Causing Distractions";
				TutorialLabel.text = DistractionString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = DistractionTexture;
				ShortLabel.text = DistractionShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreMoney) && ShowMoneyMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreMoney = true;
					IgnoreMoney = true;
				}
				TitleLabel.text = "Getting Money";
				TutorialLabel.text = MoneyString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = MoneyTexture;
				ShortLabel.text = MoneyShortString;
				DisplayHint();
			}
			if (ForcingTutorial || !IgnorePhoto)
			{
				if (!ForcingTutorial && Yandere.transform.position.z > -50f)
				{
					ShowPhotoMessage = true;
				}
				if (ShowPhotoMessage && !Show)
				{
					if (!ForcingTutorial)
					{
						TutorialGlobals.IgnorePhoto = true;
						IgnorePhoto = true;
					}
					TitleLabel.text = "Taking Photographs";
					TutorialLabel.text = PhotoString;
					TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
					TutorialImage.mainTexture = PhotoTexture;
					ShortLabel.text = PhotoShortString;
					DisplayHint();
				}
			}
			if ((ForcingTutorial || !IgnoreClub) && ShowClubMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreClub = true;
					IgnoreClub = true;
				}
				TitleLabel.text = "Joining Clubs";
				TutorialLabel.text = ClubString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = ClubTexture;
				ShortLabel.text = ClubShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreInfo) && ShowInfoMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreInfo = true;
					IgnoreInfo = true;
				}
				TitleLabel.text = "Info-chan's Services";
				TutorialLabel.text = InfoString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = InfoTexture;
				ShortLabel.text = InfoShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnorePool) && ShowPoolMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnorePool = true;
					IgnorePool = true;
				}
				TitleLabel.text = "Cleaning Blood";
				TutorialLabel.text = PoolString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = PoolTexture;
				ShortLabel.text = PoolShortString;
				DisplayHint();
			}
			if ((ForcingTutorial || !IgnoreRep) && ShowRepMessage && !Show)
			{
				if (!ForcingTutorial)
				{
					TutorialGlobals.IgnoreRep = true;
					IgnoreRep = true;
				}
				TitleLabel.text = "Reputation";
				TutorialLabel.text = RepString;
				TutorialLabel.text = TutorialLabel.text.Replace('@', '\n');
				TutorialImage.mainTexture = RepTexture;
				ShortLabel.text = RepShortString;
				DisplayHint();
			}
		}
	}

	public void DisplayHint()
	{
		if (!Yandere.PauseScreen.Show)
		{
			Yandere.PauseScreen.Hint.Show = true;
			Yandere.PauseScreen.Hint.DisplayTutorial = true;
			HintTimer = 10f;
		}
	}

	public void SummonWindow()
	{
		Debug.Log("SummonWindow() has been called.");
		ShadowLabel.text = TutorialLabel.text;
		ShortShadow.text = ShortLabel.text;
		Yandere.RPGCamera.enabled = false;
		Yandere.Blur.enabled = true;
		Time.timeScale = 0f;
		HintTimer = 1f;
		Show = true;
		Timer = 0f;
		if (ForcingTutorial)
		{
			TutorialLabel.gameObject.SetActive(value: true);
			ShortLabel.gameObject.SetActive(value: false);
		}
		else
		{
			TutorialLabel.gameObject.SetActive(value: false);
			ShortLabel.gameObject.SetActive(value: true);
		}
	}

	public void ShowTutorial()
	{
		Debug.Log("ShowTutorial() has been called, and ForceID is: " + ForceID);
		if (!ForcingTutorial)
		{
			Debug.Log("ForcingTutorial is being set to true.");
			TutorialLabel.gameObject.SetActive(value: true);
			ShortLabel.gameObject.SetActive(value: false);
			DisableButton.SetActive(value: false);
			ContinueLabel.text = "RETURN";
			ForcingTutorial = true;
			HintTimer = 0f;
			Timer = 6f;
		}
		else
		{
			TutorialLabel.gameObject.SetActive(value: false);
			ShortLabel.gameObject.SetActive(value: true);
			DisableButton.SetActive(value: true);
			ContinueLabel.text = "EXIT";
			ForcingTutorial = false;
			Timer = 0f;
		}
		ShowDistractionMessage = false;
		ShowClothingMessage = false;
		ShowCouncilMessage = false;
		ShowTeacherMessage = false;
		ShowPersonaMessage = false;
		ShowLockerMessage = false;
		ShowPoliceMessage = false;
		ShowSanityMessage = false;
		ShowSenpaiMessage = false;
		ShowVisionMessage = false;
		ShowWeaponMessage = false;
		ShowBloodMessage = false;
		ShowClassMessage = false;
		ShowMoneyMessage = false;
		ShowPhotoMessage = false;
		ShowClubMessage = false;
		ShowInfoMessage = false;
		ShowPoolMessage = false;
		ShowRepMessage = false;
		switch (ForceID)
		{
		case 1:
			ShowClothingMessage = ForcingTutorial;
			IgnoreClothing = false;
			break;
		case 2:
			ShowCouncilMessage = ForcingTutorial;
			IgnoreCouncil = false;
			break;
		case 3:
			ShowTeacherMessage = ForcingTutorial;
			IgnoreTeacher = false;
			break;
		case 4:
			ShowLockerMessage = ForcingTutorial;
			IgnoreLocker = false;
			break;
		case 5:
			ShowPoliceMessage = ForcingTutorial;
			IgnorePolice = false;
			break;
		case 6:
			ShowSenpaiMessage = ForcingTutorial;
			IgnoreSenpai = false;
			break;
		case 7:
			ShowVisionMessage = ForcingTutorial;
			IgnoreVision = false;
			break;
		case 8:
			ShowWeaponMessage = ForcingTutorial;
			IgnoreWeapon = false;
			break;
		case 9:
			ShowSanityMessage = ForcingTutorial;
			IgnoreSanity = false;
			break;
		case 10:
			ShowBloodMessage = ForcingTutorial;
			IgnoreBlood = false;
			break;
		case 11:
			ShowClassMessage = ForcingTutorial;
			IgnoreClass = false;
			break;
		case 12:
			ShowPhotoMessage = ForcingTutorial;
			IgnorePhoto = false;
			break;
		case 13:
			ShowClubMessage = ForcingTutorial;
			IgnoreClub = false;
			break;
		case 14:
			ShowInfoMessage = ForcingTutorial;
			IgnoreInfo = false;
			break;
		case 15:
			ShowPoolMessage = ForcingTutorial;
			IgnorePool = false;
			break;
		case 16:
			ShowRepMessage = ForcingTutorial;
			IgnoreRep = false;
			break;
		case 17:
			ShowMoneyMessage = ForcingTutorial;
			IgnoreMoney = false;
			break;
		case 18:
			ShowDistractionMessage = ForcingTutorial;
			IgnoreDistraction = false;
			break;
		case 19:
			ShowPersonaMessage = ForcingTutorial;
			IgnorePersona = false;
			break;
		}
		Update();
		switch (ForceID)
		{
		case 1:
			ShowClothingMessage = ForcingTutorial;
			IgnoreClothing = true;
			break;
		case 2:
			ShowCouncilMessage = ForcingTutorial;
			IgnoreCouncil = true;
			break;
		case 3:
			ShowTeacherMessage = ForcingTutorial;
			IgnoreTeacher = true;
			break;
		case 4:
			ShowLockerMessage = ForcingTutorial;
			IgnoreLocker = true;
			break;
		case 5:
			ShowPoliceMessage = ForcingTutorial;
			IgnorePolice = true;
			break;
		case 6:
			ShowSenpaiMessage = ForcingTutorial;
			IgnoreSenpai = true;
			break;
		case 7:
			ShowVisionMessage = ForcingTutorial;
			IgnoreVision = true;
			break;
		case 8:
			ShowWeaponMessage = ForcingTutorial;
			IgnoreWeapon = true;
			break;
		case 9:
			ShowSanityMessage = ForcingTutorial;
			IgnoreSanity = true;
			break;
		case 10:
			ShowBloodMessage = ForcingTutorial;
			IgnoreBlood = true;
			break;
		case 11:
			ShowClassMessage = ForcingTutorial;
			IgnoreClass = true;
			break;
		case 12:
			ShowPhotoMessage = ForcingTutorial;
			IgnorePhoto = true;
			break;
		case 13:
			ShowClubMessage = ForcingTutorial;
			IgnoreClub = true;
			break;
		case 14:
			ShowInfoMessage = ForcingTutorial;
			IgnoreInfo = true;
			break;
		case 15:
			ShowPoolMessage = ForcingTutorial;
			IgnorePool = true;
			break;
		case 16:
			ShowRepMessage = ForcingTutorial;
			IgnoreRep = true;
			break;
		case 17:
			ShowMoneyMessage = ForcingTutorial;
			IgnoreMoney = true;
			break;
		case 18:
			ShowDistractionMessage = ForcingTutorial;
			IgnoreDistraction = true;
			break;
		case 19:
			ShowPersonaMessage = ForcingTutorial;
			IgnorePersona = true;
			break;
		}
	}
}
