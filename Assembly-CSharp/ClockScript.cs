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

	public RetroMinigameScript RetroMinigame;

	public StudentManagerScript StudentManager;

	public CameraEffectsScript CameraEffects;

	public GrandfatherScript Grandfather;

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
		if (!MissionMode)
		{
			Profile.bloom.enabled = true;
			BloomDisabled = OptionGlobals.DisableBloom;
			OptionGlobals.DisableBloom = false;
		}
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f);
		PeriodLabel.text = "BEFORE CLASS";
		PresentTime = StartHour * 60f;
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			int profile = GameGlobals.Profile;
			int @int = PlayerPrefs.GetInt("SaveSlot");
			Weekday = PlayerPrefs.GetInt("Profile_" + profile + "_Slot_" + @int + "_Weekday");
			if (Weekday == 1)
			{
				DateGlobals.Weekday = DayOfWeek.Monday;
			}
			else if (Weekday == 2)
			{
				DateGlobals.Weekday = DayOfWeek.Tuesday;
			}
			else if (Weekday == 3)
			{
				DateGlobals.Weekday = DayOfWeek.Wednesday;
			}
			else if (Weekday == 4)
			{
				DateGlobals.Weekday = DayOfWeek.Thursday;
			}
			else if (Weekday == 5)
			{
				DateGlobals.Weekday = DayOfWeek.Friday;
			}
		}
		else if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			Weekday = 1;
		}
		else if (DateGlobals.Weekday == DayOfWeek.Tuesday)
		{
			Weekday = 2;
		}
		else if (DateGlobals.Weekday == DayOfWeek.Wednesday)
		{
			Weekday = 3;
		}
		else if (DateGlobals.Weekday == DayOfWeek.Thursday)
		{
			Weekday = 4;
		}
		else if (DateGlobals.Weekday == DayOfWeek.Friday)
		{
			Weekday = 5;
		}
		Day = Weekday + (DateGlobals.Week - 1) * 5;
		if (DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			DateGlobals.Weekday = DayOfWeek.Monday;
		}
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.PreviousSchoolAtmosphere = 1f;
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		if (SchoolGlobals.SchoolAtmosphere < 0.5f)
		{
			CameraEffects.UpdateBloom(1f);
			CameraEffects.UpdateBloomKnee(0.5f);
			CameraEffects.UpdateBloomRadius(4f);
			Police.Darkness.enabled = true;
			Police.Darkness.color = new Color(Police.Darkness.color.r, Police.Darkness.color.g, Police.Darkness.color.b, 1f);
			FadeIn = true;
		}
		else
		{
			CameraEffects.UpdateBloom(11f);
			CameraEffects.UpdateBloomKnee(1f);
			CameraEffects.UpdateBloomRadius(7f);
			BloomKnee = 1f;
			BloomRadius = 7f;
			BloomIntensity = 11f;
			UpdateBloom = true;
		}
		if (GameGlobals.EightiesTutorial)
		{
			DayLabel.text = GetWeekdayText(DateGlobals.Weekday) ?? "";
		}
		else
		{
			DayLabel.text = GetWeekdayText(DateGlobals.Weekday) + ", WEEK " + DateGlobals.Week;
		}
		MainLight.color = new Color(1f, 1f, 1f, 1f);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
		if (ClubGlobals.GetClubClosed(ClubType.Photography) || StudentGlobals.GetStudentGrudge(56) || StudentGlobals.GetStudentGrudge(57) || StudentGlobals.GetStudentGrudge(58) || StudentGlobals.GetStudentGrudge(59) || StudentGlobals.GetStudentGrudge(60))
		{
			IgnorePhotographyClub = true;
		}
		MissionMode = MissionModeGlobals.MissionMode;
		HourTime = PresentTime / 60f;
		Hour = Mathf.Floor(PresentTime / 60f);
		Minute = Mathf.Floor((PresentTime / 60f - Hour) * 60f);
		UpdateClock();
		if (GameGlobals.Eighties)
		{
			BecomeEighties();
		}
		if (StudentManager.RecordingVideo)
		{
			CameraEffects.UpdateBloom(1f);
			CameraEffects.UpdateBloomRadius(4f);
			CameraEffects.UpdateBloomKnee(0.75f);
		}
	}

	public void Update()
	{
		if (FadeIn && Time.deltaTime < 1f)
		{
			Police.Darkness.color = new Color(Police.Darkness.color.r, Police.Darkness.color.g, Police.Darkness.color.b, Mathf.MoveTowards(Police.Darkness.color.a, 0f, Time.deltaTime));
			if (Police.Darkness.color.a == 0f)
			{
				Police.Darkness.enabled = false;
				FadeIn = false;
			}
		}
		if (!MissionMode && CameraTimer < 1f)
		{
			CameraTimer += Time.deltaTime;
			if (CameraTimer > 1f && !StudentManager.MemorialScene.enabled)
			{
				if (BloomDisabled)
				{
					OptionGlobals.DisableBloom = true;
					Profile.bloom.enabled = false;
				}
				if (!GameGlobals.KokonaTutorial)
				{
					Yandere.RPGCamera.enabled = true;
					Yandere.CanMove = true;
				}
				else
				{
					Yandere.CanMove = false;
				}
				if (!StudentManager.CameFromLoad)
				{
					GivePlayerBroughtWeapon();
				}
				if (!StudentManager.KokonaTutorial)
				{
					Yandere.RPGCamera.ZeroEverything();
					Yandere.FixCamera();
				}
			}
		}
		if (PresentTime < 1080f)
		{
			if (UpdateBloom)
			{
				if (BloomWait == 0f)
				{
					if (!ReduceKnee)
					{
						if (Lerp)
						{
							BloomIntensity = Mathf.Lerp(BloomIntensity, 1f, Time.deltaTime);
							BloomRadius = Mathf.Lerp(BloomRadius, 4f, Time.deltaTime);
							if (BloomIntensity < 1.1f)
							{
								BloomIntensity = 1f;
								BloomRadius = 4f;
							}
						}
						else
						{
							BloomIntensity = Mathf.MoveTowards(BloomIntensity, 1f, Time.deltaTime * BloomFadeSpeed);
							BloomRadius = Mathf.MoveTowards(BloomRadius, 4f, Time.deltaTime * BloomFadeSpeed);
						}
						CameraEffects.UpdateBloom(BloomIntensity);
						CameraEffects.UpdateBloomRadius(BloomRadius);
						if (BloomIntensity == 1f && BloomRadius == 4f)
						{
							ReduceKnee = true;
						}
					}
					else
					{
						BloomKnee = Mathf.MoveTowards(BloomKnee, 0.75f, Time.deltaTime * (BloomFadeSpeed * 0.1f));
						CameraEffects.UpdateBloomKnee(BloomKnee);
						if (BloomKnee == 0.75f)
						{
							UpdateBloom = false;
						}
					}
				}
				else
				{
					BloomWait = Mathf.MoveTowards(BloomWait, 0f, Time.deltaTime);
				}
			}
		}
		else if (LoveManager.WaitingToConfess)
		{
			if (!StopTime)
			{
				LoveManager.BeginConfession();
			}
		}
		else if (!Police.FadeOut && !Yandere.Attacking && !Yandere.Struggling && !Yandere.DelinquentFighting && !Yandere.Pickpocketing && !Yandere.Noticed)
		{
			Debug.Log("Ending the day because it's 6:00 PM.");
			if (!StudentManager.Portal.GetComponent<PortalScript>().EndedFinalEvents)
			{
				StudentManager.Portal.GetComponent<PortalScript>().EndFinalEvents();
			}
			StudentManager.Reputation.UpdateRep();
			Police.DayOver = true;
			Yandere.StudentManager.StopMoving();
			Police.Darkness.enabled = true;
			Police.FadeOut = true;
			StopTime = true;
		}
		if (!StopTime)
		{
			if (Period == 3)
			{
				PresentTime += Time.deltaTime * (1f / 60f) * TimeSpeed * 0.5f;
			}
			else
			{
				PresentTime += Time.deltaTime * (1f / 60f) * TimeSpeed;
			}
		}
		HourTime = PresentTime / 60f;
		Hour = Mathf.Floor(PresentTime / 60f);
		Minute = Mathf.Floor((PresentTime / 60f - Hour) * 60f);
		if (Minute != LastMinute)
		{
			UpdateClock();
			UpdateClockHands();
			if (!Horror)
			{
				UpdateLighting();
			}
		}
		if (LateStudent && HourTime > 7.9f)
		{
			ActivateLateStudent();
		}
		if (HourTime < 8.5f)
		{
			if (Period < 1)
			{
				PeriodLabel.text = "BEFORE CLASS";
				DeactivateTrespassZones();
				ChangePeriod();
				Period++;
			}
		}
		else if (HourTime < 13f)
		{
			if (Period < 2)
			{
				PeriodLabel.text = "CLASS TIME";
				ActivateTrespassZones();
				ChangePeriod();
				Period++;
			}
		}
		else if (HourTime < 13.5f)
		{
			if (Period < 3)
			{
				PeriodLabel.text = "LUNCH TIME";
				StudentManager.DramaPhase = 0;
				StudentManager.UpdateDrama();
				DeactivateTrespassZones();
				ChangePeriod();
				Period++;
				StudentManager.WednesdayGiftBox.SetActive(value: false);
				StudentManager.FridayTestNotes.SetActive(value: false);
				StudentManager.MondayBento.SetActive(value: false);
				StudentManager.RivalBookBag.NoBento = true;
				StudentManager.Unstop();
				if (!GameGlobals.Eighties && DateGlobals.Week == 1 && !StudentManager.MissionMode)
				{
					StudentManager.UpdateLunchtimeStudents();
				}
				UpdateClock();
			}
		}
		else if (HourTime < 15.5f)
		{
			if (Period < 4)
			{
				PeriodLabel.text = "CLASS TIME";
				ActivateTrespassZones();
				ChangePeriod();
				Period++;
			}
		}
		else if (HourTime < 16f)
		{
			if (Period < 5)
			{
				StudentManager.Reputation.RepUpdateLabel.text = "REP WILL UPDATE AFTER SCHOOL";
				if (StudentManager.Bully && StudentManager.Bullies > 0)
				{
					StudentManager.UpdateGraffiti();
				}
				PeriodLabel.text = "CLEANING TIME";
				DeactivateTrespassZones();
				if (Weekday == 5)
				{
					MeetingRoomTrespassZone.enabled = true;
				}
				StudentManager.Unstop();
				ChangePeriod();
				Period++;
				UpdateClock();
			}
		}
		else if (Period < 6)
		{
			PeriodLabel.text = "AFTER SCHOOL";
			StudentManager.DramaPhase = 0;
			StudentManager.UpdateDrama();
			ChangePeriod();
			Period++;
			if (StudentManager.Week == 2)
			{
				StudentManager.RainbowBoysHangoutParent.transform.position = new Vector3(0f, 4f, -22f);
				StudentManager.EightiesHangouts.List[12].transform.position = new Vector3(-1f, 4f, -22f);
				StudentManager.Students[12].PyroUrge = false;
			}
		}
		if (!IgnorePhotographyClub && HourTime > 16.75f && StudentManager.SleuthPhase < 4)
		{
			StudentManager.SleuthPhase = 3;
			StudentManager.UpdateSleuths();
		}
		if (!Horror)
		{
			if (StudentManager.WestBathroomArea.bounds.Contains(Yandere.transform.position) || StudentManager.EastBathroomArea.bounds.Contains(Yandere.transform.position))
			{
				for (int i = 1; i < Bathroom.Length; i++)
				{
					if (Bathroom[i].bounds.Contains(Yandere.transform.position))
					{
						if (!BathroomLight[i].enabled)
						{
							BathroomDim = 0.5f;
						}
						else
						{
							BathroomDim = 0f;
						}
					}
				}
			}
			else
			{
				BathroomDim = 0f;
			}
			if (BathroomDimSprite.alpha != BathroomDim)
			{
				BathroomDimSprite.alpha = Mathf.MoveTowards(BathroomDimSprite.alpha, BathroomDim, Time.deltaTime * 10f);
			}
		}
		if (!TimeSkip)
		{
			return;
		}
		if (HalfwayTime == 0f)
		{
			HalfwayTime = PresentTime + (TargetTime - PresentTime) * 0.5f;
			OriginalPosition = Yandere.transform.position;
			if (!StudentManager.Eighties)
			{
				Yandere.Phone.transform.localPosition = new Vector3(0.02f, -0.005f, 0.03f);
				Yandere.Phone.transform.localEulerAngles = new Vector3(0f, -165f, -165f);
			}
			else
			{
				Yandere.Phone.transform.localPosition = new Vector3(0.02f, -0.0066666f, 0.03f);
				Yandere.Phone.transform.localEulerAngles = new Vector3(-75f, 120f, 75f);
			}
			Yandere.TimeSkipping = true;
			Yandere.CanMove = false;
			if (Yandere.Armed)
			{
				Yandere.Unequip();
			}
		}
		TimeSkipSpeed += Time.deltaTime;
		if (Time.timeScale < 10f)
		{
			Time.timeScale = Mathf.MoveTowards(Time.timeScale, 10f, TimeSkipSpeed * Time.unscaledDeltaTime);
		}
		Yandere.CharacterAnimation["f02_timeSkip_00"].speed = 1f / Time.timeScale;
		if (PresentTime > TargetTime)
		{
			EndTimeSkip();
		}
		if (Yandere.PauseScreen.transform.localPosition.x == 1351f && Input.GetButtonDown(InputNames.Xbox_A))
		{
			if (!StudentManager.Eighties)
			{
				RetroMinigame.MyRenderer.mainTexture = RetroMinigame.ModernTexture;
			}
			Yandere.PauseScreen.PromptBar.Label[0].text = "Jump / Retry";
			RetroMinigame.gameObject.SetActive(value: true);
			RetroMinigame.Show = true;
		}
		else if (Yandere.CameraEffects.Streaks.color.a > 0f || Yandere.CameraEffects.MurderStreaks.color.a > 0f || Yandere.NearSenpai || Input.GetButtonDown(InputNames.Xbox_B))
		{
			EndTimeSkip();
		}
	}

	public void EndTimeSkip()
	{
		Debug.Log("Ending TimeSkip now.");
		if (GameGlobals.AlphabetMode)
		{
			StopTime = true;
		}
		Yandere.PauseScreen.PromptBar.ClearButtons();
		Yandere.PauseScreen.PromptBar.Show = false;
		PromptParent.localScale = new Vector3(1f, 1f, 1f);
		Yandere.transform.position = OriginalPosition;
		Yandere.Phone.SetActive(value: false);
		Yandere.TimeSkipping = false;
		Time.timeScale = 1f;
		TimeSkip = false;
		HalfwayTime = 0f;
		TimeSkipSpeed = 1f;
		if (!Yandere.Noticed && !Police.FadeOut && !Yandere.Attacked)
		{
			Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
			Yandere.CanMoveTimer = 0.5f;
		}
		RetroMinigame.MinigameCamera.SetActive(value: false);
		RetroMinigame.Show = false;
	}

	public string GetWeekdayText(DayOfWeek weekday)
	{
		switch (weekday)
		{
		case DayOfWeek.Sunday:
			Weekday = 0;
			return "SUNDAY";
		case DayOfWeek.Monday:
			Weekday = 1;
			return "MONDAY";
		case DayOfWeek.Tuesday:
			Weekday = 2;
			return "TUESDAY";
		case DayOfWeek.Wednesday:
			Weekday = 3;
			return "WEDNESDAY";
		case DayOfWeek.Thursday:
			Weekday = 4;
			return "THURSDAY";
		case DayOfWeek.Friday:
			Weekday = 5;
			return "FRIDAY";
		default:
			Weekday = 6;
			return "SATURDAY";
		}
	}

	private void ActivateTrespassZones()
	{
		if (!SchoolBell.isPlaying || SchoolBell.time > 1f)
		{
			SchoolBell.Play();
		}
		Collider[] trespassZones = TrespassZones;
		for (int i = 0; i < trespassZones.Length; i++)
		{
			trespassZones[i].enabled = true;
		}
	}

	public void DeactivateTrespassZones()
	{
		Yandere.Trespassing = false;
		if ((!SchoolBell.isPlaying || SchoolBell.time > 1f) && !StudentManager.SpawnNobody)
		{
			SchoolBell.Play();
		}
		Collider[] trespassZones = TrespassZones;
		foreach (Collider collider in trespassZones)
		{
			if (!collider.GetComponent<TrespassScript>().OffLimits)
			{
				collider.enabled = false;
				if (collider.GetComponent<TrespassScript>().CookingClub)
				{
					collider.enabled = true;
				}
			}
		}
	}

	public void ActivateLateStudent()
	{
		if (!StudentManager.MissionMode && StudentManager.Students[7] != null && StudentManager.Students[7].Alive)
		{
			StudentManager.Students[7].gameObject.SetActive(value: true);
			StudentManager.Students[7].Pathfinding.speed = 4f;
			StudentManager.Students[7].Spawned = true;
			StudentManager.Students[7].Hurry = true;
		}
		LateStudent = false;
	}

	public void NightLighting()
	{
		MainLight.color = new Color(0.25f, 0.25f, 0.5f);
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.5f);
		SkyboxColor = new Color(0.1f, 0.1f, 0.2f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.1f, 0.1f, 0.2f));
	}

	public void UpdateClock()
	{
		LastMinute = Minute;
		if (Hour == 0f || Hour == 12f)
		{
			HourNumber = "12";
		}
		else if (Hour < 12f)
		{
			HourNumber = Hour.ToString("f0");
		}
		else
		{
			HourNumber = (Hour - 12f).ToString("f0");
		}
		if (Minute < 10f)
		{
			MinuteNumber = "0" + Minute.ToString("f0");
		}
		else
		{
			MinuteNumber = Minute.ToString("f0");
		}
		TimeText = HourNumber + ":" + MinuteNumber + ((Hour < 12f) ? " AM" : " PM");
		TimeLabel.text = TimeText;
	}

	public void UpdateClockHands()
	{
		MinuteHand.localEulerAngles = new Vector3(MinuteHand.localEulerAngles.x, MinuteHand.localEulerAngles.y, Minute * 6f);
		HourHand.localEulerAngles = new Vector3(HourHand.localEulerAngles.x, HourHand.localEulerAngles.y, Hour * 30f);
		Grandfather.UpdateClockHands();
	}

	public void UpdateLighting()
	{
		Sun.eulerAngles = new Vector3(Sun.eulerAngles.x, Sun.eulerAngles.y, -45f + 90f * (PresentTime - 420f) / 660f);
		AmbientLightDim = 0.75f;
		if (PresentTime > 930f)
		{
			DayProgress = (PresentTime - 930f) / 150f;
			MainLight.color = new Color(1f - 0.1490196f * DayProgress, 1f - 0.40392154f * DayProgress, 1f - 0.70980394f * DayProgress);
			RenderSettings.ambientLight = new Color(1f - 0.1490196f * DayProgress - (1f - AmbientLightDim) * (1f - DayProgress), 1f - 0.40392154f * DayProgress - (1f - AmbientLightDim) * (1f - DayProgress), 1f - 0.70980394f * DayProgress - (1f - AmbientLightDim) * (1f - DayProgress));
			SkyboxColor = new Color(1f - 0.1490196f * DayProgress - 0.5f * (1f - DayProgress), 1f - 0.40392154f * DayProgress - 0.5f * (1f - DayProgress), 1f - 0.70980394f * DayProgress - 0.5f * (1f - DayProgress));
			RenderSettings.skybox.SetColor("_Tint", new Color(SkyboxColor.r, SkyboxColor.g, SkyboxColor.b));
		}
		else
		{
			RenderSettings.ambientLight = new Color(AmbientLightDim, AmbientLightDim, AmbientLightDim);
		}
	}

	public void BecomeEighties()
	{
		StudentManager.EightiesifyLabel(TimeLabel);
		StudentManager.EightiesifyLabel(PeriodLabel);
		StudentManager.EightiesifyLabel(DayLabel);
		StudentManager.EightiesifyLabel(Yandere.Inventory.MoneyLabel);
		LateStudent = false;
	}

	public void GivePlayerBroughtWeapon()
	{
		int bringingItem = PlayerGlobals.BringingItem;
		if (bringingItem > 0 && bringingItem < Police.EndOfDay.WeaponManager.BroughtWeapons.Length)
		{
			Police.EndOfDay.WeaponManager.BroughtWeapons[bringingItem].Prompt.Circle[3].fillAmount = 0f;
			Police.EndOfDay.WeaponManager.BroughtWeapons[bringingItem].UnequipImmediately = true;
		}
	}

	public void ChangePeriod()
	{
		StudentManager.UpdateInfatuatedTargetDistances();
	}
}
