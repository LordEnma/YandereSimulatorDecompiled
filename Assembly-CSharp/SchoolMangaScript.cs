using UnityEngine;

public class SchoolMangaScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public GameObject ProgressWindow;

	public GameObject Window;

	public UILabel ProgressLabel;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public UISprite Darkness;

	public UILabel[] Labels;

	public float CooldownTimer;

	public float DownTimer;

	public float UpTimer;

	public bool TimeSkipping;

	public bool Initialized;

	public bool CannotRead;

	public bool FadeOut;

	public int Selected;

	public int RomanceMangaProgress;

	public int HorrorMangaProgress;

	public int EnlightenedMangaProgress;

	public Transform Highlight;

	private void Start()
	{
		if (!Initialized)
		{
			RomanceMangaProgress = CollectibleGlobals.RomanceMangaProgress;
			HorrorMangaProgress = CollectibleGlobals.HorrorMangaProgress;
			EnlightenedMangaProgress = CollectibleGlobals.EnlightenedMangaProgress;
		}
		Initialized = true;
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (CooldownTimer > 0f)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Try again in a few seconds...";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Prompt.Yandere.Police.Show)
			{
				Yandere.NotificationManager.CustomText = "Not when police are coming!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Yandere.StudentManager.Clock.HourTime < 15.5f)
			{
				Yandere.NotificationManager.CustomText = "Only available after 3:30 PM";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Yandere.StudentManager.Clock.HourTime > 17.5835f)
			{
				Yandere.NotificationManager.CustomText = "Not available after 5:35 PM";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Yandere.Armed || Yandere.Bloodiness > 0f || Yandere.Sanity < 33.333f || Yandere.Attacking || Yandere.Dragging || Yandere.Carrying || Yandere.PickUp != null || Yandere.Chased || Yandere.Chasers > 0 || (Yandere.StudentManager.Reporter != null && !Yandere.Police.Show) || Yandere.StudentManager.MurderTakingPlace)
			{
				DisplayErrorMessage();
			}
			else
			{
				UpdateOwnedManga();
				Prompt.Yandere.RPGCamera.enabled = false;
				Prompt.Yandere.CanMove = false;
				Time.timeScale = 0.0001f;
				Window.SetActive(value: true);
				UpdateHighlight();
			}
		}
		if (Window.activeInHierarchy)
		{
			if (Input.GetKey("down"))
			{
				DownTimer += Time.deltaTime;
			}
			if (Input.GetKeyUp("down"))
			{
				DownTimer = 0f;
			}
			if (Yandere.PauseScreen.InputManager.TappedDown || DownTimer > 0.5f)
			{
				if (DownTimer > 0.5f)
				{
					DownTimer = 0.4f;
				}
				Selected++;
				if (Selected == 16)
				{
					Selected = 17;
				}
				if (Selected > 17)
				{
					Selected = 1;
				}
				UpdateHighlight();
			}
			if (Input.GetKey("up"))
			{
				UpTimer += Time.deltaTime;
			}
			if (Input.GetKeyUp("up"))
			{
				UpTimer = 0f;
			}
			if (Yandere.PauseScreen.InputManager.TappedUp || UpTimer > 0.5f)
			{
				if (UpTimer > 0.5f)
				{
					UpTimer = 0.4f;
				}
				Selected--;
				if (Selected == 16)
				{
					Selected = 15;
				}
				if (Selected < 1)
				{
					Selected = 17;
				}
				UpdateHighlight();
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (Selected < 16)
				{
					if (Labels[Selected].alpha == 1f && !CannotRead)
					{
						Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
						Yandere.RPGCamera.enabled = false;
						Darkness.enabled = true;
						Yandere.CanMove = false;
						TimeSkipping = true;
						FadeOut = true;
						Window.SetActive(value: false);
						Time.timeScale = 1f;
					}
				}
				else
				{
					CloseWindow();
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				CloseWindow();
			}
		}
		if (TimeSkipping)
		{
			if (FadeOut)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
				if (Darkness.color.a > 0.99999f)
				{
					Yandere.StudentManager.PutStudentsToSleep();
					Yandere.StudentManager.Clock.PresentTime += 25f;
					Yandere.StudentManager.Clock.UpdateClock();
					CooldownTimer = 4f;
					FadeOut = false;
				}
				return;
			}
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (!(Darkness.color.a < 0.1f))
			{
				return;
			}
			Darkness.alpha = 0f;
			if (Selected < 6)
			{
				RomanceMangaProgress += 20 + Yandere.Class.LanguageGrade * 6;
				if (RomanceMangaProgress >= 100)
				{
					Yandere.Class.Seduction++;
					RomanceMangaProgress = 0;
					Yandere.NotificationManager.CustomText = "You have reached Seduction Level " + Yandere.Class.Seduction + ".";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else if (Selected < 11)
			{
				HorrorMangaProgress += 20 + Yandere.Class.LanguageGrade * 6;
				if (HorrorMangaProgress >= 100)
				{
					Yandere.Class.Numbness++;
					HorrorMangaProgress = 0;
					Yandere.NotificationManager.CustomText = "You have reached Numbness Level " + Yandere.Class.Numbness + ".";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else
			{
				EnlightenedMangaProgress += 20 + Yandere.Class.LanguageGrade * 6;
				if (EnlightenedMangaProgress >= 100)
				{
					Yandere.Class.Enlightenment++;
					EnlightenedMangaProgress = 0;
					Yandere.NotificationManager.CustomText = "You have reached Enlightenment Level " + Yandere.Class.Enlightenment + ".";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			Yandere.RPGCamera.enabled = true;
			Darkness.enabled = false;
			Yandere.CanMove = true;
			TimeSkipping = false;
		}
		else
		{
			CooldownTimer = Mathf.MoveTowards(CooldownTimer, 0f, Time.deltaTime);
		}
	}

	private void CloseWindow()
	{
		Prompt.Yandere.RPGCamera.enabled = true;
		Prompt.Yandere.CanMove = true;
		Window.SetActive(value: false);
		Time.timeScale = 1f;
	}

	public void Disable()
	{
		Prompt.enabled = false;
		base.enabled = false;
		Prompt.Hide();
	}

	public void DisplayErrorMessage()
	{
		if (Yandere.Armed)
		{
			Yandere.NotificationManager.CustomText = "Carrying Weapon";
		}
		else if (Yandere.Bloodiness > 0f)
		{
			Yandere.NotificationManager.CustomText = "Bloody";
		}
		else if (Yandere.Sanity < 33.333f)
		{
			Yandere.NotificationManager.CustomText = "Visibly Insane";
		}
		else if (Yandere.Attacking)
		{
			Yandere.NotificationManager.CustomText = "In Combat";
		}
		else if (Yandere.Dragging || Yandere.Carrying)
		{
			Yandere.NotificationManager.CustomText = "Holding Corpse";
		}
		else if (Yandere.PickUp != null)
		{
			Yandere.NotificationManager.CustomText = "Carrying Item";
		}
		else if (Yandere.Chased || Yandere.Chasers > 0)
		{
			Yandere.NotificationManager.CustomText = "Chased";
		}
		else if ((bool)Yandere.StudentManager.Reporter && !Yandere.Police.Show)
		{
			Yandere.NotificationManager.CustomText = "Murder being reported";
		}
		else if (Yandere.StudentManager.MurderTakingPlace)
		{
			Yandere.NotificationManager.CustomText = "Murder taking place";
		}
		Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		Yandere.NotificationManager.CustomText = "Cannot pass time. Reason:";
		Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
	}

	private void UpdateOwnedManga()
	{
		for (int i = 1; i < 16; i++)
		{
			Labels[i].alpha = 0.5f;
			if (StudentManager.MangaCollected[i])
			{
				Labels[i].alpha = 1f;
			}
		}
	}

	private void UpdateHighlight()
	{
		ProgressWindow.SetActive(value: false);
		Highlight.localPosition = new Vector3(0f, 400 - 50 * Selected, 0f);
		if (Selected >= 16)
		{
			return;
		}
		ProgressWindow.SetActive(value: true);
		int num = 0;
		num = ((Selected < 5) ? RomanceMangaProgress : ((Selected >= 10) ? EnlightenedMangaProgress : HorrorMangaProgress));
		Debug.Log("Selected is: " + Selected + " and Percent is: " + num);
		ProgressLabel.text = "You have read " + num + "% of this manga.\n\nIf you read it for the next 30 minutes, you will read " + (20 + Yandere.Class.LanguageGrade * 6) + "% of it.";
		CannotRead = false;
		if (Selected < 6)
		{
			if (Labels[Selected].alpha == 1f)
			{
				if (Yandere.Class.Seduction > Selected - 1)
				{
					ProgressLabel.text = "You have already read this manga.";
					CannotRead = true;
				}
				else if (Yandere.Class.Seduction < Selected - 1)
				{
					ProgressLabel.text = "You need to read the previous volume in the series before you can read this one.";
					CannotRead = true;
				}
			}
			else
			{
				ProgressLabel.text = "You have not yet collected this manga.";
			}
		}
		else if (Selected < 11)
		{
			if (Labels[Selected].alpha == 1f)
			{
				if (Yandere.Class.Numbness > Selected - 6)
				{
					ProgressLabel.text = "You have already read this manga.";
					CannotRead = true;
				}
				else if (Yandere.Class.Numbness < Selected - 6)
				{
					ProgressLabel.text = "You need to read the previous volume in the series before you can read this one.";
					CannotRead = true;
				}
			}
			else
			{
				ProgressLabel.text = "You have not yet collected this manga.";
			}
		}
		else if (Labels[Selected].alpha == 1f)
		{
			if (Yandere.Class.Enlightenment > Selected - 11)
			{
				ProgressLabel.text = "You have already read this manga.";
				CannotRead = true;
			}
			else if (Yandere.Class.Enlightenment < Selected - 11)
			{
				ProgressLabel.text = "You need to read the previous volume in the series before you can read this one.";
				CannotRead = true;
			}
		}
		else
		{
			ProgressLabel.text = "You have not yet collected this manga.";
		}
	}

	public void SaveMangaProgress()
	{
		Start();
		CollectibleGlobals.RomanceMangaProgress = RomanceMangaProgress;
		CollectibleGlobals.HorrorMangaProgress = HorrorMangaProgress;
		CollectibleGlobals.EnlightenedMangaProgress = EnlightenedMangaProgress;
	}
}
