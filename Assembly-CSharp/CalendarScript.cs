using System;
using System.IO;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000105 RID: 261
public class CalendarScript : MonoBehaviour
{
	// Token: 0x06000AA3 RID: 2723 RVA: 0x00061C54 File Offset: 0x0005FE54
	private void Start()
	{
		Debug.Log("We just arrived at the calendar screen. DateGlobals.PassDays is: " + DateGlobals.PassDays.ToString());
		this.NewTitleScreenProfile.colorGrading.enabled = false;
		this.SetVignettePink();
		PlayerGlobals.BringingItem = 0;
		if (GameGlobals.RivalEliminationID == 0 && StudentGlobals.GetStudentDead(10 + DateGlobals.Week))
		{
			Debug.Log("Upon entering the Calendar screen, the rival was dead, but RivalEliminationID was 0. Setting it to 1.");
			GameGlobals.RivalEliminationID = 1;
		}
		if (DateGlobals.Week == 0)
		{
			Debug.Log("Save file had to be deleted because Week was '0''.");
			this.ResetSaveFile();
		}
		else if (GameGlobals.Eighties)
		{
			if (DateGlobals.Week == 1)
			{
				Debug.Log("Rival is cute.");
			}
			else if (DateGlobals.Week == 2)
			{
				Debug.Log("Rival is pryomaniac.");
			}
			else if (DateGlobals.Week == 3)
			{
				Debug.Log("Rival is bookworm.");
			}
			else if (DateGlobals.Week == 4)
			{
				Debug.Log("Rival is sporty.");
			}
			else if (DateGlobals.Week == 5)
			{
				Debug.Log("Rival is rich.");
			}
			else if (DateGlobals.Week == 6)
			{
				Debug.Log("Rival is idol.");
			}
			else if (DateGlobals.Week == 7)
			{
				Debug.Log("Rival is prodigy.");
			}
			else if (DateGlobals.Week == 8)
			{
				Debug.Log("Rival is traditional.");
			}
			else if (DateGlobals.Week == 9)
			{
				Debug.Log("Rival is gravure.");
			}
			else if (DateGlobals.Week == 10)
			{
				Debug.Log("Rival is investigator.");
			}
			for (int i = 1; i < 11; i++)
			{
				PlayerGlobals.SetShrineCollectible(i, true);
			}
		}
		else if (DateGlobals.Week > 2)
		{
			Debug.Log("Save file had to be deleted because 80s and 202X got mixed up.");
			this.ResetSaveFile();
		}
		this.LoveSickCheck();
		if (!ConversationGlobals.GetTopicDiscovered(1))
		{
			for (int j = 1; j < 26; j++)
			{
				ConversationGlobals.SetTopicDiscovered(j, true);
			}
		}
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 1f;
			PlayerGlobals.Money = 10f;
			PlayerGlobals.SetCannotBringItem(4, true);
			PlayerGlobals.SetCannotBringItem(5, true);
			PlayerGlobals.SetCannotBringItem(6, true);
			PlayerGlobals.SetCannotBringItem(7, true);
		}
		if (DateGlobals.PassDays > 0 && !SchoolGlobals.HighSecurity && SchoolGlobals.SchoolAtmosphere >= SchoolGlobals.PreviousSchoolAtmosphere)
		{
			SchoolGlobals.SchoolAtmosphere += 0.05f;
		}
		this.ImproveSchoolAtmosphere();
		DateGlobals.DayPassed = true;
		this.Continue.transform.localPosition = new Vector3(this.Continue.transform.localPosition.x, -610f, this.Continue.transform.localPosition.z);
		this.ChallengePanel.alpha = 0f;
		this.CalendarPanel.alpha = 1f;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
		Time.timeScale = 1f;
		if (GameGlobals.RivalEliminationID > 0)
		{
			this.DeadlineLabel.SetActive(false);
		}
		this.WeekNumber.text = "WEEK " + DateGlobals.Week.ToString();
		this.LoveSickCheck();
		this.ChangeDayColor();
		if (GameGlobals.Eighties)
		{
			this.BecomeEighties();
		}
		else
		{
			this.AmaiButton.SetActive(false);
			this.StatsButton.SetActive(false);
			this.SkipButton.transform.localPosition = new Vector3(-120f, -500f, 0f);
			if (DateGlobals.Week == 1)
			{
				this.DayNumber[1].text = "2";
				this.DayNumber[2].text = "3";
				this.DayNumber[3].text = "4";
				this.DayNumber[4].text = "5";
				this.DayNumber[5].text = "6";
				this.DayNumber[6].text = "7";
				this.DayNumber[7].text = "8";
				this.Adjustment = -50;
			}
			else if (DateGlobals.Week == 2)
			{
				this.DayNumber[1].text = "9";
				this.DayNumber[2].text = "10";
				this.DayNumber[3].text = "11";
				this.DayNumber[4].text = "12";
				this.DayNumber[5].text = "13";
				this.DayNumber[6].text = "14";
				this.DayNumber[7].text = "15";
				this.Adjustment = -50;
				this.AmaiButton.SetActive(true);
			}
		}
		this.Highlight.localPosition = new Vector3(-750f + this.Offset + 250f * (float)DateGlobals.Weekday + (float)this.Adjustment, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
		if (DateGlobals.Weekday == DayOfWeek.Saturday)
		{
			this.Highlight.localPosition = new Vector3(-1150f, this.Highlight.localPosition.y, this.Highlight.localPosition.z);
		}
		if (GameGlobals.CameFromTitleScreen)
		{
			GameGlobals.CameFromTitleScreen = false;
			this.CameFromTitleScreen = true;
		}
	}

