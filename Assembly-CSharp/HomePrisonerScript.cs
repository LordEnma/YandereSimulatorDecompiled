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

	public GameObject ConfirmationWindow;

	public Transform TortureDestination;

	public Transform TortureTarget;

	public GameObject NowLoading;

	public GameObject YesButton;

	public Transform Highlight;

	public AudioSource Jukebox;

	public GameObject MyFlies;

	public GameObject Flies;

	public UILabel ConfirmationLabel;

	public UILabel SanityLabel;

	public UILabel DescLabel;

	public UILabel Subtitle;

	public UILabel NoLabel;

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

	public UISprite HealthBar;

	public UISprite HealthBot;

	public UISprite HealthTop;

	public UILabel HealthLabel;

	public UILabel MealsLabel;

	public float Health;

	public void Start()
	{
		if (PrisonerManager.StudentID > 0)
		{
			Sanity = StudentGlobals.GetStudentSanity(PrisonerManager.StudentID);
			Health = StudentGlobals.GetStudentHealth(PrisonerManager.StudentID);
			if (!Initialized && Health > 0f && (float)Sanity < 100f)
			{
				Debug.Log("Prisoner # " + PrisonerManager.ChosenPrisoner + " is now having their animation updated.");
				Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapIdle_02");
			}
		}
		HealthLabel.text = "Health: " + Health + "%";
		SanityLabel.text = "Sanity: " + Sanity + "%";
		MealsLabel.text = "Meals: " + PlayerGlobals.Meals;
		Prisoner.Sanity = Sanity;
		Subtitle.text = string.Empty;
		HealthBar.transform.localScale = new Vector3(1f, Health / 100f, 1f);
		HealthBar.color = new Color(1f - Health / 100f, Health / 100f, 0f);
		HealthTop.color = new Color(1f - Health / 100f, Health / 100f, 0f);
		HealthBot.color = new Color(1f - Health / 100f, Health / 100f, 0f);
		HealthTop.transform.localPosition = new Vector3(0f, -200f + Health / 100f * 400f, 0f);
		for (int i = 1; i < Descriptions.Length - 1; i++)
		{
			Descriptions[i] = "If you torture your prisoner for " + Hours[i] + ", you will reduce their sanity by " + (SanityNumbers[i] + ClassGlobals.PsychologyGrade * 10) + "%, and " + Notes[i];
		}
		if (Initialized)
		{
			if ((float)Sanity == 100f)
			{
				BanterText = FullSanityBanterText;
				Banter = FullSanityBanter;
			}
			else if ((float)Sanity >= 50f)
			{
				BanterText = HighSanityBanterText;
				Banter = HighSanityBanter;
			}
			else if ((float)Sanity == 0f)
			{
				BanterText = NoSanityBanterText;
				Banter = NoSanityBanter;
			}
			else
			{
				BanterText = LowSanityBanterText;
				Banter = LowSanityBanter;
			}
		}
		OptionLabels[1].alpha = 1f;
		OptionLabels[2].alpha = 1f;
		OptionLabels[3].alpha = 1f;
		OptionLabels[4].alpha = 1f;
		OptionLabels[5].alpha = 1f;
		if (Health > 0f)
		{
			if (!HomeGlobals.Night)
			{
				UILabel uILabel = OptionLabels[2];
				uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0.5f);
				if (HomeGlobals.LateForSchool)
				{
					UILabel uILabel2 = OptionLabels[1];
					uILabel2.color = new Color(uILabel2.color.r, uILabel2.color.g, uILabel2.color.b, 0.5f);
				}
				if (DateGlobals.Weekday == DayOfWeek.Friday)
				{
					UILabel uILabel3 = OptionLabels[3];
					uILabel3.color = new Color(uILabel3.color.r, uILabel3.color.g, uILabel3.color.b, 0.5f);
					UILabel uILabel4 = OptionLabels[4];
					uILabel4.color = new Color(uILabel4.color.r, uILabel4.color.g, uILabel4.color.b, 0.5f);
				}
			}
			else
			{
				UILabel uILabel5 = OptionLabels[1];
				uILabel5.color = new Color(uILabel5.color.r, uILabel5.color.g, uILabel5.color.b, 0.5f);
				UILabel uILabel6 = OptionLabels[3];
				uILabel6.color = new Color(uILabel6.color.r, uILabel6.color.g, uILabel6.color.b, 0.5f);
				UILabel uILabel7 = OptionLabels[4];
				uILabel7.color = new Color(uILabel7.color.r, uILabel7.color.g, uILabel7.color.b, 0.5f);
			}
			if (Sanity > 0)
			{
				OptionLabels[5].text = "?????";
				UILabel uILabel8 = OptionLabels[5];
				uILabel8.color = new Color(uILabel8.color.r, uILabel8.color.g, uILabel8.color.b, 0.5f);
			}
			else
			{
				OptionLabels[5].text = "Bring to School";
				UILabel uILabel9 = OptionLabels[1];
				uILabel9.color = new Color(uILabel9.color.r, uILabel9.color.g, uILabel9.color.b, 0.5f);
				UILabel uILabel10 = OptionLabels[2];
				uILabel10.color = new Color(uILabel10.color.r, uILabel10.color.g, uILabel10.color.b, 0.5f);
				UILabel uILabel11 = OptionLabels[3];
				uILabel11.color = new Color(uILabel11.color.r, uILabel11.color.g, uILabel11.color.b, 0.5f);
				UILabel uILabel12 = OptionLabels[4];
				uILabel12.color = new Color(uILabel12.color.r, uILabel12.color.g, uILabel12.color.b, 0.5f);
				UILabel uILabel13 = OptionLabels[5];
				uILabel13.color = new Color(uILabel13.color.r, uILabel13.color.g, uILabel13.color.b, 1f);
				if (DateGlobals.Weekday == DayOfWeek.Sunday)
				{
					OptionLabels[5].alpha = 0.5f;
				}
				if (HomeGlobals.Night)
				{
					uILabel13.color = new Color(uILabel13.color.r, uILabel13.color.g, uILabel13.color.b, 0.5f);
				}
			}
			if (DateGlobals.Weekday == DayOfWeek.Sunday)
			{
				UILabel uILabel14 = OptionLabels[1];
				uILabel14.color = new Color(uILabel14.color.r, uILabel14.color.g, uILabel14.color.b, 0.5f);
			}
		}
		else
		{
			OptionLabels[1].alpha = 0.5f;
			OptionLabels[2].alpha = 0.5f;
			OptionLabels[3].alpha = 0.5f;
			OptionLabels[4].alpha = 0.5f;
			OptionLabels[5].alpha = 0.5f;
			if (HomeGlobals.Night)
			{
				ConfirmationLabel.text = "Disposing of this corpse will take several hours. You will go to sleep after completing the task. Are you ready to dispose of the corpse now?";
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday && GameGlobals.RivalEliminationID == 0)
			{
				ConfirmationLabel.text = "You can't dispose of a corpse today. You need to go to school and eliminate your rival before she confesses to the boy you love.";
				YesButton.SetActive(value: false);
				NoLabel.text = "Back";
			}
		}
		if (!Initialized)
		{
			Initialized = true;
			UpdateDesc();
		}
		if (StudentGlobals.Prisoners == 0)
		{
			base.enabled = false;
		}
		Prisoner = EightiesPrisoner;
	}

	private void Update()
	{
		AudioSource component = GetComponent<AudioSource>();
		if (Health > 0f)
		{
			if (Vector3.Distance(HomeYandere.transform.position, Prisoner.transform.position) < 2f && HomeYandere.CanMove)
			{
				BanterTimer += Time.deltaTime;
				if (BanterTimer > 5f && !Bantering)
				{
					Bantering = true;
					if (BanterID < Banter.Length - 1)
					{
						BanterID++;
						Subtitle.text = BanterText[BanterID];
						component.clip = Banter[BanterID];
						component.Play();
					}
				}
			}
			if (Bantering && !component.isPlaying)
			{
				Subtitle.text = string.Empty;
				Bantering = false;
				BanterTimer = 0f;
			}
		}
		if (HomeYandere.CanMove || (!(HomeCamera.Destination == HomeCamera.Destinations[10]) && !(HomeCamera.Destination == TortureDestination)))
		{
			return;
		}
		if (InputManager.TappedDown)
		{
			ID++;
			if (ID > 5)
			{
				ID = 1;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 465f - (float)ID * 40f, Highlight.localPosition.z);
			UpdateDesc();
		}
		if (InputManager.TappedUp)
		{
			ID--;
			if (ID < 1)
			{
				ID = 5;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 465f - (float)ID * 40f, Highlight.localPosition.z);
			UpdateDesc();
		}
		if (!ZoomIn)
		{
			if (ConfirmationWindow.activeInHierarchy)
			{
				if (YesButton.activeInHierarchy && Input.GetButtonDown(InputNames.Xbox_A))
				{
					StudentGlobals.SetStudentDead(PrisonerManager.StudentID, value: true);
					if (PrisonerManager.ChosenPrisoner == 1)
					{
						StudentGlobals.Prisoner1 = 0;
					}
					if (PrisonerManager.ChosenPrisoner == 2)
					{
						StudentGlobals.Prisoner2 = 0;
					}
					if (PrisonerManager.ChosenPrisoner == 3)
					{
						StudentGlobals.Prisoner3 = 0;
					}
					if (PrisonerManager.ChosenPrisoner == 4)
					{
						StudentGlobals.Prisoner4 = 0;
					}
					if (PrisonerManager.ChosenPrisoner == 5)
					{
						StudentGlobals.Prisoner5 = 0;
					}
					if (PrisonerManager.ChosenPrisoner == 6)
					{
						StudentGlobals.Prisoner6 = 0;
					}
					if (PrisonerManager.ChosenPrisoner == 7)
					{
						StudentGlobals.Prisoner7 = 0;
					}
					if (PrisonerManager.ChosenPrisoner == 8)
					{
						StudentGlobals.Prisoner8 = 0;
					}
					if (PrisonerManager.ChosenPrisoner == 9)
					{
						StudentGlobals.Prisoner9 = 0;
					}
					if (PrisonerManager.ChosenPrisoner == 10)
					{
						StudentGlobals.Prisoner10 = 0;
					}
					StudentGlobals.Prisoners--;
					HomeCamera.HomeDarkness.Disposing = true;
					HomeCamera.HomeDarkness.FadeOut = true;
					HomeCamera.OutOfRoom = false;
					base.gameObject.SetActive(value: false);
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					ConfirmationWindow.SetActive(value: false);
					HomeCamera.PromptBar.Show = true;
					UpdateDesc();
				}
				return;
			}
			if (Input.GetButtonDown(InputNames.Xbox_A) && OptionLabels[ID].color.a == 1f)
			{
				if ((float)Sanity > 0f)
				{
					if ((float)Sanity == 100f)
					{
						Debug.Log("This code is running.");
						if (Prisoner.Male)
						{
							Prisoner.Character.GetComponent<Animation>().CrossFade("kidnapTorture_01");
						}
						else
						{
							Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapTorture_01");
						}
					}
					else if ((float)Sanity >= 50f)
					{
						if (Prisoner.Male)
						{
							Prisoner.Character.GetComponent<Animation>().CrossFade("kidnapTorture_02");
						}
						else
						{
							Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapTorture_02");
						}
					}
					else
					{
						if (Prisoner.Male)
						{
							Prisoner.Character.GetComponent<Animation>().CrossFade("kidnapSurrender_00");
						}
						else
						{
							Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapSurrender_00");
						}
						TortureDestination.localPosition = new Vector3(TortureDestination.localPosition.x, 0f, 1f);
						TortureTarget.localPosition = new Vector3(TortureTarget.localPosition.x, 1.1f, TortureTarget.localPosition.z);
					}
					HomeCamera.Destination = TortureDestination;
					HomeCamera.Target = TortureTarget;
					HomeCamera.Torturing = true;
					Prisoner.Tortured = true;
					Prisoner.RightEyeRotOrigin.x = -6f;
					Prisoner.LeftEyeRotOrigin.x = 6f;
					ZoomIn = true;
					if (PrisonerManager.ChosenPrisoner > 1)
					{
						Darkness.Sprite.alpha = 1f;
					}
					HomeCamera.UpdateDOF(0.6f);
				}
				else
				{
					Debug.Log("Now bringing a prisoner to school.");
					HomeCamera.OutOfRoom = false;
					Darkness.FadeOut = true;
				}
				HomeWindow.Show = false;
				HomeCamera.PromptBar.ClearButtons();
				HomeCamera.PromptBar.Show = false;
				Jukebox.volume -= 0.5f;
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				HomeCamera.Destination = HomeCamera.Destinations[0];
				HomeCamera.Target = HomeCamera.Targets[0];
				HomeCamera.PromptBar.ClearButtons();
				HomeCamera.PromptBar.Show = false;
				HomeYandere.CanMove = true;
				HomeYandere.gameObject.SetActive(value: true);
				HomeWindow.Show = false;
			}
			if (Input.GetButtonDown(InputNames.Xbox_X) && PlayerGlobals.Meals > 0 && StudentGlobals.GetStudentHealth(PrisonerManager.StudentID) > 0 && StudentGlobals.GetStudentHealth(PrisonerManager.StudentID) < 100)
			{
				StudentGlobals.SetStudentHealth(PrisonerManager.StudentID, StudentGlobals.GetStudentHealth(PrisonerManager.StudentID) + 10);
				PlayerGlobals.Meals--;
				Start();
			}
			if (Input.GetButtonDown(InputNames.Xbox_Y) && Health == 0f)
			{
				ConfirmationWindow.SetActive(value: true);
				HomeCamera.PromptBar.Show = false;
			}
			return;
		}
		TortureDestination.Translate(Vector3.forward * (Time.deltaTime * 0.02f));
		Jukebox.volume -= Time.deltaTime * 0.05f;
		Timer += Time.deltaTime;
		if ((float)Sanity >= 50f)
		{
			TortureDestination.localPosition = new Vector3(TortureDestination.localPosition.x, TortureDestination.localPosition.y + Time.deltaTime * 0.05f, TortureDestination.localPosition.z);
			if ((float)Sanity == 100f)
			{
				if (Timer > 2f && !PlayedAudio)
				{
					component.clip = FirstTorture;
					PlayedAudio = true;
					component.Play();
				}
			}
			else if (Timer > 1.5f && !PlayedAudio)
			{
				component.clip = Over50Torture;
				PlayedAudio = true;
				component.Play();
			}
		}
		else if (Timer > 5f && !PlayedAudio)
		{
			component.clip = Under50Torture;
			PlayedAudio = true;
			component.Play();
		}
		if (Timer > 10f)
		{
			if (Darkness.Sprite.color.a != 1f)
			{
				Darkness.enabled = false;
				Darkness.Sprite.color = new Color(Darkness.Sprite.color.r, Darkness.Sprite.color.g, Darkness.Sprite.color.b, 1f);
				component.clip = TortureHit;
				component.Play();
			}
		}
		else if (PrisonerManager.ChosenPrisoner > 1)
		{
			Darkness.Sprite.alpha = 0.99999f;
		}
		if (!(Timer > 15f))
		{
			return;
		}
		Debug.Log("StudentGlobals.GetStudentSanity was: " + StudentGlobals.GetStudentSanity(PrisonerManager.StudentID));
		StudentGlobals.PreviousSanity = StudentGlobals.GetStudentSanity(PrisonerManager.StudentID);
		if (ID == 1)
		{
			Time.timeScale = 1f;
			NowLoading.SetActive(value: true);
			HomeGlobals.LateForSchool = true;
			if (DateGlobals.Weekday == DayOfWeek.Saturday)
			{
				DateGlobals.PassDays = 1;
				SceneManager.LoadScene("CalendarScene");
			}
			else
			{
				SceneManager.LoadScene("LoadingScene");
			}
			StudentGlobals.SetStudentSanity(PrisonerManager.StudentID, Sanity - 2 - ClassGlobals.PsychologyGrade * 10);
		}
		else if (ID == 2)
		{
			if (DateGlobals.PassDays < 1)
			{
				DateGlobals.PassDays = 1;
			}
			if (DateGlobals.Weekday == DayOfWeek.Sunday)
			{
				DateGlobals.ForceSkip = true;
			}
			SceneManager.LoadScene("CalendarScene");
			StudentGlobals.SetStudentSanity(PrisonerManager.StudentID, Sanity - 8 - ClassGlobals.PsychologyGrade * 10);
		}
		else if (ID == 3)
		{
			HomeGlobals.Night = true;
			SceneManager.LoadScene("HomeScene");
			StudentGlobals.SetStudentSanity(PrisonerManager.StudentID, Sanity - 24 - ClassGlobals.PsychologyGrade * 10);
			if (DateGlobals.Weekday != DayOfWeek.Sunday)
			{
				PlayerGlobals.Reputation -= 20f;
			}
		}
		else if (ID == 4)
		{
			if (DateGlobals.PassDays < 1)
			{
				DateGlobals.PassDays = 1;
			}
			if (DateGlobals.Weekday == DayOfWeek.Sunday)
			{
				DateGlobals.ForceSkip = true;
			}
			else
			{
				PlayerGlobals.Reputation -= 20f;
			}
			SceneManager.LoadScene("CalendarScene");
			StudentGlobals.SetStudentSanity(PrisonerManager.StudentID, Sanity - 36 - ClassGlobals.PsychologyGrade * 10);
		}
		if ((float)StudentGlobals.GetStudentSanity(PrisonerManager.StudentID) < 0f)
		{
			StudentGlobals.SetStudentSanity(PrisonerManager.StudentID, 0);
		}
		StudentGlobals.PreviousPrisoner = PrisonerManager.StudentID;
		Debug.Log("And, StudentGlobals.PreviousPrisoner is: " + StudentGlobals.PreviousPrisoner);
		Debug.Log("So, StudentGlobals.PreviousSanity is: " + StudentGlobals.PreviousSanity);
		Debug.Log("And now, StudentGlobals.GetStudentSanity is: " + StudentGlobals.GetStudentSanity(PrisonerManager.StudentID));
	}

	public void UpdateDesc()
	{
		Start();
		HomeCamera.PromptBar.Label[0].text = "Accept";
		DescLabel.text = Descriptions[ID];
		if (!HomeGlobals.Night)
		{
			if (HomeGlobals.LateForSchool && ID == 1)
			{
				DescLabel.text = "This option is unavailable if you are late for school.";
				HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
			if (ID == 2)
			{
				DescLabel.text = "This option is unavailable in the daytime.";
				HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
			if (DateGlobals.Weekday == DayOfWeek.Friday && (ID == 3 || ID == 4))
			{
				DescLabel.text = "This option is unavailable on Friday.";
				HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
		}
		else if (ID != 2)
		{
			DescLabel.text = "This option is unavailable at nighttime.";
			HomeCamera.PromptBar.Label[0].text = string.Empty;
		}
		if (ID == 5)
		{
			if ((float)Sanity > 0f)
			{
				DescLabel.text = "This option is unavailable until your prisoner's Sanity has reached zero.";
			}
			if (HomeGlobals.Night)
			{
				DescLabel.text = "This option is unavailable at nighttime.";
				HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
		}
		if (Health == 0f)
		{
			DescLabel.text = "Your prisoner has died. You should dispose of the body.";
			HomeCamera.PromptBar.Label[0].text = "";
		}
		if (StudentGlobals.GetStudentHealth(PrisonerManager.StudentID) == 0)
		{
			HomeCamera.PromptBar.Label[3].text = "Dispose";
		}
		else if (PlayerGlobals.Meals > 0 && StudentGlobals.GetStudentHealth(PrisonerManager.StudentID) > 0 && StudentGlobals.GetStudentHealth(PrisonerManager.StudentID) < 100)
		{
			HomeCamera.PromptBar.Label[2].text = "Feed Meal";
		}
		else
		{
			HomeCamera.PromptBar.Label[2].text = "";
		}
		HomeCamera.PromptBar.UpdateButtons();
	}
}
