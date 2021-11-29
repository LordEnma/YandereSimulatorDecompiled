using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class TutorialWindowScript : MonoBehaviour
{
	// Token: 0x06001EDF RID: 7903 RVA: 0x001B3B1C File Offset: 0x001B1D1C
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
		if (OptionGlobals.TutorialsOff)
		{
			base.enabled = false;
			return;
		}
		this.IgnoreClothing = TutorialGlobals.IgnoreClothing;
		this.IgnoreCouncil = TutorialGlobals.IgnoreCouncil;
		this.IgnoreTeacher = TutorialGlobals.IgnoreTeacher;
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

	// Token: 0x06001EE0 RID: 7904 RVA: 0x001B3C14 File Offset: 0x001B1E14
	private void Update()
	{
		if (this.Show)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1.2925f, 1.2925f, 1.2925f), Time.unscaledDeltaTime * 10f);
			if (base.transform.localScale.x > 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					if (this.ForcingTutorial)
					{
						this.ShowTutorial();
					}
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
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
			if (base.transform.localScale.x < 0.1f)
			{
				base.transform.localScale = new Vector3(0f, 0f, 0f);
				this.Hide = false;
				if (OptionGlobals.TutorialsOff)
				{
					base.enabled = false;
				}
			}
		}
		if (this.HintTimer > 0f)
		{
			this.HintTimer = Mathf.MoveTowards(this.HintTimer, 0f, Time.deltaTime);
			return;
		}
		if (this.ForcingTutorial || (this.Yandere.CanMove && !this.Yandere.Egg && !this.Yandere.Aiming && !this.Yandere.PauseScreen.Show && !this.Yandere.CinematicCamera.activeInHierarchy))
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
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
					if (this.Yandere.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.Yandere.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position))
					{
						this.ShowVisionMessage = true;
					}
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
					{
						this.ShowWeaponMessage = true;
					}
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
					if (!this.ForcingTutorial && this.Yandere.transform.position.z > -50f)
					{
						this.ShowPhotoMessage = true;
					}
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
				if ((this.ForcingTutorial || !this.IgnoreRep) && this.ShowRepMessage && !this.Show)
				{
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
		}
	}

	// Token: 0x06001EE1 RID: 7905 RVA: 0x001B4A98 File Offset: 0x001B2C98
	public void DisplayHint()
	{
		if (!this.Yandere.PauseScreen.Show)
		{
			this.Yandere.PauseScreen.Hint.Show = true;
			this.Yandere.PauseScreen.Hint.DisplayTutorial = true;
			this.HintTimer = 10f;
		}
	}

	// Token: 0x06001EE2 RID: 7906 RVA: 0x001B4AF0 File Offset: 0x001B2CF0
	public void SummonWindow()
	{
		Debug.Log("SummonWindow() has been called.");
		this.ShadowLabel.text = this.TutorialLabel.text;
		this.ShortShadow.text = this.ShortLabel.text;
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.Blur.enabled = true;
		Time.timeScale = 0f;
		this.HintTimer = 1f;
		this.Show = true;
		this.Timer = 0f;
		if (this.ForcingTutorial)
		{
			this.TutorialLabel.gameObject.SetActive(true);
			this.ShortLabel.gameObject.SetActive(false);
			return;
		}
		this.TutorialLabel.gameObject.SetActive(false);
		this.ShortLabel.gameObject.SetActive(true);
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x001B4BCC File Offset: 0x001B2DCC
	public void ShowTutorial()
	{
		Debug.Log("ShowTutorial() has been called, and ForceID is: " + this.ForceID.ToString());
		if (!this.ForcingTutorial)
		{
			Debug.Log("ForcingTutorial is being set to true.");
			this.TutorialLabel.gameObject.SetActive(true);
			this.ShortLabel.gameObject.SetActive(false);
			this.DisableButton.SetActive(false);
			this.ContinueLabel.text = "RETURN";
			this.ForcingTutorial = true;
			this.HintTimer = 0f;
			this.Timer = 6f;
		}
		else
		{
			this.TutorialLabel.gameObject.SetActive(false);
			this.ShortLabel.gameObject.SetActive(true);
			this.DisableButton.SetActive(true);
			this.ContinueLabel.text = "EXIT";
			this.ForcingTutorial = false;
			this.Timer = 0f;
		}
		this.ShowClothingMessage = false;
		this.ShowCouncilMessage = false;
		this.ShowTeacherMessage = false;
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
		}
		this.Update();
		switch (this.ForceID)
		{
		case 1:
			this.ShowClothingMessage = this.ForcingTutorial;
			this.IgnoreClothing = true;
			return;
		case 2:
			this.ShowCouncilMessage = this.ForcingTutorial;
			this.IgnoreCouncil = true;
			return;
		case 3:
			this.ShowTeacherMessage = this.ForcingTutorial;
			this.IgnoreTeacher = true;
			return;
		case 4:
			this.ShowLockerMessage = this.ForcingTutorial;
			this.IgnoreLocker = true;
			return;
		case 5:
			this.ShowPoliceMessage = this.ForcingTutorial;
			this.IgnorePolice = true;
			return;
		case 6:
			this.ShowSenpaiMessage = this.ForcingTutorial;
			this.IgnoreSenpai = true;
			return;
		case 7:
			this.ShowVisionMessage = this.ForcingTutorial;
			this.IgnoreVision = true;
			return;
		case 8:
			this.ShowWeaponMessage = this.ForcingTutorial;
			this.IgnoreWeapon = true;
			return;
		case 9:
			this.ShowSanityMessage = this.ForcingTutorial;
			this.IgnoreSanity = true;
			return;
		case 10:
			this.ShowBloodMessage = this.ForcingTutorial;
			this.IgnoreBlood = true;
			return;
		case 11:
			this.ShowClassMessage = this.ForcingTutorial;
			this.IgnoreClass = true;
			return;
		case 12:
			this.ShowPhotoMessage = this.ForcingTutorial;
			this.IgnorePhoto = true;
			return;
		case 13:
			this.ShowClubMessage = this.ForcingTutorial;
			this.IgnoreClub = true;
			return;
		case 14:
			this.ShowInfoMessage = this.ForcingTutorial;
			this.IgnoreInfo = true;
			return;
		case 15:
			this.ShowPoolMessage = this.ForcingTutorial;
			this.IgnorePool = true;
			return;
		case 16:
			this.ShowRepMessage = this.ForcingTutorial;
			this.IgnoreRep = true;
			return;
		case 17:
			this.ShowMoneyMessage = this.ForcingTutorial;
			this.IgnoreMoney = true;
			return;
		default:
			return;
		}
	}

	// Token: 0x0400406A RID: 16490
	public YandereScript Yandere;

	// Token: 0x0400406B RID: 16491
	public bool ShowClothingMessage;

	// Token: 0x0400406C RID: 16492
	public bool ShowCouncilMessage;

	// Token: 0x0400406D RID: 16493
	public bool ShowTeacherMessage;

	// Token: 0x0400406E RID: 16494
	public bool ShowLockerMessage;

	// Token: 0x0400406F RID: 16495
	public bool ShowPoliceMessage;

	// Token: 0x04004070 RID: 16496
	public bool ShowSanityMessage;

	// Token: 0x04004071 RID: 16497
	public bool ShowSenpaiMessage;

	// Token: 0x04004072 RID: 16498
	public bool ShowVisionMessage;

	// Token: 0x04004073 RID: 16499
	public bool ShowWeaponMessage;

	// Token: 0x04004074 RID: 16500
	public bool ShowBloodMessage;

	// Token: 0x04004075 RID: 16501
	public bool ShowClassMessage;

	// Token: 0x04004076 RID: 16502
	public bool ShowMoneyMessage;

	// Token: 0x04004077 RID: 16503
	public bool ShowPhotoMessage;

	// Token: 0x04004078 RID: 16504
	public bool ShowClubMessage;

	// Token: 0x04004079 RID: 16505
	public bool ShowInfoMessage;

	// Token: 0x0400407A RID: 16506
	public bool ShowPoolMessage;

	// Token: 0x0400407B RID: 16507
	public bool ShowRepMessage;

	// Token: 0x0400407C RID: 16508
	public bool IgnoreClothing;

	// Token: 0x0400407D RID: 16509
	public bool IgnoreCouncil;

	// Token: 0x0400407E RID: 16510
	public bool IgnoreTeacher;

	// Token: 0x0400407F RID: 16511
	public bool IgnoreLocker;

	// Token: 0x04004080 RID: 16512
	public bool IgnorePolice;

	// Token: 0x04004081 RID: 16513
	public bool IgnoreSanity;

	// Token: 0x04004082 RID: 16514
	public bool IgnoreSenpai;

	// Token: 0x04004083 RID: 16515
	public bool IgnoreVision;

	// Token: 0x04004084 RID: 16516
	public bool IgnoreWeapon;

	// Token: 0x04004085 RID: 16517
	public bool IgnoreBlood;

	// Token: 0x04004086 RID: 16518
	public bool IgnoreClass;

	// Token: 0x04004087 RID: 16519
	public bool IgnoreMoney;

	// Token: 0x04004088 RID: 16520
	public bool IgnorePhoto;

	// Token: 0x04004089 RID: 16521
	public bool IgnoreClub;

	// Token: 0x0400408A RID: 16522
	public bool IgnoreInfo;

	// Token: 0x0400408B RID: 16523
	public bool IgnorePool;

	// Token: 0x0400408C RID: 16524
	public bool IgnoreRep;

	// Token: 0x0400408D RID: 16525
	public bool Hide;

	// Token: 0x0400408E RID: 16526
	public bool Show;

	// Token: 0x0400408F RID: 16527
	public UILabel TutorialLabel;

	// Token: 0x04004090 RID: 16528
	public UILabel ShadowLabel;

	// Token: 0x04004091 RID: 16529
	public UILabel TitleLabel;

	// Token: 0x04004092 RID: 16530
	public UITexture TutorialImage;

	// Token: 0x04004093 RID: 16531
	public string DisabledShortString;

	// Token: 0x04004094 RID: 16532
	public string DisabledString;

	// Token: 0x04004095 RID: 16533
	public Texture DisabledTexture;

	// Token: 0x04004096 RID: 16534
	public string ClothingShortString;

	// Token: 0x04004097 RID: 16535
	public string ClothingString;

	// Token: 0x04004098 RID: 16536
	public Texture ClothingTexture;

	// Token: 0x04004099 RID: 16537
	public string CouncilShortString;

	// Token: 0x0400409A RID: 16538
	public string CouncilString;

	// Token: 0x0400409B RID: 16539
	public Texture CouncilTexture;

	// Token: 0x0400409C RID: 16540
	public string TeacherShortString;

	// Token: 0x0400409D RID: 16541
	public string TeacherString;

	// Token: 0x0400409E RID: 16542
	public Texture TeacherTexture;

	// Token: 0x0400409F RID: 16543
	public string LockerShortString;

	// Token: 0x040040A0 RID: 16544
	public string LockerString;

	// Token: 0x040040A1 RID: 16545
	public Texture LockerTexture;

	// Token: 0x040040A2 RID: 16546
	public string PoliceShortString;

	// Token: 0x040040A3 RID: 16547
	public string PoliceString;

	// Token: 0x040040A4 RID: 16548
	public Texture PoliceTexture;

	// Token: 0x040040A5 RID: 16549
	public string SanityShortString;

	// Token: 0x040040A6 RID: 16550
	public string SanityString;

	// Token: 0x040040A7 RID: 16551
	public Texture SanityTexture;

	// Token: 0x040040A8 RID: 16552
	public string SenpaiShortString;

	// Token: 0x040040A9 RID: 16553
	public string SenpaiString;

	// Token: 0x040040AA RID: 16554
	public Texture SenpaiTexture;

	// Token: 0x040040AB RID: 16555
	public string VisionShortString;

	// Token: 0x040040AC RID: 16556
	public string VisionString;

	// Token: 0x040040AD RID: 16557
	public Texture VisionTexture;

	// Token: 0x040040AE RID: 16558
	public string WeaponShortString;

	// Token: 0x040040AF RID: 16559
	public string WeaponString;

	// Token: 0x040040B0 RID: 16560
	public Texture WeaponTexture;

	// Token: 0x040040B1 RID: 16561
	public string BloodShortString;

	// Token: 0x040040B2 RID: 16562
	public string BloodString;

	// Token: 0x040040B3 RID: 16563
	public Texture BloodTexture;

	// Token: 0x040040B4 RID: 16564
	public string ClassShortString;

	// Token: 0x040040B5 RID: 16565
	public string ClassString;

	// Token: 0x040040B6 RID: 16566
	public Texture ClassTexture;

	// Token: 0x040040B7 RID: 16567
	public string MoneyShortString;

	// Token: 0x040040B8 RID: 16568
	public string MoneyString;

	// Token: 0x040040B9 RID: 16569
	public Texture MoneyTexture;

	// Token: 0x040040BA RID: 16570
	public string PhotoShortString;

	// Token: 0x040040BB RID: 16571
	public string PhotoString;

	// Token: 0x040040BC RID: 16572
	public Texture PhotoTexture;

	// Token: 0x040040BD RID: 16573
	public string ClubShortString;

	// Token: 0x040040BE RID: 16574
	public string ClubString;

	// Token: 0x040040BF RID: 16575
	public Texture ClubTexture;

	// Token: 0x040040C0 RID: 16576
	public string InfoShortString;

	// Token: 0x040040C1 RID: 16577
	public string InfoString;

	// Token: 0x040040C2 RID: 16578
	public Texture InfoTexture;

	// Token: 0x040040C3 RID: 16579
	public string PoolShortString;

	// Token: 0x040040C4 RID: 16580
	public string PoolString;

	// Token: 0x040040C5 RID: 16581
	public Texture PoolTexture;

	// Token: 0x040040C6 RID: 16582
	public string RepShortString;

	// Token: 0x040040C7 RID: 16583
	public string RepString;

	// Token: 0x040040C8 RID: 16584
	public Texture RepTexture;

	// Token: 0x040040C9 RID: 16585
	public string PointsShortString;

	// Token: 0x040040CA RID: 16586
	public string PointsString;

	// Token: 0x040040CB RID: 16587
	public float HintTimer;

	// Token: 0x040040CC RID: 16588
	public float Timer;

	// Token: 0x040040CD RID: 16589
	public bool ForcingTutorial;

	// Token: 0x040040CE RID: 16590
	public int ForceID;

	// Token: 0x040040CF RID: 16591
	public GameObject DisableButton;

	// Token: 0x040040D0 RID: 16592
	public UILabel ContinueLabel;

	// Token: 0x040040D1 RID: 16593
	public UILabel ShortLabel;

	// Token: 0x040040D2 RID: 16594
	public UILabel ShortShadow;
}