	// Token: 0x06000AA4 RID: 2724 RVA: 0x00062194 File Offset: 0x00060394
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (!this.FadeOut)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
			if (this.Darkness.color.a < 0f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 0f);
			}
			if (this.Timer > 1f)
			{
				if (!this.Incremented)
				{
					if (DateGlobals.PassDays > 0)
					{
						if (this.Eighties)
						{
							base.GetComponent<AudioSource>().clip = this.EightiesJingle;
							base.GetComponent<AudioSource>().volume = 0.25f;
						}
						base.GetComponent<AudioSource>().pitch = 1f - (0.8f - SchoolGlobals.SchoolAtmosphere * 0.8f);
						base.GetComponent<AudioSource>().Play();
					}
					if (DateGlobals.Weekday != DayOfWeek.Friday || this.Skipping)
					{
						bool flag = false;
						if ((DateGlobals.Week == 1 && DateGlobals.Weekday == DayOfWeek.Sunday) || DateGlobals.ForceSkip)
						{
							DateGlobals.ForceSkip = false;
							this.SundayLabel.SetActive(false);
							flag = true;
							Debug.Log("ForceSkip was true.");
						}
						while (flag || (DateGlobals.PassDays > 0 && DateGlobals.Weekday != DayOfWeek.Saturday && DateGlobals.Weekday != DayOfWeek.Sunday))
						{
							DateGlobals.GameplayDay++;
							DateGlobals.PassDays--;
							DateGlobals.Weekday++;
							this.ChangeDayColor();
							flag = false;
							Debug.Log("Passed one day. " + DateGlobals.PassDays.ToString() + " days remaining.");
						}
						this.Skipping = false;
					}
					else if (!this.CameFromTitleScreen)
					{
						DateGlobals.GameplayDay++;
						DateGlobals.PassDays--;
						DateGlobals.Weekday++;
						this.ChangeDayColor();
					}
					this.Target = 250f * (float)DateGlobals.Weekday + (float)this.Adjustment;
					if (DateGlobals.Weekday > DayOfWeek.Saturday)
					{
						this.Darkness.color = new Color(0f, 0f, 0f, 0f);
						DateGlobals.Weekday = DayOfWeek.Sunday;
						this.Target = (float)this.Adjustment;
					}
					if (!this.Eighties && DateGlobals.Weekday != DayOfWeek.Sunday && DateGlobals.Weekday < DayOfWeek.Saturday && GameGlobals.RivalEliminationID > 0 && !GameGlobals.InformedAboutSkipping && DateGlobals.Week < 2)
					{
						GameGlobals.InformedAboutSkipping = true;
						this.CongratulationsWindow.SetActive(true);
					}
					this.Incremented = true;
					this.ChangeDayColor();
				}
				this.Continue.localPosition = new Vector3(this.Continue.localPosition.x, Mathf.Lerp(this.Continue.localPosition.y, -500f, Time.deltaTime * 10f), this.Continue.localPosition.z);
				if (!this.Switch)
				{
					if (this.ViewingStats)
					{
						if (Input.GetButtonDown("B"))
						{
							this.Switch = true;
						}
					}
					else if (this.CongratulationsWindow.activeInHierarchy)
					{
						if (Input.GetButtonDown("A"))
						{
							this.CongratulationsWindow.SetActive(false);
						}
					}
					else if (this.ResetWeekWindow.activeInHierarchy)
					{
						if (Input.GetButtonDown("A"))
						{
							this.FadeOut = true;
							this.ResetWeek = true;
						}
						else if (Input.GetButtonDown("B"))
						{
							this.ResetWeekWindow.SetActive(false);
						}
						else if (Input.GetButtonDown("X"))
						{
							this.ConfirmationWindow.SetActive(true);
							this.ResetWeekWindow.SetActive(false);
						}
					}
					else if (this.ConfirmationWindow.activeInHierarchy)
					{
						if (Input.GetButtonDown("A"))
						{
							this.FadeOut = true;
							this.Reset = true;
						}
						if (Input.GetButtonDown("B"))
						{
							this.ConfirmationWindow.SetActive(false);
						}
					}
					else if (this.SkipConfirmationWindow.activeInHierarchy)
					{
						if (Input.GetButtonDown("A"))
						{
							this.SundayLabel.SetActive(false);
							if (StudentGlobals.MemorialStudents > 0)
							{
								StudentGlobals.MemorialStudents = 0;
								StudentGlobals.MemorialStudent1 = 0;
								StudentGlobals.MemorialStudent2 = 0;
								StudentGlobals.MemorialStudent3 = 0;
								StudentGlobals.MemorialStudent4 = 0;
								StudentGlobals.MemorialStudent5 = 0;
								StudentGlobals.MemorialStudent6 = 0;
								StudentGlobals.MemorialStudent7 = 0;
								StudentGlobals.MemorialStudent8 = 0;
								StudentGlobals.MemorialStudent9 = 0;
							}
							this.SkipConfirmationWindow.SetActive(false);
							ClassGlobals.BonusStudyPoints += 10;
							GameGlobals.ShowAbduction = false;
							DateGlobals.Weekday++;
							this.Incremented = false;
							this.Skipping = true;
							if (!SchoolGlobals.HighSecurity && SchoolGlobals.SchoolAtmosphere >= SchoolGlobals.PreviousSchoolAtmosphere)
							{
								SchoolGlobals.SchoolAtmosphere += 0.05f;
							}
							this.ImproveSchoolAtmosphere();
							if ((GameGlobals.RivalEliminationID == 0 && DateGlobals.Weekday == DayOfWeek.Friday) || DateGlobals.Weekday > DayOfWeek.Friday)
							{
								this.SkipButton.SetActive(false);
								if (this.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
								{
									this.SkipButton.SetActive(true);
								}
							}
						}
						if (Input.GetButtonDown("B"))
						{
							this.SkipConfirmationWindow.SetActive(false);
						}
					}
					else if (this.AmaiWindow.activeInHierarchy)
					{
						if (Input.GetButtonDown("A"))
						{
							this.AmaiButton.SetActive(false);
							this.AmaiWindow.SetActive(false);
							DateGlobals.Weekday++;
							this.Incremented = false;
							if (!SchoolGlobals.HighSecurity)
							{
								SchoolGlobals.SchoolAtmosphere += 0.05f;
							}
							this.ImproveSchoolAtmosphere();
							this.AmaiWindow.SetActive(false);
						}
						if (Input.GetButtonDown("B"))
						{
							this.AmaiWindow.SetActive(false);
						}
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.FadeOut = true;
						}
						else if (Input.GetButtonDown("B"))
						{
							this.ResetWeekWindow.SetActive(true);
						}
						else if (Input.GetButtonDown("X") && this.Eighties)
						{
							this.Switch = true;
						}
						if (this.SkipButton.activeInHierarchy)
						{
							if (Input.GetButtonDown("Y"))
							{
								this.SkipConfirmationWindow.SetActive(true);
							}
						}
						else if (this.AmaiButton.activeInHierarchy && Input.GetButtonDown("Y"))
						{
							this.AmaiWindow.SetActive(true);
						}
					}
				}
			}
		}
		else
		{
			this.Continue.localPosition = new Vector3(this.Continue.localPosition.x, Mathf.Lerp(this.Continue.localPosition.y, -610f, Time.deltaTime * 10f), this.Continue.localPosition.z);
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				if (this.ResetWeek)
				{
					int num = GameGlobals.Profile;
					int num2 = 11;
					Debug.Log("We're currently on Profile #" + num.ToString());
					if (this.Eighties && num < 11)
					{
						Debug.Log("...but we're in the 80s! Let's adjust that!");
						num += 10;
					}
					if (File.Exists(string.Concat(new string[]
					{
						Application.streamingAssetsPath,
						"/SaveFiles/Profile_",
						num.ToString(),
						"_Slot_",
						num2.ToString(),
						".yansave"
					})))
					{
						YanSave.LoadData("Profile_" + num.ToString() + "_Slot_" + num2.ToString(), false);
						YanSave.LoadPrefs("Profile_" + num.ToString() + "_Slot_" + num2.ToString());
						Debug.Log("Successfully loaded the save in Slot #" + num2.ToString());
					}
					else
					{
						Debug.Log("Attempted to load a save from Slot #" + num2.ToString() + ", but apparently it didn't exist.");
					}
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
				else if (this.Reset)
				{
					this.ResetSaveFile();
				}
				else
				{
					if (HomeGlobals.Night)
					{
						HomeGlobals.Night = false;
					}
					if (DateGlobals.Weekday == DayOfWeek.Saturday)
					{
						if (!this.Eighties)
						{
							SceneManager.LoadScene("BusStopScene");
						}
						else
						{
							GameGlobals.EightiesCutsceneID = DateGlobals.Week + 1;
							SceneManager.LoadScene("EightiesCutsceneScene");
						}
					}
					else
					{
						if (DateGlobals.Weekday == DayOfWeek.Sunday && !this.Eighties)
						{
							HomeGlobals.Night = true;
						}
						SceneManager.LoadScene("HomeScene");
					}
				}
			}
		}
		if (this.Incremented)
		{
			this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, -750f + this.Offset + this.Target, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
		}
		if (this.Switch)
		{
			if (!this.ViewingStats)
			{
				if (this.Phase == 1)
				{
					this.CalendarPanel.alpha = Mathf.MoveTowards(this.CalendarPanel.alpha, 0f, Time.deltaTime * 5f);
					if (this.CalendarPanel.alpha <= 0f)
					{
						this.Phase++;
					}
				}
				else
				{
					this.ChallengePanel.alpha = Mathf.MoveTowards(this.ChallengePanel.alpha, 1f, Time.deltaTime * 5f);
					if (this.ChallengePanel.alpha >= 1f)
					{
						this.ViewingStats = true;
						this.Switch = false;
						this.Phase = 1;
					}
				}
			}
			else if (this.Phase == 1)
			{
				this.ChallengePanel.alpha = Mathf.MoveTowards(this.ChallengePanel.alpha, 0f, Time.deltaTime * 5f);
				if (this.ChallengePanel.alpha <= 0f)
				{
					this.Phase++;
				}
			}
			else
			{
				this.CalendarPanel.alpha = Mathf.MoveTowards(this.CalendarPanel.alpha, 1f, Time.deltaTime * 5f);
				if (this.CalendarPanel.alpha >= 1f)
				{
					this.ViewingStats = false;
					this.Switch = false;
					this.Phase = 1;
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			GameGlobals.LoveSick = !GameGlobals.LoveSick;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	// Token: 0x06000AA5 RID: 2725 RVA: 0x00062CA4 File Offset: 0x00060EA4
	public void ChangeDayColor()
	{
		foreach (UILabel uilabel in this.DayLabel)
		{
		}
		UILabel[] array = this.DayNumber;
		for (int i = 0; i < array.Length; i++)
		{
			array[i] != null;
		}
		if ((GameGlobals.RivalEliminationID == 0 && DateGlobals.Weekday < DayOfWeek.Friday) || (GameGlobals.RivalEliminationID > 0 && DateGlobals.Weekday < DayOfWeek.Saturday))
		{
			this.SkipButton.SetActive(true);
		}
		else
		{
			this.SkipButton.SetActive(false);
			if (this.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
			{
				this.SkipButton.SetActive(true);
			}
		}
		if (!this.Eighties && DateGlobals.Week == 2)
		{
			this.SkipButton.SetActive(false);
		}
	}

	// Token: 0x06000AA6 RID: 2726 RVA: 0x00062D5C File Offset: 0x00060F5C
	public void LoveSickCheck()
	{
		if (GameGlobals.LoveSick)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.SchoolAtmosphere = 0f;
			this.LoveSick = true;
			Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
			foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
			{
				UISprite component = gameObject.GetComponent<UISprite>();
				if (component != null)
				{
					component.color = new Color(1f, 0f, 0f, component.color.a);
				}
				UITexture component2 = gameObject.GetComponent<UITexture>();
				if (component2 != null)
				{
					component2.color = new Color(1f, 0f, 0f, component2.color.a);
				}
				UILabel component3 = gameObject.GetComponent<UILabel>();
				if (component3 != null)
				{
					if (component3.color != Color.black)
					{
						component3.color = new Color(1f, 0f, 0f, component3.color.a);
					}
					if (component3.text == "?")
					{
						component3.color = new Color(1f, 0f, 0f, component3.color.a);
					}
				}
			}
			this.Darkness.color = Color.black;
			this.AtmosphereLabel.enabled = false;
			this.Cloud.enabled = false;
			this.Sun.enabled = false;
		}
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x00062EF0 File Offset: 0x000610F0
	public void SetVignettePink()
	{
		VignetteModel.Settings settings = this.NewTitleScreenProfile.vignette.settings;
		settings.color = new Color(1f, 0.75f, 1f, 1f);
		this.NewTitleScreenProfile.vignette.settings = settings;
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x00062F40 File Offset: 0x00061140
	private void ImproveSchoolAtmosphere()
	{
		if (SchoolGlobals.SchoolAtmosphere > 1f)
		{
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		this.Sun.color = new Color(this.Sun.color.r, this.Sun.color.g, this.Sun.color.b, SchoolGlobals.SchoolAtmosphere);
		this.Cloud.color = new Color(this.Cloud.color.r, this.Cloud.color.g, this.Cloud.color.b, 1f - SchoolGlobals.SchoolAtmosphere);
		this.AtmosphereLabel.text = (SchoolGlobals.SchoolAtmosphere * 100f).ToString("f0") + "%";
		float num = 1f - SchoolGlobals.SchoolAtmosphere;
		this.GrayscaleEffect.desaturation = num;
		this.Vignette.intensity = num * 5f;
		this.Vignette.blur = num;
		this.Vignette.chromaticAberration = num;
		SchoolGlobals.PreviousSchoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x0006306C File Offset: 0x0006126C
	private void BecomeEighties()
	{
		this.Vignette.enabled = false;
		StudentGlobals.FemaleUniform = 6;
		StudentGlobals.MaleUniform = 1;
		if (DateGlobals.Week > 1 && DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			this.SundayLabel.SetActive(true);
			this.SkipButton.SetActive(true);
		}
		if (DateGlobals.ForceSkip)
		{
			this.SundayLabel.SetActive(false);
		}
		this.Eighties = true;
		this.Labels = (UnityEngine.Object.FindSceneObjectsOfType(typeof(UILabel)) as UILabel[]);
		for (int i = 0; i < this.Labels.Length; i++)
		{
			this.EightiesifyLabel(this.Labels[i]);
		}
		this.EightiesifyLabel(this.SkipLabel);
		for (int i = 1; i < this.DayNumber.Length; i++)
		{
			this.DayNumber[i].fontSize = 150;
			this.DayNumber[i].effectDistance = new Vector2(10f, 10f);
		}
		for (int i = 0; i < this.DayLabel.Length; i++)
		{
			this.DayLabel[i].pivot = UIWidget.Pivot.Center;
			this.DayLabel[i].transform.localPosition = new Vector3(0f, 120f, 0f);
			this.DayLabel[i].transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
		}
		Camera.main.backgroundColor = new Color(0f, 0f, 0.75f, 1f);
		this.AtmosphereLabel.color = new Color(0f, 0f, 0f, 1f);
		this.YearLabel.text = "1989";
		this.Offset = 0f;
		this.Highlight.localScale = new Vector3(1f, 1.25f, 1f);
		this.DeadlineLabel.transform.localPosition = new Vector3(500f, -200f, 0f);
		this.Continue.localPosition = new Vector3(650f, this.Continue.localPosition.y, this.Continue.localPosition.z);
		if (DateGlobals.Week == 1)
		{
			this.DayNumber[1].text = "2";
			this.DayNumber[2].text = "3";
			this.DayNumber[3].text = "4";
			this.DayNumber[4].text = "5";
			this.DayNumber[5].text = "6";
			this.DayNumber[6].text = "7";
			this.DayNumber[7].text = "8";
		}
		else if (DateGlobals.Week == 2)
		{
			this.DayNumber[1].text = "9";
			this.DayNumber[2].text = "10";
			this.DayNumber[3].text = "11";
			this.DayNumber[4].text = "12";
			this.DayNumber[5].text = "13";
			this.DayNumber[6].text = "14";
			this.DayNumber[7].text = "15";
		}
		else if (DateGlobals.Week == 3)
		{
			this.DayNumber[1].text = "16";
			this.DayNumber[2].text = "17";
			this.DayNumber[3].text = "18";
			this.DayNumber[4].text = "19";
			this.DayNumber[5].text = "20";
			this.DayNumber[6].text = "21";
			this.DayNumber[7].text = "22";
		}
		else if (DateGlobals.Week == 4)
		{
			this.DayNumber[1].text = "23";
			this.DayNumber[2].text = "24";
			this.DayNumber[3].text = "25";
			this.DayNumber[4].text = "26";
			this.DayNumber[5].text = "27";
			this.DayNumber[6].text = "28";
			this.DayNumber[7].text = "29";
		}
		else if (DateGlobals.Week == 5)
		{
			this.DayNumber[1].text = "30";
			this.DayNumber[2].text = "1";
			this.DayNumber[3].text = "2";
			this.DayNumber[4].text = "3";
			this.DayNumber[5].text = "4";
			this.DayNumber[6].text = "5";
			this.DayNumber[7].text = "6";
		}
		else if (DateGlobals.Week == 6)
		{
			this.DayNumber[1].text = "7";
			this.DayNumber[2].text = "8";
			this.DayNumber[3].text = "9";
			this.DayNumber[4].text = "10";
			this.DayNumber[5].text = "11";
			this.DayNumber[6].text = "12";
			this.DayNumber[7].text = "13";
		}
		else if (DateGlobals.Week == 7)
		{
			this.DayNumber[1].text = "14";
			this.DayNumber[2].text = "15";
			this.DayNumber[3].text = "16";
			this.DayNumber[4].text = "17";
			this.DayNumber[5].text = "18";
			this.DayNumber[6].text = "19";
			this.DayNumber[7].text = "20";
		}
		else if (DateGlobals.Week == 8)
		{
			this.DayNumber[1].text = "21";
			this.DayNumber[2].text = "22";
			this.DayNumber[3].text = "23";
			this.DayNumber[4].text = "24";
			this.DayNumber[5].text = "25";
			this.DayNumber[6].text = "26";
			this.DayNumber[7].text = "27";
		}
		else if (DateGlobals.Week == 9)
		{
			this.DayNumber[1].text = "28";
			this.DayNumber[2].text = "29";
			this.DayNumber[3].text = "30";
			this.DayNumber[4].text = "31";
			this.DayNumber[5].text = "1";
			this.DayNumber[6].text = "2";
			this.DayNumber[7].text = "3";
		}
		else if (DateGlobals.Week == 10)
		{
			this.DayNumber[1].text = "4";
			this.DayNumber[2].text = "5";
			this.DayNumber[3].text = "6";
			this.DayNumber[4].text = "7";
			this.DayNumber[5].text = "8";
			this.DayNumber[6].text = "9";
			this.DayNumber[7].text = "10";
		}
		else if (DateGlobals.Week == 11)
		{
			GameGlobals.RivalEliminationID = 1;
			this.EndingLabel.SetActive(true);
			this.DayNumber[1].text = "11";
			this.DayNumber[2].text = "12";
			this.DayNumber[3].text = "13";
			this.DayNumber[4].text = "14";
			this.DayNumber[5].text = "15";
			this.DayNumber[6].text = "16";
			this.DayNumber[7].text = "17";
		}
		if ((DateGlobals.Week == 9 && DateGlobals.Weekday > DayOfWeek.Wednesday) || DateGlobals.Week > 9)
		{
			this.MonthLabel.text = "JUNE";
		}
		else if ((DateGlobals.Week == 5 && DateGlobals.Weekday > DayOfWeek.Sunday) || DateGlobals.Week > 5)
		{
			this.MonthLabel.text = "MAY";
		}
		if (SchoolGlobals.SchoolAtmosphere <= 0.5f)
		{
			this.AtmosphereLabel.color = new Color(1f, 1f, 1f);
		}
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x0006394C File Offset: 0x00061B4C
	public void EightiesifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.VCR;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x000639B4 File Offset: 0x00061BB4
	public void ResetSaveFile()
	{
		int num = GameGlobals.Profile;
		bool eighties = GameGlobals.Eighties;
		bool debug = GameGlobals.Debug;
		int femaleUniform = StudentGlobals.FemaleUniform;
		int maleUniform = StudentGlobals.MaleUniform;
		Globals.DeleteAll();
		if (eighties && num < 11)
		{
			num += 10;
		}
		PlayerPrefs.SetInt("ProfileCreated_" + num.ToString(), 1);
		GameGlobals.Eighties = eighties;
		GameGlobals.Profile = num;
		GameGlobals.Debug = debug;
		StudentGlobals.FemaleUniform = femaleUniform;
		StudentGlobals.MaleUniform = maleUniform;
		GameGlobals.LoveSick = this.LoveSick;
		DateGlobals.PassDays = 1;
		if (GameGlobals.Eighties)
		{
			for (int i = 1; i < 101; i++)
			{
				StudentGlobals.SetStudentPhotographed(i, true);
			}
		}
		if (eighties)
		{
			OptionGlobals.DisableTint = false;
		}
		else
		{
			OptionGlobals.DisableTint = true;
		}
		YanSave.SaveData("Profile_" + num.ToString() + "_Slot_" + 11.ToString());
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// Token: 0x04000CC6 RID: 3270
	public PostProcessingProfile NewTitleScreenProfile;

	// Token: 0x04000CC7 RID: 3271
	public SelectiveGrayscale GrayscaleEffect;

	// Token: 0x04000CC8 RID: 3272
	public ChallengeScript Challenge;

	// Token: 0x04000CC9 RID: 3273
	public Vignetting Vignette;

	// Token: 0x04000CCA RID: 3274
	public GameObject SkipConfirmationWindow;

	// Token: 0x04000CCB RID: 3275
	public GameObject CongratulationsWindow;

	// Token: 0x04000CCC RID: 3276
	public GameObject ConfirmationWindow;

	// Token: 0x04000CCD RID: 3277
	public GameObject ResetWeekWindow;

	// Token: 0x04000CCE RID: 3278
	public GameObject AmaiWindow;

	// Token: 0x04000CCF RID: 3279
	public GameObject DeadlineLabel;

	// Token: 0x04000CD0 RID: 3280
	public GameObject StatsButton;

	// Token: 0x04000CD1 RID: 3281
	public GameObject AmaiButton;

	// Token: 0x04000CD2 RID: 3282
	public GameObject SkipButton;

	// Token: 0x04000CD3 RID: 3283
	public UILabel AtmosphereLabel;

	// Token: 0x04000CD4 RID: 3284
	public UIPanel ChallengePanel;

	// Token: 0x04000CD5 RID: 3285
	public UIPanel CalendarPanel;

	// Token: 0x04000CD6 RID: 3286
	public UISprite Darkness;

	// Token: 0x04000CD7 RID: 3287
	public UITexture Cloud;

	// Token: 0x04000CD8 RID: 3288
	public UITexture Sun;

	// Token: 0x04000CD9 RID: 3289
	public Transform Highlight;

	// Token: 0x04000CDA RID: 3290
	public Transform Continue;

	// Token: 0x04000CDB RID: 3291
	public UILabel[] DayNumber;

	// Token: 0x04000CDC RID: 3292
	public UILabel[] DayLabel;

	// Token: 0x04000CDD RID: 3293
	public UILabel MonthLabel;

	// Token: 0x04000CDE RID: 3294
	public UILabel WeekNumber;

	// Token: 0x04000CDF RID: 3295
	public UILabel YearLabel;

	// Token: 0x04000CE0 RID: 3296
	public UILabel SkipLabel;

	// Token: 0x04000CE1 RID: 3297
	public bool CameFromTitleScreen;

	// Token: 0x04000CE2 RID: 3298
	public bool ViewingStats;

	// Token: 0x04000CE3 RID: 3299
	public bool Incremented;

	// Token: 0x04000CE4 RID: 3300
	public bool ResetWeek;

	// Token: 0x04000CE5 RID: 3301
	public bool Eighties;

	// Token: 0x04000CE6 RID: 3302
	public bool LoveSick;

	// Token: 0x04000CE7 RID: 3303
	public bool Skipping;

	// Token: 0x04000CE8 RID: 3304
	public bool FadeOut;

	// Token: 0x04000CE9 RID: 3305
	public bool Switch;

	// Token: 0x04000CEA RID: 3306
	public bool Reset;

	// Token: 0x04000CEB RID: 3307
	public float Timer;

	// Token: 0x04000CEC RID: 3308
	public float Target;

	// Token: 0x04000CED RID: 3309
	public float Offset = 66.66666f;

	// Token: 0x04000CEE RID: 3310
	public int Adjustment;

	// Token: 0x04000CEF RID: 3311
	public int Phase = 1;

	// Token: 0x04000CF0 RID: 3312
	public AudioClip EightiesJingle;

	// Token: 0x04000CF1 RID: 3313
	public UILabel[] Labels;

	// Token: 0x04000CF2 RID: 3314
	public GameObject SundayLabel;

	// Token: 0x04000CF3 RID: 3315
	public GameObject EndingLabel;

	// Token: 0x04000CF4 RID: 3316
	public Font VCR;
}
